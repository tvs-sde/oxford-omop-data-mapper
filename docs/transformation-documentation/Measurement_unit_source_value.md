---
layout: default
title: unit_source_value
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# unit_source_value
### Oxford vital signs: temperature.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as degrees C; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20temperature.%20mapping){: .btn }
### Oxford vital signs: systolic blood pressure.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as mmHg; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20systolic%20blood%20pressure.%20mapping){: .btn }
### Oxford vital signs: respiratory rate.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as br/min; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20respiratory%20rate.%20mapping){: .btn }
### Oxford vital signs: oxygen saturation.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as %; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20oxygen%20saturation.%20mapping){: .btn }
### Oxford vital signs: delivered oxygen concentration.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as %; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20delivered%20oxygen%20concentration.%20mapping){: .btn }
### Oxford vital signs: mean arterial pressure.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as mmHg; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20mean%20arterial%20pressure.%20mapping){: .btn }
### Oxford vital signs: heart rate.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as bpm; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20heart%20rate.%20mapping){: .btn }
### Oxford numeric Glasgow Coma Score totals; component responses are excluded.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Dimensionless score; unexpected explicit physical units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20numeric%20Glasgow%20Coma%20Score%20totals;%20component%20responses%20are%20excluded.%20mapping){: .btn }
### Oxford vital signs: diastolic blood pressure.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original supplied units. Missing units are interpreted as mmHg; other explicit units are excluded.

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20vital%20signs:%20diastolic%20blood%20pressure.%20mapping){: .btn }
### Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.
* Value copied from `RESULT_UNITS`

* `RESULT_UNITS` Original units; null, blank or <no data> units default to kg for Weight and Weight Measured events only. 

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20Oxford%20clinical%20observations:%20weight,%20height%20and%20body%20mass%20index%20from%20clinical_observations_bmi.parquet.%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Peak At Diagnosis
* Constant value set to `U/L`. Units per litre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Peak%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Normal Upper Limit
* Constant value set to `U/L`. Units per litre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Normal%20Upper%20Limit%20mapping){: .btn }
### COSD V8 Measurement Tumour Height Above Anal Verge
* Constant value set to `cm`. `centimetres`

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_source_value%20field%20COSD%20V8%20Measurement%20Tumour%20Height%20Above%20Anal%20Verge%20mapping){: .btn }
