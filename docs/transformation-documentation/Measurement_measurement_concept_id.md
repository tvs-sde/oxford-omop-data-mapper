---
layout: default
title: measurement_concept_id
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# measurement_concept_id
### Sus OP  Measurement
Source column  `measurement_source_concept_id`.
Maps concepts to standard valid concepts in the `measurement` domain.

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus CCMDS Measurement - Gestation Length at Delivery
* Constant value set to `4260747`. Length of gestation at birth

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20Sus%20CCMDS%20Measurement%20-%20Gestation%20Length%20at%20Delivery%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Constant value set to `4099154`. Body Weight

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### Sus APC Measurement
Source column  `measurement_source_concept_id`.
Maps concepts to standard valid concepts in the `measurement` domain.

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
* Constant value set to `4099154`. Body Weight

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
* Constant value set to `4099154`. Body Weight

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
* Constant value set to `607590`. Body Height

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
### Oxford Lab Measurement
Source column  `measurement_source_concept_id`.
Maps concepts to standard valid concepts in the `measurement` domain.

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
<<<<<<< HEAD
### COSD V8 SK Measurement Tumour Laterality
=======
### COSD V9 UR Measurement Tumour Laterality
>>>>>>> main
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
<<<<<<< HEAD
with SK as (
    select
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where Type = 'SK'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from SK
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
=======
-- Query to extract Tumour Laterality for UR cancer area from COSD v9.
-- Identifies the side of the body for a tumour relating to paired organs.
-- Only valid laterality codes (L, R, M, B) are included.
-- MeasurementDate uses the primary diagnosis date.
-- TumourLaterality will be mapped to a measurement value concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as MeasurementDate,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_901
where type = 'UR'
  and (Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code') in ('L','R','M','B');
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20SK%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 SK Measurement TNM Stage Grouping Integrated
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 UR Measurement TNM Category Integrated Stage
>>>>>>> main
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `TnmStageGroupingIntegrated` Code, using a TNM coding edition, that classifies the combination of tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	TnmStageGroupingIntegrated
from SK
where TnmStageGroupingIntegrated is not null;
=======
* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
-- Query to extract TNM Stage Grouping (Integrated) for UR cancer area from COSD v9.
-- The TNM stage grouping classifies the combination of T, N and M into stage groupings after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TnmStageGroupingIntegrated will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_901
where type = 'UR'
  and TnmStageGroupingIntegrated is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20SK%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V8 SK Measurement TNM Stage Grouping Final Pretreatment
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
-- Query to extract TNM Stage Grouping (Final Pretreatment) for UR cancer area from COSD v9.
-- The TNM stage grouping classifies the combination of T, N and M into stage groupings before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TnmStageGroupingFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'UR'
  and TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Tcategory Integrated Stage
Source column  `TcategoryIntegratedStage`.
Lookup TCategory concepts.


|TcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
-- Query to extract T Category (Integrated Stage) for UR cancer area from COSD v9.
-- The T category classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TcategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'UR'
  and TcategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
-- Query to extract T Category (Final Pretreatment) for UR cancer area from COSD v9.
-- The T category classifies the size and extent of the primary tumour before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'UR'
  and TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `4272032`. Prostate specific antigen measurement

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V9 UR Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site (Primary Pathway/Diagnosis) for UR cancer area from COSD v9.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with UR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from UR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Non Primary Pathway Recurrence Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site (Non-Primary Pathway - Recurrence) for UR cancer area from COSD v9.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with UR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from UR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Non Primary Pathway Progression Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site (Non-Primary Pathway - Progression) for UR cancer area from COSD v9.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with UR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from UR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Ncategory Integrated Stage
Source column  `NcategoryIntegratedStage`.
Lookup NCategory concepts.


|NcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
-- Query to extract N Category (Integrated Stage) for UR cancer area from COSD v9.
-- The N category classifies the absence or presence and extent of regional lymph node metastases after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- NcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NcategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'UR'
  and NcategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
-- Query to extract N Category (Final Pretreatment) for UR cancer area from COSD v9.
-- The N category classifies the absence or presence and extent of regional lymph node metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- NcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'UR'
  and NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Mcategory Integrated Stage
Source column  `McategoryIntegratedStage`.
Lookup  concepts.


|McategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
-- Query to extract M Category (Integrated Stage) for UR cancer area from COSD v9.
-- The M category classifies the absence or presence of distant metastases after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- McategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as McategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'UR'
  and McategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
-- Query to extract M Category (Final Pretreatment) for UR cancer area from COSD v9.
-- The M category classifies the absence or presence of distant metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- McategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'UR'
  and McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
-- Query to extract Grade of Differentiation (at Diagnosis) for UR cancer area from COSD v9.
-- The grade classifies the differentiation of the tumour at the time of diagnosis.
-- MeasurementDate uses the primary diagnosis date.
-- GradeOfDifferentiationAtDiagnosis will be mapped to a measurement value concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as MeasurementDate,
    Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_901
where type = 'UR'
  and GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V9 UR Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 UR Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
-- Query to extract Tumour Laterality for UR cancer area from COSD v8.
-- Identifies the side of the body for a tumour relating to paired organs.
-- Only valid laterality codes (L, R, M, B) are included.
-- MeasurementDate uses diagnosis date, falling back to non-primary diagnosis date.
-- TumourLaterality will be mapped to a measurement value concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_81
where type = 'UR'
  and (Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.TumourLaterality.@code') in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 UR Measurement TNMcategory Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
-- Query to extract TNM Stage Grouping (Integrated) for UR cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of T, N and M into stage groupings after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TnmStageGroupingIntegrated will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_81
where type = 'UR'
  and TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20TNMcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement TNMcategory Final Pre Treatment Stage
>>>>>>> main
Source column  `TnmStageGroupingFinalPreTreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `TnmStageGroupingFinalPreTreatment` Code, using a TNM coding edition, that classifies the combination of tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPreTreatment,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	TnmStageGroupingFinalPreTreatment
from SK
where TnmStageGroupingFinalPreTreatment is not null;
=======
* `TnmStageGroupingFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
-- Query to extract TNM Stage Grouping (Final Pretreatment) for UR cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of T, N and M into stage groupings before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TnmStageGroupingFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'UR'
  and TnmStageGroupingFinalPreTreatment is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20SK%20Measurement%20TNM%20Stage%20Grouping%20Final%20Pretreatment%20mapping){: .btn }
### COSD v8 SK Measurement TCategory Integrated Stage
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20TNMcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Tcategory Integrated Stage
>>>>>>> main
Source column  `TcategoryIntegratedStage`.
Lookup TCategory concepts.


|TcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `TcategoryIntegratedStage` Code, using a TNM coding edition, that classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	TCategoryIntegratedStage
from SK
where TCategoryIntegratedStage is not null;
=======
* `TcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
-- Query to extract T Category (Integrated Stage) for UR cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTCategory' as TcategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'UR'
  and TcategoryIntegratedStage is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20TCategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 SK Measurement TCategory Final Pretreatment
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Tcategory Final Pre Treatment Stage
>>>>>>> main
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `TcategoryFinalPreTreatment` Code, using a TNM coding edition, that classifies the size and extent of the primary tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTCategory' as TCategoryFinalPreTreatment,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	TCategoryFinalPreTreatment
from SK
where TCategoryFinalPreTreatment is not null;
=======
* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
-- Query to extract T Category (Final Pretreatment) for UR cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'UR'
  and TcategoryFinalPreTreatment is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20TCategory%20Final%20Pretreatment%20mapping){: .btn }
### COSD v8 SK Measurement Primary Pathway Metastatic Site
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `4272032`. Prostate specific antigen measurement

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Measurement Primary Pathway Metastatic Site
>>>>>>> main
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
<<<<<<< HEAD
with SK as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        unnest(
            [
                [ Record ->> '$.Skin.SkinCore.SkinCoreDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.Skin.SkinCore.SkinCoreDiagnosis.MetastaticSite[*].@code'
=======
-- Query to extract Metastatic Site (Primary Pathway/Diagnosis) for UR cancer area from COSD v8.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        unnest(
            [
                [ Record ->> '$.Urological.UrologicalCore.UrologicalCoreDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.Urological.UrologicalCore.UrologicalCoreDiagnosis.MetastaticSite[*].@code'
>>>>>>> main
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
<<<<<<< HEAD
    where Type = 'SK'
=======
    where type = 'UR'
>>>>>>> main
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
<<<<<<< HEAD
from SK
=======
from ur
>>>>>>> main
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 SK Measurement Non Primary Pathway Metastatic Site
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UR Measurement Non Primary Pathway Metastatic Site
>>>>>>> main
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
<<<<<<< HEAD
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
		Record ->> '$.Skin.SkinCore.SkinCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' as MetastaticSite
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
	MetastaticSite
from SK
=======
-- Query to extract Metastatic Site (Non-Primary Pathway) for UR cancer area from COSD v8.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.Urological.UrologicalCore.UrologicalCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' ],
                Record ->> '$.Urological.UrologicalCore.UrologicalCoreNonPrimaryCancerPathwayRoute.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from ur
>>>>>>> main
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 SK Measurement NCategory Integrated Stage
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UR Measurement Ncategory Integrated Stage
>>>>>>> main
Source column  `NcategoryIntegratedStage`.
Lookup NCategory concepts.


|NcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `NcategoryIntegratedStage` Code, using a TNM coding edition, that classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NCategoryIntegratedStage
from SK
where NCategoryIntegratedStage is not null;
=======
* `NcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
-- Query to extract N Category (Integrated Stage) for UR cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- NcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageNCategory' as NcategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'UR'
  and NcategoryIntegratedStage is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20NCategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 SK Measurement NCategory Final Pretreatment
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Ncategory Final Pre Treatment Stage
>>>>>>> main
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `NcategoryFinalPreTreatment` Code, using a TNM coding edition, that classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentNCategory' as NCategoryFinalPreTreatment,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NCategoryFinalPreTreatment
from SK
where NCategoryFinalPreTreatment is not null;
=======
* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
-- Query to extract N Category (Final Pretreatment) for UR cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- NcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'UR'
  and NcategoryFinalPreTreatment is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20NCategory%20Final%20Pretreatment%20mapping){: .btn }
### COSD v8 SK Measurement MCategory Integrated Stage
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Mcategory Integrated Stage
>>>>>>> main
Source column  `McategoryIntegratedStage`.
Lookup  concepts.


|McategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `McategoryIntegratedStage` Code, using a TNM coding edition, that classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	MCategoryIntegratedStage
from SK
where MCategoryIntegratedStage is not null;
=======
* `McategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
-- Query to extract M Category (Integrated Stage) for UR cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases after treatment.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- McategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.IntegratedStageMCategory' as McategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'UR'
  and McategoryIntegratedStage is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20MCategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 SK Measurement MCategory Final Pretreatment
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Mcategory Final Pre Treatment Stage
>>>>>>> main
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

<<<<<<< HEAD
* `McategoryFinalPreTreatment` Code, using a TNM coding edition, that classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentMCategory' as MCategoryFinalPreTreatment,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	MCategoryFinalPreTreatment
from SK
where MCategoryFinalPreTreatment is not null;
=======
* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
-- Query to extract M Category (Final Pretreatment) for UR cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- McategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'UR'
  and McategoryFinalPreTreatment is not null;
>>>>>>> main
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20MCategory%20Final%20Pretreatment%20mapping){: .btn }
### COSD v8 SK Measurement Grade Of Differentiation
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Grade Of Differentiation
>>>>>>> main
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
<<<<<<< HEAD
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
		Record ->> '$.Skin.SkinCore.SkinCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select distinct
	NhsNumber,
	coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
	GradeOfDifferentiationAtDiagnosis
from SK
=======
-- Query to extract Grade of Differentiation (at Diagnosis) for UR cancer area from COSD v8.
-- The grade classifies the differentiation of the tumour at the time of diagnosis.
-- MeasurementDate uses diagnosis date, falling back to non-primary diagnosis date.
-- GradeOfDifferentiation will be mapped to a measurement value concept in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis',
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_81
where type = 'UR'
  and GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 UG Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from UG
where TumourLaterality is not null
  and TumourLaterality in ('L', 'R', 'M', 'B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 UG Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        unnest(
            [
                [ Record ->> '$.UpperGI.UpperGICore.UpperGICoreDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.UpperGI.UpperGICore.UpperGICoreDiagnosis.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from ug
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UG Measurement Non Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' as MetastaticSite
from omop_staging.cosd_staging_81
where type = 'UG'
  and MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UG Measurement Integrated Stage TNM Stage Grouping
Source column  `IntegratedStageTNMStageGrouping`.
Lookup TNMCategory concepts.


|IntegratedStageTNMStageGrouping|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `IntegratedStageTNMStageGrouping` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGrouping' as IntegratedStageTNMStageGrouping
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    IntegratedStageTNMStageGrouping
from UG
where IntegratedStageTNMStageGrouping is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Integrated%20Stage%20TNM%20Stage%20Grouping%20mapping){: .btn }
### COSD V8 UG Measurement Integrated Stage T Category
Source column  `IntegratedStageTCategory`.
Lookup TCategory concepts.


|IntegratedStageTCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `IntegratedStageTCategory` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTCategory' as IntegratedStageTCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    IntegratedStageTCategory
from UG
where IntegratedStageTCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Integrated%20Stage%20T%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Integrated Stage N Category
Source column  `IntegratedStageNCategory`.
Lookup NCategory concepts.


|IntegratedStageNCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `IntegratedStageNCategory` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageNCategory' as IntegratedStageNCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    IntegratedStageNCategory
from UG
where IntegratedStageNCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Integrated%20Stage%20N%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Integrated Stage M Category
Source column  `IntegratedStageMCategory`.
Lookup  concepts.


|IntegratedStageMCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `IntegratedStageMCategory` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageMCategory' as IntegratedStageMCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    IntegratedStageMCategory
from UG
where IntegratedStageMCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Integrated%20Stage%20M%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from UG
>>>>>>> main
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


<<<<<<< HEAD
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD v8 SK Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20SK%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
=======
[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 UG Measurement Final Pretreatment TNM Stage Grouping
Source column  `FinalPreTreatmentTNMStageGrouping`.
Lookup TNMCategory concepts.


|FinalPreTreatmentTNMStageGrouping|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `FinalPreTreatmentTNMStageGrouping` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGrouping' as FinalPreTreatmentTNMStageGrouping
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    FinalPreTreatmentTNMStageGrouping
from UG
where FinalPreTreatmentTNMStageGrouping is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Final%20Pretreatment%20TNM%20Stage%20Grouping%20mapping){: .btn }
### COSD V8 UG Measurement Final Pretreatment T Category
Source column  `FinalPreTreatmentTCategory`.
Lookup TCategory concepts.


|FinalPreTreatmentTCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `FinalPreTreatmentTCategory` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTCategory' as FinalPreTreatmentTCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    FinalPreTreatmentTCategory
from UG
where FinalPreTreatmentTCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Final%20Pretreatment%20T%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Final Pretreatment N Category
Source column  `FinalPreTreatmentNCategory`.
Lookup NCategory concepts.


|FinalPreTreatmentNCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `FinalPreTreatmentNCategory` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentNCategory' as FinalPreTreatmentNCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    FinalPreTreatmentNCategory
from UG
where FinalPreTreatmentNCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Final%20Pretreatment%20N%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Final Pretreatment M Category
Source column  `FinalPreTreatmentMCategory`.
Lookup  concepts.


|FinalPreTreatmentMCategory|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `FinalPreTreatmentMCategory` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentMCategory' as FinalPreTreatmentMCategory
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    FinalPreTreatmentMCategory
from UG
where FinalPreTreatmentMCategory is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Final%20Pretreatment%20M%20Category%20mapping){: .btn }
### COSD V8 UG Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20UG%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 LV Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_901
where type = 'LV'
  and TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 LV Measurement TNM Stage Grouping Integrated
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_901
where type = 'LV'
  and TnmStageGroupingIntegrated is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V9 LV Measurement TNM Stage Grouping Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'LV'
  and TnmStageGroupingFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20TNM%20Stage%20Grouping%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Tcategory Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LV'
  and TCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LV'
  and TcategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from lv
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Non Primary Pathway Recurrence Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from lv
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Non Primary Pathway Progression Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from lv
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Ncategory Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LV'
  and NCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LV'
  and NcategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Mcategory Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as MCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LV'
  and MCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LV'
  and McategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_901
where type = 'LV'
  and GradeOfDifferentiationAtDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V9 LV Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 LV Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from lv
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD v8 LV Measurement TNM Stage Grouping Integrated
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from lv
where TnmStageGroupingIntegrated is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD v8 LV Measurement Tcategory Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from lv
where TCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreDiagnosis.MetastaticSite.@code' as MetastaticSite
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from lv
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 LV Measurement Ncategory Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NCategoryIntegratedStage
from lv
where NCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Mcategory Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    MCategoryIntegratedStage
from lv
where MCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Liver.LiverCore.LiverCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from lv
where GradeOfDifferentiationAtDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD v8 LV Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
>>>>>>> main
### COSD V9 Lung Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
select 
	distinct
	    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
	    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
	    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_901
where type = 'LU'
  and (Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code') in ('L','R','M','B')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the TNM Stage Grouping (Integrated) which provides a precise summary of the anatomical extent of cancer. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_901
where type = 'LU'
  and TnmStageGroupingIntegrated is not null
  and NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the TNM Stage Grouping (Final pre-treatment) which provides a precise summary of the anatomical extent of cancer. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'LU'
  and TnmStageGroupingFinalPretreatment is not null
  and NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour for the integrated stage during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LU'
  and TCategoryIntegratedStage is not null
  and NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LU'
  and TcategoryFinalPreTreatment is not null
  and NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS for the primary pathway. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with lung as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest ([[Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticType.@code'], Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticType.@code'], recursive := true) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select distinct
    NHSNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from lung
where MetastaticSite is not null
  and MetastaticSite != '97'
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Recurrence Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at recurrence for a non-primary cancer pathway. [METASTATIC SITE (RECURRENCE)]()

```sql
with lung as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest ([[Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code'], Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'], recursive := true) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from lung
where MetastaticSite is not null
  and MetastaticSite != '97'
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Progression Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at progression for a non-primary cancer pathway. [METASTATIC SITE (PROGRESSION)]()

```sql
with lung as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NHSNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest ([[Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code'], Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'], recursive := true) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from lung
where MetastaticSite is not null
  and MetastaticSite != '97'
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` The N category (regional lymph nodes) assigned to the tumour for the integrated stage. [N CATEGORY INTEGRATED STAGE](https://www.datadictionary.nhs.uk/data_elements/n_category_integrated_stage.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LU'
  and NCategoryIntegratedStage is not null
  and NhsNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` The N category (regional lymph nodes) assigned to the tumour at the time of the final pre-treatment stage. [N CATEGORY FINAL PRETREATMENT](https://www.datadictionary.nhs.uk/data_elements/n_category_final_pretreatment.html)

```sql
select
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LU'
  and NcategoryFinalPreTreatment is not null
  and NhsNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` The M category (distant metastasis) assigned to the tumour for the integrated stage. [M CATEGORY INTEGRATED STAGE](https://www.datadictionary.nhs.uk/data_elements/m_category_integrated_stage.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as MCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'LU'
  and MCategoryIntegratedStage is not null
  and NhsNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` The M category (distant metastasis) assigned to the tumour at the time of the final pre-treatment stage. [M CATEGORY FINAL PRETREATMENT](https://www.datadictionary.nhs.uk/data_elements/m_category_final_pretreatment.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'LU'
  and McategoryFinalPreTreatment is not null
  and NhsNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Grade of Differentiation (At Diagnosis)
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_901
where Type = 'LU'
  and GradeOfDifferentiationAtDiagnosis is not null
  and NhsNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V8 Lung Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` An indication of the side of the body on which the Primary Tumour originated. Valid values are: L (Left), R (Right), M (Midline), B (Bilateral). [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with lung as (
    select
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from lung
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B')
  and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with lung as (
    select
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from lung
where TnmStageGroupingIntegrated is not null
and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` The TNM STAGE GROUPING (FINAL PRETREATMENT) is a combination of the results of the clinical T, N and M, the T, N and M assigned on the basis of the operative findings, and the pathological T, N and M, recorded before the start of treatment, coded at the end of the CANCER CARE SPELL. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with lung as (
    select
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from lung
where TnmStageGroupingFinalPretreatment is not null
and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with lung as (
    select
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from lung
where TCategoryIntegratedStage is not null
and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with lung as (
    select
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from lung
where TcategoryFinalPreTreatment is not null
and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` A code that records the site(s) of metastatic disease at diagnosis. [METASTATIC SITE]()

```sql
with lung as (
select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    unnest(
      [
        [
          Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MetastaticSite.@code'
        ], 
        Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MetastaticSite[*].@code'
      ], recursive := true
    ) as MetastaticSite
from omop_staging.cosd_staging_81
where Type = 'LU'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from lung
where MetastaticSite is not null
  and MetastaticSite != 97
  and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement Non Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` A code that records the site(s) of metastatic disease relating to a Non-Primary Cancer Pathway. [METASTATIC SITE (NON PRIMARY CANCER PATHWAY)]()

```sql
with lung as (
    select distinct
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' ],
                Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayRoute.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'LU'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from lung
where MetastaticSite is not null
  and MetastaticSite != '97'
  and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with lung as (
	select 
		Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
		Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'LU'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NCategoryIntegratedStage
from lung
where NCategoryIntegratedStage is not null
and NhsNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement N Category (Final Pretreatment)
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with lung as (
	select 
		Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment,
		Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'LU'
)
select distinct
	NHSNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NcategoryFinalPreTreatment
from lung
where NcategoryFinalPreTreatment is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Integrated Stage)
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases using the integrated stage during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with lung as (
	select 
		Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
		Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'LU'
)
select distinct
	NHSNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	MCategoryIntegratedStage
from lung
where MCategoryIntegratedStage is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Integrated%20Stage)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Final Pretreatment)
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with lung as (
	select 
		Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment,
		Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'LU'
)
select distinct
	NHSNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	McategoryFinalPreTreatment
from lung
where McategoryFinalPreTreatment is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement Grade of Differentiation (At Diagnosis)
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with lung as (
	select 
		Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
		Record ->> '$.Lung.LungCore.LungCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
	from omop_staging.cosd_staging_81
	where Type = 'LU'
)
select distinct
	NHSNumber,
	coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
	GradeOfDifferentiationAtDiagnosis
from lung
where GradeOfDifferentiationAtDiagnosis is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V9 HN Measurement Tnm Stage Grouping Integrated
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
-- Query to extract TNM Stage Grouping (Integrated) for HN cancer area from COSD v9.
-- The TNM stage grouping classifies the combination of tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TnmStageGroupingIntegrated will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_901
where type = 'HN'
  and TnmStageGroupingIntegrated is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Tnm%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V9 HN Measurement Tnm Stage Grouping Final Pretreatment
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
-- Query to extract TNM Stage Grouping (Final Pretreatment) for HN cancer area from COSD v9.
-- The TNM stage grouping classifies the combination of tumour, node and metastases into stage groupings before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TnmStageGroupingFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'HN'
  and TnmStageGroupingFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Tnm%20Stage%20Grouping%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
-- Query to extract T Category (Integrated Stage) for HN cancer area from COSD v9.
-- The T category classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TCategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'HN'
  and TCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement T Category Final Pretreatment
Source column  `TCategoryFinalPretreatment`.
Lookup TCategory concepts.


|TCategoryFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
-- Query to extract T Category (Final Pretreatment) for HN cancer area from COSD v9.
-- The T category classifies the size and extent of the primary tumour before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TCategoryFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TCategoryFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'HN'
  and TCategoryFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20T%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site from the Primary Pathway for HN cancer area from COSD v9.
-- MetastaticSite records the site of metastatic disease at patient diagnosis, excluding code 97 (not applicable).
-- Uses unnest to flatten the array of metastatic sites into individual rows.
-- MetastaticSite will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from hn
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement Non Primary Pathway Recurrence Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site from the Non Primary Pathway (Recurrence) for HN cancer area from COSD v9.
-- MetastaticSite records the site of metastatic disease at recurrence, excluding code 97 (not applicable).
-- Uses unnest to flatten the array of metastatic sites into individual rows.
-- MetastaticSite will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from hn
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement Non Primary Pathway Progression Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site from the Non Primary Pathway (Progression) for HN cancer area from COSD v9.
-- MetastaticSite records the site of metastatic disease at progression, excluding code 97 (not applicable).
-- Uses unnest to flatten the array of metastatic sites into individual rows.
-- MetastaticSite will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from hn
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
-- Query to extract N Category (Integrated Stage) for HN cancer area from COSD v9.
-- The N category classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- NCategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'HN'
  and NCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement N Category Final Pretreatment
Source column  `NCategoryFinalPretreatment`.
Lookup NCategory concepts.


|NCategoryFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
-- Query to extract N Category (Final Pretreatment) for HN cancer area from COSD v9.
-- The N category classifies the absence or presence and extent of regional lymph node metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- NCategoryFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NCategoryFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'HN'
  and NCategoryFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20N%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
-- Query to extract M Category (Integrated Stage) for HN cancer area from COSD v9.
-- The M category classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- MCategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as MCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'HN'
  and MCategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement M Category Final Pretreatment
Source column  `MCategoryFinalPretreatment`.
Lookup  concepts.


|MCategoryFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
-- Query to extract M Category (Final Pretreatment) for HN cancer area from COSD v9.
-- The M category classifies the absence or presence of distant metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- MCategoryFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as MCategoryFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'HN'
  and MCategoryFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20M%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement Grade Of Differentiation At Diagnosis
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
-- Query to extract Grade of Differentiation (At Diagnosis) for HN cancer area from COSD v9.
-- The grade represents the definitive grade of the tumour at the time of patient diagnosis.
-- GradeOfDifferentiationAtDiagnosis will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_901
where type = 'HN'
  and GradeOfDifferentiationAtDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Grade%20Of%20Differentiation%20At%20Diagnosis%20mapping){: .btn }
### COSD V9 HN Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 HN Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
-- Query to extract Tumour Laterality for HN cancer area from COSD v8.
-- Identifies the side of the body for a tumour relating to paired organs, filtering only valid laterality codes.
-- MeasurementDate uses primary diagnosis date, falling back to non-primary diagnosis date.
-- TumourLaterality will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from hn
where TumourLaterality in ('L', 'R', 'M', 'B');
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD v8 HN Measurement TNMcategory Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
-- Query to extract TNM Stage Grouping (Integrated) for HN cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TnmStageGroupingIntegrated will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from hn
where TnmStageGroupingIntegrated is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20TNMcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement TNMcategory Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
-- Query to extract TNM Stage Grouping (Final Pretreatment) for HN cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of tumour, node and metastases into stage groupings before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TnmStageGroupingFinalPretreatment will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from hn
where TnmStageGroupingFinalPretreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20TNMcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Tcategory Integrated Stage
Source column  `TcategoryIntegratedStage`.
Lookup TCategory concepts.


|TcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
-- Query to extract T Category (Integrated Stage) for HN cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTCategory' as TcategoryIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryIntegratedStage
from hn
where TcategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
-- Query to extract T Category (Final Pretreatment) for HN cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from hn
where TcategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site from the Primary Pathway for HN cancer area from COSD v8.
-- MetastaticSite records the site of metastatic disease at patient diagnosis, excluding code 97 (not applicable).
-- MetastaticSite will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.MetastaticSite.@code' as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from hn
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 HN Measurement Non Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site from the Non Primary Pathway for HN cancer area from COSD v8.
-- MetastaticSite records the site of metastatic disease in the non-primary cancer pathway, excluding code 97 (not applicable).
-- MetastaticSite will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from hn
where MetastaticSite is not null
  and MetastaticSite != '97';
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 HN Measurement Ncategory Integrated Stage
Source column  `NcategoryIntegratedStage`.
Lookup NCategory concepts.


|NcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
-- Query to extract N Category (Integrated Stage) for HN cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- NcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageNCategory' as NcategoryIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NcategoryIntegratedStage
from hn
where NcategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
-- Query to extract N Category (Final Pretreatment) for HN cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- NcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NcategoryFinalPreTreatment
from hn
where NcategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Mcategory Integrated Stage
Source column  `McategoryIntegratedStage`.
Lookup  concepts.


|McategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
-- Query to extract M Category (Integrated Stage) for HN cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- McategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageMCategory' as McategoryIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    McategoryIntegratedStage
from hn
where McategoryIntegratedStage is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
-- Query to extract M Category (Final Pretreatment) for HN cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- McategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    McategoryFinalPreTreatment
from hn
where McategoryFinalPreTreatment is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
-- Query to extract Grade of Differentiation (At Diagnosis) for HN cancer area from COSD v8.
-- The grade represents the definitive grade of the tumour at the time of patient diagnosis.
-- MeasurementDate uses the diagnosis date, falling back to non-primary diagnosis date.
-- GradeOfDifferentiationAtDiagnosis will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from hn
where GradeOfDifferentiationAtDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20v8%20HN%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 HN Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 GY Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from gy
where TumourLaterality is not null
  and TumourLaterality in ('L', 'R', 'M', 'B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 GY Measurement TNM Stage Grouping Integrated
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from gy
where TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V8 GY Measurement TNM Stage Grouping Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from gy
where TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20TNM%20Stage%20Grouping%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Tcategory Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from gy
where TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from gy
where TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
METASTATIC SITE (AT DIAGNOSIS)


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|0|Bone (Retired 1 July 2012)|
|02|0|Brain|
|03|0|Liver|
|04|0|Lung|
|05|0|Other metastatic site (Retired 1 July 2012)|
|06|0|Multiple metastatic sites (Retired 1 April 2018)|
|07|0|Unknown metastatic site|
|08|0|Skin|
|09|0|Distant Lymph Nodes|
|10|0|Bone (excluding Bone Marrow)|
|11|0|Bone marrow|
|12|0|Regional Lymph Nodes|
|98|0|Other metastatic site (not listed)|
|99|0|Other metastatic site (Retired 1 April 2018)|
|97|0|Not Applicable (Disease not spread)|


* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.MetastaticSite.@code' as MetastaticSite
from omop_staging.cosd_staging_81
where type = 'GY'
  and MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 GY Measurement Non Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
METASTATIC SITE (AT DIAGNOSIS)


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|0|Bone (Retired 1 July 2012)|
|02|0|Brain|
|03|0|Liver|
|04|0|Lung|
|05|0|Other metastatic site (Retired 1 July 2012)|
|06|0|Multiple metastatic sites (Retired 1 April 2018)|
|07|0|Unknown metastatic site|
|08|0|Skin|
|09|0|Distant Lymph Nodes|
|10|0|Bone (excluding Bone Marrow)|
|11|0|Bone marrow|
|12|0|Regional Lymph Nodes|
|98|0|Other metastatic site (not listed)|
|99|0|Other metastatic site (Retired 1 April 2018)|
|97|0|Not Applicable (Disease not spread)|


* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' as MetastaticSite
from omop_staging.cosd_staging_81
where type = 'GY'
  and MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 GY Measurement Ncategory Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NCategoryIntegratedStage
from gy
where NCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NcategoryFinalPreTreatment
from gy
where NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Mcategory Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    MCategoryIntegratedStage
from gy
where MCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    McategoryFinalPreTreatment
from gy
where McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 GY Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
GRADE OF DIFFERENTIATION (AT DIAGNOSIS)


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|G1|0|Well differentiated|
|G2|0|Moderately differentiated|
|G3|0|Poorly differentiated|
|G4|0|Undifferentiated / anaplastic|
|GX|0|Grade of differentiation is not appropriate or cannot be assessed|


* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from gy
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 GY Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20GY%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 CT Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
-- Query to extract Tumour Laterality for CT (CTYA) cancer area from COSD v8.
-- TumourLaterality is a categorical code (L, R, M, B) identifying the side of the body for the tumour.
-- MeasurementDate uses primary diagnosis date, falling back to non-primary diagnosis date.
-- TumourLaterality will be mapped to a measurement value concept in OMOP in a later step.
-- Only valid laterality codes (L, R, M, B) are included; codes 8 (Not Applicable) and 9 (Not Known) are excluded.
with CT as (
    select
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from CT
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 CT Measurement TNM Stage Grouping Integrated
Source column  `TNMStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TNMStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TNMStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
-- Query to extract TNM Stage Grouping (Integrated) for CT (CTYA) cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of T, N, and M categories into stage groupings after treatment and/or after all available evidence.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TNMStageGroupingIntegrated will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGrouping' as TNMStageGroupingIntegrated
from omop_staging.cosd_staging_81
where type = 'CT'
  and TNMStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V8 CT Measurement TNM Stage Grouping Final Pre Treatment Stage
Source column  `TNMStageGroupingFinalPreTreatment`.
Lookup TNMCategory concepts.


|TNMStageGroupingFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TNMStageGroupingFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
-- Query to extract TNM Stage Grouping (Final Pretreatment) for CT (CTYA) cancer area from COSD v8.
-- The TNM stage grouping classifies the combination of T, N, and M categories into stage groupings before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TNMStageGroupingFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGrouping' as TNMStageGroupingFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'CT'
  and TNMStageGroupingFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20TNM%20Stage%20Grouping%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Tcategory Integrated Stage
Source column  `TcategoryIntegratedStage`.
Lookup TCategory concepts.


|TcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
-- Query to extract T Category (Integrated Stage) for CT (CTYA) cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour after treatment and/or after all available evidence.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- TcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTCategory' as TcategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'CT'
  and TcategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
-- Query to extract T Category (Final Pretreatment) for CT (CTYA) cancer area from COSD v8.
-- The T category classifies the size and extent of the primary tumour before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- TcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'CT'
  and TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Primary Pathway Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
-- Query to extract Metastatic Site (Primary Pathway/Diagnosis) for CT (CTYA) cancer area from COSD v8.
-- MetastaticSite is a repeating field so unnest is used to normalise each site into its own row.
-- Code 97 (Not Applicable - Disease not spread) is excluded.
-- MetastaticSite will be mapped to a measurement value concept in OMOP in a later step.
with CT as (
    select distinct
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        unnest(
            [
                [ Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from CT
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 CT Measurement Ncategory Integrated Stage
Source column  `NcategoryIntegratedStage`.
Lookup NCategory concepts.


|NcategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
-- Query to extract N Category (Integrated Stage) for CT (CTYA) cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases after treatment and/or after all available evidence.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- NcategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageNCategory' as NcategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'CT'
  and NcategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
-- Query to extract N Category (Final Pretreatment) for CT (CTYA) cancer area from COSD v8.
-- The N category classifies the absence or presence and extent of regional lymph node metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- NcategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'CT'
  and NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Mcategory Integrated Stage
Source column  `McategoryIntegratedStage`.
Lookup  concepts.


|McategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
-- Query to extract M Category (Integrated Stage) for CT (CTYA) cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases after treatment and/or after all available evidence.
-- MeasurementDate falls back to diagnosis date if the integrated staging date is unavailable.
-- McategoryIntegratedStage will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageMCategory' as McategoryIntegratedStage
from omop_staging.cosd_staging_81
where type = 'CT'
  and McategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
-- Query to extract M Category (Final Pretreatment) for CT (CTYA) cancer area from COSD v8.
-- The M category classifies the absence or presence of distant metastases before treatment.
-- MeasurementDate falls back to diagnosis date if the staging date is unavailable.
-- McategoryFinalPreTreatment will be mapped to a measurement concept in OMOP in a later step.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGroupingDate',
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
    ) as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_81
where type = 'CT'
  and McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Peak At Diagnosis
* Constant value set to `4012918`. Lactate dehydrogenase measurement

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Peak%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Normal Upper Limit
* Constant value set to `4012918`. Lactate dehydrogenase measurement

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Normal%20Upper%20Limit%20mapping){: .btn }
### COSD V8 CT Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
-- Query to extract Grade of Differentiation (At Diagnosis) for CT (CTYA) cancer area from COSD v8.
-- GradeOfDifferentiation is a categorical code (G1-G4, GX) describing tumour differentiation.
-- MeasurementDate uses primary diagnosis date, falling back to non-primary diagnosis date.
-- GradeOfDifferentiation will be mapped to a measurement value concept in OMOP in a later step.
with CT as (
    select
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from CT
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 CT Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CT%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 CR Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from cr
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 CR Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from cr
where TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from cr
where TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Tcategory Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from cr
where TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Tcategory Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from cr
where TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        unnest(
            [
                [Record ->> '$.Core.CoreCore.CoreDiagnosis.MetastaticSite.@code'],
                Record ->> '$.Core.CoreCore.CoreDiagnosis.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from cr
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 CR Measurement Non Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.Core.CoreCore.CoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' as MetastaticSite
from omop_staging.cosd_staging_81
where type = 'CR'
  and MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 CR Measurement Ncategory Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NCategoryIntegratedStage
from cr
where NCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Ncategory Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NcategoryFinalPreTreatment
from cr
where NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Mcategory Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
        Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    MCategoryIntegratedStage
from cr
where MCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Mcategory Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment,
        Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    McategoryFinalPreTreatment
from cr
where McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Core.CoreCore.CoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from cr
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 CR Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20CR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
select 
	distinct
	    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
	    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
	    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_901
where type = 'CO'
  and (Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code') in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
from omop_staging.cosd_staging_901
where type = 'CO'
  and TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
from omop_staging.cosd_staging_901
where type = 'CO'
  and TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'CO'
  and TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'CO'
  and TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Synchronous Tumour Indicator
Source column  `SynchronousTumourIndicator`.
Lookup SynchronousTumour concepts.


|SynchronousTumourIndicator|measurement_concept_id|notes|
|------|-----|-----|
|01|36768217|Cecum|
|02|36770601|Appendix|
|03|36768852|Ascending Colon|
|04|36768109|Hepatic Flexure|
|05|36770627|Transverse Colon|
|06|36769645|Splenic Flexure|
|07|36769819|Descending Colon|
|08|36770395|Sigmoid Colon|
|09|36768690|Rectosigmoid|
|10|36769244|Rectum|

Notes
* [OMOP Cancer Modifier Measurements](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&standardConcept=Standard&page=1&pageSize=500&query=&boosts)
* [NHS - Synchronous Tumour Colon location (at Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/synchronous_tumour_colon_location__at_diagnosis_.html?hl=synchronous%2Ctumour%2Ccolon%2Clocation%2Cdiagnosis)

* `SynchronousTumourIndicator` An indication of whether there is a presence of synchronous tumours at a tumour site during a Cancer Care Spell. [SYNCHRONOUS TUMOUR INDICATOR](https://www.datadictionary.nhs.uk/data_elements/synchronous_tumour_indicator.html)

```sql
select 
	distinct
	    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
	    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
	    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisColorectal.SynchronousTumourIndicator.@code' as SynchronousTumourIndicator
from omop_staging.cosd_staging_901
where type = 'CO'
  and SynchronousTumourIndicator is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V9 Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with CO as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from CO
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Recurrence Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with CO as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from CO
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Progression Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with CO as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select
    distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from CO
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NCategoryIntegratedStage
from omop_staging.cosd_staging_901
where type = 'CO'
  and NCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement N Category Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NcategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'CO'
  and NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as MCategoryIntegratedStage
from omop_staging.cosd_staging_901
where Type = 'CO'
  and MCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
select 
  distinct
    record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
        record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
    ) as MeasurementDate,
    record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as McategoryFinalPreTreatment
from omop_staging.cosd_staging_901
where type = 'CO'
  and McategoryFinalPreTreatment is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Grade of Differentiation (At Diagnosis)
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis,
from omop_staging.cosd_staging_901
where Type = 'CO'
  and GradeOfDifferentiationAtDiagnosis is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV9MeasurementAdultComorbidityEvaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20CosdV9MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from co
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Measurement Tumour Height Above Anal Verge
* Constant value set to `3029142`. `Distance from anal verge`

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Tumour%20Height%20Above%20Anal%20Verge%20mapping){: .btn }
### COSD V8 Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [TNM STAGE GROUPING (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__integrated_.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGrouping' as TnmStageGroupingIntegrated,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingIntegrated
from co
where TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from co
where TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from co
where TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the size and extent of the primary Tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from co
where TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Synchronous Tumour Indicator
Source column  `SynchronousTumourIndicator`.
Lookup SynchronousTumour concepts.


|SynchronousTumourIndicator|measurement_concept_id|notes|
|------|-----|-----|
|01|36768217|Cecum|
|02|36770601|Appendix|
|03|36768852|Ascending Colon|
|04|36768109|Hepatic Flexure|
|05|36770627|Transverse Colon|
|06|36769645|Splenic Flexure|
|07|36769819|Descending Colon|
|08|36770395|Sigmoid Colon|
|09|36768690|Rectosigmoid|
|10|36769244|Rectum|

Notes
* [OMOP Cancer Modifier Measurements](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&standardConcept=Standard&page=1&pageSize=500&query=&boosts)
* [NHS - Synchronous Tumour Colon location (at Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/synchronous_tumour_colon_location__at_diagnosis_.html?hl=synchronous%2Ctumour%2Ccolon%2Clocation%2Cdiagnosis)

* `SynchronousTumourIndicator` An indication of whether there is a presence of synchronous tumours at a tumour site during a Cancer Care Spell. [SYNCHRONOUS TUMOUR INDICATOR](https://www.datadictionary.nhs.uk/data_elements/synchronous_tumour_indicator.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.ColorectalDiagnosis.SynchronousTumourColonLocation.@code' as SynchronousTumourIndicator
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    SynchronousTumourIndicator
from co
where SynchronousTumourIndicator is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V8 Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with co as (
select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    unnest(
      [
        [
          Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MetastaticSite.@code'
        ], 
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MetastaticSite[*].@code'
      ], recursive := true
    ) as MetastaticSite
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from co
where MetastaticSite is not null
  and MetastaticSite != 97;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement Non Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with co as (
    select distinct
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' ],
                Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreNonPrimaryCancerPathwayRoute.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'CO'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from co
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NCategoryIntegratedStage
from CO
where NCategoryIntegratedStage is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement N Category Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence and extent of regional Lymph Node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	NcategoryFinalPreTreatment
from CO
where NcategoryFinalPreTreatment is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select distinct
	NhsNumber,
	coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	MCategoryIntegratedStage
from CO
where MCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select distinct
	NhsNumber,
	coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
	McategoryFinalPreTreatment
from CO
where McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Grade of Differentiation (At Diagnosis)
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select distinct
	NhsNumber,
	coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
	GradeOfDifferentiationAtDiagnosis
from CO
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV8MeasurementAdultComorbidityEvaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20CosdV8MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V9 Breast Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` The laterality (side) of the tumour - Left (L), Right (R), Midline (M), or Bilateral (B). [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
select 
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
from omop_staging.cosd_staging_901
where type = 'BR'
  and (Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.TumourLaterality.@code') in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Integrated Stage
Source column  `TnmStageGroupingIntegrated`.
Lookup TNMCategory concepts.


|TnmStageGroupingIntegrated|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingIntegrated` The TNM stage grouping (combined T, N, M categories) of the integrated stage. [TNM STAGE GROUPING (INTEGRATED STAGE)]()

```sql
with BR as (
    select 
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingIntegrated' as TnmStageGroupingIntegrated
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    TnmStageGroupingIntegrated
from BR
where TnmStageGroupingIntegrated is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Final Pre-Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` The TNM stage grouping (combined T, N, M categories) of the final pre-treatment stage. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with BR as (
    select 
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.TnmStageGroupingFinalPretreatment' as TnmStageGroupingFinalPretreatment
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    TnmStageGroupingFinalPretreatment
from BR
where TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` The T category (tumour size) of the integrated stage in TNM staging. [T CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/t_category__integrated_stage_.html)

```sql
with BR as (
    select 
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.TCategoryIntegratedStage' as TCategoryIntegratedStage
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    TCategoryIntegratedStage
from BR
where TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Final Pre-Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` The T category (tumour size) of the final pre-treatment stage in TNM staging. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with BR as (
    select 
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.TCategoryFinalPretreatment' as TcategoryFinalPreTreatment
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    TcategoryFinalPreTreatment
from BR
where TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis.MetastaticSite.@code' ],
                Record ->> '$.PrimaryPathway.Diagnosis.MetastaticTypeAndSiteDiagnosis[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    MetastaticSite
from BR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Recurrence Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at recurrence diagnosis [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Recurrence.MetastaticTypeAndSiteRecurrence[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from BR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Progression Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at progression diagnosis [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression.MetastaticSite.@code' ],
                Record ->> '$.NonPrimaryPathway.Progression.MetastaticTypeAndSiteProgression[*].MetastaticSite.@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from BR
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of regional lymph node metastasis after all information from treatment is available during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.NCategoryIntegratedStage' as NCategoryIntegratedStage
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    NCategoryIntegratedStage
from BR
where NCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Final Pre-Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of regional lymph node metastasis before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRE-TREATMENT STAGE)]()

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.NCategoryFinalPretreatment' as NcategoryFinalPreTreatment
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    NcategoryFinalPreTreatment
from BR
where NcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after treatment and/or after all available evidence has been collected during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with BR as (
    select 
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage',
            Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        Record ->> '$.PrimaryPathway.Staging.MCategoryIntegratedStage' as MCategoryIntegratedStage
    from omop_staging.cosd_staging_901
    where Type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    MCategoryIntegratedStage
from BR
where MCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Final Pre-Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRE-TREATMENT STAGE)]()

```sql
with BR as (
    select 
        record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(
            record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage',
            record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        ) as MeasurementDate,
        record ->> '$.PrimaryPathway.Staging.MCategoryFinalPretreatment' as McategoryFinalPreTreatment
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    MeasurementDate,
    McategoryFinalPreTreatment
from BR
where McategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Grade of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The grade of differentiation of the cancer at diagnosis, indicating how much the cancer cells differ from normal cells. [GRADE OF DIFFERENTIATION AT DIAGNOSIS](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation_at_diagnosis.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_901
    where Type = 'BR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    GradeOfDifferentiationAtDiagnosis
from BR
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Grade%20of%20Differentiation%20mapping){: .btn }
### CosdV9BreastMeasurementAdultComorbidityEvaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20CosdV9BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Breast Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` The laterality of the tumour in relation to the midline of the body (Left, Right, Midline, Bilateral). [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with br as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from br
where TumourLaterality is not null
  and TumourLaterality in ('L','R','M','B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Breast Measurement TNM Category Final Pre Treatment Stage
Source column  `TnmStageGroupingFinalPretreatment`.
Lookup TNMCategory concepts.


|TnmStageGroupingFinalPretreatment|measurement_concept_id|notes|
|------|-----|-----|
|1|1635812|IRS-modified TNM stage 1|
|I|1635812|IRS-modified TNM stage 1|
|1a|1635812|IRS-modified TNM stage 1|
|IA|1635812|IRS-modified TNM stage 1|
|1a1|1633843|Stage 1A1|
|IA1|1633843|Stage 1A1|
|1a2|1634275|Stage 1A2|
|IA2|1634275|Stage 1A2|
|1a3|1633775|Stage 1A3|
|IA3|1633775|Stage 1A3|
|1b|1635812|IRS-modified TNM stage 1|
|IB|1635812|IRS-modified TNM stage 1|
|2|1635007|IRS-modified TNM stage 2|
|II|1635007|IRS-modified TNM stage 2|
|2a|1635007|IRS-modified TNM stage 2|
|IIA|1635007|IRS-modified TNM stage 2|
|2b|1635007|IRS-modified TNM stage 2|
|IIB|1635007|IRS-modified TNM stage 2|
|2c|1635007|IRS-modified TNM stage 2|
|IIC|1635007|IRS-modified TNM stage 2|
|3|1633995|IRS-modified TNM stage 3|
|III|1633995|IRS-modified TNM stage 3|
|3a|1633995|IRS-modified TNM stage 3|
|IIIA|1633995|IRS-modified TNM stage 3|
|3b|1633995|IRS-modified TNM stage 3|
|IIIB|1633995|IRS-modified TNM stage 3|
|3c|1633995|IRS-modified TNM stage 3|
|IIIC|1633995|IRS-modified TNM stage 3|
|4|1634737|IRS-modified TNM stage 4|
|IV|1634737|IRS-modified TNM stage 4|
|4a|1634737|IRS-modified TNM stage 4|
|IVA|1634737|IRS-modified TNM stage 4|
|4b|1634737|IRS-modified TNM stage 4|
|IVB|1634737|IRS-modified TNM stage 4|
|4c|1634737|IRS-modified TNM stage 4|
|IVC|1634737|IRS-modified TNM stage 4|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TnmStageGroupingFinalPretreatment` Is the code, using a TNM CODING EDITION, which classifies the combination of Tumour, node and metastases into stage groupings before treatment during a Cancer Care Spell. [TNM STAGE GROUPING (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping__final_pretreatment_.html)

```sql
with br as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGrouping' as TnmStageGroupingFinalPretreatment,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TnmStageGroupingFinalPretreatment
from br
where TnmStageGroupingFinalPretreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Integrated Stage
Source column  `TCategoryIntegratedStage`.
Lookup TCategory concepts.


|TCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the extent of the primary tumour at a given point in a Cancer Care Spell. [T CATEGORY (INTEGRATED)]()

```sql
with br as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTCategory' as TCategoryIntegratedStage,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NhsNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TCategoryIntegratedStage
from br
where TCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Final Pre Treatment Stage
Source column  `TcategoryFinalPreTreatment`.
Lookup TCategory concepts.


|TcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1634213|AJCC/UICC T0 Category|
|1|1635564|AJCC/UICC T1 Category|
|1a|1633880|AJCC/UICC T1a Category|
|1b|1633921|AJCC/UICC T1b Category|
|1c|1633529|AJCC/UICC T1c Category|
|1d|1634100|AJCC/UICC T1d Category|
|2|1635562|AJCC/UICC T2 Category|
|2a|1635327|AJCC/UICC T2a Category|
|2b|1633593|AJCC/UICC T2b Category|
|2c|1635270|AJCC/UICC T2c Category|
|2d|1633678|AJCC/UICC T2d Category|
|3|1634376|AJCC/UICC T3 Category|
|3a|1633771|AJCC/UICC T3a Category|
|3b|1634980|AJCC/UICC T3b Category|
|3c|1633360|AJCC/UICC T3c Category|
|3d|1635625|AJCC/UICC T3d Category|
|3e|1634730|AJCC/UICC T3e Category|
|4|1634654|AJCC/UICC T4 Category|
|4a|1635222|AJCC/UICC T4a Category|
|4b|1634436|AJCC/UICC T4b Category|
|4c|1635526|AJCC/UICC T4c Category|
|4d|1633909|AJCC/UICC T4d Category|
|4e|1634193|AJCC/UICC T4e Category|
|X|1635682|AJCC/UICC TX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `TcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the extent of the primary tumour before treatment during a Cancer Care Spell. [T CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/t_category__final_pretreatment_.html)

```sql
with br as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTCategory' as TcategoryFinalPreTreatment,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NhsNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    TcategoryFinalPreTreatment
from br
where TcategoryFinalPreTreatment is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` The site of metastatic cancer on the Primary Cancer Pathway. [METASTATIC SITE]()

```sql
with br as (
select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    unnest(
      [
        [
          Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MetastaticSite.@code'
        ], 
        Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MetastaticSite[*].@code'
      ], recursive := true
    ) as MetastaticSite
from omop_staging.cosd_staging_81
where Type = 'BR'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from br
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement Non Primary Pathway Metastasis
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` The site of metastatic cancer on the Non-Primary Cancer Pathway. [METASTATIC SITE]()

```sql
with br as (
    select distinct
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        unnest(
            [
                [ Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.MetastaticSite.@code' ],
                Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.MetastaticSite[*].@code'
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    MetastaticSite
from br
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Integrated Stage
Source column  `NCategoryIntegratedStage`.
Lookup NCategory concepts.


|NCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the presence or absence of regional lymph node metastases after all information from treatment is available during a Cancer Care Spell. [N CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/n_category__integrated_stage_.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageNCategory' as NCategoryIntegratedStage,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NHSNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NCategoryIntegratedStage
from BR
where NCategoryIntegratedStage is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Final Pre Treatment Stage
Source column  `NcategoryFinalPreTreatment`.
Lookup NCategory concepts.


|NcategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1633440|AJCC/UICC N0 Category|
|0a|1633621|AJCC/UICC N0a Category|
|0b|1635244|AJCC/UICC N0b Category|
|1|1634434|AJCC/UICC N1 Category|
|1a|1633735|AJCC/UICC N1a Category|
|1b|1635130|AJCC/UICC N1b Category|
|1c|1634620|AJCC/UICC N1c Category|
|2|1634119|AJCC/UICC N2 Category|
|2a|1635644|AJCC/UICC N2a Category|
|2b|1634134|AJCC/UICC N2b Category|
|2c|1634080|AJCC/UICC N2c Category|
|3|1635320|AJCC/UICC N3 Category|
|3a|1635590|AJCC/UICC N3a Category|
|3b|1633422|AJCC/UICC N3b Category|
|3c|1634735|AJCC/UICC N3c Category|
|4|1635445|AJCC/UICC N4 Category|
|X|1633885|AJCC/UICC NX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `NcategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the presence or absence of regional lymph node metastases before treatment during a Cancer Care Spell. [N CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/n_category__final_pretreatment_.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentNCategory' as NcategoryFinalPreTreatment,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NHSNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    NcategoryFinalPreTreatment
from BR
where NcategoryFinalPreTreatment is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Integrated Stage
Source column  `MCategoryIntegratedStage`.
Lookup  concepts.


|MCategoryIntegratedStage|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `MCategoryIntegratedStage` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases after all information from treatment is available during a Cancer Care Spell. [M CATEGORY (INTEGRATED STAGE)](https://www.datadictionary.nhs.uk/data_elements/m_category__integrated_stage_.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageMCategory' as MCategoryIntegratedStage,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as StageDateIntegratedStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NHSNumber,
    coalesce(StageDateIntegratedStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    MCategoryIntegratedStage
from BR
where MCategoryIntegratedStage is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Final Pre Treatment Stage
Source column  `McategoryFinalPreTreatment`.
Lookup  concepts.


|McategoryFinalPreTreatment|measurement_concept_id|notes|
|------|-----|-----|
|0|1635624|AJCC/UICC M0 Category|
|1|1635142|AJCC/UICC M1 Category|
|1a|1635100|AJCC/UICC M1a Category|
|1b|1634463|AJCC/UICC M1b Category|
|1c|1635519|AJCC/UICC M1c Category|
|1d|1634064|AJCC/UICC M1d Category|
|X  |1633547|AJCC/UICC MX Category|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=tnm&boosts)

* `McategoryFinalPreTreatment` Is the code, using a TNM CODING EDITION, which classifies the absence or presence of distant metastases before treatment during a Cancer Care Spell. [M CATEGORY (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/m_category__final_pretreatment_.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentMCategory' as McategoryFinalPreTreatment,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as StageDateFinalPretreatmentStage
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NHSNumber,
    coalesce(StageDateFinalPretreatmentStage, ClinicalDateCancerDiagnosis) as MeasurementDate,
    McategoryFinalPreTreatment
from BR
where McategoryFinalPreTreatment is not null
and NHSNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Grade of Differentiation (At Diagnosis)
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` The definitive grade of the Tumour at the time of PATIENT DIAGNOSIS. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select distinct
    NHSNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from BR
where GradeOfDifferentiationAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV8BreastMeasurementAdultComorbidityEvaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20CosdV8BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 BA Measurement Tumour Laterality
Source column  `TumourLaterality`.
Lookup TumourLaterality concepts.


|TumourLaterality|measurement_concept_id|notes|
|------|-----|-----|
|L|36770232|Left|
|R|36770058|Right|
|M|36769853|Midline|
|B|36770109|Bilateral|

Notes
* [OMOP Laterality](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Topography&page=1&pageSize=500&query=&boosts)
* [NHS - Tumour Laterality](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html?hl=tumour%2Claterality)

* `TumourLaterality` Identifies the side of the body for a Tumour relating to paired organs within a PATIENT. [TUMOUR LATERALITY](https://www.datadictionary.nhs.uk/data_elements/tumour_laterality.html)

```sql
with BA as (
    select
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.TumourLaterality.@code' as TumourLaterality
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    TumourLaterality
from BA
where TumourLaterality is not null
  and TumourLaterality in ('L', 'R', 'M', 'B');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20BA%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 BA Measurement Metastatic Site
Source column  `MetastaticSite`.
Lookup MetastasisSite concepts.


|MetastaticSite|measurement_concept_id|notes|
|------|-----|-----|
|01|36769301|Metastasis to bone|
|02|36768862|Metastasis to brain|
|03|36770544|Metastasis to liver|
|04|36770283|Metastasis to lung|
|07|36769180|Metastasis to the Unknown Site|
|08|35225673|Metastasis to skin|
|09|36769243|Distant spread to lymph node|
|10|36769301|Metastasis to bone|
|11|35226074|Metastasis to bone marrow|
|12|36769269|Regional spread to lymph node|
|98|36769180|Metastasis|
|99|36769180|Metastasis|

Notes
* [OMOP Metastasis](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&page=1&pageSize=500&query=metastasis&boosts)
* [NHS - Metastasis](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html?hl=metastatic%2Csite%2Cdiagnosis)

* `MetastaticSite` Is the site of the metastatic disease at PATIENT DIAGNOSIS. [METASTATIC SITE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/metastatic_site__at_diagnosis_.html)

```sql
select distinct
    Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    Record ->> '$.CNS.CNSCore.CNSCoreDiagnosis.MetastaticSite.@code' as MetastaticSite
from omop_staging.cosd_staging_81
where type = 'BA'
  and MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20BA%20Measurement%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 BA Measurement Grade Of Differentiation
Source column  `GradeOfDifferentiationAtDiagnosis`.
Lookup GradeDifferentiation concepts.


|GradeOfDifferentiationAtDiagnosis|measurement_concept_id|notes|
|------|-----|-----|
|GX|0|GX grade|
|G1|36768162|Grade 1: Well differentiated|
|G2|36770626|Grade 2: Moderately differentiated|
|G3|36769666|Grade 3: Poorly differentiated|
|G4|36769737|Grade 4: Undifferentiated|

Notes
* [OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)
* [NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)

* `GradeOfDifferentiationAtDiagnosis` Definitive grade of the tumour at the time of patient diagnosis during a cancer care spell. [GRADE OF DIFFERENTIATION (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html)

```sql
with BA as (
    select
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CNS.CNSCore.CNSCoreDiagnosis.DiagnosisGradeOfDifferentiation.@code' as GradeOfDifferentiationAtDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NhsNumber,
    coalesce(ClinicalDateCancerDiagnosis, DateOfNonPrimaryCancerDiagnosisClinicallyAgreed) as MeasurementDate,
    GradeOfDifferentiationAtDiagnosis
from BA
where GradeOfDifferentiationAtDiagnosis is not null
  and GradeOfDifferentiationAtDiagnosis != ''
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20BA%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 BA Measurement Adult Comorbidity Evaluation
* Constant value set to `40488785`. Adult comorbidity evaluation-27

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_concept_id%20field%20COSD%20V8%20BA%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
