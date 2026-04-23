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

The tool is distributed as the Docker image `ghcr.io/answerdigital/oxford-omop-data-mapper:latest`. Each command below is shown as a full `docker run` invocation so it can be copied and pasted.

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
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
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
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
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
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type sus-apc "/input/April 2022 Submission.zip" --ccmds "/input/April 2022 CCMDS.zip"
```

### Stage a SUS outpatient file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type sus-op /input/OS_SEM_1234_Outpatient_Q1_12345678_aaaaaaaa.csv
```

### Stage a SUS A&E file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type sus-ae /input/OS_SEM_1234_AE_Q1_12345678_aaaaaaaa.csv
```

### Stage a COSD file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type cosd "/input/April 2022 Submission.zip"
```

### Stage a SACT file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type sact /input/SACT_v3-20200101-20200131.csv
```

### Stage an RTDS file

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type rtds /input/Rtds.zip
```

### Stage an Oxford GP extract

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
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
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
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
| `-t, --type <type>`             | Required. One of `sus-apc`, `sus-op`, `sus-ae`, `cosd`, `sact`, `rtds`, `oxford-gp`, `oxford-prescribing`, `oxford-lab`, `oxford-death`.                |
| `-d, --duckdb-source <expr>`    | Optional. A DuckDB source expression used in place of the default staging table, eg `"read_csv('/data/medication_results_short.csv', all_varchar=true)"`. Useful for transforming directly from a CSV without a separate staging step. |
| `--dry-run`                     | Optional. Runs the transformation without writing to the OMOP tables. Defaults to `false`.                                                              |
| `--batch-size <n>`              | Optional. Number of records to process per batch. Defaults to `4000000`.                                                                                |

### Example

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      transform --type sus-apc
```

### Example - transform directly from a CSV

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      --rm \
      -v /path/to/database/folder:/data \
      -v /path/to/your/data:/input \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      transform --type oxford-prescribing \
        --duckdb-source "read_csv('/input/medication_results_short.csv', all_varchar=true)"
```

### Remarks

Note that `oxford-prescribing`, `oxford-lab` and `oxford-death` are transform-only types - there is no `stage load` path for them. They are typically used with `--duckdb-source` against a CSV, or against data materialised into the `omop_staging` schema by an earlier process.

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
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      finalise
```

### Remarks

Removes any `person` records that either have no gender or no ethnicity, and any locations that are not referenced by a retained person.
