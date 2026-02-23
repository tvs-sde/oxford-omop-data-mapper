---
layout: default
title: qualifier_concept_id
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# qualifier_concept_id
### CosdV9LungSurgicalAccessType
Source column  `SurgicalAccessType`.
Lookup SurgicalAccessType concepts for lung cancer procedures.


|SurgicalAccessType|qualifier_concept_id|notes|
|------|-----|-----|
|1|4044378|Open approach|
|2|4044378|Laparoscopic/Thoracoscopic with planned conversion to open surgery|
|3|4044378|Laparoscopic/Thoracoscopic with unplanned conversion to open surgery|
|4|44808608|Laparoscopic/Thoracoscopic completed|
|5|44790026|Robotic surgery|
|Z|0|Other|

Notes
* [OMOP Open approach](https://athena.ohdsi.org/search-terms/terms/4044378)
* [OMOP Laparoscopic/Thoracoscopic](https://athena.ohdsi.org/search-terms/terms/44808608)
* [OMOP Robotic surgery](https://athena.ohdsi.org/search-terms/terms/44790026)
* [SURGICAL ACCESS TYPE](https://www.datadictionary.nhs.uk/data_elements/surgical_access_type.html)

* `SurgicalAccessType` A code representing the surgical access type used during a procedure. [SURGICAL ACCESS TYPE](https://www.datadictionary.nhs.uk/data_elements/surgical_access_type.html)

```sql
with LU as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        Record ->> '$.Treatment.TreatmentStartDateCancer' as TreatmentStartDateCancer,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        Record ->> '$.Treatment.Surgery.SurgicalAccessType.@code' as SurgicalAccessType,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        SurgicalAccessType,
        NhsNumber,
        least(
            DateFirstSeen,
            DateFirstSeenCancerSpecialist,
            DateOfPrimaryDiagnosisClinicallyAgreed,
            StageDateFinalPretreatmentStage,
            StageDateIntegratedStage,
            TreatmentStartDateCancer,
            ProcedureDate
        ) as Date
from LU o
where o.SurgicalAccessType is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20qualifier_concept_id%20field%20CosdV9LungSurgicalAccessType%20mapping){: .btn }
### CosdV8LungSurgicalAccessType
Source column  `SurgicalAccessType`.
Lookup SurgicalAccessType concepts for lung cancer procedures.


|SurgicalAccessType|qualifier_concept_id|notes|
|------|-----|-----|
|1|4044378|Open approach|
|2|4044378|Laparoscopic/Thoracoscopic with planned conversion to open surgery|
|3|4044378|Laparoscopic/Thoracoscopic with unplanned conversion to open surgery|
|4|44808608|Laparoscopic/Thoracoscopic completed|
|5|44790026|Robotic surgery|
|Z|0|Other|

Notes
* [OMOP Open approach](https://athena.ohdsi.org/search-terms/terms/4044378)
* [OMOP Laparoscopic/Thoracoscopic](https://athena.ohdsi.org/search-terms/terms/44808608)
* [OMOP Robotic surgery](https://athena.ohdsi.org/search-terms/terms/44790026)
* [SURGICAL ACCESS TYPE](https://www.datadictionary.nhs.uk/data_elements/surgical_access_type.html)

* `SurgicalAccessType` A code representing the surgical access type used during a procedure. [SURGICAL ACCESS TYPE](https://www.datadictionary.nhs.uk/data_elements/surgical_access_type.html)

```sql
with LU as (
    select 
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        unnest ([[Record ->> '$.Lung.LungCore.LungCoreTreatment.CancerTreatmentStartDate'], Record ->> '$.Lung.LungCore.LungCoreTreatment[*].CancerTreatmentStartDate'], recursive := true) as CancerTreatmentStartDate,
        Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.SurgicalAccessType.@code' as SurgicalAccessType,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          SurgicalAccessType,
          NhsNumber,
          least(
                DateFirstSeen,
                SpecialistDateFirstSeen,
                ClinicalDateCancerDiagnosis,
                IntegratedStageTNMStageGroupingDate,
                FinalPreTreatmentTNMStageGroupingDate,
                CancerTreatmentStartDate,
                ProcedureDate
              ) as Date
from LU o
where o.SurgicalAccessType is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20qualifier_concept_id%20field%20CosdV8LungSurgicalAccessType%20mapping){: .btn }
