---
layout: default
title: Database Setup
parent: Quick Start Guide
---

# Database setup

The OMOP mapper tool stores data in a [DuckDB](https://duckdb.org/) database file. A single `.db` file holds the CDM tables, the OMOP vocabulary tables and the tool''s own `omop_staging` schema.

The database is created and populated with vocabularies by running the tool''s `init` verb. There are no external migration scripts to run.

The setup is two steps:

1. [Download the Athena vocabularies](#download-vocabularies) - Athena data cannot be redistributed in this repository, and the vocabularies required depend on the data sources you plan to transform.
2. [Run the `init` command](#run-init) - Creates the DuckDB file, provisions all schemas/tables/sequences and loads the vocabulary CSVs.

## Download vocabularies

1. Create an [https://athena.ohdsi.org/](https://athena.ohdsi.org/) account and download at least the following vocabularies.

> | Id |  CDM | Code | Name |
> |-------|-----------|-------------------|-----------------------|
> |154|CDM 5| NHS Ethnic Category|NHS Ethnic Category |
> |148|CDM 5| OMOP Invest Drug| OMOP Investigational Drugs|
> |142|CDM 5| OPS| Operations and Procedures Classification (OPS)|
> |141|   CDM 5   | Cancer Modifier| Diagnostic Modifiers of Cancer (OMOP) |
> |90|   CDM 5   |ICDO3 |International Classification of Diseases for Oncology, Third Edition (WHO) |
> |82   |   CDM 5   | RxNorm Extension | OMOP RxNorm Extension |
> |75|CDM 5| dm+d| Dictionary of Medicines and Devices (NHS)|
> |71| CDM 5 | ABMS | Provider Specialty (American Board of Medical Specialties) |
> |57| CDM 5 | HES Specialty| Hospital Episode Statistics Specialty (NHS) |
> |55|CDM 5| OPCS4| OPCS Classification of Interventions and Procedures version 4 (NHS)|
> |48   |    CDM 5  | Medicare Specialty | Medicare provider/supplier specialty codes (CMS) |
> |47   |   CDM 5   | NUCC  | National Uniform Claim Committee Health Care Provider Taxonomy Code Set (NUCC) |
> |44|CDM 5| Ethnicity |OMOP Ethnicity|
> |34|CDM 5| ICD10| International Classification of Diseases, Tenth Revision (WHO)|
> |14   |   CDM 5   | CMS Place of Service | CMS Place of Service |
> |13|CDM 5| Race| Race and Ethnicity Code Set (USBC)|
> |12|CDM 5| Gender|OMOP Gender|
> |8    |  CDM 5   | RxNorm | RxNorm (NLM) |
> |6    | CDM 5 |  LOINC |Logical Observation Identifiers Names and Codes (Regenstrief Institute) |
> |3| CDM 5     | ICD9Proc |International Classification of Diseases, Ninth Revision, Clinical Modification, Volume 3 (NCHS) |
> |2    |CDM 5| ICD9CM| International Classification of Diseases, Ninth Revision, Clinical Modification, Volume 1 and 2 (NCHS) |
> |1|CDM 5| SNOMED|Systematic Nomenclature of Medicine - Clinical Terms (IHTSDO)|

It is difficult to add more vocabularies retrospectively, so err on the side of including anything you may want later.

2. Unpack the downloaded archive into a directory. `init` expects to find the Athena CSV files (`CONCEPT.csv`, `CONCEPT_ANCESTOR.csv`, `CONCEPT_CLASS.csv`, `CONCEPT_RELATIONSHIP.csv`, `CONCEPT_SYNONYM.csv`, `DOMAIN.csv`, `DRUG_STRENGTH.csv`, `RELATIONSHIP.csv`, `VOCABULARY.csv`) directly inside this directory.

## Run `init`

The `init` command creates an empty DuckDB database file at the location given by `ConnectionString`, provisions the `dbo`, `cdm` and `omop_staging` schemas (including sequences, CDM tables and Oxford concept lookups), and then `COPY`s the Athena CSV files from the directory given by `VocabularyDirectory` into the `cdm.*` vocabulary tables.

Both settings can be supplied via `appsettings.json` or as `-e` environment variables on the Docker command line. See the [configuration guide]({% link docs/user-guide/configuration.md %}) for the full list.

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

In this example:

* `/path/to/athena/extract` is the host directory containing the unpacked Athena CSVs. It is mounted into the container at `/vocabulary`.
* `/path/to/database/folder` is the host directory where the `omop.db` DuckDB file will be created. It is mounted at `/data`.

`init` is destructive against the target database file - run it once against a fresh database location. To reset the database, delete the `.db` file and re-run `init`.

Once `init` completes, the database is ready for staging and transforming data. Continue with the [Quick Start Guide]({% link docs/quick-start.md %}).