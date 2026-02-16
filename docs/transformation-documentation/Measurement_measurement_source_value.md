---
layout: default
title: measurement_source_value
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# measurement_source_value
### Sus OP  Measurement
* Value copied from `DiagnosisICD`

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        op.GeneratedRecordIdentifier,
        op.NHSNumber,
        op.CDSActivityDate
from omop_staging.sus_OP_ICDDiagnosis d
    inner join omop_staging.sus_OP op
        on d.MessageId = op.MessageId
where op.NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus APC Measurement
* Value copied from `DiagnosisICD`

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        apc.GeneratedRecordIdentifier,
        apc.NHSNumber,
        apc.CDSActivityDate
from omop_staging.sus_ICDDiagnosis d
    inner join omop_staging.sus_APC apc
        on d.MessageId = apc.MessageId
where apc.NHSNumber is not null
order by
	d.DiagnosisICD,
    apc.GeneratedRecordIdentifier,
    apc.NHSNumber,
    apc.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### Oxford Lab Measurement
* Value copied from `EVENT`

* `EVENT` Lab test event []()

```sql
select
	NHS_NUMBER,
	EVENT,
	EVENT_START_DT_TM,
	RESULT_VALUE,
	RESULT_UNITS,
	NORMAL_LOW,
	NORMAL_HIGH
from ##duckdb_source##
where lower(EVENT) not like '%comment%'
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
### COSD V9 Lung Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Integrated Stage
* Value copied from `TnmStageGroupingIntegrated`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Final Pre Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Final Pre Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Progression Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

* `NCategoryIntegratedStage` The N category (regional lymph nodes) assigned to the tumour for the integrated stage. [N CATEGORY INTEGRATED STAGE]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Final Pre Treatment Stage
* Value copied from `NcategoryFinalPreTreatment`

* `NcategoryFinalPreTreatment` The N category (regional lymph nodes) assigned to the tumour at the time of the final pre-treatment stage. [N CATEGORY FINAL PRETREATMENT]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Integrated Stage
* Value copied from `MCategoryIntegratedStage`

* `MCategoryIntegratedStage` The M category (distant metastasis) assigned to the tumour for the integrated stage. [M CATEGORY INTEGRATED STAGE]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Final Pre Treatment Stage
* Value copied from `McategoryFinalPreTreatment`

* `McategoryFinalPreTreatment` The M category (distant metastasis) assigned to the tumour at the time of the final pre-treatment stage. [M CATEGORY FINAL PRETREATMENT]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `GradeOfDifferentiationAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V8 Lung Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Integrated Stage
* Value copied from `TnmStageGroupingIntegrated`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Final Pre Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Final Pre Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement Non Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement N Category (Final Pretreatment)
* Value copied from `NcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Integrated Stage)
* Value copied from `MCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Integrated%20Stage)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Final Pretreatment)
* Value copied from `McategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `GradeOfDifferentiationAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V9 Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Measurement TNM Category Integrated Stage
* Value copied from `TnmStageGroupingIntegrated`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement TNM Category Final Pre Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Final Pre Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Synchronous Tumour Indicator
* Value copied from `SynchronousTumourIndicator`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V9 Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Progression Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement N Category Final Pre Treatment Stage
* Value copied from `NcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Integrated Stage
* Value copied from `MCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Final Pre Treatment Stage
* Value copied from `McategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `GradeOfDifferentiationAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV9MeasurementAdultComorbidityEvaluation
* Value copied from `AdultComorbidityEvaluation`

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		AdultComorbidityEvaluation,
		NhsNumber,
		least(
			cast(DateFirstSeen as date),
			cast(DateFirstSeenCancerSpecialist as date),
			cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
			cast(StageDateFinalPretreatmentStage as date),
			cast(StageDateIntegratedStage as date),
			cast(TreatmentStartDateCancer as date),
			cast(ProcedureDate as date)
		) as MeasurementDate
