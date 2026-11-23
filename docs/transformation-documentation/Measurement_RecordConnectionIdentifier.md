---
layout: default
title: RecordConnectionIdentifier
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# RecordConnectionIdentifier
### Sus CCMDS Measurement - Gestation Length at Delivery
* Value copied from `GeneratedRecordIdentifier`

* `GeneratedRecordIdentifier` CDS specific identifier that binds multiple CDS messages together. [CDS RECORD IDENTIFIER](https://www.datadictionary.nhs.uk/data_elements/cds_record_identifier.html)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Sus%20CCMDS%20Measurement%20-%20Gestation%20Length%20at%20Delivery%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Value copied from `GeneratedRecordIdentifier`

* `GeneratedRecordIdentifier` CDS specific identifier that binds multiple CDS messages together. [CDS RECORD IDENTIFIER](https://www.datadictionary.nhs.uk/data_elements/cds_record_identifier.html)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### Sus APC Measurement
* Value copied from `GeneratedRecordIdentifier`

* `GeneratedRecordIdentifier` CDS specific identifier that binds multiple CDS messages together. [CDS RECORD IDENTIFIER](https://www.datadictionary.nhs.uk/data_elements/cds_record_identifier.html)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### Oxford vital signs: temperature.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20temperature.%20mapping){: .btn }
### Oxford vital signs: systolic blood pressure.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20systolic%20blood%20pressure.%20mapping){: .btn }
### Oxford vital signs: respiratory rate.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20respiratory%20rate.%20mapping){: .btn }
### Oxford vital signs: oxygen saturation.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20oxygen%20saturation.%20mapping){: .btn }
### Oxford vital signs: delivered oxygen concentration.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20delivered%20oxygen%20concentration.%20mapping){: .btn }
### Oxford vital signs: mean arterial pressure.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20mean%20arterial%20pressure.%20mapping){: .btn }
### Oxford vital signs: heart rate.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20heart%20rate.%20mapping){: .btn }
### Oxford numeric Glasgow Coma Score totals; component responses are excluded.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges, preserving distinct readings across batches and identifying identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20numeric%20Glasgow%20Coma%20Score%20totals;%20component%20responses%20are%20excluded.%20mapping){: .btn }
### Oxford vital signs: diastolic blood pressure.
* Value copied from `record_connection_identifier`

* `record_connection_identifier` Stable hash of the warehouse identifier and original event timestamp, name, result, units and ranges; preserves distinct same-day readings and identifies identical rows on reruns.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20RecordConnectionIdentifier%20field%20Oxford%20vital%20signs:%20diastolic%20blood%20pressure.%20mapping){: .btn }
