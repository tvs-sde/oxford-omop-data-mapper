---
layout: default
title: device_source_concept_id
parent: DeviceExposure
grand_parent: Transformation Documentation
has_toc: false
---
# device_source_concept_id
### SUS OP Device Exposure
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
	select
		distinct
		op.SUSgeneratedspellID,
		op.NHSNumber,
		op.AppointmentDate,
		op.AppointmentTime,
		p.ProcedureOPCS as PrimaryProcedure
	from omop_staging.sus_OP op
		inner join omop_staging.sus_OP_OPCSProcedure p
		on op.MessageId = p.MessageId
	where NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20SUS%20OP%20Device%20Exposure%20mapping){: .btn }
### SUS CCMDS Device Exposure
Source column  `CriticalCareActivityCode`.
CCMDS Critical Care Activity Code Device Concept IDs


|CriticalCareActivityCode|device_source_concept_id|notes|
|------|-----|-----|
|1|4107141|Respiratory support via a tracheal tube (Respiratory support via a tracheal tube provided)|
|2|45761109|Nasal Continuous Positive Airway Pressure (nCPAP) (PATIENT receiving nCPAP for any part of the day)|
|5|45757846|Peritoneal Dialysis (PATIENT received Peritoneal Dialysis)|
|7|4209766|Parenteral Nutrition (PATIENT receiving Parenteral Nutrition (amino acids +/- lipids))|
|9|45759341|Oxygen Therapy|
|11|4121351|Care of an intra-arterial catheter or chest drain (PATIENT receiving care of an intra-arterial catheter or chest drain)|
|13|4229159|Tracheostomy cared for by nursing staff (PATIENT receiving care of tracheostomy cared for by nursing staff not by an external Carer (e.g. parent))|
|14|4229159|Tracheostomy cared for by external Carer (PATIENT receiving care of tracheostomy cared for by an external Carer (e.g. parent) not by a NURSE)|
|16|45758443|Haemofiltration (PATIENT received Haemofiltration)|
|26|36715434|Phototherapy (PATIENT receiving phototherapy)|
|51|4097216|Invasive ventilation via endotracheal tube|
|52|4044008|Invasive ventilation via tracheostomy tube|
|53|45768197|Non-invasive ventilatory support|
|55|4266238|Nasopharyngeal airway|
|56|45768197|Advanced ventilatory support (Jet or Oscillatory ventilation)|
|59|4219814|Acute severe asthma requiring intravenous bronchodilator therapy or continuous nebuliser|
|60|4126195|Arterial line monitoring|
|61|4030875|Cardiac pacing via an external box (pacing wires or external pads or oesophageal pacing)|
|62|4179206|Central venous pressure monitoring|
|63|4042177|Bolus intravenous fluids (> 80 ml/kg/day) in addition to maintenance intravenous fluids|
|73|40491434|Continuous pulse oximetry|
|80|4139525|Heated Humidified High Flow Therapy (HHHFT)|
|81|4124293|Presence of an umbilical venous line|

