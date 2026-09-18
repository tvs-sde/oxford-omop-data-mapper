---
layout: default
title: route_concept_id
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# route_concept_id
### Oxford Prescribing Drug Exposure
Source column  `rxroute`.
Prescribing Drug Routes to OMOP Condition Concept IDs


|rxroute|route_concept_id|notes|
|------|-----|-----|
|affected eye(s)|40549429|ocular|
|anal|4290759|rectal|
|bath|4263689|topical|
|both ears|4023156|otic|
|both eyes|40549429|ocular|
|buccal|4181897|buccal|
|caudal|4220455|caudal|
|chewed|4132161|oral|
|dental|4163765|dental|
|endotracheal|40491832|transtracheal|
|enteral feed|4167540|enteral|
|epidural|4225555|epidural|
|flush|0|flush|
|gastrojejunostomy|4133177|jejunostomy|
|gastrostomy|4132254|gastrostomy|
|gingival|4156704|gingival|
|handihaler|40486069|respiratory tract|
|inhalation|40486069|respiratory tract|
|intraarterial|4240824|intra-arterial|
|intraarticular|4006860|intra-articular|
|intrabiliary|4223965|intrabiliary|
|intracameral|4303409|intracameral|
|intracardiac|4156705|intracardiac|
|intracavernosal|37174549|intracorporus cavernosum|
|intradermal|4156706|intradermal|
|intradiscal|4163769|intradiscal|
|intralesional|4157758|intralesional|
|intralymphatic|4157759|intralymphatic|
|intramuscular|4302612|intramuscular|
|intramyometrial|4168038|intramyometrial|
|intraocular|4157760|intraocular|
|intraosseous|4213522|intraosseous|
|intraperitoneal|4243022|intraperitoneal|
|intrapleural|4156707|intrapleural|
|intrathecal|4217202|intrathecal|
|intratracheal|4229543|intratracheal|
|intraurethral|4305382|transurethral|
|intrauterine|4269621|intrauterine|
|intra|4171047|intra|
|intravenous|4171047|intravenous|
|intravenous (central)|4170113|intravenous central|
|intraventricular|4222259|intraventricular route - cardiac|
|intravesical|4186838|intravesical|
|intraviteal|4302785|intravitreal|
|intravitreal|4302785|intravitreal|
|irrigation|0|irrigation|
|jejunostomy|4133177|jejunostomy|
|left ear|4023156|otic|
|left eye|40549429|ocular|
|line lock|0|line lock|
|local infiltration|37397638|infiltrationr|
|nasal|4262914|nasal|
|nasogastric|4132711|nasogastric|
|nasojejunal|4305834|nasojejunal|
|nebulised inhalation|40486069|respiratory tract|
|oral|4132161|oral|
|orogastric|4303795|orogastric|
|orojejunal|4133177|jejunostomy|
|oromucosal|4186839|oromucosal|
|paravertebral|4170267|paravertebral|
|patient-controlled epidural analgesia|4225555|epidural|
|patient-controlled intravenous analgesia|4171047|intravenous|
|per rectum|4290759|rectal|
|regional analgesia|0|regional analgesia|
|right ear|4023156|otic|
|right eye|40549429|ocular|
|rinse|4263689|topical|
|soak|4263689|topical|
|soap|4263689|topical|
|subconjunctival|4163770|subconjunctival|
|subcutaneous|4142048|subcutaneous|
|subdermal|4142048|subcutaneous|
|sublingual|4292110|sublingual|
|topical|4263689|topical|
|transdermal|4262099|transdermal|
|transurethral|4305382|transurethral|
|vaginal|4057765|vaginal|
|via cvvhd|0|via cvvhd|
|transmucosal|0|transmucosal|
|shampoo|0|shampoo|

