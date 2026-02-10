---
layout: default
title: ProcedureOccurrence
has_children: true
parent: Transformation Documentation
has_toc: false
---

# ProcedureOccurrence
* [nhs_number]({% link docs/transformation-documentation/ProcedureOccurrence_nhs_number.md %})
* [procedure_concept_id]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_concept_id.md %})
* [procedure_date]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_date.md %})
* [procedure_datetime]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_datetime.md %})
* [procedure_end_date]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_end_date.md %})
* [procedure_end_datetime]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_end_datetime.md %})
* [procedure_type_concept_id]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_type_concept_id.md %})
* [procedure_source_value]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_source_value.md %})
* [procedure_source_concept_id]({% link docs/transformation-documentation/ProcedureOccurrence_procedure_source_concept_id.md %})
* [RecordConnectionIdentifier]({% link docs/transformation-documentation/ProcedureOccurrence_RecordConnectionIdentifier.md %})
* [quantity]({% link docs/transformation-documentation/ProcedureOccurrence_quantity.md %})

## SusOPProcedureOccurrence
<a href="SusOPProcedureOccurrence.svg" target="_blank"><img src="SusOPProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusOPProcedureOccurrence%20mapping){: .btn }
## SusCCMDSProcedureOccurrence
<a href="SusCCMDSProcedureOccurrence.svg" target="_blank"><img src="SusCCMDSProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusCCMDSProcedureOccurrence%20mapping){: .btn }
## SusAPCProcedureOccurrence
<a href="SusAPCProcedureOccurrence.svg" target="_blank"><img src="SusAPCProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAPCProcedureOccurrence%20mapping){: .btn }
## SusAEProcedureOccurrence
<a href="SusAEProcedureOccurrence.svg" target="_blank"><img src="SusAEProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAEProcedureOccurrence%20mapping){: .btn }
## RtdsProcedureOccurrence
<a href="RtdsProcedureOccurrence.svg" target="_blank"><img src="RtdsProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=RtdsProcedureOccurrence%20mapping){: .btn }
## OxfordGPProcedureOccurrence
<a href="OxfordGPProcedureOccurrence.svg" target="_blank"><img src="OxfordGPProcedureOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OxfordGPProcedureOccurrence%20mapping){: .btn }
## CosdV9LungProcedureOccurrenceRelapseMethodOfDetection
<a href="CosdV9LungProcedureOccurrenceRelapseMethodOfDetection.svg" target="_blank"><img src="CosdV9LungProcedureOccurrenceRelapseMethodOfDetection.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
## CosdV9LungProcedureOccurrenceProcedureOpcs
<a href="CosdV9LungProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV9LungProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , ProcedureOpcsCode(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9LungProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV9LungProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV9LungProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV9LungProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9LungProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV8LungProcedureOccurrenceRelapseMethodOfDetection
<a href="CosdV8LungProcedureOccurrenceRelapseMethodOfDetection.svg" target="_blank"><img src="CosdV8LungProcedureOccurrenceRelapseMethodOfDetection.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
## CosdV8LungProcedureOccurrenceProcedureOpcs
<a href="CosdV8LungProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV8LungProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , ProcedureOpcsCode(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8LungProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV8LungProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV8LungProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV8LungProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Assumptions
>
> * Primary procedure OPCS codes from lung cancer treatment records
> * Procedure dates are taken as recorded in the clinical system
> * Duplicates are handled by selecting distinct records based on NHS Number, Procedure Date, and Primary Procedure OPCS

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8LungProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV9CTYAProcedureOccurrenceProcedureOpcs
<a href="CosdV9CTYAProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV9CTYAProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9CTYAProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9CTYAProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV8CTYAProcedureOccurrenceProcedureOpcs
<a href="CosdV8CTYAProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV8CTYAProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8CTYAProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV9ProcedureOccurrenceProcedureOpcs
<a href="CosdV9ProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV9ProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9ProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV9ProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV9ProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV9ProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9ProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV8ProcedureOccurrenceProcedureOpcs
<a href="CosdV8ProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV8ProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8ProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV8ProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV8ProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV8ProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8ProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV9BreastProcedureOccurrenceProcedureOpcs
<a href="CosdV9BreastProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV9BreastProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9BreastProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
## CosdV8BreastProcedureOccurrenceProcedureOpcs
<a href="CosdV8BreastProcedureOccurrenceProcedureOpcs.svg" target="_blank"><img src="CosdV8BreastProcedureOccurrenceProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8BreastProcedureOccurrenceProcedureOpcs%20mapping){: .btn }
## CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs
<a href="CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs.svg" target="_blank"><img src="CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs.svg" /></a>

{: .important-title }
> Duplicates
>
> COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.
>
> In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.
>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs%20mapping){: .btn }
