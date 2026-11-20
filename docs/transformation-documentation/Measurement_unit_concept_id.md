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


* `RESULT_UNITS` Original units 

```sql
select
    nhs_number,
    EVENT_END_DT_TM,
    EVENT,
    RESULT_VALUE,
    RESULT_UNITS,
    NORMAL_LOW,
    NORMAL_HIGH
from ##duckdb_source##
)
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20Oxford%20clinical%20observations:%20weight,%20height%20and%20body%20mass%20index%20from%20clinical_observations_bmi.parquet.%20mapping){: .btn }
### COSD V9 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `8842`. nanogram per millilitre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20COSD%20V9%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Measurement Prostate Specific Antigen Diagnosis
* Constant value set to `8842`. nanogram per millilitre

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20unit_concept_id%20field%20COSD%20V8%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
