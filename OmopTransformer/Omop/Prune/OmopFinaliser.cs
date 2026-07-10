using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Omop.Prune;

internal class OmopFinaliser
{
    private readonly Configuration _configuration;
    private readonly ILogger<OmopFinaliser> _logger;

    public OmopFinaliser(IOptions<Configuration> configuration, ILogger<OmopFinaliser> logger)
    {
        _logger = logger;
        _configuration = configuration.Value;
    }

    public async Task Prune(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Clearing incomplete omop records.");

        await PruneRecords(cancellationToken);

        _logger.LogInformation("Apply data fixes.");

        await ApplyDQDFixes(cancellationToken);

        _logger.LogInformation("Rebuilding era tables.");

        await RebuildEraTables(cancellationToken);
    }

    private async Task RebuildEraTables(CancellationToken cancellationToken)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);
        await connection.ExecuteAsync(@"
/****************************************************
OHDSI-SQL File Instructions
-----------------------------
 1. Set parameter name of schema that contains CDMv4 instance
    (@SOURCE_CDMV4, @SOURCE_CDMV4_SCHEMA)
 2. Set parameter name of schema that contains CDMv5 instance
    (@TARGET_CDMV5, cdm)
 3. Run this script through SqlRender to produce a script that will work in your
    source dialect. SqlRender can be found here: https://github.com/OHDSI/SqlRender
 4. Run the script produced by SQL Render on your target RDBDMS.
<RDBMS> File Instructions
-------------------------
 1. This script will hold a number of placeholders for your CDM V4 and CDMV5
    database/schema. In order to make this file work in your environment, you
    should plan to do a global ""FIND AND REPLACE"" on this file to fill in the
    file with values that pertain to your environment. The following are the
    tokens you should use when doing your ""FIND AND REPLACE"" operation:
    
     [CDM]
     [CDM].[CDMSCHEMA]
    
*********************************************************************************/
/* SCRIPT PARAMETERS */
truncate table cdm.drug_era;
truncate table cdm.condition_era;
/****
CONDITION ERA
Note: Eras derived from CONDITION_OCCURRENCE table, using 30d gap
 ****/

drop table if exists condition_era_phase_1;

/* / */


drop table if exists cteConditionTarget;

/* / */

create temp table cteConditionTarget
(
    PERSON_ID               INT
    ,CONDITION_CONCEPT_ID   INT
    ,CONDITION_START_DATE   DATE
    ,CONDITION_END_DATE     DATE
);

insert into cteConditionTarget
(
    PERSON_ID
    ,CONDITION_CONCEPT_ID
    ,CONDITION_START_DATE
    ,CONDITION_END_DATE
)
-- create base eras from the concepts found in condition_occurrence
SELECT co.PERSON_ID
    ,co.condition_concept_id
    ,co.CONDITION_START_DATE
    ,COALESCE(co.CONDITION_END_DATE, date_add(CONDITION_START_DATE, interval 1 day)) AS CONDITION_END_DATE
FROM cdm.CONDITION_OCCURRENCE co;


drop table if exists cteCondEndDates;

create temp table cteCondEndDates
(
    PERSON_ID               INT
    ,CONDITION_CONCEPT_ID   INT
    ,END_DATE               DATE
);

insert into cteCondEndDates
(
    PERSON_ID
    ,CONDITION_CONCEPT_ID
    ,END_DATE
)
SELECT PERSON_ID
    ,CONDITION_CONCEPT_ID
    ,EVENT_DATE - interval 30 day AS END_DATE -- unpad the end date
FROM (
    SELECT E1.PERSON_ID
        ,E1.CONDITION_CONCEPT_ID
        ,E1.EVENT_DATE
        ,COALESCE(E1.START_ORDINAL, MAX(E2.START_ORDINAL)) START_ORDINAL
        ,E1.OVERALL_ORD
    FROM (
        SELECT PERSON_ID
            ,CONDITION_CONCEPT_ID
            ,EVENT_DATE
            ,EVENT_TYPE
            ,START_ORDINAL
            ,ROW_NUMBER() OVER (
                PARTITION BY PERSON_ID
                ,CONDITION_CONCEPT_ID ORDER BY EVENT_DATE
                    ,EVENT_TYPE
                ) AS OVERALL_ORD -- this re-numbers the inner UNION so all rows are numbered ordered by the event date
        FROM (
            -- select the start dates, assigning a row number to each
            SELECT PERSON_ID
                ,CONDITION_CONCEPT_ID
                ,CONDITION_START_DATE AS EVENT_DATE
                ,- 1 AS EVENT_TYPE
                ,ROW_NUMBER() OVER (
                    PARTITION BY PERSON_ID
                    ,CONDITION_CONCEPT_ID ORDER BY CONDITION_START_DATE
                    ) AS START_ORDINAL
            FROM cteConditionTarget

            UNION ALL

            -- pad the end dates by 30 to allow a grace period for overlapping ranges.
            SELECT PERSON_ID
                ,CONDITION_CONCEPT_ID
                ,date_add(CONDITION_END_DATE, interval 30 day)
                ,1 AS EVENT_TYPE
                ,NULL
            FROM cteConditionTarget
            ) RAWDATA
        ) E1
    INNER JOIN (
        SELECT PERSON_ID
            ,CONDITION_CONCEPT_ID
            ,CONDITION_START_DATE AS EVENT_DATE
            ,ROW_NUMBER() OVER (
                PARTITION BY PERSON_ID
                ,CONDITION_CONCEPT_ID ORDER BY CONDITION_START_DATE
                ) AS START_ORDINAL
        FROM cteConditionTarget
        ) E2 ON E1.PERSON_ID = E2.PERSON_ID
        AND E1.CONDITION_CONCEPT_ID = E2.CONDITION_CONCEPT_ID
        AND E2.EVENT_DATE <= E1.EVENT_DATE
    GROUP BY E1.PERSON_ID
        ,E1.CONDITION_CONCEPT_ID
        ,E1.EVENT_DATE
        ,E1.START_ORDINAL
        ,E1.OVERALL_ORD
    ) E
WHERE (2 * E.START_ORDINAL) - E.OVERALL_ORD = 0;




/* / */

drop table if exists cteConditionEnds;


/* / */

create temp table cteConditionEnds
(
    PERSON_ID               INT
    ,CONDITION_CONCEPT_ID   INT
    ,CONDITION_START_DATE   DATE
    ,ERA_END_DATE           DATE
);

insert into cteConditionEnds
(
    PERSON_ID
    ,CONDITION_CONCEPT_ID
    ,CONDITION_START_DATE
    ,ERA_END_DATE
)
SELECT c.PERSON_ID
    ,c.CONDITION_CONCEPT_ID
    ,c.CONDITION_START_DATE
    ,MIN(e.END_DATE) AS ERA_END_DATE
FROM cteConditionTarget c
INNER JOIN cteCondEndDates e ON c.PERSON_ID = e.PERSON_ID
    AND c.CONDITION_CONCEPT_ID = e.CONDITION_CONCEPT_ID
    AND e.END_DATE >= c.CONDITION_START_DATE
GROUP BY c.PERSON_ID
    ,c.CONDITION_CONCEPT_ID
    ,c.CONDITION_START_DATE;

/* / */

INSERT INTO cdm.condition_era (
    condition_era_id
    ,person_id
    ,condition_concept_id
    ,condition_era_start_date
    ,condition_era_end_date
    ,condition_occurrence_count
    )
SELECT row_number() OVER (
        ORDER BY person_id
        ) AS condition_era_id
    ,person_id
    ,CONDITION_CONCEPT_ID
    ,min(CONDITION_START_DATE) AS CONDITION_ERA_START_DATE
    ,ERA_END_DATE AS CONDITION_ERA_END_DATE
    ,COUNT(*) AS CONDITION_OCCURRENCE_COUNT
FROM cteConditionEnds
GROUP BY person_id
    ,CONDITION_CONCEPT_ID
    ,ERA_END_DATE;

drop table if exists tmp_de;

create temp table tmp_de
(
    drug_era_id                 INT
    ,person_id                  INT
    ,drug_concept_id            INT
    ,drug_era_start_date        DATE
    ,drug_era_end_date          DATE
    ,drug_exposure_count        INT
    ,gap_days                   INT
);

insert into tmp_de
(
    drug_era_id
    ,person_id
    ,drug_concept_id
    ,drug_era_start_date
    ,drug_era_end_date
    ,drug_exposure_count
    ,gap_days
)

WITH
ctePreDrugTarget(drug_exposure_id, person_id, ingredient_concept_id, drug_exposure_start_date, days_supply, drug_exposure_end_date) AS
(-- Normalize DRUG_EXPOSURE_END_DATE to either the existing drug exposure end date, or add days supply, or add 1 day to the start date
    SELECT
        d.drug_exposure_id
        , d.person_id
        , c.concept_id AS ingredient_concept_id
        , d.drug_exposure_start_date AS drug_exposure_start_date
        , d.days_supply AS days_supply
        , COALESCE(
            ---NULLIF returns NULL if both values are the same, otherwise it returns the first parameter
            NULLIF(drug_exposure_end_date, NULL),
            ---If drug_exposure_end_date != NULL, return drug_exposure_end_date, otherwise go to next case
            NULLIF(drug_exposure_start_date + days_supply, drug_exposure_start_date),
            ---If days_supply != NULL or 0, return drug_exposure_start_date + days_supply, otherwise go to next case
            date_add(drug_exposure_start_date, interval 1 day)
            ---Add 1 day to the drug_exposure_start_date since there is no end_date or INTERVAL for the days_supply
        ) AS drug_exposure_end_date
    FROM cdm.drug_exposure d
        JOIN cdm.concept_ancestor ca ON ca.descendant_concept_id = d.drug_concept_id
        JOIN cdm.concept c ON ca.ancestor_concept_id = c.concept_id
        WHERE c.vocabulary_id = 'RxNorm' ---8 selects RxNorm from the vocabulary_id
        AND c.concept_class_id = 'Ingredient'
        AND d.drug_concept_id != 0 ---Our unmapped drug_concept_id's are set to 0, so we don't want different drugs wrapped up in the same era
        AND coalesce(d.days_supply,0) >= 0 ---We have cases where days_supply is negative, and this can set the end_date before the start_date, which we don't want. So we're just looking over those rows. This is a data-quality issue.
)

, cteSubExposureEndDates (person_id, ingredient_concept_id, end_date) AS --- A preliminary sorting that groups all of the overlapping exposures into one exposure so that we don't double-count non-gap-days
(
    SELECT person_id, ingredient_concept_id, event_date AS end_date
    FROM
    (
        SELECT person_id, ingredient_concept_id, event_date, event_type,
        MAX(start_ordinal) OVER (PARTITION BY person_id, ingredient_concept_id
            ORDER BY event_date, event_type ROWS unbounded preceding) AS start_ordinal,
        -- this pulls the current START down from the prior rows so that the NULLs
        -- from the END DATES will contain a value we can compare with
            ROW_NUMBER() OVER (PARTITION BY person_id, ingredient_concept_id
                ORDER BY event_date, event_type) AS overall_ord
            -- this re-numbers the inner UNION so all rows are numbered ordered by the event date
        FROM (
            -- select the start dates, assigning a row number to each
            SELECT person_id, ingredient_concept_id, drug_exposure_start_date AS event_date,
            -1 AS event_type,
            ROW_NUMBER() OVER (PARTITION BY person_id, ingredient_concept_id
                ORDER BY drug_exposure_start_date) AS start_ordinal
            FROM ctePreDrugTarget

            UNION ALL

            SELECT person_id, ingredient_concept_id, drug_exposure_end_date, 1 AS event_type, NULL
            FROM ctePreDrugTarget
        ) RAWDATA
    ) e
    WHERE (2 * e.start_ordinal) - e.overall_ord = 0
)

, cteDrugExposureEnds (person_id, drug_concept_id, drug_exposure_start_date, drug_sub_exposure_end_date) AS
(
SELECT
    dt.person_id
    , dt.ingredient_concept_id
    , dt.drug_exposure_start_date
    , MIN(e.end_date) AS drug_sub_exposure_end_date
FROM ctePreDrugTarget dt
JOIN cteSubExposureEndDates e ON dt.person_id = e.person_id AND dt.ingredient_concept_id = e.ingredient_concept_id AND e.end_date >= dt.drug_exposure_start_date
GROUP BY
        dt.drug_exposure_id
        , dt.person_id
    , dt.ingredient_concept_id
    , dt.drug_exposure_start_date
)
--------------------------------------------------------------------------------------------------------------
, cteSubExposures(row_number, person_id, drug_concept_id, drug_sub_exposure_start_date, drug_sub_exposure_end_date, drug_exposure_count) AS
(
    SELECT ROW_NUMBER() OVER (PARTITION BY person_id, drug_concept_id, drug_sub_exposure_end_date ORDER BY person_id)
        , person_id, drug_concept_id, MIN(drug_exposure_start_date) AS drug_sub_exposure_start_date, drug_sub_exposure_end_date, COUNT(*) AS drug_exposure_count
    FROM cteDrugExposureEnds
    GROUP BY person_id, drug_concept_id, drug_sub_exposure_end_date
    --ORDER BY person_id, drug_concept_id
)
--------------------------------------------------------------------------------------------------------------
/*Everything above grouped exposures into sub_exposures if there was overlap between exposures.
 *So there was no persistence window. Now we can add the persistence window to calculate eras.
 */
--------------------------------------------------------------------------------------------------------------
, cteFinalTarget(row_number, person_id, ingredient_concept_id, drug_sub_exposure_start_date, drug_sub_exposure_end_date, drug_exposure_count, days_exposed) AS
(
    SELECT row_number, person_id, drug_concept_id, drug_sub_exposure_start_date, drug_sub_exposure_end_date, drug_exposure_count
        , date_diff('day',drug_sub_exposure_start_date,drug_sub_exposure_end_date) AS days_exposed
    FROM cteSubExposures
)
--------------------------------------------------------------------------------------------------------------
, cteEndDates (person_id, ingredient_concept_id, end_date) AS -- the magic
(
    SELECT person_id, ingredient_concept_id, event_date - interval 30 day AS end_date -- unpad the end date
    FROM
    (
        SELECT person_id, ingredient_concept_id, event_date, event_type,
        MAX(start_ordinal) OVER (PARTITION BY person_id, ingredient_concept_id
            ORDER BY event_date, event_type ROWS UNBOUNDED PRECEDING) AS start_ordinal,
        -- this pulls the current START down from the prior rows so that the NULLs
        -- from the END DATES will contain a value we can compare with
            ROW_NUMBER() OVER (PARTITION BY person_id, ingredient_concept_id
                ORDER BY event_date, event_type) AS overall_ord
            -- this re-numbers the inner UNION so all rows are numbered ordered by the event date
        FROM (
            -- select the start dates, assigning a row number to each
            SELECT person_id, ingredient_concept_id, drug_sub_exposure_start_date AS event_date,
            -1 AS event_type,
            ROW_NUMBER() OVER (PARTITION BY person_id, ingredient_concept_id
                ORDER BY drug_sub_exposure_start_date) AS start_ordinal
            FROM cteFinalTarget

            UNION ALL

            -- pad the end dates by 30 to allow a grace period for overlapping ranges.
            SELECT person_id, ingredient_concept_id, date_add(drug_sub_exposure_end_date, interval 30 day), 1 AS event_type, NULL
            FROM cteFinalTarget
        ) RAWDATA
    ) e
    WHERE (2 * e.start_ordinal) - e.overall_ord = 0

)
, cteDrugEraEnds (person_id, drug_concept_id, drug_sub_exposure_start_date, drug_era_end_date, drug_exposure_count, days_exposed) AS
(
SELECT
    ft.person_id
    , ft.ingredient_concept_id
    , ft.drug_sub_exposure_start_date
    , MIN(e.end_date) AS era_end_date
    , drug_exposure_count
    , days_exposed
FROM cteFinalTarget ft
JOIN cteEndDates e ON ft.person_id = e.person_id AND ft.ingredient_concept_id = e.ingredient_concept_id AND e.end_date >= ft.drug_sub_exposure_start_date
GROUP BY
        ft.person_id
    , ft.ingredient_concept_id
    , ft.drug_sub_exposure_start_date
    , drug_exposure_count
    , days_exposed
)
SELECT
    row_number()over(order by person_id) drug_era_id
    , person_id
    , drug_concept_id
    , MIN(drug_sub_exposure_start_date) AS drug_era_start_date
    , drug_era_end_date
    , SUM(drug_exposure_count) AS drug_exposure_count
    , datediff('day',MIN(drug_sub_exposure_start_date),drug_era_end_date)-SUM(days_exposed) as gap_days
FROM cteDrugEraEnds dee
GROUP BY person_id, drug_concept_id, drug_era_end_date;

INSERT INTO cdm.drug_era(drug_era_id,person_id, drug_concept_id, drug_era_start_date, drug_era_end_date, drug_exposure_count, gap_days)
SELECT * FROM tmp_de;


");
    }

    private async Task ApplyDQDFixes(CancellationToken cancellationToken)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        _logger.LogInformation("Correcting male genders.");

        await connection.ExecuteAsync(@"
-- Combined UPDATE statements for the 'person' table
-- Updates gender to MALE (8507) based on specific conditions
UPDATE cdm.person
SET gender_concept_id = 8507
FROM cdm.CONDITION_OCCURRENCE AS cdmTable
JOIN cdm.concept_ancestor AS ca 
    ON ca.descendant_concept_id = cdmTable.CONDITION_CONCEPT_ID
WHERE 
    cdm.person.person_id = cdmTable.person_id
    AND cdm.person.gender_concept_id <> 8507
    AND (
        ca.ancestor_concept_id IN (4090861, 4025213)
        OR cdmTable.CONDITION_CONCEPT_ID IN (79758, 196068)
    );
");

        _logger.LogInformation("Correcting female genders.");

        await connection.ExecuteAsync(@"

UPDATE cdm.person
SET gender_concept_id = 8507
FROM cdm.CONDITION_OCCURRENCE AS cdmTable
WHERE cdm.person.person_id = cdmTable.person_id
	and cdmTable.CONDITION_CONCEPT_ID = 196068;

-- Updates gender to FEMALE (8532) based on a list of conditions
UPDATE cdm.person
SET gender_concept_id = 8532
FROM cdm.CONDITION_OCCURRENCE AS cdmTable
WHERE 
    cdm.person.person_id = cdmTable.person_id
    AND cdm.person.gender_concept_id <> 8532
    AND cdmTable.CONDITION_CONCEPT_ID IN (
        201801, 200052, 4194652, 437501, 201817, 201238, 195500,
        195197, 197236, 199764, 4162860, 441805, 196359, 196048, 437501
    );");

        _logger.LogInformation("Correcting deaths where the patient had a DEVICE_EXPOSURE beyond 60 days.");

        await connection.ExecuteAsync(@"

-- Combined DELETE statements for the 'death' table
-- Deletes death records where related events occur >60 days after death
delete from cdm.death d
where exists (
    select 1
    from cdm.DEVICE_EXPOSURE de
    where de.person_id = d.person_id
      and (
        (de.DEVICE_EXPOSURE_END_DATE is not null and de.DEVICE_EXPOSURE_END_DATE > d.death_date + interval '60' day) or
        (de.DEVICE_EXPOSURE_START_DATE is not null and de.DEVICE_EXPOSURE_START_DATE > d.death_date + interval '60' day) or
        (de.DEVICE_EXPOSURE_END_DATETIME is not null and cast(de.DEVICE_EXPOSURE_END_DATETIME as date) > d.death_date + interval '60' day) or
        (de.DEVICE_EXPOSURE_START_DATETIME is not null and cast(de.DEVICE_EXPOSURE_START_DATETIME as date) > d.death_date + interval '60' day)
      )
);

");

        _logger.LogInformation("Correcting deaths where the patient had a PROCEDURE_OCCURRENCE beyond 60 days.");


        await connection.ExecuteAsync(@"

delete from cdm.death d
where exists (
    select 1
    from cdm.PROCEDURE_OCCURRENCE po
    where po.person_id = d.person_id
      and (
        (po.PROCEDURE_DATE is not null and po.PROCEDURE_DATE > d.death_date + interval '60' day) or
        (po.PROCEDURE_END_DATE is not null and po.PROCEDURE_END_DATE > d.death_date + interval '60' day) or
        (po.PROCEDURE_DATETIME is not null and cast(po.PROCEDURE_DATETIME as date) > d.death_date + interval '60' day) or
        (po.PROCEDURE_END_DATETIME is not null and cast(po.PROCEDURE_END_DATETIME as date) > d.death_date + interval '60' day)
      )
);

");

        _logger.LogInformation("Correcting deaths where the patient had a VISIT_DETAIL beyond 60 days.");


        await connection.ExecuteAsync(@"

delete from cdm.death d
where exists (
    select 1
    from cdm.VISIT_DETAIL vd
    where vd.person_id = d.person_id
      and (
        (vd.VISIT_DETAIL_END_DATE is not null and vd.VISIT_DETAIL_END_DATE > d.death_date + interval '60' day) or
        (vd.VISIT_DETAIL_START_DATE is not null and vd.VISIT_DETAIL_START_DATE > d.death_date + interval '60' day) or
        (vd.VISIT_DETAIL_END_DATETIME is not null and cast(vd.VISIT_DETAIL_END_DATETIME as date) > d.death_date + interval '60' day) or
        (vd.VISIT_DETAIL_START_DATETIME is not null and cast(vd.VISIT_DETAIL_START_DATETIME as date) > d.death_date + interval '60' day)
      )
);
");

        _logger.LogInformation("Correcting deaths where the patient had a VISIT_OCCURRENCE beyond 60 days.");


        await connection.ExecuteAsync(@"

delete from cdm.death d
where exists (
    select 1
    from cdm.VISIT_OCCURRENCE vo
    where vo.person_id = d.person_id
      and (
        (vo.VISIT_END_DATE is not null and vo.VISIT_END_DATE > d.death_date + interval '60' day) or
        (vo.VISIT_START_DATE is not null and vo.VISIT_START_DATE > d.death_date + interval '60' day) or
        (vo.VISIT_END_DATETIME is not null and cast(vo.VISIT_END_DATETIME as date) > d.death_date + interval '60' day) or
        (vo.VISIT_START_DATETIME is not null and cast(vo.VISIT_START_DATETIME as date) > d.death_date + interval '60' day)
      )
);
");

        _logger.LogInformation("Correcting deaths where the patient had a DRUG_EXPOSURE beyond 60 days.");


        await connection.ExecuteAsync(@"
delete from cdm.death d
where exists (
    select 1
    from cdm.DRUG_EXPOSURE de
    where de.person_id = d.person_id
      and (
        (de.DRUG_EXPOSURE_END_DATE is not null and de.DRUG_EXPOSURE_END_DATE > d.death_date + interval '60' day) or
        (de.DRUG_EXPOSURE_START_DATE is not null and de.DRUG_EXPOSURE_START_DATE > d.death_date + interval '60' day) or
        (de.DRUG_EXPOSURE_END_DATETIME is not null and cast(de.DRUG_EXPOSURE_END_DATETIME as date) > d.death_date + interval '60' day) or
        (de.DRUG_EXPOSURE_START_DATETIME is not null and cast(de.DRUG_EXPOSURE_START_DATETIME as date) > d.death_date + interval '60' day)
      )
);");

        _logger.LogInformation("Correcting deaths where the patient had a OBSERVATION beyond 60 days.");


        await connection.ExecuteAsync(@"

delete from cdm.death d
where exists (
    select 1
    from cdm.OBSERVATION o
    where o.person_id = d.person_id
      and (
        (o.OBSERVATION_DATE is not null and o.OBSERVATION_DATE > d.death_date + interval '60' day) or
        (o.OBSERVATION_DATETIME is not null and cast(o.OBSERVATION_DATETIME as date) > d.death_date + interval '60' day)
      )
);

");

        _logger.LogInformation("Correcting deaths where the patient had a CONDITION_ERA beyond 60 days.");


        await connection.ExecuteAsync(@"

delete from cdm.death d
where exists (
    select 1
    from cdm.CONDITION_ERA ce
    where ce.person_id = d.person_id
      and ce.CONDITION_ERA_END_DATE is not null 
      and ce.CONDITION_ERA_END_DATE > d.death_date + interval '60' day
);

");

        _logger.LogInformation("Extending visit_occurrence start and end dates to accomodate encapsulated visit_detail records.");


        await connection.ExecuteAsync(@"

with visit_dates as (
    select
        vo.visit_occurrence_id,
        min(vo.visit_start_date) as visit_start_date,
        min(vo.visit_start_datetime) as visit_start_datetime,
        max(vo.visit_end_date) as visit_end_date,
        max(vo.visit_end_datetime) as visit_end_datetime
    from
        cdm.visit_occurrence vo
    inner join
        cdm.visit_detail vd
        on vo.visit_occurrence_id = vd.visit_occurrence_id
    group by
        vo.visit_occurrence_id
)
update cdm.visit_occurrence
set
    visit_start_date = vd.visit_start_date,
    visit_start_datetime = vd.visit_start_datetime,
    visit_end_date = vd.visit_end_date,
    visit_end_datetime = vd.visit_end_datetime
from
    visit_dates vd
where
    cdm.visit_occurrence.visit_occurrence_id = vd.visit_occurrence_id;

");

    }

    private async Task PruneRecords(CancellationToken cancellationToken)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        await connection.ExecuteAsync(@"
create temporary table personstodelete_temp (
    person_id integer not null
);

insert into personstodelete_temp (
    person_id
)
select
    person_id
from cdm.person
where gender_concept_id is null
    or person_source_value is null
    or race_concept_id is null
    or ethnicity_concept_id is null;

update cdm.observation
set
    visit_occurrence_id = null,
    visit_detail_id = null
where person_id in (select person_id from personstodelete_temp);

delete from cdm.condition_occurrence
where person_id in (select person_id from personstodelete_temp);

delete from cdm.measurement
where person_id in (select person_id from personstodelete_temp);

delete from cdm.death
where person_id in (select person_id from personstodelete_temp);

delete from cdm.procedure_occurrence
where person_id in (select person_id from personstodelete_temp);

delete from cdm.drug_exposure
where person_id in (select person_id from personstodelete_temp);

delete from cdm.device_exposure
where person_id in (select person_id from personstodelete_temp);

delete from cdm.visit_detail
where person_id in (select person_id from personstodelete_temp);

delete from cdm.visit_occurrence
where person_id in (select person_id from personstodelete_temp);

delete from cdm.observation
where person_id in (select person_id from personstodelete_temp);

delete from cdm.person
where person_id in (select person_id from personstodelete_temp);

drop table personstodelete_temp;

delete from cdm.location l
where not exists (
    select 1
    from cdm.person p
    where p.location_id = l.location_id
);");
    }
}

