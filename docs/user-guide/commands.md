---
layout: default
title: Commands
parent: User Guide
nav_order: 2
has_children: false
---

# Commands
{: .no_toc }

<details open markdown="block">
  <summary>
    Table of contents
  </summary>
  {: .text-delta }
- TOC
{:toc}
</details>

The tool is distributed as the Docker image `ghcr.io/tvs-sde/oxford-omop-data-mapper:latest`. Each command below is shown as a full `docker run` invocation so it can be copied and pasted.

Every command reads its `ConnectionString`, `VocabularyDirectory` and `BatchSize` settings from `appsettings.json` or from `-e` environment variables. See the [configuration guide]({% link docs/user-guide/configuration.md %}) for the full list.

In the examples below, replace `/path/to/database/folder` and `/path/to/your/data` with directories on the host. The database folder must be the one that contains (or will contain) the DuckDB `omop.db` file.

---

## Init command

Creates the DuckDB database file and imports the Athena vocabulary.

### Example

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      -e VocabularyDirectory="/vocabulary" \
      --rm \
      -v /path/to/athena/extract:/vocabulary \
      -v /path/to/database/folder:/data \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      init
```

### Remarks

`init` creates the `dbo`, `cdm` and `omop_staging` schemas, all OMOP CDM tables, the tool's sequences and Oxford-specific concept tables, then `COPY`s the Athena CSVs (`CONCEPT.csv`, `CONCEPT_ANCESTOR.csv`, `CONCEPT_CLASS.csv`, `CONCEPT_RELATIONSHIP.csv`, `CONCEPT_SYNONYM.csv`, `DOMAIN.csv`, `DRUG_STRENGTH.csv`, `RELATIONSHIP.csv`, `VOCABULARY.csv`) from `VocabularyDirectory` into `cdm.*`.

Run `init` once against a fresh database location. To reset the database, delete the `.db` file and re-run `init`. See the [Database Setup guide]({% link docs/database-setup.md %}) for more detail.

---

## Docs command

Generates transformation documentation and writes it to a specified directory.

### Example

Generates transformation documentation into the host directory mounted at `/out`.

```
docker run \
      --rm \
      -v /path/to/output:/out \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      docs /out
```

### Remarks

The documentation comprises:

* Markdown documents
* SVG diagrams
* Machine readable JSON transformation explanations

Each OMOP field has a document that describes how it is mapped from all known data sources. This could be a plain copy, or include complex transformations or lookups. If a transformation includes a SQL query, the query is included alongside an explanation of its output.

The `docs` command does not require a database connection.

#### JSON example

```
{
  "omopTable": "Observation",
  "origin": "SUS-APC",
  "omopColumns": [
    {
      "name": "nhs_number",
      "operation_description": "Value copied from `NHSNumber`",
      "dataSource": [
        {
          "name": "NHSNumber",
          "description": "Patient NHS Number",
          "origins": [
            {
              "origin": "NHS NUMBER",
              "url": "https://www.datadictionary.nhs.uk/data_elements/nhs_number.html"
            }
          ]
        }
      ],
      "query": "\nselect \n\tl1.NHSNumber, \n\tmax(l1.CDSActivityDate) as CDSActivityDate, \n\tl1.CarerSupportIndicator,\n\tl5.HospitalProviderSpellNumber,\n\tl1.RecordConnectionIdentifier\nfrom omop_staging.cds_line01 l1\n\tleft outer join omop_staging.cds_line05 l5\n\t\ton l1.MessageId = l5.MessageId\nwhere NHSNumber is not null\n\tand CarerSupportIndicator is not null\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\ngroup by \n\tl1.NHSNumber, \n\tl1.CarerSupportIndicator,\n\tl5.HospitalProviderSpellNumber,\n\tl1.RecordConnectionIdentifier;\n\t",
      "lookup_table_markdown": null
    }
  ]
}
```

---

## Stage command

Loads staging data from the file system into the `omop_staging` schema.

### Options

| Option                           | Applies to | Remarks                                                                                                                                                       |
|----------------------------------|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `-t, --type <type>`              | all        | Required. One of `sus-apc`, `sus-op`, `sus-ae`, `cosd`, `sact`, `rtds`, `oxford-gp`.                                                                           |
| `<filename>` (positional)        | all except `oxford-gp` | Path to the source file inside the container.                                                                                                                  |
| `--ccmds <path>`                 | `sus-apc`  | Optional path to a matching CCMDS file for the same SUS APC extract.                                                                                           |
| `--allowed_nhs_number_list_path` | all        | Optional. File containing a list of allowed patient NHS numbers, one per line. Records for patients outside this list are dropped (National Data Opt-Out).     |
| `--demographics <path>`          | `oxford-gp`| Required. Path to the Oxford GP demographics CSV.                                                                                                              |
| `--appointments <path>`          | `oxford-gp`| Required. Path to the Oxford GP appointments CSV.                                                                                                              |
| `--events <path>`                | `oxford-gp`| Required. Path to the Oxford GP events CSV.                                                                                                                    |
| `--medications <path>`           | `oxford-gp`| Required. Path to the Oxford GP medications CSV.                                                                                                               |

Supported data formats include:

* [SUS+ SEM CSV Extracts](https://digital.nhs.uk/services/secondary-uses-service-sus/secondary-uses-services-sus-guidance) - `sus-apc`, `sus-op`, `sus-ae`
* [COSD v8-1 / v9-0-1 XML](https://digital.nhs.uk/ndrs/data/data-sets/cosd) - `cosd`
* [SACT v3.0](https://digital.nhs.uk/data-and-information/information-standards/information-standards-and-data-collections-including-extractions/publications-and-notifications/standards-and-collections/dcb1533-systemic-anti-cancer-therapy-data-set) - `sact`
* [RTDS](https://digital.nhs.uk/ndrs/data/data-sets/rtds) - `rtds`
* Oxford GP extract (demographics, appointments, events, medications CSVs) - `oxford-gp`

Staged data is appended to existing staging tables. To clear the staging tables first, run [`stage clear`](#clear-staging-command).

### Stage a SUS APC file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type sus-apc "/input/April 2022 Submission.zip" --ccmds "/input/April 2022 CCMDS.zip"
```