Notes
* [OMOP Routes](https://athena.ohdsi.org/search-terms/terms?domain=Route&standardConcept=Standard&page=1&pageSize=500&query=&boosts

* `rxroute` The route of drug administration 

```sql
select
	patient_identifier_Value,
	beg_dt_tm,
	end_dt_tm,
	lower(replace(catalog, 'zzz', '')) as catalog,
	lower(order_mnemonic) as order_mnemonic,
	order_detail_display_line,
	lower(rxroute) as rxroute,
	strengthdoseunit,
	strengthdose,
	EVENT_ID
from ##duckdb_source##
where concept_identifier is null or
TRY_CAST(TRIM(concept_identifier) AS INTEGER) = 0
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20route_concept_id%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
Source column  `rxroute`.
Prescribing Drug Routes to OMOP Condition Concept IDs


|rxroute|route_concept_id|notes|
|------|-----|-----|
|affected eye(s)|40549429|ocular|
|anal|4290759|rectal|
|bath|4263689|topical|
|both ears|4023156|otic|
|both eyes|40549429|ocular|
|buccal|4181897|buccal|
|caudal|4220455|caudal|
|chewed|4132161|oral|
|dental|4163765|dental|
|endotracheal|40491832|transtracheal|
|enteral feed|4167540|enteral|
|epidural|4225555|epidural|
|flush|0|flush|
|gastrojejunostomy|4133177|jejunostomy|
|gastrostomy|4132254|gastrostomy|
|gingival|4156704|gingival|
|handihaler|40486069|respiratory tract|
|inhalation|40486069|respiratory tract|
|intraarterial|4240824|intra-arterial|
|intraarticular|4006860|intra-articular|
|intrabiliary|4223965|intrabiliary|
|intracameral|4303409|intracameral|
|intracardiac|4156705|intracardiac|
|intracavernosal|37174549|intracorporus cavernosum|
|intradermal|4156706|intradermal|
|intradiscal|4163769|intradiscal|
|intralesional|4157758|intralesional|
|intralymphatic|4157759|intralymphatic|
|intramuscular|4302612|intramuscular|
|intramyometrial|4168038|intramyometrial|
|intraocular|4157760|intraocular|
|intraosseous|4213522|intraosseous|
|intraperitoneal|4243022|intraperitoneal|
|intrapleural|4156707|intrapleural|
|intrathecal|4217202|intrathecal|
|intratracheal|4229543|intratracheal|
|intraurethral|4305382|transurethral|
|intrauterine|4269621|intrauterine|
|intra|4171047|intra|
|intravenous|4171047|intravenous|
|intravenous (central)|4170113|intravenous central|
|intraventricular|4222259|intraventricular route - cardiac|
|intravesical|4186838|intravesical|
|intraviteal|4302785|intravitreal|
|intravitreal|4302785|intravitreal|
|irrigation|0|irrigation|
|jejunostomy|4133177|jejunostomy|
|left ear|4023156|otic|
|left eye|40549429|ocular|
|line lock|0|line lock|
|local infiltration|37397638|infiltrationr|
|nasal|4262914|nasal|
|nasogastric|4132711|nasogastric|
|nasojejunal|4305834|nasojejunal|
|nebulised inhalation|40486069|respiratory tract|
|oral|4132161|oral|
|orogastric|4303795|orogastric|
|orojejunal|4133177|jejunostomy|
|oromucosal|4186839|oromucosal|
|paravertebral|4170267|paravertebral|
|patient-controlled epidural analgesia|4225555|epidural|
|patient-controlled intravenous analgesia|4171047|intravenous|
|per rectum|4290759|rectal|
|regional analgesia|0|regional analgesia|
|right ear|4023156|otic|
|right eye|40549429|ocular|
|rinse|4263689|topical|
|soak|4263689|topical|
|soap|4263689|topical|
|subconjunctival|4163770|subconjunctival|
|subcutaneous|4142048|subcutaneous|
|subdermal|4142048|subcutaneous|
|sublingual|4292110|sublingual|
|topical|4263689|topical|
|transdermal|4262099|transdermal|
|transurethral|4305382|transurethral|
|vaginal|4057765|vaginal|
|via cvvhd|0|via cvvhd|
|transmucosal|0|transmucosal|
|shampoo|0|shampoo|

Notes
* [OMOP Routes](https://athena.ohdsi.org/search-terms/terms?domain=Route&standardConcept=Standard&page=1&pageSize=500&query=&boosts

* `rxroute` The route of drug administration 

```sql
select
	patient_identifier_Value,
	beg_dt_tm,
	end_dt_tm,
	order_detail_display_line,
	order_mnemonic,
	lower(rxroute) as rxroute,
	strengthdoseunit,
	strengthdose,
	concept_identifier,
	EVENT_ID
from ##duckdb_source##
where concept_identifier is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20route_concept_id%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
