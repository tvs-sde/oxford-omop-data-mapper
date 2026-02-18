---
layout: default
title: condition_source_value
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_source_value
### SUS Outpatient Condition Occurrence
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
	order by
		d.DiagnosisICD,
		op.GeneratedRecordIdentifier,
		op.NHSNumber,
		op.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SACT Condition Occurrence
* Value copied from `Primary_Diagnosis`

* `Primary_Diagnosis` PRIMARY DIAGNOSIS (ICD AT START SYSTEMIC ANTI-CANCER THERAPY) is the PRIMARY DIAGNOSIS (ICD) at the start of the Systemic Anti-Cancer Therapy. [PRIMARY DIAGNOSIS (ICD AT START SYSTEMIC ANTI-CANCER THERAPY)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_at_start_systemic_anti-cancer_therapy_.html)

```sql
	select
		Primary_Diagnosis,
		replace(NHS_Number, ' ', '') as NHS_Number,
		min(Administration_Date) as Administration_Date
	from omop_staging.sact_staging
	group by
		Primary_Diagnosis,
		NHS_Number
	order by
		NHS_Number,
		Primary_Diagnosis,
		min(Administration_Date)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
### Rtds Condition Occurrence
* Value copied from `DiagnosisCode`

* `DiagnosisCode` ICD10 Diagnosis Code []()

```sql
with results as (
	select 
		distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as PatientId,
			dc.DiagnosisCode,
			dc.DateStamp as event_start_date,
			dc.DateStamp as event_end_date
	from omop_staging.RTDS_5_Diagnosis_Course dc
	where dc.DiagnosisTableName = 'ICD-10'
)
select
	PatientId,
	DiagnosisCode,
	event_start_date,
	event_end_date