### Stage a SUS outpatient file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type sus-op /input/OS_SEM_1234_Outpatient_Q1_12345678_aaaaaaaa.csv
```

### Stage a SUS A&E file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type sus-ae /input/OS_SEM_1234_AE_Q1_12345678_aaaaaaaa.csv
```

### Stage a COSD file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type cosd "/input/April 2022 Submission.zip"
```

### Stage a SACT file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type sact /input/SACT_v3-20200101-20200131.csv
```

### Stage an RTDS file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type rtds /input/Rtds.zip
```

### Stage an Oxford GP extract

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage load --type oxford-gp \
        --demographics /input/demographics.csv \
        --appointments /input/appointments.csv \
        --events /input/events.csv \
        --medications /input/medications.csv
```

### Opt-out example

```
stage load --type sus-op /input/OS_SEM_1234_Outpatient_Q1_12345678_aaaaaaaa.csv \
  --allowed_nhs_number_list_path /input/allowed_patients.txt
```

Records for any patient whose NHS number is not in `allowed_patients.txt` are excluded from staging.

---

## Clear staging command

Clears the staging tables for a given type.

### Example

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      stage clear --type sus-apc
```

### Remarks

Supported `--type` flags: `sus-apc`, `sus-op`, `sus-ae`, `cosd`, `sact`, `rtds`, `oxford-gp`.

---

## Transform command

Transforms the staged data (and records data provenance) into the OMOP tables.

### Options

| Option                          | Remarks                                                                                                                                                |
|---------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| `-t, --type <type>`             | Required. One of `sus-apc`, `sus-op`, `sus-ae`, `cosd`, `sact`, `rtds`, `oxford-gp`, `oxford-demographics`, `oxford-procedures`, `oxford-diagnosis`, `oxford-clinical-observations-vital-signs`, `oxford-prescribing`, `oxford-lab`, `oxford-death`. |
| `-d, --duckdb-source <expr>`    | Optional. A DuckDB source expression used in place of the default staging table, eg `"read_csv('/data/medication_results_short.csv', all_varchar=true)"`. Useful for transforming directly from a CSV without a separate staging step. |
| `--dry-run`                     | Optional. Runs the transformation without writing to the OMOP tables. Defaults to `false`.                                                              |
| `--batch-size <n>`              | Optional. Number of records to process per batch. Defaults to `4000000`.                                                                                |

### Example

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      transform --type sus-apc
```

### Example - transform directly from a CSV

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      transform --type oxford-prescribing \
        --duckdb-source "read_csv('/input/medication_results_short.csv', all_varchar=true)"
```

### Example - transform Oxford demographics directly from Parquet

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      transform --type oxford-demographics \
        --duckdb-source "read_parquet('/input/databricks_demographics.parquet')"
```

