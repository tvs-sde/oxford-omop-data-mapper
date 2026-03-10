---
layout: default
title: procedure_source_concept_id
parent: ProcedureOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# procedure_source_concept_id
### SUS Outpatient Procedure Occurrence
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with results as
(
	select
		distinct
			op.GeneratedRecordIdentifier,
			op.NHSNumber,
			op.AppointmentDate,
			op.AppointmentTime,
			p.ProcedureOPCS as PrimaryProcedure
	from omop_staging.sus_OP op
		inner join omop_staging.sus_OP_OPCSProcedure p
		on op.MessageId = p.MessageId
	where NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
)
select *
from results
order by 
	GeneratedRecordIdentifier,
	NHSNumber,
	AppointmentDate, 
	AppointmentTime,
	PrimaryProcedure
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20SUS%20Outpatient%20Procedure%20Occurrence%20mapping){: .btn }
### SUS CCMDS Procedure Occurrence
Source column  `ProcedureSourceValue`.
CCMDS Critical Care Activity Code Concept IDs


|ProcedureSourceValue|procedure_source_concept_id|notes|
|------|-----|-----|
|1|4161831|Respiratory support via a tracheal tube (Respiratory support via a tracheal tube provided)|
|2|4165535|Nasal Continuous Positive Airway Pressure (nCPAP) (PATIENT receiving nCPAP for any part of the day)|
|3|4301351|Surgery (PATIENT received surgery)|
|4|4193981|Exchange Transfusion (PATIENT received exchange transfusion)|
|5|4324124|Peritoneal Dialysis (PATIENT received Peritoneal Dialysis)|
|6|44806352|Continuous infusion of inotrope, pulmonary vasodilator or prostaglandin (PATIENT received a continuous infusion of an inotrope, vasodilator (includes pulmonary vasodilators) or prostaglandin|
|7|4021169|Parenteral Nutrition (PATIENT receiving Parenteral Nutrition (amino acids +/- lipids))|
|8|4273223|Convulsions (PATIENT having convulsions requiring treatment)|
|9|4239130|Oxygen Therapy|
|10|46271806|Neonatal abstinence syndrome (PATIENT receiving drug treatment for neonatal abstinence (withdrawal) syndrome)|
|11|37395956|Care of an intra-arterial catheter or chest drain (PATIENT receiving care of an intra-arterial catheter or chest drain)|
|12|4050429|Dilution Exchange Transfusion (PATIENT received Dilution Exchange Transfusion)|
|13|4262010|Tracheostomy cared for by nursing staff (PATIENT receiving care of tracheostomy cared for by nursing staff not by an external Carer (e.g. parent))|
|14|4262010|Tracheostomy cared for by external Carer (PATIENT receiving care of tracheostomy cared for by an external Carer (e.g. parent) not by a NURSE)|
|15|4122478|Recurrent apnoea (PATIENT has recurrent apnoea needing frequent intervention, i.e. over 5 stimulations in 8 hours, or resuscitation with IPPV two or more times in 24 hours)|
|16|4050864|Haemofiltration (PATIENT received Haemofiltration)|
|21|4237490|Resident - Caring for Baby|
|22|4141651|Continuous monitoring|
|23|4165358|Intravenous glucose and electrolyte solutions (PATIENT being given intravenous glucose and electrolyte solutions)|
|24|4263536|Tube-fed (PATIENT being tube-fed)|
|25|618552|Barrier nursed (PATIENT being barrier nursed)|
|26|4151902|Phototherapy (PATIENT receiving phototherapy)|
|27|4301936|Special monitoring|
|28|4033847|Observations at regular intervals|
|29|4303434|Intravenous medication|
|50|4141651|Continuous electrocardiogram monitoring|
|51|37157166|Invasive ventilation via endotracheal tube|
|52|4337047|Invasive ventilation via tracheostomy tube|
|53|44791135|Non-invasive ventilatory support|
|55|4082245|Nasopharyngeal airway|
|56|4074666|Advanced ventilatory support (Jet or Oscillatory ventilation)|
|57|4061066|Upper airway obstruction requiring nebulised Epinephrine/ Adrenaline|
|58|4122478|Apnoea requiring intervention|
|59|46272934|Acute severe asthma requiring intravenous bronchodilator therapy or continuous nebuliser|
|60|4213288|Arterial line monitoring|
|61|4049990|Cardiac pacing via an external box (pacing wires or external pads or oesophageal pacing)|
|62|4322479|Central venous pressure monitoring|
|63|4161519|Bolus intravenous fluids (> 80 ml/kg/day) in addition to maintenance intravenous fluids|
|64|4232320|Cardio-pulmonary resuscitation (CPR)|
|65|4336747|Extracorporeal membrane oxygenation (ECMO) or Ventricular Assist Device (VAD) or aortic balloon pump|
|66|4120120|Haemodialysis|
|67|4052539|Plasma filtration or Plasma exchange|
|68|2000097|ICP-intracranial pressure monitoring|
|69|40756782|Intraventricular catheter or external ventricular drain|
|70|4080110|Diabetic ketoacidosis (DKA) requiring continuous infusion of insulin|
|71|4144062|Intravenous infusion of thrombolytic agent (limited to tissue plasminogen activator [tPA] and streptokinase)|
|72|44805305|Extracorporeal liver support using Molecular Absorbent Liver Recirculating System (MARS)|
|73|4262005|Continuous pulse oximetry|
|74|4222885|Patient nursed in single occupancy cubicle|
|80|37158406|Heated Humidified High Flow Therapy (HHHFT)|
|81|4051310|Presence of an umbilical venous line|
|82|4080110|Continuous infusion of insulin (PATIENT  receiving a continuous infusion of insulin)|
|83|4203429|Therapeutic hypothermia|
|87|4022139|Administration of intravenous (IV) blood products|
|96|4086422|intravenous infusion of sedative agent|

Notes
* [CRITICAL CARE ACTIVITY CODES](https://archive.datadictionary.nhs.uk/DD%20Release%20May%202024/attributes/critical_care_activity_code.html)
* [OMOP Procedures](https://athena.ohdsi.org/search-terms/terms?domain=Procedure&invalidReason=Valid&standardConcept=Standard&vocabulary=SNOMED&page=1&pageSize=15&query=)

* `ProcedureSourceValue` Used to look up the Procedure code. [CRITICAL CARE ACTIVITY CODE](https://www.datadictionary.nhs.uk/data_elements/critical_care_activity_code.html)

```sql
with results as
(
	select 
		distinct
			apc.NHSNumber,
			apc.GeneratedRecordIdentifier,
			cc.CriticalCareStartDate as ProcedureOccurrenceStartDate,
			coalesce(cc.CriticalCareStartTime, '00:00:00') as ProcedureOccurrenceStartTime,
			coalesce(cc.CriticalCarePeriodDischargeDate, cc.EventDate) as ProcedureOccurrenceEndDate,
			coalesce(cc.CriticalCarePeriodDischargeTime, '00:00:00') as ProcedureOccurrenceEndTime,
			d.CriticalCareActivityCode as ProcedureSourceValue
	from omop_staging.sus_CCMDS_CriticalCareActivityCode d
		inner join omop_staging.sus_CCMDS cc 
			on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc 
			on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
	where apc.NHSNumber is not null
		and d.CriticalCareActivityCode != '99'  -- No Defined Critical Care Activity
)
select *
from results
order by 
	NHSNumber,
	GeneratedRecordIdentifier,
	ProcedureOccurrenceStartDate, 
	ProcedureOccurrenceStartTime,
	ProcedureOccurrenceEndDate,
	ProcedureOccurrenceEndTime,
	ProcedureSourceValue

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20SUS%20CCMDS%20Procedure%20Occurrence%20mapping){: .btn }
### SUS APC Procedure Occurrence
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select
	distinct
		apc.GeneratedRecordIdentifier,
		apc.NHSNumber,
		p.ProcedureDateOPCS as PrimaryProcedureDate,
		p.ProcedureOPCS as PrimaryProcedure
from omop_staging.sus_APC apc
	inner join omop_staging.sus_OPCSProcedure p
		on apc.MessageId = p.MessageId
where NHSNumber is not null
order by
	apc.GeneratedRecordIdentifier,
	apc.NHSNumber,
	p.ProcedureDateOPCS,
	p.ProcedureOPCS
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Occurrence
Source column  `PrimaryProcedure`.
Accident and Emergency Treatment to OMOP Procedure Concept IDs


|PrimaryProcedure|procedure_source_concept_id|notes|
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
				ae.GeneratedRecordIdentifier,
				ae.NHSNumber,
				ae.CDSActivityDate as PrimaryProcedureDate,
				p.AccidentAndEmergencyTreatment as PrimaryProcedure
		from omop_staging.sus_AE ae
			inner join omop_staging.sus_AE_treatment p
				on AE.MessageId = p.MessageId
		where NHSNumber is not null
		order by
			ae.GeneratedRecordIdentifier,
			ae.NHSNumber,
			ae.CDSActivityDate,
			p.AccidentAndEmergencyTreatment
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20SUS%20AE%20Procedure%20Occurrence%20mapping){: .btn }
### Rtds Procedure Occurrence
Source column  `ProcedureCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureCode` OPCS Procedure Code []()

```sql
with records as (
	select
		PatientSer,
		ProcedureCode,
		ActualStartDateTime_s as Start_date,
		ActualEndDateTime_s as End_date
	from omop_staging.rtds_2a_attendances

	union

	select 
		PatientSer,
		ProcedureCode,
		Start_date,
		End_date
	from omop_staging.rtds_2b_plan
), records_with_patient as (
	select
		(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = r.PatientSer limit 1) as PatientId,
		r.*
	from records r
)
select distinct
	PatientId,
	ProcedureCode,
	Start_date as event_start_date,
	End_date as event_end_date
from records_with_patient
where PatientId is not null
	and regexp_matches(patientid, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Rtds%20Procedure%20Occurrence%20mapping){: .btn }
### Oxford Procedure Occurrence
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Oxford%20Procedure%20Occurrence%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs.@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    ProcedureDate,
    -- Procedure (OPCS): The OPCS-4 code identifying a patient procedure other than the primary procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    ProcedureOpcs
from ur
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    ProcedureDate,
    -- Primary Procedure (OPCS): The OPCS-4 code identifying the primary surgical procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    PrimaryProcedureOpcs
from ur
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureSnomedCt`.
Resolve Snomed codes to OMOP concepts.

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    -- Diagnostic Procedure (SNOMED CT): The SNOMED CT concept ID identifying the diagnostic procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    -- Diagnostic Procedure (OPCS): The OPCS-4 code identifying the diagnostic procedure carried out. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Procedure OPCS
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    ProcedureDate,
    -- Procedure (OPCS): The OPCS-4 code identifying a patient procedure other than the primary procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    ProcedureOPCS
from ur
where NhsNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    ProcedureDate,
    -- Primary Procedure (OPCS): The OPCS-4 code identifying the primary surgical procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    PrimaryProcedureOPCS
from ur
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ug as (
    select distinct
        -- NHS Number: Patient identifier, used to link to the person table.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        -- Procedure (OPCS): Secondary OPCS-4 procedure code(s), maps to procedure_source_value in procedure_occurrence.
        -- Multiple secondary procedures may exist per treatment. Will be mapped to a standard OMOP concept via OPCS-4 vocabulary lookup.
        -- This unnest covers both Treatment arrays and ProcedureOpcs arrays within each treatment.
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs,

        -- Procedure Date: The date the procedure was performed, maps to procedure_date in procedure_occurrence.
        -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
        -- Note: ProcedureOpcs unnests across both treatments and procedures within each treatment,
        -- while ProcedureDate only unnests across treatments. When multiple secondary procedures exist
        -- per treatment, the date association may need reconciliation in later ETL steps.
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from ug
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ug as (
    select distinct
        -- NHS Number: Patient identifier, used to link to the person table.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        -- Primary Procedure (OPCS): The primary OPCS-4 procedure code, maps to procedure_source_value in procedure_occurrence.
        -- Will be mapped to a standard OMOP concept in a later ETL step via OPCS-4 vocabulary lookup.
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs,

        -- Procedure Date: The date the procedure was performed, maps to procedure_date in procedure_occurrence.
        -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from ug
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureSnomedCt`.
Resolve Snomed codes to OMOP concepts.

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

    -- Diagnostic Procedure (SNOMED CT): The SNOMED CT concept ID for the diagnostic procedure, maps to procedure_source_value in procedure_occurrence.
    -- Will be mapped to a standard OMOP concept in a later ETL step via SNOMED CT vocabulary lookup.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt,

    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed, maps to procedure_date in procedure_occurrence.
    -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

    -- Diagnostic Procedure (OPCS): The OPCS-4 code for the diagnostic procedure, maps to procedure_source_value in procedure_occurrence.
    -- Will be mapped to a standard OMOP concept in a later ETL step via OPCS-4 vocabulary lookup.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs,

    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed, maps to procedure_date in procedure_occurrence.
    -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Procedure OPCS
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ug as (
    select distinct
        -- NHS Number: Patient identifier, used to link to the person table.
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        -- Procedure (OPCS): Secondary OPCS-4 procedure code(s), maps to procedure_source_value in procedure_occurrence.
        -- Multiple secondary procedures may exist per treatment. Will be mapped to a standard OMOP concept via OPCS-4 vocabulary lookup.
        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS,

        -- Procedure Date: The date the procedure was performed, maps to procedure_date in procedure_occurrence.
        -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
        -- Note: ProcedureOPCS unnests across procedure codes within a single treatment, while ProcedureDate unnests across treatments.
        -- When multiple secondary procedures exist per treatment, the date association may need reconciliation in later ETL steps.
        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NHSNumber,
    ProcedureOPCS,
    ProcedureDate
from ug
where NHSNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ug as (
    select distinct
        -- NHS Number: Patient identifier, used to link to the person table.
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        -- Primary Procedure (OPCS): The primary OPCS-4 procedure code, maps to procedure_source_value in procedure_occurrence.
        -- Will be mapped to a standard OMOP concept in a later ETL step via OPCS-4 vocabulary lookup.
        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS,

        -- Procedure Date: The date the procedure was performed, maps to procedure_date in procedure_occurrence.
        -- Currently in string format (CCYY-MM-DD), will be cast to date type in a later ETL step.
        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NHSNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from ug
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Procedure date associated with the surgery treatment record
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        -- Secondary OPCS procedure codes for the surgery (other than the primary procedure)
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from COSD
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Procedure date associated with the surgery treatment record
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        -- The primary OPCS procedure code for the surgery
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from COSD
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureSnomedCt`.
Resolve Snomed codes to OMOP concepts.

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. Will be mapped to procedure_source_value and used to derive procedure_concept_id via SNOMED-to-OMOP concept mapping in a later ETL step. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Date of the diagnostic procedure
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureDate'], recursive := true) as DiagnosticProcedureDate,
        -- The SNOMED CT concept ID used to identify the diagnostic procedure
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureSnomedCt.@code'], recursive := true) as DiagnosticProcedureSnomedCt
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DiagnosticProcedureDate,
    DiagnosticProcedureSnomedCt
from COSD
where NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Date of the diagnostic procedure
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureDate'], recursive := true) as DiagnosticProcedureDate,
        -- The OPCS code used to identify the diagnostic procedure
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureOpcs.@code'], recursive := true) as DiagnosticProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DiagnosticProcedureDate,
    DiagnosticProcedureOpcs
from COSD
where NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Procedure OPCS
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        -- Procedure date associated with the surgery treatment record
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        -- Secondary OPCS procedure codes for the surgery (other than the primary procedure)
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NHSNumber,
    ProcedureDate,
    ProcedureOPCS
from COSD
where NHSNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        -- Procedure date associated with the surgery treatment record
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        -- The primary OPCS procedure code for the surgery
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from COSD
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Procedure Opcs Procedure Date
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from sa
where NhsNumber is not null
  and ProcedureOpcs is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Primary Procedure Opcs Procedure Date
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from sa
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Procedure OPCS Procedure Date
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOPCS
from sa
where NhsNumber is not null
  and ProcedureOPCS is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Primary Procedure OPCS Procedure Date
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from sa
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Date the procedure was performed; sits at the same Surgery level as ProcedureOpcs
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        -- OPCS code(s) for secondary procedures; unnested because multiple procedures can exist per Surgery
        unnest(
            [
                [Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from lv
where NhsNumber is not null
  and ProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- OPCS code identifying the primary procedure carried out
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs,
    -- Date the procedure was performed, currently a string in CCYY-MM-DD format; will be cast to date in a later ETL step
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Procedure OPCS
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    -- OPCS code identifying a secondary (non-primary) procedure performed during the same care spell
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code' as ProcedureOPCS,
    -- Date the procedure was performed, currently a string in CCYY-MM-DD format; will be cast to date in a later ETL step
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_81
where type = 'LV'
  and NHSNumber is not null
  and ProcedureOPCS is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    -- OPCS code identifying the primary procedure carried out
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOPCS,
    -- Date the procedure was performed, currently a string in CCYY-MM-DD format; will be cast to date in a later ETL step
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_81
where type = 'LV'
  and NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lung as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from lung
where ProcedureOpcsCode is not null
and NhsNumber is not null
and ProcedureDate is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the main PROCEDURE (OPCS) undertaken by a PATIENT. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'LU'
  and NhsNumber is not null
  and ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Lung Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest ([[Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
  distinct
		NhsNumber,
		ProcedureDate,
		ProcedureOpcsCode
from lung
where ProcedureOpcsCode is not null
and NhsNumber is not null
and ProcedureDate is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V8%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Lung Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with Lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOPCS
  from omop_staging.cosd_staging_81
  where Type = 'LU'
)
select
      distinct
          ProcedureDate,
          NhsNumber,
          PrimaryProcedureOPCS
from Lung l
where l.ProcedureDate is not null
and l.PrimaryProcedureOPCS is not null
and l.NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    -- Procedure (OPCS): The OPCS-4 code identifying a patient procedure other than the primary procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' as ProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Procedure Date: The date the surgical procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    -- Primary Procedure (OPCS): The OPCS-4 code identifying the primary surgical procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureSnomedCt`.
Resolve Snomed codes to OMOP concepts.

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    -- Diagnostic Procedure (SNOMED CT): The SNOMED CT concept ID identifying the diagnostic procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
select distinct
    -- NHS Number: Patient identifier, used to link to the person table.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Diagnostic Procedure Date: The date the diagnostic procedure was performed. Will be cast to a date type in a later ETL step (expected format CCYY-MM-DD).
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    -- Diagnostic Procedure (OPCS): The OPCS-4 code identifying the diagnostic procedure. Will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
-- COSD v9.01 CT - Procedure Occurrence: Procedure (OPCS)
-- Extracts secondary surgical procedure OPCS codes and procedure date from Treatment/Surgery.
-- Uses CTE because Treatment and ProcedureOpcs are repeating elements requiring unnest.
-- Note: ProcedureOpcs can contain multiple codes per Surgery (ProcedureOpcs[*]),
-- while ProcedureDate is one per Surgery. The zip unnest may produce misaligned rows
-- when multiple OPCS codes exist per surgery; later ETL steps should validate alignment.

with ct as (
    select distinct
        -- NHS Number: unique patient identifier used to link to the OMOP person table.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        -- Procedure Date: the date the surgical procedure was performed, will be mapped to procedure_date (string to date conversion in later ETL step).
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,

        -- Procedure OPCS: OPCS-4 code for secondary (non-primary) procedures performed during surgery.
        -- Will be mapped to procedure_source_value and used to derive procedure_concept_id.
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from ct
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
-- COSD v9.01 CT - Procedure Occurrence: Primary Procedure (OPCS)
-- Extracts the primary surgical procedure OPCS code and procedure date from Treatment/Surgery.
-- Uses CTE because Treatment is a repeating element requiring unnest.

with ct as (
    select distinct
        -- NHS Number: unique patient identifier used to link to the OMOP person table.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        -- Procedure Date: the date the surgical procedure was performed, will be mapped to procedure_date (string to date conversion in later ETL step).
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,

        -- Primary Procedure OPCS: the OPCS-4 code for the primary procedure, will be mapped to procedure_source_value and used to derive procedure_concept_id.
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from ct
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CT Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
-- COSD v8 CT - Procedure Occurrence: Primary Procedure (OPCS)
-- Extracts the primary surgical procedure OPCS code and procedure date from CTYACoreTreatment/CTYACoreSurgeryAndOtherProcedures.
-- Uses CTE because CTYACoreTreatment is a repeating element requiring unnest.

with ct as (
    select distinct
        -- NHS Number: unique patient identifier used to link to the OMOP person table.
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        -- Procedure Date: the date the surgical procedure was performed, will be mapped to procedure_date (string to date conversion in later ETL step).
        unnest ([[Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CTYACoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.CTYA.CTYACore.CTYACoreTreatment[*].CTYACoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,

        -- Primary Procedure OPCS: the OPCS-4 code for the primary procedure, will be mapped to procedure_source_value and used to derive procedure_concept_id.
        unnest ([[Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CTYACoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.CTYA.CTYACore.CTYACoreTreatment[*].CTYACoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ct
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Secondary OPCS procedure code(s) for the surgery
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs,
        -- Date the procedure was performed
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from co
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        -- Primary OPCS procedure code for the surgery
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs,
        -- Date the procedure was performed
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from co
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Procedure OPCS
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        -- Secondary OPCS procedure code(s) for the surgery
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS,
        -- Date the procedure was performed
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureOPCS,
    ProcedureDate
from co
where NhsNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Primary Procedure OPCS
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        -- Primary OPCS procedure code for the surgery
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS,
        -- Date the procedure was performed
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'CO'
)
select distinct
    NhsNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from co
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with CO as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        unnest(
            [
                [ Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' ],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from CO
where ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V9%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
    coalesce(Record ->> '$.Treatment[0].Surgery.PrimaryProcedureOpcs.@code', Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code') as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'CO'
  and ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V9%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest(
      [
        [
          Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'
        ], 
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code',
      ], recursive := true
    ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select
  distinct
		NhsNumber,
		ProcedureDate,
		ProcedureOpcsCode
from co
where co.ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V8%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with CO as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOpcs
  from omop_staging.cosd_staging_81
  where Type = 'CO'
)
select
      distinct
          ProcedureDate,
          NhsNumber,
          PrimaryProcedureOpcs
from CO o
where o.ProcedureDate is not null and o.PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20Cosd%20V8%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        unnest(
            [
                [ Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' ],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from BR
where ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` The main or first Procedure in a series of Procedures. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        coalesce(Record ->> '$.Treatment[0].Surgery.PrimaryProcedureOpcs.@code', Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code') as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from BR
where ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Procedure Opcs
Source column  `ProcedureOpcsCode`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with br as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest(
      [
        [
          Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'
        ], 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'
      ], recursive := true
    ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select
  distinct
        NhsNumber,
        ProcedureDate,
        ProcedureOpcsCode
from br
where br.ProcedureOpcsCode is not null;
--no rows in ci
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Primary Procedure Opcs
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` The main or first Procedure in a series of Procedures. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with BR as (
  select
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOpcs
  from omop_staging.cosd_staging_81
  where Type = 'BR'
)
select
      distinct
          NhsNumber,
          ProcedureDate,
          PrimaryProcedureOpcs
from BR
where ProcedureDate is not null and PrimaryProcedureOpcs is not null;
--no rows in ci
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Procedure Opcs Procedure Date
Source column  `ProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
-- Secondary OPCS-4 procedures for CNS cancer area (COSD v9 BA)
-- ProcedureOpcs maps to procedure_source_value in OMOP procedure_occurrence
-- ProcedureDate maps to procedure_date in OMOP procedure_occurrence (string, to be cast to date in a later ETL step)
-- NhsNumber links to person_id via the person table
-- This query captures secondary/additional OPCS procedures (as distinct from the primary procedure)
-- Uses the most comprehensive unnest pattern to handle both Treatment-level and ProcedureOpcs-level arrays
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureDate'],
                Record ->> '$.Treatment[*].Surgery.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'],
                Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from ba
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Primary Procedure Opcs Procedure Date
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
-- Primary OPCS-4 procedure for CNS cancer area (COSD v9 BA)
-- PrimaryProcedureOpcs maps to procedure_source_value in OMOP procedure_occurrence
-- ProcedureDate maps to procedure_date in OMOP procedure_occurrence (string, to be cast to date in a later ETL step)
-- NhsNumber links to person_id via the person table
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureDate'],
                Record ->> '$.Treatment[*].Surgery.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'],
                Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'
            ],
            recursive := true
        ) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from ba
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Excision Or Procedure Type Procedure Date
Source column  `ExcisionOrProcedureType`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ExcisionOrProcedureType` The type of excision performed on Central Nervous System (CNS) tumours during a Central Nervous System Cancer Care Spell. Coded values include Limited less than 50% (1), Partial 50-69% (2), Subtotal 70-95% (3), Total Macroscopic (4), Extent Uncertain (5), CSF Division Procedure (6). Will be stored as procedure_source_value and mapped to a standard concept in a later ETL step. [EXCISION TYPE (CENTRAL NERVOUS SYSTEM TUMOURS)](https://www.datadictionary.nhs.uk/data_elements/excision_type__central_nervous_system_tumours_.html)

```sql
-- CNS excision type procedure for CNS cancer area (COSD v9 BA)
-- ExcisionOrProcedureType maps to procedure_source_value in OMOP procedure_occurrence
-- ProcedureDate maps to procedure_date in OMOP procedure_occurrence (string, to be cast to date in a later ETL step)
-- NhsNumber links to person_id via the person table
-- Both ExcisionOrProcedureType and ProcedureDate are unnested at the Treatment level
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureDate'],
                Record ->> '$.Treatment[*].Surgery.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.SurgeryCNS.ExcisionOrProcedureType.@code'],
                Record ->> '$.Treatment[*].Surgery.SurgeryCNS.ExcisionOrProcedureType.@code'
            ],
            recursive := true
        ) as ExcisionOrProcedureType
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ExcisionOrProcedureType
from ba
where NhsNumber is not null
  and ExcisionOrProcedureType is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Excision%20Or%20Procedure%20Type%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Biopsy Type Procedure Date
Source column  `BiopsyType`.
BIOPSY ANAESTHETIC TYPE


|BiopsyType|procedure_source_concept_id|notes|
|------|-----|-----|
|1|4303995|Local anaesthetic|
|2|4219502|Sedation|
|3|4174669|General anaesthetic|
|9|0|Not Known (Not Recorded)|


* `BiopsyType` The type of biopsy carried out on Central Nervous System (CNS) tumours during a Central Nervous System Cancer Care Spell. Coded values include Frame-based stereotactic biopsy (1), Frameless stereotactic biopsy (2), Open biopsy (3), Percutaneous biopsy (4), Endoscopic biopsy (5), Other biopsy (6). Will be stored as procedure_source_value and mapped to a standard concept in a later ETL step. [BIOPSY TYPE (CENTRAL NERVOUS SYSTEM TUMOURS)](https://www.datadictionary.nhs.uk/data_elements/biopsy_type__central_nervous_system_tumours_.html)

```sql
-- CNS biopsy type procedure for CNS cancer area (COSD v9 BA)
-- BiopsyType maps to procedure_source_value in OMOP procedure_occurrence
-- ProcedureDate maps to procedure_date (scalar path used to match BiopsyType cardinality)
-- NhsNumber links to person_id via the person table
-- BiopsyType is a scalar field (not unnested), so ProcedureDate is also selected as scalar
-- to maintain correct row-level alignment within the same Treatment/Surgery node
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.SurgeryCNS.BiopsyType.@code' as BiopsyType
from omop_staging.cosd_staging_901
where type = 'BA'
  and NhsNumber is not null
  and BiopsyType is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Biopsy%20Type%20Procedure%20Date%20mapping){: .btn }
### COSD V8 BA Procedure Occurrence Primary Procedure OPCS Procedure Date
Source column  `PrimaryProcedureOpcs`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
-- Primary OPCS-4 procedure for CNS cancer area (COSD v8 BA)
-- PrimaryProcedureOPCS maps to procedure_source_value in OMOP procedure_occurrence
-- ProcedureDate maps to procedure_date in OMOP procedure_occurrence (string, to be cast to date in a later ETL step)
-- NHSNumber links to person_id via the person table
with ba as (
    select distinct
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest (
            [
                [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.ProcedureDate'],
                Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CNSCoreSurgeryAndOtherProcedures.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'],
                Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CNSCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'
            ],
            recursive := true
        ) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ba
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_concept_id%20field%20COSD%20V8%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
