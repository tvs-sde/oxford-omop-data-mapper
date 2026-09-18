---
layout: default
title: VisitDetail
has_children: true
parent: Transformation Documentation
has_toc: false
---

# VisitDetail
* [nhs_number]({% link docs/transformation-documentation/VisitDetail_nhs_number.md %})
* [HospitalProviderSpellNumber]({% link docs/transformation-documentation/VisitDetail_HospitalProviderSpellNumber.md %})
* [visit_detail_start_date]({% link docs/transformation-documentation/VisitDetail_visit_detail_start_date.md %})
* [visit_detail_start_datetime]({% link docs/transformation-documentation/VisitDetail_visit_detail_start_datetime.md %})
* [visit_detail_end_date]({% link docs/transformation-documentation/VisitDetail_visit_detail_end_date.md %})
* [visit_detail_end_datetime]({% link docs/transformation-documentation/VisitDetail_visit_detail_end_datetime.md %})
* [visit_detail_concept_id]({% link docs/transformation-documentation/VisitDetail_visit_detail_concept_id.md %})
* [visit_detail_type_concept_id]({% link docs/transformation-documentation/VisitDetail_visit_detail_type_concept_id.md %})
* [RecordConnectionIdentifier]({% link docs/transformation-documentation/VisitDetail_RecordConnectionIdentifier.md %})
* [admitted_from_concept_id]({% link docs/transformation-documentation/VisitDetail_admitted_from_concept_id.md %})
* [admitted_from_source_value]({% link docs/transformation-documentation/VisitDetail_admitted_from_source_value.md %})
* [discharged_to_source_value]({% link docs/transformation-documentation/VisitDetail_discharged_to_source_value.md %})
* [discharged_to_concept_id]({% link docs/transformation-documentation/VisitDetail_discharged_to_concept_id.md %})

## SusOPVisitDetail
<a href="SusOPVisitDetail.svg" target="_blank"><img src="SusOPVisitDetail.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only
> * `Location Class` ID 24 is a Consultant Clinic within the Health Care Provider.
> * `Patient Classification` ID 1 is the only entry that covers 24 hours or more with the use of a bed, and whilst others may be a day/night only, they will be discounted because they are less than 24 hours. Also, maternity is also not taken as an `Inpatient` visit.
> * No calculations to be made between Start and end visit date to try to calculate 24 hours, but instead the `Patient Classification` will be sufficient

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusOPVisitDetail%20mapping){: .btn }
## SusCCMDSVisitDetail
<a href="SusCCMDSVisitDetail.svg" target="_blank"><img src="SusCCMDSVisitDetail.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusCCMDSVisitDetail%20mapping){: .btn }
## SusAPCVisitDetail
<a href="SusAPCVisitDetail.svg" target="_blank"><img src="SusAPCVisitDetail.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only
> * `Location Class` ID 24 is a Consultant Clinic within the Health Care Provider.
> * `Patient Classification` ID 1 is the only entry that covers 24 hours or more with the use of a bed, and whilst others may be a day/night only, they will be discounted because they are less than 24 hours. Also, maternity is also not taken as an `Inpatient` visit.
> * No calculations to be made between Start and end visit date to try to calculate 24 hours, but instead the `Patient Classification` will be sufficient

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAPCVisitDetail%20mapping){: .btn }
## SusAEVisitDetail
<a href="SusAEVisitDetail.svg" target="_blank"><img src="SusAEVisitDetail.svg" /></a>

{: .important-title }
> Assumptions
>
> * `Emergency` covers a visit to A&E within the given Hospital Provider, and hence covers Admission Code 21 and 24 only

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=SusAEVisitDetail%20mapping){: .btn }
## OxfordGPVisitDetails
<a href="OxfordGPVisitDetails.svg" target="_blank"><img src="OxfordGPVisitDetails.svg" /></a>

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OxfordGPVisitDetails%20mapping){: .btn }
