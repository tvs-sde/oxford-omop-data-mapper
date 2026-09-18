---
layout: default
title: range_low
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# range_low
### Oxford Lab Measurement
Source column  `NORMAL_LOW`.
Converts text to number.

* `NORMAL_LOW` Lab test normal range (low) []()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20range_low%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
