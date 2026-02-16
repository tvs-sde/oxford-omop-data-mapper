---
layout: default
title: specialty_concept_id
parent: Provider
grand_parent: Transformation Documentation
has_toc: false
---
# specialty_concept_id
### SUS Outpatient Provider
Source column  `MainSpecialtyCode`.
Lookup provider concept.


|MainSpecialtyCode|specialty_concept_id|notes|
|------|-----|-----|
|100|38004447|General Surgery|
|101|38004474|Urology|
|107|38004496|Vascular Surgery|
|110|38003915|Trauma and Orthopedics|
|120|0|Ear Nose and Throat|
|130|38004463|Ophthalmology|
|140|38004464|Oral Surgery|
|141|44777671|Restorative Dentistry|
|142|38003677|Pediatric Dentistry|
|143|44777673|Orthodontics|
|145|38003826|Oral and Maxillofacial Surgery|
|146|38003674|Endodontics|
|147|38003678|Periodontics|
|148|38003679|Prosthodontics|
|149|903261|Surgical Dentistry|
|150|38004459|Neurosurgery|
|160|38004467|Plastic Surgery|
|170|0|Cardiothoracic Surgery|
|171|45756819|Pediatric Surgery|
|180|38004510|Emergency Medicine|
|190|0|Anesthetics|
|192|0|Intensive Care Medicine|
|200|0|Aviation and Space Medicine|
|300|38004456|General Internal Medicine|
|301|38004455|Gastroenterology|
|302|45756771|Endocrinology and Diabetes|
|303|38004501|Clinical Hematology|
|304|0|Clinical Physiology|
|305|38004025|Clinical Pharmacology|
|310|0|Audio Vestibular Medicine|
|311|45756760|Clinical Genetics|
|313|44777719|Clinical Immunology|
|314|38003967|Rehabilitation Medicine|
|315|0|Palliative Medicine|
|317|38003830|Allergy|
|320|38004451|Cardiology|
|321|45756805|Pediatric Cardiology|
|325|903263|Sport and Exercise Medicine|
|326|903264|Acute Internal Medicine|
|330|38004452|Dermatology|
|340|0|Respiratory Medicine|
|350|38004484|Infectious Diseases|
|352|44777687|Tropical Medicine|
|360|0|Genitourinary Medicine|
|361|0|Renal Medicine|
|370|38004507|Medical Oncology|
|371|38004476|Nuclear Medicine|
|400|38004458|Neurology|
|401|45756763|Clinical Neurophysiology|
|410|38004491|Rheumatology|
|420|38004477|Pediatrics|
|421|44777781|Pediatric Neurology|
|430|38004478|Geriatric Medicine|
|450|0|Dental Medicine|
|451|903265|Special Care Dentistry|
|460|38004463|Medical Ophthalmology|
|501|38003905|Obstetrics|
|502|38003902|Gynecology|
|504|903266|Community Sexual and Reproductive Health|
|560|44777784|Midwifery|
|600|38004446|General Medical Practice|
|601|38003675|General Dental Practice|
|700|0|Learning Disability|
|710|0|Adult Mental Illness|
|711|45756756|Child and Adolescent Psychiatry|
|712|45756775|Forensic Psychiatry|
|713|0|Medical Psychotherapy|
|715|38004470|Old Age Psychiatry|
|800|38004507|Clinical Oncology|
|810|45756825|Radiology|
|820|38004466|General Pathology|
|821|44777706|Blood Transfusion|
|822|45756796|Chemical Pathology|
|823|38004501|Hematology|
|824|44777708|Histopathology|
|830|38003930|Immunopathology|
|831|903269|Medical Microbiology and Virology|
|833|44777684|Medical Microbiology|
|834|903269|Medical Virology|
|900|44777712|Community Medicine|
|901|44777713|Occupational Medicine|
|902|0|Community Health Services Dental|
|903|903271|Public Health Medicine|
|904|38003673|Public Health Dental|
|950|0|Nursing|
|960|0|Allied Health Professional|

