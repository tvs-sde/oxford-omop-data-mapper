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
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_high%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
