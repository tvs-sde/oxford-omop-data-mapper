---
layout: default
title: VisitOccurrence
has_children: true
parent: Transformation Documentation
has_toc: false
---

# VisitOccurrence
* [NhsNumber]({% link docs/transformation-documentation/VisitOccurrence_NhsNumber.md %})
* [HospitalProviderSpellNumber]({% link docs/transformation-documentation/VisitOccurrence_HospitalProviderSpellNumber.md %})
* [visit_start_date]({% link docs/transformation-documentation/VisitOccurrence_visit_start_date.md %})
* [visit_start_datetime]({% link docs/transformation-documentation/VisitOccurrence_visit_start_datetime.md %})
* [visit_end_date]({% link docs/transformation-documentation/VisitOccurrence_visit_end_date.md %})
* [visit_end_datetime]({% link docs/transformation-documentation/VisitOccurrence_visit_end_datetime.md %})
* [visit_concept_id]({% link docs/transformation-documentation/VisitOccurrence_visit_concept_id.md %})
* [visit_type_concept_id]({% link docs/transformation-documentation/VisitOccurrence_visit_type_concept_id.md %})
* [admitted_from_concept_id]({% link docs/transformation-documentation/VisitOccurrence_admitted_from_concept_id.md %})
* [admitted_from_source_value]({% link docs/transformation-documentation/VisitOccurrence_admitted_from_source_value.md %})
* [discharged_to_concept_id]({% link docs/transformation-documentation/VisitOccurrence_discharged_to_concept_id.md %})
* [discharged_to_source_value]({% link docs/transformation-documentation/VisitOccurrence_discharged_to_source_value.md %})
* [RecordConnectionIdentifier]({% link docs/transformation-documentation/VisitOccurrence_RecordConnectionIdentifier.md %})

## SusOPVisitOccurrenceWithSpell
<a href="SusOPVisitOccurrenceWithSpell.svg" target="_blank"><img src="SusOPVisitOccurrenceWithSpell.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only
> * `Location Class` ID 24 is a Consultant Clinic within the Health Care Provider.
> * `Patient Classification` ID 1 is the only entry that covers 24 hours or more with the use of a bed, and whilst others may be a day/night only, they will be discounted because they are less than 24 hours.
> * No calculations to be made between Start and end visit date to try to calculate 24 hours, but instead the `Patient Classification` will be sufficient

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusOPVisitOccurrenceWithSpell%20mapping){: .btn }
## SusAPCVisitOccurrenceWithSpell
<a href="SusAPCVisitOccurrenceWithSpell.svg" target="_blank"><img src="SusAPCVisitOccurrenceWithSpell.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only
> * `Location Class` ID 24 is a Consultant Clinic within the Health Care Provider.
> * `Patient Classification` ID 1 is the only entry that covers 24 hours or more with the use of a bed, and whilst others may be a day/night only, they will be discounted because they are less than 24 hours. Also, maternity is also not taken as an `Inpatient` visit.
> * No calculations to be made between Start and end visit date to try to calculate 24 hours, but instead the `Patient Classification` will be sufficient

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAPCVisitOccurrenceWithSpell%20mapping){: .btn }
## SusAEVisitOccurrenceWithSpell
<a href="SusAEVisitOccurrenceWithSpell.svg" target="_blank"><img src="SusAEVisitOccurrenceWithSpell.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAEVisitOccurrenceWithSpell%20mapping){: .btn }
## SactVisitOccurrence
<a href="SactVisitOccurrence.svg" target="_blank"><img src="SactVisitOccurrence.svg" /></a>

{: .important-title }
> Assumptions
>
> * SACT Data has the following definition for the Administration Timestamp:
> * i) For recording the date and time when the anti-cancer drug was administered to a patient (an infusion commenced)
> * ii) For recording continuous oral chemotherapy, the administration date will be the first day of the nominal cycle, or the date on which an oral drug was dispensed to the patient.
> * The assumption made is that all the drugs were administered in a Cancer clinic as we have no way of identifying if an oral drug was taken at home

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SactVisitOccurrence%20mapping){: .btn }
## RtdsVisitOccurrence
<a href="RtdsVisitOccurrence.svg" target="_blank"><img src="RtdsVisitOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=RtdsVisitOccurrence%20mapping){: .btn }
## OxfordGPVisitOccurrence
<a href="OxfordGPVisitOccurrence.svg" target="_blank"><img src="OxfordGPVisitOccurrence.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OxfordGPVisitOccurrence%20mapping){: .btn }