from CO o
where o.AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20CosdV9MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Measurement Tumour Height Above Anal Verge
* Value copied from `TumourHeightAboveAnalVerge`

* `TumourHeightAboveAnalVerge` Is the approximate height of the lower limit of the Tumour above the anal verge (as measured by a rigid sigmoidoscopy) during a Colorectal Cancer Care Spell, where the UNIT OF MEASUREMENT is 'Centimetres (cm)' [TUMOUR HEIGHT ABOVE ANAL VERGE](https://www.datadictionary.nhs.uk/data_elements/tumour_height_above_anal_verge.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.ColorectalDiagnosis.TumourHeightAboveAnalVerge.@value' as TumourHeightAboveAnalVerge
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    TumourHeightAboveAnalVerge
from co
where TumourHeightAboveAnalVerge is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Tumour%20Height%20Above%20Anal%20Verge%20mapping){: .btn }
### COSD V8 Measurement TNM Category Integrated Stage
* Value copied from `TnmStageGroupingIntegrated`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement TNM Category Final Pre Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Final Pre Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Synchronous Tumour Indicator
* Value copied from `SynchronousTumourIndicator`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V8 Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement Non Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement N Category Final Pre Treatment Stage
* Value copied from `NcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Integrated Stage
* Value copied from `MCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Final Pre Treatment Stage
* Value copied from `McategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `GradeOfDifferentiationAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV8MeasurementAdultComorbidityEvaluation
* Value copied from `AdultComorbidityEvaluation`

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with CO as (
	select 
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_81
	where Type = 'CO'
)
select
      distinct
          AdultComorbidityEvaluation,
          NhsNumber,
          least(
                cast (DateFirstSeen as date),
                cast (SpecialistDateFirstSeen as date),
                cast (ClinicalDateCancerDiagnosis as date),
                cast (IntegratedStageTNMStageGroupingDate as date),
                cast (FinalPreTreatmentTNMStageGroupingDate as date),
                cast (CancerTreatmentStartDate as date),
                cast (ProcedureDate as date)
              ) as MeasurementDate
from CO o
where o.AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		SpecialistDateFirstSeen is null and
		ClinicalDateCancerDiagnosis is null and
		IntegratedStageTNMStageGroupingDate is null and
		FinalPreTreatmentTNMStageGroupingDate is null and
		CancerTreatmentStartDate is null and
		ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20CosdV8MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V9 Breast Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Integrated Stage
* Value copied from `TnmStageGroupingIntegrated`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Final Pre-Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Final Pre-Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Progression Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Final Pre-Treatment Stage
* Value copied from `NcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Integrated Stage
* Value copied from `MCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Final Pre-Treatment Stage
* Value copied from `McategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Grade of Differentiation
* Value copied from `GradeOfDifferentiationAtDiagnosis`

* `GradeOfDifferentiationAtDiagnosis` The grade of differentiation of the cancer at diagnosis, indicating how much the cancer cells differ from normal cells. [GRADE OF DIFFERENTIATION AT DIAGNOSIS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V9%20Breast%20Measurement%20Grade%20of%20Differentiation%20mapping){: .btn }
### COSD V8 Breast Measurement Tumour Laterality
* Value copied from `TumourLaterality`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Breast Measurement TNM Category Final Pre Treatment Stage
* Value copied from `TnmStageGroupingFinalPretreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Integrated Stage
* Value copied from `TCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Final Pre Treatment Stage
* Value copied from `TcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement Non Primary Pathway Metastasis
* Value copied from `MetastaticSite`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Integrated Stage
* Value copied from `NCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Final Pre Treatment Stage
* Value copied from `NcategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Integrated Stage
* Value copied from `MCategoryIntegratedStage`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Final Pre Treatment Stage
* Value copied from `McategoryFinalPreTreatment`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `GradeOfDifferentiationAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_value%20field%20COSD%20V8%20Breast%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
