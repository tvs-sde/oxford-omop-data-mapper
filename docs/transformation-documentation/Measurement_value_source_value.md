---
layout: default
title: value_source_value
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# value_source_value
### Sus OP  Measurement
Source column  `DiagnosisICD`.
Resolve Measurement domain ICD10 codes to `Maps To Value` concepts.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Value copied from `ValueAsNumber`

* `ValueAsNumber` Value of the Person weight [PERSON WEIGHT](https://www.datadictionary.nhs.uk/data_elements/person_weight.html)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### Sus APC Measurement
Source column  `DiagnosisICD`.
Resolve Measurement domain ICD10 codes to `Maps To Value` concepts.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
* Value copied from `Weight_At_Start_Of_Regimen`

* `Weight_At_Start_Of_Regimen` Weight when the Regimen started [WEIGHT AT START OF REGIMEN]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
* Value copied from `Weight_At_Start_Of_Cycle`

* `Weight_At_Start_Of_Cycle` Weight when the cycle started [WEIGHT AT START OF CYCLE]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Cycle,
			Start_Date_Of_Cycle
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
* Value copied from `Height_At_Start_Of_Regimen`

* `Height_At_Start_Of_Regimen` Height when the treatment started [HEIGHT AT START OF TREATMENT]()

```sql
		select distinct 
			NHS_Number,
			Height_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
### Oxford vital signs: temperature.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric temperature, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in ('Temperature', 'Temperature POCT', 'Temperature Tympanic')
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'degrees c'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20temperature.%20mapping){: .btn }
### Oxford vital signs: systolic blood pressure.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric systolic pressure, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in (
    'Booking Systolic Blood Pressure', 'Systolic Blood Pressure', 'Systolic Blood Pressure Invasive',
    'Systolic Blood Pressure Sitting', 'Systolic Blood Pressure Standing', 'Systolic Blood Pressure Supine'
)
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'mmhg'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20systolic%20blood%20pressure.%20mapping){: .btn }
### Oxford vital signs: respiratory rate.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric respiratory rate, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in ('Respiratory Rate', 'Respiratory Rate Total', 'Respiratory Rate, Spontaneous')
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'br/min'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20respiratory%20rate.%20mapping){: .btn }
### Oxford vital signs: oxygen saturation.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric saturation, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in ('Oxygen Saturation', 'SpO2')
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', '%'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20oxygen%20saturation.%20mapping){: .btn }
### Oxford vital signs: delivered oxygen concentration.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric oxygen concentration, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) = 'Oxygen % delivered'
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', '%'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20delivered%20oxygen%20concentration.%20mapping){: .btn }
### Oxford vital signs: mean arterial pressure.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric mean pressure, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in ('Mean Arterial Pressure', 'Mean Arterial Pressure, Cuff', 'Mean Arterial Pressure, Invasive')
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'mmhg'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20mean%20arterial%20pressure.%20mapping){: .btn }
### Oxford vital signs: heart rate.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric heart rate, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in ('Apical Heart Rate', 'Heart Rate', 'Heart Rate Monitored', 'Peripheral Pulse Rate')
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'bpm'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20heart%20rate.%20mapping){: .btn }
### Oxford numeric Glasgow Coma Score totals; component responses are excluded.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Original numeric score; values are not clipped to the usual 3-15 range.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) = 'Glasgow Coma Score'
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20numeric%20Glasgow%20Coma%20Score%20totals;%20component%20responses%20are%20excluded.%20mapping){: .btn }
### Oxford vital signs: diastolic blood pressure.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Finite numeric diastolic pressure, preserved without physiological clipping.

```sql
select
    patient_identifier_value,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH,
    md5(to_json(row(WAREHOUSE_IDENTIFIER, EVENT_END_DT_TM, EVENT, RESULT_VALUE,
        RESULT_UNITS, NORMAL_LOW, NORMAL_HIGH))) as record_connection_identifier
from ##duckdb_source##
where trim(EVENT) in (
    'Booking Diastolic Blood Pressure', 'Diastolic Blood Pressure', 'Diastolic Blood Pressure Invasive',
    'Diastolic Blood Pressure Sitting', 'Diastolic Blood Pressure Standing', 'Diastolic Blood Pressure Supine'
)
  and isfinite(try_cast(trim(RESULT_VALUE) as double))
  and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>', 'mmhg'))
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20vital%20signs:%20diastolic%20blood%20pressure.%20mapping){: .btn }
### Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Original result 

```sql
select
    nhs_number,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    case
        when trim(EVENT) in ('Weight', 'Weight Measured')
            and (RESULT_UNITS is null or lower(trim(RESULT_UNITS)) in ('', '<no data>'))
        then 'kg'
        else RESULT_UNITS
    end as RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH
from ##duckdb_source##
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Oxford%20clinical%20observations:%20weight,%20height%20and%20body%20mass%20index%20from%20clinical_observations_bmi.parquet.%20mapping){: .btn }
### COSD V9 Lung Measurement Surgical Access Type
* Value copied from `SurgicalAccessType`

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
            cast(DateFirstSeen as date),
            cast(DateFirstSeenCancerSpecialist as date),
            cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
            cast(StageDateFinalPretreatmentStage as date),
            cast(nullif(StageDateIntegratedStage, '') as date),
            cast(TreatmentStartDateCancer as date),
            cast(ProcedureDate as date)
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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20COSD%20V9%20Lung%20Measurement%20Surgical%20Access%20Type%20mapping){: .btn }
### COSD V8 Lung Measurement Surgical Access Type
* Value copied from `SurgicalAccessType`

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
                cast (DateFirstSeen as date),
                cast (SpecialistDateFirstSeen as date),
                cast (ClinicalDateCancerDiagnosis as date),
                cast (IntegratedStageTNMStageGroupingDate as date),
                cast (FinalPreTreatmentTNMStageGroupingDate as date),
                cast (CancerTreatmentStartDate as date),
                cast (ProcedureDate as date)
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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20COSD%20V8%20Lung%20Measurement%20Surgical%20Access%20Type%20mapping){: .btn }