The demographics source must contain `date_of_birth`, `ethnic_group`, `sex` and `nhs_number`.
The transformation creates or updates OMOP Person records, using the NHS number as `person_source_value`.
`Male` and `Female` map to gender concepts `8507` and `8532`. UK ethnic groups map to the same
OMOP race concepts as the NHS ethnicity lookup; the original ethnic group is preserved in
`race_source_value`. No data, not known, not stated and unmapped "Other" groups map to race concept `0`.
OMOP `ethnicity_concept_id` is `0`, as it represents Hispanic/non-Hispanic ethnicity rather than UK ethnic groups.

### Example - transform Oxford vital signs directly from Parquet

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      transform --type oxford-clinical-observations-vital-signs \
        --duckdb-source "read_parquet('/input/clinical_observations_vital_signs.parquet')"
```

The Parquet file is supplied at runtime; its name can be changed through `--duckdb-source`.
Required columns are `patient_identifier_value`, `WAREHOUSE_IDENTIFIER`, `EVENT_END_DT_TM`, `EVENT`, `RESULT_VALUE`,
`RESULT_UNITS`, `NORMAL_LOW` and `NORMAL_HIGH`. The export must already apply the MPI
`Not Opted Out` restriction. The transformer cannot reconstruct opt-out status from these
columns. `WAREHOUSE_IDENTIFIER` is not used as a fallback patient identifier.
Load demographics first: the exported NHS number joins OMOP Person's `person_source_value`.

Ten separate mapping/query pairs run under one provenance run ID. Each numeric
reading type has its own small query, without a shared event/unit `CASE` expression.
Every query has its own independent source-record class and mapper; source records
do not inherit from a shared base class, so their schemas can evolve separately.

| Mapping | Events | Target |
|---------|--------|--------|
| Heart rate | Apical Heart Rate, Heart Rate, Heart Rate Monitored, Peripheral Pulse Rate | Measurement: Heart rate (`3027018`) |
| Systolic blood pressure | Booking Systolic Blood Pressure; Systolic Blood Pressure, including Invasive, Sitting, Standing and Supine variants | Measurement: Systolic blood pressure (`3004249`) |
| Diastolic blood pressure | Booking Diastolic Blood Pressure; Diastolic Blood Pressure, including Invasive, Sitting, Standing and Supine variants | Measurement: Diastolic blood pressure (`3012888`) |
| Mean arterial pressure | Mean Arterial Pressure; Mean Arterial Pressure, Cuff; Mean Arterial Pressure, Invasive | Measurement: Mean blood pressure (`3027598`) |
| Respiratory rate | Respiratory Rate; Respiratory Rate Total; Respiratory Rate, Spontaneous | Measurement: Respiratory rate (`3024171`) |
| Temperature | Temperature; Temperature POCT; Temperature Tympanic | Measurement: Body temperature (`3020891`) |
| Oxygen saturation | Oxygen Saturation; SpO2 | Measurement: Pulse-oximetry oxygen saturation (`3016502`) |
| Delivered oxygen concentration | Oxygen % delivered | Measurement: Inhaled oxygen concentration (`3024882`), not oxygen saturation |
| Glasgow Coma Score | Glasgow Coma Score totals only | Measurement: Glasgow coma score (`3032652`, SNOMED CT `248241002`) |
| Tracheostomy present | Tracheostomy In Situ, with Yes answers only | Condition occurrence: Tracheostomy present (`4201387`, SNOMED CT `302108003`) |

Glasgow Coma Score sets both measurement concept IDs directly to `3032652`, without
vocabulary resolution. Tracheostomy sets both condition concept IDs directly to
`4201387`; only Yes answers are selected, ignoring case and surrounding whitespace.
No, missing and other answers do not produce conditions or observations.
The positive event timestamp supplies the condition start; no condition end is inferred.
These mappings are not a substitute for local vocabulary/clinical review.

The event end timestamp supplies date/datetime, EHR type concept `32817` is used, and
original event names are retained in the corresponding source fields.
Measurements also retain their original results and units.
No provider, visit, relationship between separate events or physiological correction is inferred.
Position and method variants retain their original event names even where they share a broad concept.
Ranges use the existing numeric parser.
Each mapping supplies a stable record-connection identifier derived from the warehouse
identifier and original event timestamp, name, result, units and ranges. This prevents
the shared recorders from collapsing distinct same-day readings across batches and
provides a rerun key for identical exported rows. No source event ID is available.

For numeric vital signs, null, blank and `<no data>` units default by event:
heart/pulse rate to `bpm`, respiratory rate to `br/min`, blood pressure to `mmHg`,
temperature to `degrees C`, and oxygen saturation/concentration to `%`.
Each mapper sets its fixed unit concept directly using `ConstantValue`; no unit lookup
or synthetic unit column is needed. The original unit text is preserved separately.
Each query accepts only the expected
unit for that reading type or a missing unit; mismatched explicit units are excluded
without conversion. Unit matching ignores
case and surrounding whitespace. Glasgow Coma Score is dimensionless and requires
missing units; unexpected explicit units are excluded.
Time-point heart-rate threshold readings are no longer mapped.

Only finite numeric results are selected for measurements. Placeholders such as
`<REDACTED>`, `<long freetext>`, `patient_refused`, `ERROR` and `*` are not numeric and
are excluded. Negative values and physiological extremes are retained without clipping,
including Glasgow scores outside the usual 3-15 range.

The supplied event profile contains 60 event types; 30 are supported. These 30 are
deliberately excluded:

* Heart Rate at 1 minute; Heart Rate at 5 minutes; Heart Rate at 10 minutes.
* AVPU Scale; Best Verbal Response; Eye Opening Response; Motor Response; GCS Assessed.
* Blood Pressure Position; Blood Pressure Site.
* Delivery device used; Oxygen Humidified; Oxygen L/min delivered; Oxygen monitoring;
  Oxygen Saturation >95% on air.
* Escalated; Other Reasons for Escalation; Heart Rate and BP within normal range;
  Paediatric Vital Signs Actions Taken.
* T&T Total Score; TAT AVPU Scale; TAT Delivery Device Used; TAT Oxygen Saturation;
  TAT Pulse Rate; TAT Respiratory Rate; TAT Systolic Blood Pressure; TAT Temperature.
* Vital Signs; Vital Signs Adult; Vital Signs Stable.

Unknown events are excluded too. The upstream-excluded Vital Signs Nursing Evaluation
and `(M)` heart-rate events are never selected. Warnings describe these exclusions;
rows filtered out by SQL are not counted as invalid transformed rows.
Each query uses `ORDER BY ALL`; keep the source unchanged throughout pagination.
The grouped frequency CSV is a profiling input only, not a patient-level transformation source.

### Example - transform Oxford diagnoses directly from Parquet

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      transform --type oxford-diagnosis \
        --duckdb-source "read_parquet('/input/databricks_diagnosis.parquet')"
```

