---
layout: default
title: RecordConnectionIdentifier
parent: VisitDetail
grand_parent: Transformation Documentation
has_toc: false
---
# RecordConnectionIdentifier
### Oxford Visit Details
* Value copied from `GPEventsPrimaryKey`

* `GPEventsPrimaryKey` GP Events Unique ID 

```sql
select
	GPEventsPrimaryKey,
	d.NHSNumber,
	e.EventDate
from omop_staging.oxford_gp_event e
	inner join omop_staging.oxford_gp_demographic d
		on e.PatientIdentifier = d.PatientIdentifier
order by
	d.NHSNumber,
	e.EventDate
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20RecordConnectionIdentifier%20field%20Oxford%20Visit%20Details%20mapping){: .btn }
