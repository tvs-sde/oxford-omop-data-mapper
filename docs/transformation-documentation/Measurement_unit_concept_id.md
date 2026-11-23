---
layout: default
title: unit_concept_id
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# unit_concept_id
### Sus CCMDS Measurement - Gestation Length at Delivery
* Constant value set to `8511`. Week

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Sus%20CCMDS%20Measurement%20-%20Gestation%20Length%20at%20Delivery%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Constant value set to `9529`. Kg

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
* Constant value set to `9529`. Kg

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
* Constant value set to `9529`. Kg

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
* Constant value set to `8582`. cm

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
### Oxford vital signs: temperature.
* Constant value set to `586323`. Degree Celsius

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20temperature.%20mapping){: .btn }
### Oxford vital signs: systolic blood pressure.
* Constant value set to `8876`. Millimeter of mercury

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20systolic%20blood%20pressure.%20mapping){: .btn }
### Oxford vital signs: respiratory rate.
* Constant value set to `8541`. Per minute

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20respiratory%20rate.%20mapping){: .btn }
### Oxford vital signs: oxygen saturation.
* Constant value set to `8554`. Percent

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20oxygen%20saturation.%20mapping){: .btn }
### Oxford vital signs: delivered oxygen concentration.
* Constant value set to `8554`. Percent

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20delivered%20oxygen%20concentration.%20mapping){: .btn }
### Oxford vital signs: mean arterial pressure.
* Constant value set to `8876`. Millimeter of mercury

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20mean%20arterial%20pressure.%20mapping){: .btn }
### Oxford vital signs: heart rate.
* Constant value set to `8541`. Per minute

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20heart%20rate.%20mapping){: .btn }
### Oxford numeric Glasgow Coma Score totals; component responses are excluded.
* Constant value set to `0`. Dimensionless Glasgow Coma Score; no physical unit is inferred.

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20numeric%20Glasgow%20Coma%20Score%20totals;%20component%20responses%20are%20excluded.%20mapping){: .btn }
### Oxford vital signs: diastolic blood pressure.
* Constant value set to `8876`. Millimeter of mercury

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20vital%20signs:%20diastolic%20blood%20pressure.%20mapping){: .btn }
### Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.
Source column  `RESULT_UNITS`.


|RESULT_UNITS|unit_concept_id|notes|
|------|-----|-----|
|kg|9529|Kilogram|
|cm|8582|Centimeter|
|kg/m2|9531|Kilogram per square meter|
|<no data>|0|Unknown unit|
|square metre|0|Not a supported measurement unit|
||0|Missing unit|


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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20clinical%20observations:%20weight,%20height%20and%20body%20mass%20index%20from%20clinical_observations_bmi.parquet.%20mapping){: .btn }
### COSD V9 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `8842`. nanogram per millilitre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `8842`. nanogram per millilitre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