from results
where
    PatientId is not null
    and regexp_matches(patientid, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Recurrence
* Value copied from `NonPrimaryRecurrenceOriginalDiagnosis`

* `NonPrimaryRecurrenceOriginalDiagnosis` ORIGINAL PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS relating to the cancer recurrence. [ORIGINAL PRIMARY DIAGNOSIS (ICD)]()

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Progression
* Value copied from `NonPrimaryProgressionOriginalDiagnosis`

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Progression
* Value copied from `NonPrimaryProgressionOriginalDiagnosis`

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_81
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis
* Value copied from `CancerDiagnosis`

* `CancerDiagnosis` The primary diagnosis code for the cancer. [PRIMARY DIAGNOSIS]()

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Separates text with newlines. Trim whitespace.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null
  and CancerHistology is not null
  and CancerTopography is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Topography ICD-O-3
* Value copied from `TopographyIcdo3`

* `TopographyIcdo3` Topographical site of the tumour using the ICD-O code. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.TopographyIcd-o-3.@code' as TopographyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and TopographyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Topography%20ICD-O-3%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Secondary Diagnosis ICD
* Value copied from `SecondaryDiagnosisIcd`

* `SecondaryDiagnosisIcd` ICD code used to identify the secondary patient diagnosis. [SECONDARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/secondary_diagnosis__icd_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Progression ICD
* Value copied from `ProgressionIcd`

* `ProgressionIcd` The International Classification of Diseases (ICD) code of the cancer progression during a Cancer Care Spell. For the Cancer Outcomes and Services Data Set - Core, this is the ICD code of the original patient diagnosis of the cancer progression, agreed at the multidisciplinary team meeting by the care professional team. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as ProgressionIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and ProgressionIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Progression%20ICD%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Primary Diagnosis ICD
* Value copied from `PrimaryDiagnosisIcd`

* `PrimaryDiagnosisIcd` ICD code used to identify the primary diagnosis. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as PrimaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and PrimaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `OriginalPrimaryDiagnosisIcd`

* `OriginalPrimaryDiagnosisIcd` ICD code used to identify the original primary diagnosis. For COSDS Core, used for cancer recurrence and agreed at the multidisciplinary team meeting by the care professional team. [PRIMARY DIAGNOSIS (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as OriginalPrimaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalPrimaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Original Morphology SNOMED
* Value copied from `OriginalMorphologySnomed`

* `OriginalMorphologySnomed` SNOMED code or SNOMED CT concept ID for the morphology code of the original primary diagnosis of the cancer transformation during a Cancer Care Spell. [MORPHOLOGY (SNOMED CANCER TRANSFORMATION ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/morphology__snomed_cancer_transformation_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Transformation.OriginalMorphologySnomed.@code' as OriginalMorphologySnomed
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalMorphologySnomed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Original%20Morphology%20SNOMED%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Original Morphology ICD-O-3
* Value copied from `OriginalMorphologyIcdo3`

* `OriginalMorphologyIcdo3` Morphology code of the original primary diagnosis of the cancer transformation using the ICD-O code during a Cancer Care Spell. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Transformation.OriginalMorphologyIcd-o-3.@code' as OriginalMorphologyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalMorphologyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Original%20Morphology%20ICD-O-3%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Morphology SNOMED Transformation
* Value copied from `MorphologySnomedTransformation`

* `MorphologySnomedTransformation` Cancer transformation using SNOMED code or SNOMED CT concept ID for the cell type of the tumour during a Cancer Care Spell. [MORPHOLOGY (SNOMED CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__snomed_cancer_transformation_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Transformation.MorphologySNOMEDTransformation.MorphologySnomedTransformation.@code' as MorphologySnomedTransformation
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and MorphologySnomedTransformation is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Morphology%20SNOMED%20Transformation%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Morphology SNOMED Diagnosis
* Value copied from `MorphologySnomedDiagnosis`

* `MorphologySnomedDiagnosis` Patient diagnosis using SNOMED code or SNOMED CT concept ID for the cell type of the tumour during a Cancer Care Spell. [MORPHOLOGY (SNOMED DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/morphology__snomed_diagnosis_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.MorphologySNOMED.MorphologySnomedDiagnosis.@code' as MorphologySnomedDiagnosis
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and MorphologySnomedDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Morphology%20SNOMED%20Diagnosis%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Morphology ICD-O-3
* Value copied from `MorphologyIcdo3`

* `MorphologyIcdo3` Patient diagnosis using the ICD-O code during a Cancer Care Spell. [MORPHOLOGY (ICD-O DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_diagnosis_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.MorphologyIcd-o-3.@code' as MorphologyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and MorphologyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Morphology%20ICD-O-3%20mapping){: .btn }
### COSD V9 HA Condition Occurrence Morphology ICD-O-3 Transformation
* Value copied from `MorphologyIcdo3Transformation`

* `MorphologyIcdo3Transformation` Morphology code of the cancer transformation using the ICD-O code during a Cancer Care Spell. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    Record ->> '$.NonPrimaryPathway.Transformation.MorphologyIcd-o-3Transformation.@code' as MorphologyIcdo3Transformation
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and MorphologyIcdo3Transformation is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20HA%20Condition%20Occurrence%20Morphology%20ICD-O-3%20Transformation%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis
* Value copied from `CancerDiagnosis`

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerDiagnosis
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	);
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Separates text with newlines. Trim whitespace.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerHistology,
		CancerTopography
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	)
	and (CancerHistology is not null and CancerTopography is not null)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
* Value copied from `SecondaryDiagnosis`

* `SecondaryDiagnosis` SECONDARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the secondary PATIENT DIAGNOSIS. [SECONDARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/secondary_diagnosis__icd_.html)

```sql
with CO as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(SecondaryDiagnosis) as SecondaryDiagnosis
from CO
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
* Value copied from `NonPrimaryRecurrenceOriginalDiagnosis`

* `NonPrimaryRecurrenceOriginalDiagnosis` PRIMARY DIAGNOSIS (ICD ORIGINAL) is the International Classification of Diseases (ICD) code used to identify the original PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_original_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Progression
* Value copied from `NonPrimaryProgressionOriginalDiagnosis`

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryProgressionOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis
* Value copied from `CancerDiagnosis`

* `CancerDiagnosis` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

```sql
with co as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
		Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
		Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
	CancerDiagnosis
from co
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Separates text with newlines. Trim whitespace.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
    Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
from omop_staging.cosd_staging_901
where type = 'CO'
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Secondary Diagnosis
* Value copied from `SecondaryDiagnosis`

* `SecondaryDiagnosis` SECONDARY DIAGNOSIS (ICD) is a classification denoting a disease or condition which co-exists at the time of Consultation with the Primary Diagnosis. [SECONDARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/secondary_diagnosis__icd_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(SecondaryDiagnosis) as SecondaryDiagnosis
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Secondary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Recurrence
* Value copied from `NonPrimaryRecurrenceOriginalDiagnosis`

* `NonPrimaryRecurrenceOriginalDiagnosis` ORIGINAL PRIMARY DIAGNOSIS (ICD RECURRENCE) is the International Classification of Diseases (ICD) code of the original Primary Diagnosis of a Recurrence. [ORIGINAL PRIMARY DIAGNOSIS (ICD RECURRENCE)]()

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    NonPrimaryRecurrenceOriginalDiagnosis
from BR
where NonPrimaryRecurrenceOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Progression
* Value copied from `NonPrimaryProgressionOriginalDiagnosis`

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis
* Value copied from `CancerDiagnosis`

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with br as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
    CancerDiagnosis
from br
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Separates text with newlines. Trim whitespace.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    BasisOfDiagnosisCancer,
    CancerHistology,
    CancerTopography
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V8 Breast Condition Occurrence Progression
* Value copied from `NonPrimaryProgressionOriginalDiagnosis`

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
with BR as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'BR'
)
select distinct
    NHSNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NHSNumber is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20COSD%20V8%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis
* Value copied from `CancerDiagnosis`

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 
  where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerDiagnosis
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Separates text with newlines. Trim whitespace.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81
where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerHistology,
        CancerTopography
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    )
    and (CancerHistology is not null and CancerTopography is not null)
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_value%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
