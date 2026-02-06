---
layout: default
title: condition_status_concept_id
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_status_concept_id
### Cosd V8 CTYA Condition Occurrence Primary Diagnosis
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

```sql
with ct as (
  select 
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CT'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerDiagnosis
from ct
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	);
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20CTYA%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 CTYA Condition Occurrence Primary Diagnosis Histology Topography
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

```sql
with ct as (
  select 
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CT'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerHistology,
		CancerTopography
from ct
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	)
	and (CancerHistology is not null and CancerTopography is not null)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20CTYA%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis Histology Topography
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source column  `BasisOfDiagnosisCancer`.
Lookup NHS Data Dictionary Basis Of Diagnosis Cancer


|BasisOfDiagnosisCancer|condition_status_concept_id|notes|
|------|-----|-----|
|0|32895|Death diagnosis|
|1|32899|Preliminary diagnosis|
|2|32899|Preliminary diagnosis|
|4|32893|Confirmed diagnosis|
|5|32893|Confirmed diagnosis|
|6|32908|Secondary diagnosis|
|7|32902|Primary diagnosis|
|9|||

Notes
* [OMOP Condition Status](https://athena.ohdsi.org/search-terms/terms?domain=Condition+Status&standardConcept=Standard&page=1&pageSize=50&query=)
* [NHS Basis of Diagnosis of Cancer](https://www.datadictionary.nhs.uk/attributes/basis_of_diagnosis_for_cancer.html?hl=basis%2Cdiagnosis%2Ccancer)

* `BasisOfDiagnosisCancer` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_status_concept_id%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
