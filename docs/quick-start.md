---
layout: default
title: Quick Start Guide
nav_order: 2
has_children: true
---

# Quick Start Guide

In this guide we will transform a SUS outpatient CSV file to OMOP.

This tool supports the following format [SUS_SEM_Extract_Specification](https://digital.nhs.uk/binaries/content/assets/website-assets/services/sus/sus-guidance/sem_extract_specification-v-1.3.xlsx).

This data can be requested in bulk for your trust via the [SUS+ Portal](https://digital.nhs.uk/services/secondary-uses-service-sus/sus-portal-user-guide).

## Prerequisites
* [Docker](https://www.docker.com/get-started/) (or .NET 8 SDK if running from source)
* An unpacked [Athena](https://athena.ohdsi.org/) vocabulary extract - see the [Database Setup guide]({% link docs/database-setup.md %}).

The tool uses [DuckDB](https://duckdb.org/) for storage. The database is a single `.db` file created at the location given by the `ConnectionString` setting.

## Initialise the database

Before anything can be staged or transformed, run the `init` command to create the DuckDB database file and import the Athena vocabularies. This is a one-off step per database - see the [Database Setup guide]({% link docs/database-setup.md %}) for details.

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

## Stage the data

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      -e BatchSize=500000 \
      --rm \
      -v /path/to/your/data:/data \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      stage load --type sus-op /data/OS_SEM_1234_Outpatient_Q1_12345678_aaaaaaaa.csv --allowed_nhs_number_list_path /data/allowed_patients.txt
```

In this example `/path/to/your/data` should be the path to the directory where both the source data file and the DuckDB `omop.db` live. This directory is mounted into the container at `/data`.

An optional `--allowed_nhs_number_list_path` can be specified. This is a list of allowed patients (those who have not opted out of data processing). This file is used to exclude opt-out  patient records during the staging process. If it is not specified then we will stage all patients.

Typically this command would be run once per file until all of the available SUS data was staged into the database.

```
info: OmopTransformer.SUS.Staging.OP.SusOPStaging[0]
      Staging OP SUS data.
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: OmopTransformer.SUS.Staging.OP.SusOPStaging[0]
      Reading /data/OS_SEM_1234_Outpatient_Q1_12345678_aaaaaaaa.csv
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
info: OmopTransformer.SUS.Staging.OP.SusOPStaging[0]
      Streaming records...
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Recording SUS rows.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Batch 1.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Inserting OPRow.
info: OmopTransformer.DataOptOut[0]
      Loading allowed patient list took 2.1704667 seconds. 3954569 entries loaded.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Inserting OPRow ReadProcedure.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Inserting OPRow OpcdProcedure.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Inserting APCRow ReadDiagnoses.
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Inserting OPRow IcdDiagnoses.
info: OmopTransformer.DataOptOut[0]
      National Data Opt Out
info: OmopTransformer.DataOptOut[0]
      Allowed count: 93282
info: OmopTransformer.DataOptOut[0]
      Opt out count: 6606
info: OmopTransformer.SUS.Staging.OP.SusOPInserter[0]
      Batch 2.

.....

      Staging complete.
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

Staged data can be cleared using the [`stage clear`]({% link docs/user-guide/commands.md %}#clear-staging-command) command, eg `stage clear --type sus-op`.

## Transform the data

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      -e BatchSize=500000 \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      transform --type sus-op
```

Transform any staged `sus-op` data.

Typically this command would be run once per staged data type. In the case of SUS it would be `sus-apc`, `sus-op` then `sus-ae`.

```

      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
info: OmopTransformer.ConceptMapper[0]
      Rendering non standard to standard concept map.
info: OmopTransformer.RecordProvider[0]
      Running query. Pagination disabled (order by clause missing).
info: OmopTransformer.Transformation.IRecordTransformer[0]
      --------------------------------
      Transformation: SUS OP Person
      Valid rows: 802868
      Invalid rows: 0
      Overall time: 00:09:09.5125040. 1461 per second
      Read time: 00:01:35.2888341. 8425 per second
      Write time: 00:07:07.9566161. 1876 per second
      CPU time : 00:00:25.8439175. 31066 per second
      --------------------------------
      
warn: LookupTransformer[0]
      Missed lookups
      Lookup name: NhsGenderLookup 
        Total miss rate 0% (802858 hits, 10 misses)
        Misses
        - "0" misses: 10
      
      
info: OmopTransformer.RecordProvider[0]
      Running query. Pagination disabled (order by clause missing).
info: OmopTransformer.Transformation.IRecordTransformer[0]
      --------------------------------
      Transformation: SUS OP Location
      Valid rows: 914219
      Invalid rows: 0
      Overall time: 00:08:08.7426475. 1870 per second
      Read time: 00:04:37.7117916. 3291 per second
      Write time: 00:03:22.0637290. 4524 per second
      CPU time : 00:00:08.7078859. 104987 per second
      --------------------------------
      
info: OmopTransformer.RecordProvider[0]
      Running query. Pagination disabled (order by clause missing).
info: OmopTransformer.Transformation.IRecordTransformer[0]
      --------------------------------
      Transformation: SUS OP Death
      Valid rows: 145
      Invalid rows: 0
      Overall time: 00:01:33.6415508. n/a per second
      Read time: 00:01:33.3080972. n/a per second
      Write time: 00:00:00.3303688. n/a per second
      CPU time : 00:00:00.0023031. n/a per second
      --------------------------------
....
```

## Finalise data

This step removes invalid records, unused locations and builds the following tables
* `drug_era`
* `condition_era`

```
docker run \
      -e ConnectionString="DataSource=/data/omop.db;memory_limit=4GB" \
      -e BatchSize=500000 \
      --rm \
      -v /path/to/database/folder:/data \
      ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
      finalise
```



```
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: OmopTransformer.Omop.Prune.OmopFinaliser[0]
      Clearing incomplete omop records.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
info: OmopTransformer.Omop.Prune.OmopFinaliser[0]
      Rebuilding era tables.
info: OmopTransformer.Omop.Prune.OmopFinaliser[0]
      Apply data fixes.
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
```

## Next Steps

At this point the OMOP database is ready for consumption.

If the `observation_period` table is required for your use case (eg for Atlas), the [OHDSI OmopConstructor R package](https://github.com/OHDSI/OmopConstructor) can be used to populate this table.