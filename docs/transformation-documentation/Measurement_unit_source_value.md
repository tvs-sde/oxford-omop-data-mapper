---
layout: default
title: unit_source_value
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# unit_source_value
### Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.
* Value copied from `RESULT_UNITS`

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