The diagnosis file is supplied at runtime; it is not bundled with the application.
The source must contain `patient_identifier_value`, `diagnosis_date`, `diagnosis_datetime`,
`diagnosis_code`, `diagnosis_code_system`, `diagnosis_id` and `warehouse_identifier`.
`patient_identifier_value` is treated as the NHS number and joins existing OMOP Person records;
load demographics first. Clinical diagnosis dates and timestamps populate the start fields.
No end date, status, provider or visit linkage is inferred.

Separate Condition Occurrence mappings select rows by `diagnosis_code_system`:

| Code system | Mapping |
|-------------|---------|
| `SNOMED CT` | Existing SNOMED selector, including rows whose `source_vocabulary` is `UK ED Subset`. |
| `ICD-10`, `ICD10` | Existing ICD10 standard/non-standard selector. |
| `OPCS4` | Existing OPCS4 selector; only standard Condition-domain targets are retained. Procedure-only concepts are not inserted as conditions. |

Original diagnosis codes are preserved as `condition_source_value`. All implemented mappings
use the existing standard Condition concept selector and EHR type concept `32817`.
ICD10 codes shorter than three characters resolve to unknown concept `0`, avoiding the existing
ICD10 resolver's minimum-length exception. Missing clinical diagnosis dates produce invalid records.
IMO, Patient Care and HRG are unsupported and are not selected. A warning is logged about
excluded code systems. Missing or unrecognised code systems are also not selected.

### Remarks

Note that `oxford-demographics`, `oxford-procedures`, `oxford-diagnosis`, `oxford-prescribing`, `oxford-lab` and `oxford-death` are transform-only types - there is no `stage load` path for them. They require `--duckdb-source` against a Parquet file, CSV, or another DuckDB source expression.

The OMOP data provenance is recorded as each data set is transformed. [See data provenance.]({% link docs/data-provenance.md %}#data-provenance)

---

## Finalise command

Finalises the OMOP dataset by:

* Pruning incomplete OMOP records.
* Rebuilding era tables (`condition_era` and `drug_era`).
* Applying additional data fixes.

### Example

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/tvs-sde/oxford-omop-data-mapper:latest \
      finalise
```

### Remarks

Removes any `person` records that either have no gender or no ethnicity, and any locations that are not referenced by a retained person.