Notes
* [NHS MainSpecialtyCode](https://www.datadictionary.nhs.uk/attributes/main_specialty_code.html#attribute_main_specialty_code.data_elements)
* [OMOP Providers](https://athena.ohdsi.org/search-terms/terms?domain=Provider&standardConcept=Standard&conceptClass=Physician+Specialty&page=1&pageSize=15&query=General+Dental+Practice&boosts)

* `MainSpecialtyCode` A unique code identifying each MAIN SPECIALTY designated by Royal Colleges. [MAIN SPECIALTY CODE]()

```sql
with counts as (
	select 
		ConsultantCode,
		MainSpecialtyCode,
		count(*) as SpecialtyFrequency,
		row_number() over (partition by ConsultantCode order by count(*) desc, MainSpecialtyCode
) rnk
from (
	select
	ConsultantCode,
	MainSpecialtyCode
	from omop_staging.sus_OP 
	where MainSpecialtyCode is not null
	and ConsultantCode is not null
) grouped
	group by ConsultantCode, MainSpecialtyCode
)
select 
	ConsultantCode,
	MainSpecialtyCode
from counts
where rnk = 1
order by
	ConsultantCode,
	MainSpecialtyCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20specialty_concept_id%20field%20SUS%20Outpatient%20Provider%20mapping){: .btn }
### SUS Inpatient Provider
Source column  `MainSpecialtyCode`.
Lookup provider concept.


|MainSpecialtyCode|specialty_concept_id|notes|
|------|-----|-----|
|100|38004447|General Surgery|
|101|38004474|Urology|
|107|38004496|Vascular Surgery|
|110|38003915|Trauma and Orthopedics|
|120|0|Ear Nose and Throat|
|130|38004463|Ophthalmology|
|140|38004464|Oral Surgery|
|141|44777671|Restorative Dentistry|
|142|38003677|Pediatric Dentistry|
|143|44777673|Orthodontics|
|145|38003826|Oral and Maxillofacial Surgery|
|146|38003674|Endodontics|
|147|38003678|Periodontics|
|148|38003679|Prosthodontics|
|149|903261|Surgical Dentistry|
|150|38004459|Neurosurgery|
|160|38004467|Plastic Surgery|
|170|0|Cardiothoracic Surgery|
|171|45756819|Pediatric Surgery|
|180|38004510|Emergency Medicine|
|190|0|Anesthetics|
|192|0|Intensive Care Medicine|
|200|0|Aviation and Space Medicine|
|300|38004456|General Internal Medicine|
|301|38004455|Gastroenterology|
|302|45756771|Endocrinology and Diabetes|
|303|38004501|Clinical Hematology|
|304|0|Clinical Physiology|
|305|38004025|Clinical Pharmacology|
|310|0|Audio Vestibular Medicine|
|311|45756760|Clinical Genetics|
|313|44777719|Clinical Immunology|
|314|38003967|Rehabilitation Medicine|
|315|0|Palliative Medicine|
|317|38003830|Allergy|
|320|38004451|Cardiology|
|321|45756805|Pediatric Cardiology|
|325|903263|Sport and Exercise Medicine|
|326|903264|Acute Internal Medicine|
|330|38004452|Dermatology|
|340|0|Respiratory Medicine|
|350|38004484|Infectious Diseases|
|352|44777687|Tropical Medicine|
|360|0|Genitourinary Medicine|
|361|0|Renal Medicine|
|370|38004507|Medical Oncology|
|371|38004476|Nuclear Medicine|
|400|38004458|Neurology|
|401|45756763|Clinical Neurophysiology|
|410|38004491|Rheumatology|
|420|38004477|Pediatrics|
|421|44777781|Pediatric Neurology|
|430|38004478|Geriatric Medicine|
|450|0|Dental Medicine|
|451|903265|Special Care Dentistry|
|460|38004463|Medical Ophthalmology|
|501|38003905|Obstetrics|
|502|38003902|Gynecology|
|504|903266|Community Sexual and Reproductive Health|
|560|44777784|Midwifery|
|600|38004446|General Medical Practice|
|601|38003675|General Dental Practice|
|700|0|Learning Disability|
|710|0|Adult Mental Illness|
|711|45756756|Child and Adolescent Psychiatry|
|712|45756775|Forensic Psychiatry|
|713|0|Medical Psychotherapy|
|715|38004470|Old Age Psychiatry|
|800|38004507|Clinical Oncology|
|810|45756825|Radiology|
|820|38004466|General Pathology|
|821|44777706|Blood Transfusion|
|822|45756796|Chemical Pathology|
|823|38004501|Hematology|
|824|44777708|Histopathology|
|830|38003930|Immunopathology|
|831|903269|Medical Microbiology and Virology|
|833|44777684|Medical Microbiology|
|834|903269|Medical Virology|
|900|44777712|Community Medicine|
|901|44777713|Occupational Medicine|
|902|0|Community Health Services Dental|
|903|903271|Public Health Medicine|
|904|38003673|Public Health Dental|
|950|0|Nursing|
|960|0|Allied Health Professional|

Notes
* [NHS MainSpecialtyCode](https://www.datadictionary.nhs.uk/attributes/main_specialty_code.html#attribute_main_specialty_code.data_elements)
* [OMOP Providers](https://athena.ohdsi.org/search-terms/terms?domain=Provider&standardConcept=Standard&conceptClass=Physician+Specialty&page=1&pageSize=15&query=General+Dental+Practice&boosts)

* `MainSpecialtyCode` A unique code identifying each MAIN SPECIALTY designated by Royal Colleges. [MAIN SPECIALTY CODE]()

```sql
with counts as (
	select 
		ConsultantCode,
		MainSpecialtyCode,
		count(*) as SpecialtyFrequency,
		row_number() over (partition by ConsultantCode order by count(*) desc, 
		MainSpecialtyCode
) 
rnk
from 
(
	select
		ConsultantCode,
		MainSpecialtyCode
	from omop_staging.sus_APC
	where MainSpecialtyCode is not null
		and ConsultantCode is not null
) grouped
	group by ConsultantCode, MainSpecialtyCode
)
select 
	ConsultantCode,
	MainSpecialtyCode
from counts
where rnk = 1
order by 
	ConsultantCode,
	MainSpecialtyCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20specialty_concept_id%20field%20SUS%20Inpatient%20Provider%20mapping){: .btn }
### SACT Provider
Source column  `Consultant_Specialty_Code`.
Lookup provider concept.


|Consultant_Specialty_Code|specialty_concept_id|notes|
|------|-----|-----|
|100|38004447|General Surgery|
|101|38004474|Urology|
|107|38004496|Vascular Surgery|
|110|38003915|Trauma and Orthopedics|
|120|0|Ear Nose and Throat|
|130|38004463|Ophthalmology|
|140|38004464|Oral Surgery|
|141|44777671|Restorative Dentistry|
|142|38003677|Pediatric Dentistry|
|143|44777673|Orthodontics|
|145|38003826|Oral and Maxillofacial Surgery|
|146|38003674|Endodontics|
|147|38003678|Periodontics|
|148|38003679|Prosthodontics|
|149|903261|Surgical Dentistry|
|150|38004459|Neurosurgery|
|160|38004467|Plastic Surgery|
|170|0|Cardiothoracic Surgery|
|171|45756819|Pediatric Surgery|
|180|38004510|Emergency Medicine|
|190|0|Anesthetics|
|192|0|Intensive Care Medicine|
|200|0|Aviation and Space Medicine|
|300|38004456|General Internal Medicine|
|301|38004455|Gastroenterology|
|302|45756771|Endocrinology and Diabetes|
|303|38004501|Clinical Hematology|
|304|0|Clinical Physiology|
|305|38004025|Clinical Pharmacology|
|310|0|Audio Vestibular Medicine|
|311|45756760|Clinical Genetics|
|313|44777719|Clinical Immunology|
|314|38003967|Rehabilitation Medicine|
|315|0|Palliative Medicine|
|317|38003830|Allergy|
|320|38004451|Cardiology|
|321|45756805|Pediatric Cardiology|
|325|903263|Sport and Exercise Medicine|
|326|903264|Acute Internal Medicine|
|330|38004452|Dermatology|
|340|0|Respiratory Medicine|
|350|38004484|Infectious Diseases|
|352|44777687|Tropical Medicine|
|360|0|Genitourinary Medicine|
|361|0|Renal Medicine|
|370|38004507|Medical Oncology|
|371|38004476|Nuclear Medicine|
|400|38004458|Neurology|
|401|45756763|Clinical Neurophysiology|
|410|38004491|Rheumatology|
|420|38004477|Pediatrics|
|421|44777781|Pediatric Neurology|
|430|38004478|Geriatric Medicine|
|450|0|Dental Medicine|
|451|903265|Special Care Dentistry|
|460|38004463|Medical Ophthalmology|
|501|38003905|Obstetrics|
|502|38003902|Gynecology|
|504|903266|Community Sexual and Reproductive Health|
|560|44777784|Midwifery|
|600|38004446|General Medical Practice|
|601|38003675|General Dental Practice|
|700|0|Learning Disability|
|710|0|Adult Mental Illness|
|711|45756756|Child and Adolescent Psychiatry|
|712|45756775|Forensic Psychiatry|
|713|0|Medical Psychotherapy|
|715|38004470|Old Age Psychiatry|
|800|38004507|Clinical Oncology|
|810|45756825|Radiology|
|820|38004466|General Pathology|
|821|44777706|Blood Transfusion|
|822|45756796|Chemical Pathology|
|823|38004501|Hematology|
|824|44777708|Histopathology|
|830|38003930|Immunopathology|
|831|903269|Medical Microbiology and Virology|
|833|44777684|Medical Microbiology|
|834|903269|Medical Virology|
|900|44777712|Community Medicine|
|901|44777713|Occupational Medicine|
|902|0|Community Health Services Dental|
|903|903271|Public Health Medicine|
|904|38003673|Public Health Dental|
|950|0|Nursing|
|960|0|Allied Health Professional|

Notes
* [NHS MainSpecialtyCode](https://www.datadictionary.nhs.uk/attributes/main_specialty_code.html#attribute_main_specialty_code.data_elements)
* [OMOP Providers](https://athena.ohdsi.org/search-terms/terms?domain=Provider&standardConcept=Standard&conceptClass=Physician+Specialty&page=1&pageSize=15&query=General+Dental+Practice&boosts)

* `Consultant_Specialty_Code` A unique code identifying each MAIN SPECIALTY designated by Royal Colleges. [CONSULTANT SPECIALTY CODE]()

```sql
	select distinct 
		Consultant_GMC_Code, 
		Consultant_Specialty_Code
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20specialty_concept_id%20field%20SACT%20Provider%20mapping){: .btn }
