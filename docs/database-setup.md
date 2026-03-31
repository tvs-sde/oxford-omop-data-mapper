---
layout: default
title: Database Setup
parent: Quick Start Guide
---

# Database setup

The omop mapper tool requires a the latest omop database along with some additional tables and stored procedures.

The database needs to be setup in two steps because the Athena code list is too large to add to this repository. There is also an element of choice for which Athena vocabularies are required. It is difficult to add more vocabularies retrospectively.

The process to setup the database has two steps


1. [Download Athena Vocabulary](#download-athena-vocabulary) - Gather the Athena vocabulary
2. [Database Initiation](#database-initiation) - Initiate the database and import the vocabulary.

## Download Athena Vocabulary

1. Create an https://athena.ohdsi.org/ account and download at least the following vocabularies.
> | Id |  CDM | Code | Name |
> |-------|-----------|-------------------|-----------------------|
> |154	|	CDM 5	| NHS Ethnic Category	|NHS Ethnic Category |
> |148	|	CDM 5	| OMOP Invest Drug	| OMOP Investigational Drugs|
> |142	|	CDM 5	| OPS	| Operations and Procedures Classification (OPS)|
> |141	|   CDM 5   | Cancer Modifier	| Diagnostic Modifiers of Cancer (OMOP) |
> |90	    |   CDM 5   |ICDO3 |	International Classification of Diseases for Oncology, Third Edition (WHO) |
> |82       |   CDM 5   | RxNorm Extension | OMOP RxNorm Extension |
> |75		|	CDM 5	| dm+d	| Dictionary of Medicines and Devices (NHS)|
> |72      | CDM 5 |  CIEL    | Columbia International eHealth Laboratory (Columbia University) |
> |71	| CDM 5 | ABMS	 | Provider Specialty (American Board of Medical Specialties)	 |
> |57	| CDM 5 | HES Specialty	| Hospital Episode Statistics Specialty (NHS) |
> |55		|	CDM 5	| OPCS4| 	OPCS Classification of Interventions and Procedures version 4 (NHS) |
> |48       |    CDM 5  | Medicare Specialty | Medicare provider/supplier specialty codes (CMS) |
> |47     |   CDM 5   | NUCC  | 	National Uniform Claim Committee Health Care Provider Taxonomy Code Set (NUCC) |
> |44		|	CDM 5	| Ethnicity |	OMOP Ethnicity|
> |34		|	CDM 5	| ICD10	| International Classification of Diseases, Tenth Revision (WHO)|
> |14     |   CDM 5   | CMS Place of Service | CMS Place of Service |
> |13		|	CDM 5	| Race	| Race and Ethnicity Code Set (USBC)|
> |12		|	CDM 5	| Gender|	OMOP Gender|
> |8        |  CDM 5   | RxNorm | RxNorm (NLM) |
> |6	    | CDM 5     |  LOINC |	Logical Observation Identifiers Names and Codes (Regenstrief Institute) |
> |3	    |	CDM 5	| ICD9Proc |	International Classification of Diseases, Ninth Revision, Clinical Modification, Volume 3 (NCHS) |
> |2      |	CDM 5	| ICD9CM	| International Classification of Diseases, Ninth Revision, Clinical Modification, Volume 1 and 2 (NCHS) |
> |1		|	CDM 5	| SNOMED	|Systematic Nomenclature of Medicine - Clinical Terms (IHTSDO)|


## Database Initiation

The database can be initiated and vocabulary imported in one step `init`. 

```
  docker run \
	-e ConnectionString="DataSource=/data/omop.db;memory_limit=2GB" \
	-e BatchSize=50000 \
	-e VocabularyDirectory="/vocabulary" \
	--rm \
	-v ~/data:/data \
	-v ~/vocabulary:/vocabulary:z \
	ghcr.io/answerdigital/oxford-omop-data-mapper:latest \
	init
```