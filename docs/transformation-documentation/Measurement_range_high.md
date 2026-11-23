---
layout: default
title: range_high
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# range_high
### Oxford Lab Measurement
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Lab test normal range (high) []()

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
order by all
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
### Oxford vital signs: temperature.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20temperature.%20mapping){: .btn }
### Oxford vital signs: systolic blood pressure.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20systolic%20blood%20pressure.%20mapping){: .btn }
### Oxford vital signs: respiratory rate.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20respiratory%20rate.%20mapping){: .btn }
### Oxford vital signs: oxygen saturation.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20oxygen%20saturation.%20mapping){: .btn }
### Oxford vital signs: delivered oxygen concentration.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20delivered%20oxygen%20concentration.%20mapping){: .btn }
### Oxford vital signs: mean arterial pressure.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20mean%20arterial%20pressure.%20mapping){: .btn }
### Oxford vital signs: heart rate.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20heart%20rate.%20mapping){: .btn }
### Oxford numeric Glasgow Coma Score totals; component responses are excluded.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20numeric%20Glasgow%20Coma%20Score%20totals;%20component%20responses%20are%20excluded.%20mapping){: .btn }
### Oxford vital signs: diastolic blood pressure.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range when numeric.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20vital%20signs:%20diastolic%20blood%20pressure.%20mapping){: .btn }
### Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.
Source column  `NORMAL_HIGH`.
Converts text to number.

* `NORMAL_HIGH` Upper reference range, when numeric. 

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20clinical%20observations:%20weight,%20height%20and%20body%20mass%20index%20from%20clinical_observations_bmi.parquet.%20mapping){: .btn }