Notes
* [CRITICAL CARE ACTIVITY CODES](https://archive.datadictionary.nhs.uk/DD%20Release%20May%202024/attributes/critical_care_activity_code.html)
* [OMOP Devices](https://athena.ohdsi.org/search-terms/terms?domain=Device&invalidReason=Valid&standardConcept=Standard&page=1&pageSize=500&query=)

* `CriticalCareActivityCode` Used to look up the Device code. [CRITICAL CARE ACTIVITY CODE](https://www.datadictionary.nhs.uk/data_elements/critical_care_activity_code.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.HospitalProviderSpellNumber,
				cc.CriticalCareStartDate as DeviceExposureStartDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as DeviceExposureStartTime,
				coalesce(cc.CriticalCarePeriodDischargeDate, cc.EventDate) as DeviceExposureEndDate,
				coalesce(cc.CriticalCarePeriodDischargeTime, '00:00:00') as DeviceExposureEndTime,
				d.CriticalCareActivityCode as CriticalCareActivityCode
		from omop_staging.sus_CCMDS_CriticalCareActivityCode d
		inner join omop_staging.sus_CCMDS cc on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and d.CriticalCareActivityCode not in('3','4','6','8','10','12','15','21','22','23','24','25','27','28','29','50','57','58','64','65','66','67','68','69','70','71','72','74','82','83','87','99')

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20SUS%20CCMDS%20Device%20Exposure%20mapping){: .btn }
### SUS APC Procedure Occurrence
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select
	distinct
		apc.HospitalProviderSpellNumber,
		apc.NHSNumber,
		p.ProcedureDateOPCS as PrimaryProcedureDate,
		p.ProcedureOPCS as PrimaryProcedure
from omop_staging.sus_APC apc
	inner join omop_staging.sus_OPCSProcedure p
		on apc.MessageId = p.MessageId
where NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Device Exposure
Source column  `PrimaryProcedure`.
Accident and Emergency Treatment to OMOP Procedure Concept IDs


|PrimaryProcedure|device_source_concept_id|notes|
|------|-----|-----|
|01|4080499|Dressing|
|011|4080499|Dressing - dressing minor wound/burn/eye|
|012|4080499|Dressing - dressing major wound/burn|
|02|4080807|Bandage|
|03|4147691|Sutures|
|031|4147691|Sutures - primary sutures|
|032|4147691|Sutures - secondary/complex suture|
|033|4147691|Sutures - removal of sutures/clips|
|04|42538257|Wound Closure|
|041|4074344|Wound Closure - steristrips|
|042|4141971|Wound Closure - wound glue|
|043|42538257|Wound Closure - other (e.g. clips)|
|05|4232206|Plaster of Paris|
|051|4108844|Plaster of Paris - application|
|052|4078743|Plaster of Paris - removal|
|06|4194049|Splint|
|08|4032408|Removal|
|09|4080504|Physiotherapy|
|091|4080504|Physiotherapy - strapping, ultra sound treatment, short wave diathermy, manipulation|
|092|4218040|Physiotherapy - gait re-education, falls prevention|
|10|4190331|Manipulation|
|101|4042533|Manipulation - manipulation of upper limb fracture|
|102|42709780|Manipulation - manipulation of lower limb fracture|
|103|4190331|Manipulation - manipulation of dislocation|
|11|4211374|I&D|
|12|4311035|IV Cannula|
|13|4041656|Central Line|
|14|4178105|Irrigation|
|15|4202832|Intubation|
|16|44782942|Chest Drain|
|17|4074328|Urinary Catheter|
|18|4180456|Defibrillation|
|181|4180456|Defibrillation - defibrillation|
|182|4180456|Defibrillation - external pacing|
|19|4205502|CPR|
|20|46273093|Minor Surgery|
|21|4304206|Observation|
|22|4172321|Guidance|
|221|4172321|Guidance - written|
|222|4172321|Guidance - verbal|
|23|4160439|Anaesthesia|
|231|4174669|Anaesthesia - general anaesthetic|
|232|4303995|Anaesthesia - local anaesthetic|
|233|4117443|Anaesthesia - regional block|
|234|4140470|Anaesthesia - entonox|
|235|4219502|Anaesthesia - sedation|
|236|4160439|Anaesthesia - other|
|24|4293740|Tetanus|
|241|4293740|Tetanus - immune|
|242|4293740|Tetanus - tetanus toxoid course|
|243|4293740|Tetanus - tetanus toxoid booster|
|244|4037789|Tetanus - human immunoglobulin|
|245|4250328|Tetanus - combined tetanus/diphtheria course|
|246|4133518|Tetanus - combined tetanus/diphtheria booster|
|25|44790388|Nebuliser|
|28|4085113|Thrombolysis|
|281|4018703|Thrombolysis - streptokinase parenteral thrombolysis|
|282|4085113|Thrombolysis - recombinant|
|283|4241698|Thrombolysis - plasminogen activator|
|29|4088217|Parenteral Drugs|
|291|4161519|Parenteral Drugs - intravenous drug, e.g. stat/bolus|
|292|4030886|Parenteral Drugs - intravenous infusion|
|30|4254901|Vital Signs|
|31|4118442|Burns Review|
|32|4079701|X-ray Review|
|33|4295944|Fracture Review|
|34|4075964|Wound Cleaning|
|35|44793314|Dressing/Wound Review|
|36|4180243|Sling|
|37|4262407|Epistaxis Control|
|38|4092976|Nasal Airway|
|39|4339620|Oral Airway|
|40|4239130|Supplemental Oxygen|
|41|4306204|Positive Pressure|
|42|4213288|Arterial Line|
|43|763496|Infusion Fluids|
|44|4024656|Blood Transfusion|
|45|4149930|Pericardiocentesis|
|46|4080549|Lumbar Puncture|
|47|4170811|Joint Aspiration|
|48|4083710|Minor Plastic|
|49|4086432|Rewarming|
|50|4086433|Cooling|
|51|4162585|Medication|
|511|4123242|Medication - oral|
|512|4298276|Medication - intra-muscular|
|513|4303435|Medication - subcutaneous|
|514|4302260|Medication - per rectum|
|515|4123242|Medication - sublingual|
|516|4235706|Medication - intra-nasal|
|517|4021805|Medication - eye drops|
|518|4334396|Medication - ear drops|
|519|4075356|Medication - topical skin cream|
|52|4261887|OT|
|521|4261887|OT - OT functional assessment|
|522|4013690|OT - OT activities of daily living equipment provision|
|53|4083010|Walking Aid Loan|
|54|44791868|Social Work|
|55|4148277|Eye|
|551|4148277|Eye - orthoptic exercises|
|552|4162096|Eye - laser of retina/iris or posterior capsule|
|553|4259619|Eye - retrobulbar injection|
|554|4161695|Eye - epilation of lashes|
|555|4252594|Eye - subconjunctival injection|
|56|4305000|Dental|
|57|4052492|Prescription|
|27|0|Not Mappable|
|99|0|Not Mappable|

Notes
* [ACCIDENT and EMERGENCY CLINICAL CODES](https://archive.datadictionary.nhs.uk/DD%20Release%20September%202020/supporting_information/accident_and_emergency_treatment_tables.html)
* [OMOP Procedures](https://athena.ohdsi.org/search-terms/terms?domain=Procedure&invalidReason=Valid&standardConcept=Standard&vocabulary=SNOMED&page=1&pageSize=15&query=)

* `PrimaryProcedure` 
			ACCIDENT AND EMERGENCY TREATMENT is a six character code, comprising:
				Condition	n2 (see Treatment Table below)
				Sub-Analysis	n1 (see Sub-analysis Table below)
				Local use	up to an3
			 [ACCIDENT and EMERGENCY CLINICAL CODES]()

```sql
	select
		distinct
			ae.AEAttendanceNumber,
			ae.NHSNumber,
			ae.CDSActivityDate as PrimaryProcedureDate,
			p.AccidentAndEmergencyTreatment as PrimaryProcedure
	from omop_staging.sus_AE ae
		inner join omop_staging.sus_AE_treatment p
			on AE.MessageId = p.MessageId
	where NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20SUS%20AE%20Procedure%20Device%20Exposure%20mapping){: .btn }
### SUS AE Investigation Device Exposure
Source column  `AccidentAndEmergencyInvestigation`.
Lookup discharge destination concept.


|AccidentAndEmergencyInvestigation|device_source_concept_id|notes|
|------|-----|-----|
|01|45768233|X-ray|
|02|45768113|Electrocardiograph|
|08|45768357|Microscope (histology)|
|10|45768281|Ultrasound|
|11|4234381|Magnetic Resonance Imaging (MRI)|
|12|45762714|Computerised Tomography (CT)|
|09|45762714|Computerised Tomography (CT)|
|19|618883|Blood culture bottle|


* `AccidentAndEmergencyInvestigation` A broad coding of types of investigation which may be requested to assist with diagnosis as a result of Accident and Emergency Attendances. [ACCIDENT AND EMERGENCY INVESTIGATION]()

```sql
	select
		distinct
		ae.AEAttendanceNumber,
		ae.NHSNumber,
		coalesce(ae.ArrivalDate, ae.CDSActivityDate) as StartDate,
		coalesce(ae.ArrivalTime, '000000') as StartTime,
		coalesce(ae.AEDepartureDate, ae.AEAttendanceConclusionDate) as EndDate,
		coalesce(ae.AEDepartureTime, ae.AEAttendanceConclusionTime, '000000') as EndTime,
		i.AccidentAndEmergencyInvestigation
	from omop_staging.sus_AE_investigation i
		inner join omop_staging.sus_AE ae
			on i.MessageId = ae.MessageId
	where ae.NHSNumber is not null
	and i.AccidentAndEmergencyInvestigation in ('01', '02', '08', '09', '10', '11', '12', '19')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20SUS%20AE%20Investigation%20Device%20Exposure%20mapping){: .btn }
### Oxford Device Exposure
Source column  `SuppliedCode`.
Resolve Snomed codes to OMOP concepts.

* `SuppliedCode`  

```sql
select
	distinct
		d.NHSNumber,
		e.EventDate,
		e.SuppliedCode
from omop_staging.oxford_gp_event e
	inner join omop_staging.oxford_gp_demographic d
		on e.PatientIdentifier = d.PatientIdentifier
order by
	d.NHSNumber,
	e.EventDate,
	e.SuppliedCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_source_concept_id%20field%20Oxford%20Device%20Exposure%20mapping){: .btn }
