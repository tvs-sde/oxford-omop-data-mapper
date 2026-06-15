---
layout: default
title: nhs_number
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# nhs_number
### Sus OP  Measurement
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus CCMDS Measurement - Gestation Length at Delivery
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.GeneratedRecordIdentifier,
				cc.CriticalCareStartDate as MeasurementDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as MeasurementDateTime,
				cc.GestationLengthAtDelivery as ValueAsNumber
		from omop_staging.sus_CCMDS cc 
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and cc.GestationLengthAtDelivery is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20Sus%20CCMDS%20Measurement%20-%20Gestation%20Length%20at%20Delivery%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.GeneratedRecordIdentifier,
				cc.CriticalCareStartDate as MeasurementDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as MeasurementDateTime,
				cc.PersonWeight as ValueAsNumber
		from omop_staging.sus_CCMDS cc 
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and cc.PersonWeight is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### Sus APC Measurement
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
* Value copied from `NHS_Number`

* `NHS_Number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
* Value copied from `NHS_Number`

* `NHS_Number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Cycle,
			Start_Date_Of_Cycle
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
* Value copied from `NHS_Number`

* `NHS_Number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
		select distinct 
			NHS_Number,
			Height_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
### Oxford Lab Measurement
* Value copied from `NHS_NUMBER`

* `NHS_NUMBER` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
### COSD V9 UR Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 UR Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Tcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Prostate Specific Antigen Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Query to extract Prostate Specific Antigen (Diagnosis) for UR cancer area from COSD v9.
-- PSA is a numeric lab measurement in ng/ml at the time of prostate cancer diagnosis.
-- MeasurementDate uses the primary diagnosis date.
-- PsaDiagnosis is a numeric value that will be stored as value_as_number in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as MeasurementDate,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisProstate.PsaDiagnosis.@value' as ProstateSpecificAntigenDiagnosis
from omop_staging.cosd_staging_901
where type = 'UR'
  and ProstateSpecificAntigenDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V9 UR Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Non Primary Pathway Recurrence Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Non Primary Pathway Progression Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 UR Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Ncategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Mcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 UR Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V9 UR Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Query to extract Adult Comorbidity Evaluation - 27 Score for UR cancer area from COSD v9.
-- The ACE-27 score measures comorbidity severity during a cancer care spell.
-- MeasurementDate uses the earliest available date from various clinical events.
-- AdultComorbidityEvaluation will be mapped to a measurement value concept in OMOP in a later step.
with UR as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'UR'
)
select distinct
	NhsNumber,
	AdultComorbidityEvaluation,
	least(
		cast(DateFirstSeen as date),
		cast(DateFirstSeenCancerSpecialist as date),
		cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
		cast(StageDateFinalPretreatmentStage as date),
		cast(StageDateIntegratedStage as date)
	) as MeasurementDate
from UR
where AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null
    );
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20UR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 UR Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 UR Measurement TNMcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20TNMcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement TNMcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20TNMcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Tcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Prostate Specific Antigen Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Query to extract Prostate Specific Antigen (Diagnosis) for UR cancer area from COSD v8.
-- PSA is a numeric lab measurement in ng/ml at the time of prostate cancer diagnosis.
-- MeasurementDate uses the diagnosis date.
-- ProstateSpecificAntigenDiagnosis is a numeric value that will be stored as value_as_number in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreCancerCarePlan.UrologicalCancerCarePlan.ProstateSpecificAntigenDiagnosis.@value' as ProstateSpecificAntigenDiagnosis
from omop_staging.cosd_staging_81
where type = 'UR'
  and ProstateSpecificAntigenDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
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
            ],
            recursive := true
        ) as MetastaticSite
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    MetastaticSite
from ur
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UR Measurement Non Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
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
where MetastaticSite is not null
  and MetastaticSite != '97';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 UR Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Ncategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Mcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 UR Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20UR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V9 LV Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 LV Measurement TNM Stage Grouping Integrated
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V9 LV Measurement TNM Stage Grouping Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20TNM%20Stage%20Grouping%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Tcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Non Primary Pathway Recurrence Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Non Primary Pathway Progression Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 LV Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Ncategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Mcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 LV Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.GradeOfDifferentiationAtDiagnosis.@code' as GradeOfDifferentiationAtDiagnosis
from omop_staging.cosd_staging_901
where type = 'LV'
  and GradeOfDifferentiationAtDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V9 LV Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with lv as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        Record ->> '$.CancerCarePlan.AdultComorbidityEvaluation-27Score.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_901
    where type = 'LV'
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
from lv
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 LV Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD v8 LV Measurement TNM Stage Grouping Integrated
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20TNM%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD v8 LV Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 LV Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 LV Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD v8 LV Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Liver.LiverCore.LiverCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Liver.LiverCore.LiverCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Liver.LiverCore.LiverCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select
    distinct
        AdultComorbidityEvaluation,
        NhsNumber,
        least(
            cast(DateFirstSeen as date),
            cast(SpecialistDateFirstSeen as date),
            cast(ClinicalDateCancerDiagnosis as date),
            cast(IntegratedStageTNMStageGroupingDate as date),
            cast(CancerTreatmentStartDate as date),
            cast(ProcedureDate as date)
        ) as MeasurementDate
from lv
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        SpecialistDateFirstSeen is null and
        ClinicalDateCancerDiagnosis is null and
        IntegratedStageTNMStageGroupingDate is null and
        CancerTreatmentStartDate is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 Lung Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Progression Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V8 Lung Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement Non Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Lung Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement N Category (Final Pretreatment)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Integrated Stage)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Integrated%20Stage)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Final Pretreatment)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### COSD V9 HN Measurement Tnm Stage Grouping Integrated
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Tnm%20Stage%20Grouping%20Integrated%20mapping){: .btn }
### COSD V9 HN Measurement Tnm Stage Grouping Final Pretreatment
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Tnm%20Stage%20Grouping%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement T Category Final Pretreatment
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20T%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement Non Primary Pathway Recurrence Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement Non Primary Pathway Progression Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastatic%20Site%20mapping){: .btn }
### COSD V9 HN Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement N Category Final Pretreatment
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20N%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 HN Measurement M Category Final Pretreatment
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20M%20Category%20Final%20Pretreatment%20mapping){: .btn }
### COSD V9 HN Measurement Grade Of Differentiation At Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Grade%20Of%20Differentiation%20At%20Diagnosis%20mapping){: .btn }
### COSD V9 HN Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Query to extract Adult Comorbidity Evaluation - 27 Score for HN cancer area from COSD v9.
-- The ACE-27 score is a person score recorded during a Cancer Care Spell using the ACE-27 assessment tool.
-- MeasurementDate is the earliest available date across referral, diagnosis, staging, and procedure dates.
-- AdultComorbidityEvaluation will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        Record ->> '$.CancerCarePlan.AdultComorbidityEvaluation-27Score.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select
    distinct
        NhsNumber,
        AdultComorbidityEvaluation,
        least(
            DateFirstSeen,
            DateFirstSeenCancerSpecialist,
            DateOfPrimaryDiagnosisClinicallyAgreed,
            StageDateFinalPretreatmentStage,
            StageDateIntegratedStage,
            ProcedureDate
        ) as MeasurementDate
from hn
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 HN Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD v8 HN Measurement TNMcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20TNMcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement TNMcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20TNMcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Tcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 HN Measurement Non Primary Pathway Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Non%20Primary%20Pathway%20Metastatic%20Site%20mapping){: .btn }
### COSD v8 HN Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Ncategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Mcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD v8 HN Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20v8%20HN%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 HN Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Query to extract Adult Comorbidity Evaluation score for HN cancer area from COSD v8.
-- The ACE-27 score is a person score recorded during a Cancer Care Spell using the ACE-27 assessment tool.
-- MeasurementDate is the earliest available date across referral, diagnosis, staging, and procedure dates.
-- AdultComorbidityEvaluation will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select
    distinct
        NhsNumber,
        AdultComorbidityEvaluation,
        least(
            cast(DateFirstSeen as date),
            cast(SpecialistDateFirstSeen as date),
            cast(ClinicalDateCancerDiagnosis as date),
            cast(FinalPreTreatmentTNMStageGroupingDate as date),
            cast(IntegratedStageTNMStageGroupingDate as date)
        ) as MeasurementDate
from hn
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        SpecialistDateFirstSeen is null and
        ClinicalDateCancerDiagnosis is null and
        FinalPreTreatmentTNMStageGroupingDate is null and
        IntegratedStageTNMStageGroupingDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 CR Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 CR Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Tcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Tcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Tcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Tcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 CR Measurement Non Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 CR Measurement Ncategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Ncategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Ncategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Ncategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Mcategory Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Mcategory%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Mcategory Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Mcategory%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 CR Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 CR Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with cr as (
	select
		Record ->> '$.Core.CoreCore.CoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.Core.CoreCore.CoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
		Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
		Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
		Record ->> '$.Core.CoreCore.CoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
		Record ->> '$.Core.CoreCore.CoreTreatment.CoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
		Record ->> '$.Core.CoreCore.CoreCancerPlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
		Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_81
	where type = 'CR'
)
select
      distinct
          AdultComorbidityEvaluation,
          NhsNumber,
          least(
                cast(DateFirstSeen as date),
                cast(SpecialistDateFirstSeen as date),
                cast(ClinicalDateCancerDiagnosis as date),
                cast(IntegratedStageTNMStageGroupingDate as date),
                cast(FinalPreTreatmentTNMStageGroupingDate as date),
                cast(CancerTreatmentStartDate as date),
                cast(ProcedureDate as date)
              ) as MeasurementDate
from cr
where AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		SpecialistDateFirstSeen is null and
		ClinicalDateCancerDiagnosis is null and
		IntegratedStageTNMStageGroupingDate is null and
		FinalPreTreatmentTNMStageGroupingDate is null and
		CancerTreatmentStartDate is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20CR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Synchronous Tumour Indicator
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V9 Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Progression Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement N Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV9MeasurementAdultComorbidityEvaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20CosdV9MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Measurement Tumour Height Above Anal Verge
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Tumour%20Height%20Above%20Anal%20Verge%20mapping){: .btn }
### COSD V8 Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Synchronous Tumour Indicator
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Synchronous%20Tumour%20Indicator%20mapping){: .btn }
### COSD V8 Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement Non Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement N Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV8MeasurementAdultComorbidityEvaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20CosdV8MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V9 Breast Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Final Pre-Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Final Pre-Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Recurrence Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Progression Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Final Pre-Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Final Pre-Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Grade of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Measurement%20Grade%20of%20Differentiation%20mapping){: .btn }
### CosdV9BreastMeasurementAdultComorbidityEvaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        -- Quoting used to handle the hyphen in the field name safely
        Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
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
from BR o
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20CosdV9BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Breast Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 Breast Measurement TNM Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement Non Primary Pathway Metastasis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20Non%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Integrated Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Final Pre Treatment Stage
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement Grade of Differentiation (At Diagnosis)
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Measurement%20Grade%20of%20Differentiation%20(At%20Diagnosis)%20mapping){: .btn }
### CosdV8BreastMeasurementAdultComorbidityEvaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Breast.BreastCore.BreastCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select
      distinct
          AdultComorbidityEvaluation,
          NhsNumber,
          least(
                cast (DateFirstSeen as date),
                cast (DateFirstSeenCancerSpecialist as date),
                cast (ClinicalDateCancerDiagnosis as date),
                cast (IntegratedStageTNMStageGroupingDate as date),
                cast (FinalPreTreatmentTNMStageGroupingDate as date),
                cast (CancerTreatmentStartDate as date),
                cast (ProcedureDate as date)
              ) as MeasurementDate
from BR o
where o.AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        ClinicalDateCancerDiagnosis is null and
        IntegratedStageTNMStageGroupingDate is null and
        FinalPreTreatmentTNMStageGroupingDate is null and
        CancerTreatmentStartDate is null and
        ProcedureDate is null
    );
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20CosdV8BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 BA Measurement Tumour Laterality
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20BA%20Measurement%20Tumour%20Laterality%20mapping){: .btn }
### COSD V8 BA Measurement Metastatic Site
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20BA%20Measurement%20Metastatic%20Site%20mapping){: .btn }
### COSD V8 BA Measurement Grade Of Differentiation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20BA%20Measurement%20Grade%20Of%20Differentiation%20mapping){: .btn }
### COSD V8 BA Measurement Adult Comorbidity Evaluation
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with BA as (
    select
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.CNS.CNSCore.CNSCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.CNS.CNSCore.CNSCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(CancerTreatmentStartDate as date),
        cast(ProcedureDate as date)
    ) as MeasurementDate
from BA
where AdultComorbidityEvaluation is not null
  and not (
      DateFirstSeen is null and
      SpecialistDateFirstSeen is null and
      ClinicalDateCancerDiagnosis is null and
      CancerTreatmentStartDate is null and
      ProcedureDate is null
  );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20nhs_number%20field%20COSD%20V8%20BA%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
