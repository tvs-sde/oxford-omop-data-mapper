---
layout: default
title: measurement_source_concept_id
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# measurement_source_concept_id
### Sus OP  Measurement
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        op.GeneratedRecordIdentifier,
        op.NHSNumber,
        op.CDSActivityDate
from omop_staging.sus_OP_ICDDiagnosis d
    inner join omop_staging.sus_OP op
        on d.MessageId = op.MessageId
where op.NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus APC Measurement
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        apc.GeneratedRecordIdentifier,
        apc.NHSNumber,
        apc.CDSActivityDate
from omop_staging.sus_ICDDiagnosis d
    inner join omop_staging.sus_APC apc
        on d.MessageId = apc.MessageId
where apc.NHSNumber is not null
order by
	d.DiagnosisICD,
    apc.GeneratedRecordIdentifier,
    apc.NHSNumber,
    apc.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### Oxford Lab Measurement
Source column  `EVENT`.
OXford Lab Test Lookup lookup


|EVENT|measurement_source_concept_id|notes|
|------|-----|-----|
|Volume, 24hr urine|3012565|Volume of 24 hour Urine|
|O_Volume, 24hr urine|3012565|Volume of 24 hour Urine|
|Amylase:creatinine ratio, urine|3044902|Amylase/Creatinine [Ratio] in Urine|
|Immunofixation, urine|3017704|Immunofixation for Urine|
|KFRE 2-year risk of kidney failure|36203453|Kidney failure 2-year risk [Likelihood] by KFRE|
|KFRE 5-year risk of kidney failure|36203454|Kidney failure 5-year risk [Likelihood] by KFRE|
|3-methoxytyramine:creat ratio, urine|21494639|3-Methoxytyramine/Creatinine [Molar ratio] in Urine|
|Osmolality, urine|3026782|Osmolality of Urine|
|O_Osmolality, urine|3026782|Osmolality of Urine|
|5-HIAA:creatinine ratio, urine|3015820|5-Hydroxyindoleacetate/Creatinine [Molar ratio] in Urine|
|O_5-HIAA:creatinine ratio, urine|3015820|5-Hydroxyindoleacetate/Creatinine [Molar ratio] in Urine|
|Ganglioside GQ1b Ab, CSF|3009580|Ganglioside GQ1b IgG Ab [Presence] in Cerebral spinal fluid|
|Volume, urine|3036603|Volume of Urine|
|Thrombin time, blood|3036489|Thrombin time|
|O_Thrombin time, blood|3036489|Thrombin time|
|Galactose-1-P Uridyl Transferase, blood|3004179|Galactose 1 phosphate uridyl transferase [Presence] in Blood|
|Porphobilinogen:creatinine ratio, urine|3044597|Porphobilinogen/Creatinine [Molar ratio] in Urine|
|IgG:albumin ratio, CSF|3007798|IgG/Albumin [Mass Ratio] in Cerebral spinal fluid|
|3-methoxytyramine excretion, 24hr urine|40757475|3-Methoxytyramine [Mass/volume] in 24 hour Urine|
|Porphyrin:creatinine ratio, urine|40760492|Porphyrins/Creatinine [Molar ratio] in Urine|
|Protein:creatinine ratio, urine|3045462|Protein/Creatinine [Ratio] in Urine|
|O_Protein:creatinine ratio, urine|3045462|Protein/Creatinine [Ratio] in Urine|
|Amylase output, 24hr urine|3043288|Amylase [Presence] in 24 hour Urine|
|Amphetamine screen, urine|3000144|Amphetamine [Presence] in Urine by Screen method|
|Cannabinoids screen, urine|3006932|Cannabinoids [Presence] in Urine by Screen method|
|Ganglioside GM1 Ab, CSF|40765974|Ganglioside GM1 IgG Ab [Presence] in Cerebral spinal fluid by Immunoassay|
|Beta trace protein, Fluid|40760843|Beta-trace protein [Mass/volume] in Body fluid|
|5-HIAA output, 24hr urine|3010801|5-Hydroxyindoleacetate [Moles/volume] in 24 hour Urine|
|O_5-HIAA output, 24hr urine|3010801|5-Hydroxyindoleacetate [Moles/volume] in 24 hour Urine|
|IGLON5 Antibodies, CSF|36032315|IgLON5 IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Albumin:creatinine ratio, urine|3020682|Albumin/Creatinine [Ratio] in Urine|
|O_Albumin:creatinine ratio, urine|3020682|Albumin/Creatinine [Ratio] in Urine|
|O_Organic acids level, urine|3018363|Organic acids [Presence] in Urine|
|Glycine receptor antibody, CSF|36031502|Glycine receptor Ab [Presence] in Cerebral spinal fluid by Immunoassay|
|O_Lymphocyte proliferation screen, blood|40762156|Lymphocyte proliferation panel - Blood|
|Porphobilinogen level, urine|3034719|Porphobilinogen [Presence] in Urine|
|Lactate level, CSF|3025022|Lactate [Mass/volume] in Cerebral spinal fluid|
|3-Methoxytyramine, plasma|3030408|3-Methoxytyramine [Moles/volume] in Serum or Plasma|
|O_Lactate level, CSF|3025022|Lactate [Mass/volume] in Cerebral spinal fluid|
|Xanthochromia detection, CSF|3027572|Xanthochromia [Presence] of Cerebral spinal fluid Qualitative|
|O_Xanthochromia detection, CSF|3027572|Xanthochromia [Presence] of Cerebral spinal fluid Qualitative|
|pH, urine|3015736|pH of Urine|
|O_pH, urine|3015736|pH of Urine|
|Beta-2 microglobulin level, serum|3047079|Beta-2-Microglobulin [Presence] in Serum|
|Iohexol clearance|3966002|Iohexol renal clearance in Serum or Plasma or Urine|
|CD16+ CD56+ count, blood|3020358|CD16+CD56+ cells [#/volume] in Blood|
|Amphiphysin, CSF|1176096|Amphiphysin Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|O_Drugs of abuse screen, urine|42870589|Drugs of abuse panel - Urine by Screen method|
|Aldosterone:renin ratio, blood|3011145|Aldosterone/Renin [Ratio] in Plasma|
|Urobilinogen level, urine|3016360|Urobilinogen [Presence] in Urine|
|O_Urobilinogen level, urine|3016360|Urobilinogen [Presence] in Urine|
|Reptilase time, blood|3005308|Reptilase time|
|O_Reptilase time, blood|3005308|Reptilase time|
|Isocyanate TDI IgE level, blood|40764039|Isocyanate TDI IgE Ab/IgE total in Serum|
|O_Lactate dehydrogenase level, CSF|3016920|Lactate dehydrogenase [Enzymatic activity/volume] in Cerebral spinal fluid|
|O_Isocyanate TDI IgE level, blood|40764039|Isocyanate TDI IgE Ab/IgE total in Serum|
|Methotrexate level, CSF|3016655|Methotrexate [Mass/volume] in Cerebral spinal fluid|
|Yo (blot), CSF|1176465|PCA-1 Ab [Units/volume] in Cerebral spinal fluid by Line blot|
|Collection period, urine|44816649|Collection time of Urine|
|Orexin level, CSF|37021200|Orexin-A [Mass/volume] in Cerebral spinal fluid|
|O_Orexin level, CSF|37021200|Orexin-A [Mass/volume] in Cerebral spinal fluid|
|Isocyanate HDI IgE level, blood|40764038|Isocyanate HDI IgE Ab/IgE total in Serum|
|O_Isocyanate HDI IgE level, blood|40764038|Isocyanate HDI IgE Ab/IgE total in Serum|
|Reducing substance, urine|3020029|Reducing substances [Presence] in Urine|
|Citrate:creatinine ratio, urine|3036325|Citrate/Creatinine [Mass Ratio] in Urine|
|Citrate output, 24hr urine|3036931|Citrate [Mass/volume] in 24 hour Urine|
|O_Reducing substance, urine|3020029|Reducing substances [Presence] in Urine|
|Fibroblast growth factor 23, plasma|3052200|Fibroblast growth factor 23 [Units/volume] in Plasma|
|O_Citrate output, 24hr urine|3036931|Citrate [Mass/volume] in 24 hour Urine|
|Magnesium output, 24hr urine|3006828|Magnesium [Mass/volume] in 24 hour Urine|
|Lysozyme level, urine|3008343|Lysozyme [Mass/volume] in Urine|
|O_Magnesium output, 24hr urine|3006828|Magnesium [Mass/volume] in 24 hour Urine|
|Immature Granulocytes count, blood|3040168|Immature granulocytes [#/volume] in Blood|
|Calcium output, 24hr urine|3017730|Calcium [Mass/volume] in 24 hour Urine|
|O_Calcium output, 24hr urine|3017730|Calcium [Mass/volume] in 24 hour Urine|
|Methadone level, urine|3036180|Methadone [Presence] in Urine|
|Urea output, 24hr urine|3008071|Urine output 24 hour|
|See CSF for oligoclonal band results|3002182|Oligoclonal bands [Presence] in Cerebral spinal fluid|
|O_Urea output, 24hr urine|3008071|Urine output 24 hour|
|CD16+ CD56+ % NK cells, blood|3027831|CD3-CD16+CD56+ (Natural killer) cells/cells in Blood|
|Viscosity level, blood|3028652|Viscosity of Blood|
|Mi-2 antibody by Immunoblot|40759862|Mi-2 Ab [Presence] in Serum by Immunoblot|
|O_Viscosity level, blood|3028652|Viscosity of Blood|
|Potassium output, 24hr urine|3040170|Potassium [Mass/time] in 24 hour Urine|
|O_Chromium level, blood|3005962|Chromium [Moles/volume] in Blood|
|O_Potassium output, 24hr urine|3040170|Potassium [Mass/time] in 24 hour Urine|
|IgG, CSF|3007368|IgG [Mass/volume] in Cerebral spinal fluid|
|Citrulline level, plasma|3034087|Citrulline [Presence] in Serum or Plasma|
|Phosphate output, 24hr urine|3025776|Phosphate [Mass/volume] in 24 hour Urine|
|O_Phosphate output, 24hr urine|3025776|Phosphate [Mass/volume] in 24 hour Urine|
|Mean platelet volume, blood|3001123|Platelet [Entitic mean volume] in Blood|
|Oxalate output, 24hr urine|3038056|Oxalate [Mass/volume] in 24 hour Urine|
|O_Oxalate output, 24hr urine|3038056|Oxalate [Mass/volume] in 24 hour Urine|
|Creatinine output, 24hr urine|3001349|Creatinine [Mass/volume] in 24 hour Urine|
|O_Creatinine output, 24hr urine|3001349|Creatinine [Mass/volume] in 24 hour Urine|
|IGLON5 Titre, CSF|36031890|IgLON5 IgG Ab [Titer] in Cerebral spinal fluid by Immunofluorescence|
|ctO2c (BG)|40760909|Oxygen content in Blood by calculation|
|Yo Ab level, CSF|3038309|PCA-1 Ab [Titer] in Cerebral spinal fluid|
|11-Deoxycortisol level, serum|40758596|11-Deoxycortisol [Moles/volume] in Serum or Plasma --baseline|
|O_Biotinidase level, blood|3024509|Biotinidase [Presence] in Blood|
|CD8 CD27-CD28- T Cells, blood|21493670|CD27- cells/CD3+CD8+ (T8 suppressor cells) cells in Blood|
|Glucose level, CSF|3022548|Glucose [Mass/volume] in Cerebral spinal fluid|
|O_Glucose level, CSF|3022548|Glucose [Mass/volume] in Cerebral spinal fluid|
|Protein output, 24hr urine|3011705|Protein [Mass/volume] in 24 hour Urine|
|CD8 CD27+CD28- T Cells, blood|21493670|CD27- cells/CD3+CD8+ (T8 suppressor cells) cells in Blood|
|O_Protein output, 24hr urine|3011705|Protein [Mass/volume] in 24 hour Urine|
|INR|3034426|Prothrombin time (PT)|
|O_Porphyrins, faeces|3035602|Porphyrins [Presence] in Stool|
|Benzodiazepine level, urine|3042517|Benzodiazepines panel - Urine|
|Oligoclonal band screen, CSF|3002182|Oligoclonal bands [Presence] in Cerebral spinal fluid|
|O_Oligoclonal band screen, CSF|3002182|Oligoclonal bands [Presence] in Cerebral spinal fluid|
|FIB-4|3048264|Fibrosis score|
|Penicillin V IgE level, blood|3039829|Penicillin V IgE Ab/IgE total in Serum|
|O_Penicillin V IgE level, blood|3039829|Penicillin V IgE Ab/IgE total in Serum|
|Candida albicans IgE level, blood|40763999|Candida albicans IgE Ab/IgE total in Serum|
|O_Candida albicans IgE level, blood|40763999|Candida albicans IgE Ab/IgE total in Serum|
|Albumin level, CSF|3024474|Albumin [Mass/volume] in Cerebral spinal fluid|
|Androstenedione level, serum|3044426|Androstenedione [Presence] in Serum or Plasma|
|Sodium output, 24hr urine|3004907|Sodium [Mass/volume] in 24 hour Urine|
|Urate output, 24hr urine|3012870|Urate [Mass/volume] in 24 hour Urine|
|O_Urate output, 24hr urine|3012870|Urate [Mass/volume] in 24 hour Urine|
|O_Sodium output, 24hr urine|3004907|Sodium [Mass/volume] in 24 hour Urine|
|CD8 CD27+CD28+ T Cells, blood|21493670|CD27- cells/CD3+CD8+ (T8 suppressor cells) cells in Blood|
|Chloride output, 24hr urine|3041519|Chloride [Mass/time] in 24 hour Urine|
|O_Chloride output, 24hr urine|3041519|Chloride [Mass/time] in 24 hour Urine|
|Voltage-gated Ca channel Ab, blood|3041634|Voltage-gated calcium channel IgG Ab [Presence] in Serum|
|O_Voltage-gated Ca channel Ab, blood|3041634|Voltage-gated calcium channel IgG Ab [Presence] in Serum|
|Biotinidase level, plasma|3046027|Biotinidase [Presence] in Serum or Plasma|
|Thrombin time reference|3036489|Thrombin time|
|Voltage-gated Ca channel Ab, CSF|1988259|Voltage-gated calcium channel Ab [Moles/volume] in Cerebral spinal fluid by Immunoassay|
|PML antibody by Immunoblot|40759872|PML Ab [Presence] in Serum by Immunoblot|
|Phenylalanine level, blood|3030135|Phenylalanine [Presence] in Blood|
|O_Phenylalanine level, blood|3030135|Phenylalanine [Presence] in Blood|
|Protein electrophoresis, urine|3044927|Protein electrophoresis panel - Urine|
|O_Protein electrophoresis, urine|3044927|Protein electrophoresis panel - Urine|
|Chromium level, plasma|3008269|Chromium [Mass/volume] in Serum or Plasma|
|Everolimus level, blood|3030703|Everolimus [Mass/volume] in Blood|
|Myoglobin level, urine|3011470|Myoglobin [Presence] in Urine|
|Lobster IgE level, blood|3041475|Lobster IgE Ab/IgE total in Serum|
|Helicobacter pylori urea breath test|3011630|Helicobacter pylori [Presence] in Stomach by urea breath test|
|O_Lobster IgE level, blood|3041475|Lobster IgE Ab/IgE total in Serum|
|O_Porphyrin screen, urine|3012844|Porphyrins [Presence] in Urine|
|Ethanol level, urine|3010109|Ethanol [Presence] in Urine|
|O_11-Deoxycortisol level, blood|3007719|11-Deoxycortisol [Mass/volume] in Serum or Plasma|
|O_Ethanol level, urine|3010109|Ethanol [Presence] in Urine|
|Clobazam level, blood|40762688|cloBAZam [Mass/volume] in Blood|
|Sex hormone binding globulin, blood|3011099|Sex hormone binding globulin [Mass/volume] in Serum or Plasma|
|O_Sex hormone binding globulin, blood|3011099|Sex hormone binding globulin [Mass/volume] in Serum or Plasma|
|Guinea pig epithelium IgE level, blood|3041346|Guinea pig epithelium IgE Ab/IgE total in Serum|
|O_Amino acids level, CSF|3052322|Alanine/Amino acids.total in Cerebral spinal fluid|
|Baker's yeast IgE level, blood|3039011|Baker's yeast IgE Ab/IgE total in Serum|
|O_Guinea pig epithelium IgE level, blood|3041346|Guinea pig epithelium IgE Ab/IgE total in Serum|
|Amino acids level, CSF|3052322|Alanine/Amino acids.total in Cerebral spinal fluid|
|O_Beta-2 microglobulin, blood|3047079|Beta-2-Microglobulin [Presence] in Serum|
|Brazil nut IgE level, blood|3042333|Brazil Nut IgE Ab/IgE total in Serum|
|O_Brazil nut IgE level, blood|3042333|Brazil Nut IgE Ab/IgE total in Serum|
|Ma2, CSF|3965308|Ma2 Antibody [Presence] in Cerebral spinal fluid by Immunoassay|
|Gentamicin level, CSF|3000160|Gentamicin [Mass/volume] in Cerebral spinal fluid|
|Thiopurine methyltransferase, blood|3038882|Thiopurine methyltransferase [Enzymatic activity/volume] in Blood|
|O_Thiopurine methyltransferase, blood|3038882|Thiopurine methyltransferase [Enzymatic activity/volume] in Blood|
|Parsley IgE level, blood|40764056|Parsley IgE Ab/IgE total in Serum|
|O_Parsley IgE level, blood|40764056|Parsley IgE Ab/IgE total in Serum|
|Acylcarnitine profile, blood|3046449|Acylcarnitine [Presence] in Blood|
|Cortisol level, urine|3037229|Cortisol [Presence] in Urine|
|O_Cortisol level, urine|3037229|Cortisol [Presence] in Urine|
|Lettuce IgE level, blood|40764041|Lettuce IgE Ab/IgE total in Serum|
|O_Lettuce IgE level, blood|40764041|Lettuce IgE Ab/IgE total in Serum|
|Urobilin level, urine|3017396|Urobilin [Presence] in Urine|
|CD18 expression, blood|36660405|CD18 cells [Presence] in Blood|
|Cobalt level, plasma|3028447|Cobalt [Mass/volume] in Serum or Plasma|
|Amino acids level, urine|3032641|Amino acids panel - Urine|
|O_Amino acids level, urine|3032641|Amino acids panel - Urine|
|CD4 CD27+CD28+ T Cells, blood|3034246|CD4+CD28+ cells/cells in Blood|
|Osmolality, fluid|3004663|Osmolality of Body fluid|
|Citrate level, urine|3002514|Citrate [Presence] in Urine|
|Avocado IgE level, blood|40764055|Avocado IgE Ab/IgE total in Serum|
|O_Avocado IgE level, blood|40764055|Avocado IgE Ab/IgE total in Serum|
|Spinach IgE level, blood|40764078|Spinach IgE Ab/IgE total in Serum|
|O_Citrate level, urine|3002514|Citrate [Presence] in Urine|
|O_Spinach IgE level, blood|40764078|Spinach IgE Ab/IgE total in Serum|
|Specific Gravity Urine Dipstick|3033543|Specific gravity of Urine|
|Walnut IgE level, blood|3041778|Walnut IgE Ab/IgE total in Serum|
|O_Walnut IgE level, blood|3041778|Walnut IgE Ab/IgE total in Serum|
|Glucose level, urine|3020650|Glucose [Presence] in Urine|
|Adenosine deaminase level, fluid|3037437|Adenosine deaminase [Enzymatic activity/volume] in Body fluid|
|CD21 Low B Cells, blood|3024645|CD21 cells/cells in Blood|
|Sesame seed IgE level, blood|40764074|Sesame Seed IgE Ab/IgE total in Serum|
|Blue mussel IgE level, blood|3038242|Blue mussel IgE Ab/IgE total in Serum|
|Serum viscosity, blood|3010493|Viscosity of Serum|
|O_Sesame seed IgE level, blood|40764074|Sesame Seed IgE Ab/IgE total in Serum|
|O_Blue mussel IgE level, blood|3038242|Blue mussel IgE Ab/IgE total in Serum|
|Vacuolated lymphocytes, blood|40763527|Lymphocytes.vacuolated [Presence] in Blood by Light microscopy|
|Titin, CSF|3966635|Titin Ab [Presence] in Cerebral spinal fluid by Immunoblot|
|O_Serum viscosity, blood|3010493|Viscosity of Serum|
|CD4 CD27-CD28+ T Cells, blood|21493678|CD27-CD45RA+ cells/CD3+CD4+ (T4 helper) cells in Blood|
|O_Vacuolated lymphocytes, blood|40763527|Lymphocytes.vacuolated [Presence] in Blood by Light microscopy|
|O_Heinz bodies screen, blood|3049436|Heinz bodies [Presence] in Blood|
|Promyelocyte count, blood|3022709|Promyelocytes [#/volume] in Blood|
|Opiate level, urine|3027008|Opiates [Presence] in Urine|
|Pine nut IgE level, blood|40764091|Pine Nut IgE Ab/IgE total in Serum|
|O_Pine nut IgE level, blood|40764091|Pine Nut IgE Ab/IgE total in Serum|
|Sirolimus level, blood|3021374|Sirolimus [Mass/volume] in Blood|
|O_Sirolimus level, blood|3021374|Sirolimus [Mass/volume] in Blood|
|AMPA2 receptor antibody, CSF|42529118|AMPAR2 IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Hamster epithelium IgE level, blood|3044511|Hamster epithelium IgE Ab/IgE total in Serum|
|O_Hamster epithelium IgE level, blood|3044511|Hamster epithelium IgE Ab/IgE total in Serum|
|Ganglioside GQ1b antibody, blood|3021365|Ganglioside GQ1b Ab [Presence] in Serum|
|O_Ganglioside GQ1b Ab, blood|3021365|Ganglioside GQ1b Ab [Presence] in Serum|
|Pyruvate kinase assay, blood|3015478|Pyruvate kinase [Presence] in Blood|
|O_Pyruvate kinase assay, blood|3015478|Pyruvate kinase [Presence] in Blood|
|Lambda light chain level, blood|3004640|Lambda light chains [Mass/volume] in Serum or Plasma|
|Aspergillus fumigatus IgE level, blood|3047468|Aspergillus fumigatus IgE Ab/IgE total in Serum|
|O_Aspergillus fumigatus IgE level,blood|3047468|Aspergillus fumigatus IgE Ab/IgE total in Serum|
|CD34 level, blood|3023256|CD34 cells/cells in Blood|
|Urine volume collected|3036603|Volume of Urine|
|Hu (blot), CSF|36660666|Neuronal nuclear type 1 IgG Ab [Presence] in Cerebral spinal fluid by Line blot|
|Cheddar cheese IgE level, blood|40761038|Cheese cheddar type IgE Ab/IgE total in Serum|
|O_Cheddar cheese IgE level, blood|40761038|Cheese cheddar type IgE Ab/IgE total in Serum|
|pH (BG)|3010421|pH of Blood|
|PL-7 antibody (immunoblot), blood|40759863|PL-7 Ab [Presence] in Serum by Immunoblot|
|O_Zinc level, blood|3026103|Zinc [Presence] in Blood|
|Zinc level, plasma|3044223|Zinc [Presence] in Serum or Plasma|
|Amylase level, urine|3017315|Amylase [Enzymatic activity/volume] in Urine|
|O_Amylase level, urine|3017315|Amylase [Enzymatic activity/volume] in Urine|
|Vancomycin level, CSF|3016063|Vancomycin [Mass/volume] in Cerebral spinal fluid|
|O_Pigeon (serum) antibodies, blood|3037047|Pigeon antibody panel - Serum|
|Beta trace protein, Serum|3052056|Beta-trace protein [Mass/volume] in Serum or Plasma|
|Tissue transglutaminase IgA Ab, blood|3030555|Tissue transglutaminase IgA Ab [Presence] in Serum|
|Cardiolipin IgM Ab level, blood|3004874|Cardiolipin IgM Ab [Interpretation] in Serum|
|Ammonia level, blood|3030942|Ammonia [Mass/volume] in Blood|
|O_Ammonia level, blood|3030942|Ammonia [Mass/volume] in Blood|
|Carrot IgE level, blood|3035253|Carrot IgE Ab/IgE total in Serum|
|O_Carrot IgE level, blood|3035253|Carrot IgE Ab/IgE total in Serum|
|CD4 CD27-CD28- T Cells, blood|21493678|CD27-CD45RA+ cells/CD3+CD4+ (T4 helper) cells in Blood|
|Cashew nut IgE level, blood|3052099|Cashew nut IgE Ab/IgE total in Serum|
|Gastrin level,plasma|3009927|Gastrin [Mass/volume] in Serum or Plasma|
|Beta-hydroxybutyrate level, blood|1092084|Beta hydroxybutyrate [Moles/volume] in Blood|
|O_Cashew nut IgE level, blood|3052099|Cashew nut IgE Ab/IgE total in Serum|
|Tissue transglutaminase IgG Ab, blood|3041421|Tissue transglutaminase IgG Ab [Presence] in Serum|
|O_Beta-hydroxybutyrate level, blood|1092084|Beta hydroxybutyrate [Moles/volume] in Blood|
|Pancreatic polypeptide level, plasma|3023589|Pancreatic polypeptide [Mass/volume] in Serum or Plasma|
|Osmolality, blood|3004663|Osmolality of Body fluid|
|O_Osmolality, blood|3004663|Osmolality of Body fluid|
|PL-12 antibody (immunoblot), blood|40759864|PL-12 Ab [Presence] in Serum by Immunoblot|
|Oysters IgE level, blood|40764053|Oyster IgE Ab/IgE total in Serum|
|Pineapple IgE level, blood|40763977|Pineapple IgE Ab/IgE total in Serum|
|O_Oysters IgE level, blood|40764053|Oyster IgE Ab/IgE total in Serum|
|Scallop IgE level, blood|3041779|Scallop IgE Ab/IgE total in Serum|
|O_Pineapple IgE level, blood|40763977|Pineapple IgE Ab/IgE total in Serum|
|O_Scallop IgE level, blood|3041779|Scallop IgE Ab/IgE total in Serum|
|Protein level, CSF|3019473|Protein [Mass/volume] in Cerebral spinal fluid|
|O_Protein level, CSF|3019473|Protein [Mass/volume] in Cerebral spinal fluid|
|Chromogranin A level, plasma|3014702|Chromogranin A [Moles/volume] in Serum or Plasma|
|Chromium level, serum|3000321|Chromium [Moles/volume] in Serum or Plasma|
|AMPA1 receptor antibody, CSF|42528892|AMPAR1 IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Celery IgE level, blood|40763979|Celery IgE Ab/IgE total in Serum|
|Mushroom IgE level, blood|40763970|Mushroom IgE Ab/IgE total in Serum|
|O_Celery IgE level, blood|40763979|Celery IgE Ab/IgE total in Serum|
|O_Mushroom IgE level, blood|40763970|Mushroom IgE Ab/IgE total in Serum|
|Phenobarbitone screen, blood|1091947|Mephobarbital and PHENobarbital panel - Blood|
|Molybdenum level, blood|40758684|Molybdenum [Moles/volume] in Blood|
|Free kappa:lambda light chain ratio|3053209|Kappa light chains.free/Lambda light chains.free [Mass Ratio] in Serum|
|Ethanol level, blood|3025643|Ethanol [Mass/volume] in Blood|
|O_Ethanol level, blood|3025643|Ethanol [Mass/volume] in Blood|
|Renin level, plasma|3037310|Renin [Mass/volume] in Plasma|
|OJ antibody (immunoblot), blood|42870556|OJ Ab [Presence] in Serum by Immunoblot|
|Pistachio IgE level, blood|3039295|Pistachio IgE Ab/IgE total in Serum|
|O_Pistachio IgE level, blood|3039295|Pistachio IgE Ab/IgE total in Serum|
|Rabbit epithelium IgE level, blood|3038805|Rabbit epithelium IgE Ab/IgE total in Serum|
|O_Rabbit epithelium IgE level, blood|3038805|Rabbit epithelium IgE Ab/IgE total in Serum|
|Warfarin Dose|3024105|Warfarin [Mass] of Dose|
|C1 esterase inhibitor function, blood|3000391|Complement C1 esterase inhibitor.functional [Presence] in Serum or Plasma|
|O_C1 esterase inhibitor function, blood|3000391|Complement C1 esterase inhibitor.functional [Presence] in Serum or Plasma|
|Cryofibrinogen, blood|3027408|Cryofibrinogen [Mass/volume] in Blood|
|Promyelocyte %, blood|3022709|Promyelocytes [#/volume] in Blood|
|Manganese level, blood|3020923|Manganese [Mass/volume] in Blood|
|Lamotrigine level, plasma|3023261|lamoTRIgine [Mass/volume] in Serum or Plasma|
|Magnesium level, urine|3019738|Magnesium [Mass/volume] in Urine|
|O_Manganese level, blood|3020923|Manganese [Mass/volume] in Blood|
|Glutamic acid decarboxylase Ab, CSF|42528823|Glutamate decarboxylase Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|GABA(b)R antibody, CSF|42529115|GABABR IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|O_Magnesium level, urine|3019738|Magnesium [Mass/volume] in Urine|
|Trout IgE level, blood|40764050|Trout IgE Ab/IgE total in Serum|
|O_Haemosiderin level, urine|3036265|Hemosiderin [Presence] in Urine|
|O_Trout IgE level, blood|40764050|Trout IgE Ab/IgE total in Serum|
|Calcium level, blood|3027495|Calcium [Presence] in Blood|
|O_Calcium level, blood|3027495|Calcium [Presence] in Blood|
|Normetadrenaline output, 24hr urine|3003700|Normetanephrine [Mass/volume] in 24 hour Urine|
|Glucagon level, plasma|3023436|Glucagon [Mass/volume] in Serum or Plasma|
|Penicillin G IgE level, blood|3037297|Penicillin G IgE Ab [Units/volume] in Serum|
|O_Penicillin G IgE level, blood|3037297|Penicillin G IgE Ab [Units/volume] in Serum|
|Fructosamine level serum|3019839|Fructosamine [Moles/volume] in Serum or Plasma|
|Kappa light chain level, blood|3019812|Kappa light chains [Mass/volume] in Serum or Plasma|
|Calcium level, urine|3012065|Calcium [Presence] in Urine|
|O_Calcium level, urine|3012065|Calcium [Presence] in Urine|
|Rat urine IgE level, blood|40764107|Rat urine proteins IgE Ab/IgE total in Serum|
|O_Rat urine IgE level, blood|40764107|Rat urine proteins IgE Ab/IgE total in Serum|
|Creatinine level, urine|3007081|Creatinine [Interpretation] in Urine|
|Aspartate aminotransferase level, blood|3010587|Aspartate aminotransferase [Presence] in Serum or Plasma|
|O_Aspartate aminotransferase level,blood|3010587|Aspartate aminotransferase [Presence] in Serum or Plasma|
|O_Creatinine level, urine|3007081|Creatinine [Interpretation] in Urine|
|O_Folate level, blood|3005794|Folate [Presence] in Blood|
|Collection volume, urine|3036603|Volume of Urine|
|Oxalate level, urine|3022476|Oxalate [Presence] in Urine|
|Gentamicin timing, CSF|3000160|Gentamicin [Mass/volume] in Cerebral spinal fluid|
|O_Oxalate level, urine|3022476|Oxalate [Presence] in Urine|
|Angiotensin-converting enzyme, blood|3036335|Angiotensin converting enzyme [Enzymatic activity/volume] in Blood|
|O_Angiotensin-converting enzyme, blood|3036335|Angiotensin converting enzyme [Enzymatic activity/volume] in Blood|
|CD3 level, blood|3011412|CD3 cells [#/volume] in Blood|
|Urobilinogen (dipstick), urine|3016360|Urobilinogen [Presence] in Urine|
|Lactate dehydrogenase level, fluid|46235370|Lactate dehydrogenase in body fluid/Lactate dehydrogenase in serum|
|O_Lactate dehydrogenase level, fluid|46235370|Lactate dehydrogenase in body fluid/Lactate dehydrogenase in serum|
|Mugwort w6 IgE level, blood|3040902|Mugwort IgE Ab/IgE total in Serum|
|Inhibin B level, blood|3038854|Inhibin B [Presence] in Serum or Plasma|
|O_Inhibin B level, blood|3038854|Inhibin B [Presence] in Serum or Plasma|
|TCR delta and gamma %, blood|3029686|TCR gamma delta cells [#/volume] in Blood|
|APTT, blood|3036489|Thrombin time|
|O_APTT, blood|3036489|Thrombin time|
|Aldosterone level, plasma|3011337|Aldosterone [Mass/volume] in Serum or Plasma|
|Sp100antibody by Immunoblot|40759873|sp100 Ab [Presence] in Serum by Immunoblot|
|Barbiturate level, urine|3050636|Barbiturates panel - Urine|
|Lemon IgE level, blood|40764007|Lemon IgE Ab/IgE total in Serum|
|O_Lemon IgE level, blood|40764007|Lemon IgE Ab/IgE total in Serum|
|Jak-2 Exon 12 by sequencing, blood|1988162|JAK2 gene exon 12 full mutation analysis in Blood or Tissue by Sequencing|
|Isocyanate MDI IgE level, blood|40764038|Isocyanate HDI IgE Ab/IgE total in Serum|
|Budgerigar serum protein IgE, blood|40758718|Budgerigar feather IgE Ab [Presence] in Serum|
|O_Budgerigar serum protein IgE, blood|40758718|Budgerigar feather IgE Ab [Presence] in Serum|
|Caffeine level, plasma|3022695|Caffeine [Mass/volume] in Serum or Plasma|
|O_Isocyanate MDI IgE level, blood|40764038|Isocyanate HDI IgE Ab/IgE total in Serum|
|Magnesium level, blood|3003341|Magnesium [Presence] in Blood|
|O_Magnesium level, blood|3003341|Magnesium [Presence] in Blood|
|Amylase level, fluid|3043024|Amylase [Presence] in Body fluid|
|O_Amylase level, fluid|3043024|Amylase [Presence] in Body fluid|
|Hazelnut IgE level, blood|3041451|Hazelnut IgE Ab/IgE total in Serum|
|O_Hazelnut IgE level, blood|3041451|Hazelnut IgE Ab/IgE total in Serum|
|Ma2 Abs, blood|3966229|Ma2 Antibody [Presence] in Serum or Plasma by Immunoassay|
|Ku antibody (immunoblot), blood|42870555|Ku Ab [Presence] in Serum by Immunoblot|
|Grape IgE level, blood|3044470|Grape IgE Ab/IgE total in Serum|
|O_Grape IgE level, blood|3044470|Grape IgE Ab/IgE total in Serum|
|Salmon IgE level, blood|3039263|Salmon IgE Ab/IgE total in Serum|
|O_Salmon IgE level, blood|3039263|Salmon IgE Ab/IgE total in Serum|
|Inhibin A level, blood|3007745|Inhibin A [Presence] in Serum or Plasma|
|Vancomycin timing, CSF|3016063|Vancomycin [Mass/volume] in Cerebral spinal fluid|
|Plum IgE level, blood|3046172|Plum IgE Ab/IgE total in Serum|
|O_Inhibin A level, blood|3007745|Inhibin A [Presence] in Serum or Plasma|
|O_Plum IgE level, blood|3046172|Plum IgE Ab/IgE total in Serum|
|Latex IgE level, blood|3009841|Latex IgE Ab [Units/volume] in Blood|
|Sunflower seed IgE level, blood|40764033|Sunflower Seed IgE Ab/IgE total in Serum|
|O_Latex IgE level, blood|3009841|Latex IgE Ab [Units/volume] in Blood|
|O_Sunflower seed IgE level, blood|40764033|Sunflower Seed IgE Ab/IgE total in Serum|
|Basophil count, blood|3006315|Basophils [#/volume] in Blood|
|Reticulocyte count, blood|3023520|Reticulocytes [#/volume] in Blood|
|Haemoglobin A2 level, blood|3017572|Hemoglobin A2 [Presence] in Blood|
|O_Reticulocyte count, blood|3023520|Reticulocytes [#/volume] in Blood|
|Mouse urine IgE level, blood|40764103|Mouse urine proteins IgE Ab/IgE total in Serum|
|Platelet glycoprotein IIb/IIIa, blood|3048550|Platelet glycoprotein IIb/IIIa Ab [Presence] in Blood by Immunoassay|
|O_Mouse urine IgE level, blood|40764103|Mouse urine proteins IgE Ab/IgE total in Serum|
|Bicarbonate level, blood|3006576|Bicarbonate [Moles/volume] in Blood|
|Creatine kinase level, blood|3030170|Creatine kinase [Mass/volume] in Blood|
|Chloride level, blood|3018572|Chloride [Moles/volume] in Blood|
|O_Creatine kinase level, blood|3030170|Creatine kinase [Mass/volume] in Blood|
|O_Chloride level, blood|3018572|Chloride [Moles/volume] in Blood|
|Coconut IgE level, blood|3041601|Coconut IgE Ab/IgE total in Serum|
|O_Coconut IgE level, blood|3041601|Coconut IgE Ab/IgE total in Serum|
|Goats milk IgE level, blood|40764096|Goat milk IgE Ab/IgE total in Serum|
|O_Goats milk IgE level, blood|40764096|Goat milk IgE Ab/IgE total in Serum|
|Pumpkin seed IgE level, blood|40764013|Pumpkin Seed IgE Ab/IgE total in Serum|
|Erythrocyte sedimentation rate, blood|3015183|Erythrocyte sedimentation rate [Velocity] in Red Blood Cells|
|O_Erythrocyte sedimentation rate, blood|3015183|Erythrocyte sedimentation rate [Velocity] in Red Blood Cells|
|O_Serum free light chains, blood|40759246|Immunoglobulin light chains.free [Presence] in Serum|
|CALC Anion Gap|3045716|Anion gap in Serum or Plasma by calculation|
|Copper level, serum|3027126|Copper [Mass/volume] in Serum or Plasma|
|Rye IgE level, blood|40761129|Cultivated Rye IgE Ab/IgE total in Serum|
|O_Rye IgE level, blood|40761129|Cultivated Rye IgE Ab/IgE total in Serum|
|GABA(a)R antibody, CSF|42529115|GABABR IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Gelatin IgE level, blood|40764030|Gelatin IgE Ab/IgE total in Serum|
|Platelet glycoprotein Ia/IIa, blood|40766209|Platelet glycoprotein Ia/IIa Ab [Presence] in Blood by Immunoassay|
|O_Gelatin IgE level, blood|40764030|Gelatin IgE Ab/IgE total in Serum|
|O_Haemoglobin H inclusions screen, blood|40762276|Hemoglobin H inclusion bodies [Presence] in Blood|
|Tyrosine level, blood|3033602|Tyrosine [Presence] in Blood|
|Seminal fluid IgE level, blood|3003177|Seminal fluid IgE Ab [Units/volume] in Serum|
|O_Seminal fluid IgE level, blood|3003177|Seminal fluid IgE Ab [Units/volume] in Serum|
|Complement C4 level, blood|3052973|Complement C4 [Presence] in Serum or Plasma|
|O_Complement C4 level, blood|3052973|Complement C4 [Presence] in Serum or Plasma|
|O_Citrulline level, blood|3034087|Citrulline [Presence] in Serum or Plasma|
|O_Copper level, urine|3028506|Copper [Mass/volume] in Urine|
|Prothrombin time, blood|3034426|Prothrombin time (PT)|
|O_Prothrombin time, blood|3034426|Prothrombin time (PT)|
|Complement C3 level, blood|3049668|Complement C3 [Presence] in Serum or Plasma|
|O_Complement C3 level, blood|3049668|Complement C3 [Presence] in Serum or Plasma|
|Tobramycin level, blood|3000444|Tobramycin [Moles/volume] in Serum or Plasma --peak|
|Glycosaminoglycans screen, urine|3011208|Glycosaminoglycans [Presence] in Urine|
|O_Tobramycin level, blood|3000444|Tobramycin [Moles/volume] in Serum or Plasma --peak|
|Strawberry IgE level, blood|40764027|Strawberry IgE Ab/IgE total in Serum|
|O_Glycosaminoglycans screen, urine|3011208|Glycosaminoglycans [Presence] in Urine|
|O_Aluminium level, blood|42528608|Aluminum [Moles/volume] in Blood|
|O_Strawberry IgE level, blood|40764027|Strawberry IgE Ab/IgE total in Serum|
|Reticulocyte %, blood|3023520|Reticulocytes [#/volume] in Blood|
|Selenium level, blood|3011306|Selenium [Mass/volume] in Blood|
|ANCA Titre, Blood|3026712|Neutrophil cytoplasmic Ab [Titer] in Serum|
|Mi-2 alpha antibody (immunoblot), blood|40759862|Mi-2 Ab [Presence] in Serum by Immunoblot|
|O_Selenium level, blood|3011306|Selenium [Mass/volume] in Blood|
|European hornet venom IgE level, blood|40764086|European Hornet IgE Ab/IgE total in Serum|
|Lime IgE level, blood|40761047|Lime IgE Ab/IgE total in Serum|
|O_European hornet venom IgE level, blood|40764086|European Hornet IgE Ab/IgE total in Serum|
|Buckwheat IgE level, blood|40764023|Buckwheat IgE Ab/IgE total in Serum|
|O_Lime IgE level, blood|40761047|Lime IgE Ab/IgE total in Serum|
|O_Buckwheat IgE level, blood|40764023|Buckwheat IgE Ab/IgE total in Serum|
|Metadrenaline output, 24hr urine|3008071|Urine output 24 hour|
|Somatostatin level, plasma|3002762|Somatostatin [Mass/volume] in Plasma|
|O_Androstenedione level, blood|3044426|Androstenedione [Presence] in Serum or Plasma|
|O_Metadrenaline output, 24hr urine|3008071|Urine output 24 hour|
|Pigeon feathers IgE level, blood|3017801|Pigeon feather IgE Ab [Presence] in Serum|
|O_Pigeon feathers IgE level, blood|3017801|Pigeon feather IgE Ab [Presence] in Serum|
|Cardiolipin IgG Ab level, blood|3018499|Cardiolipin IgG Ab [Interpretation] in Serum|
|PM/Scl-100 antibody (immunoblot), blood|21494114|PM-SCL-100 Ab [Presence] in Serum by Line blot|
|Chloride, sweat|3008848|Chloride [Moles/volume] in Sweat|
|Clam IgE level, blood|3042203|Clam IgE Ab/IgE total in Serum|
|O_Clam IgE level, blood|3042203|Clam IgE Ab/IgE total in Serum|
|Mi-2 beta antibody (immunoblot), blood|40759862|Mi-2 Ab [Presence] in Serum by Immunoblot|
|Garlic IgE level, blood|40763972|Garlic IgE Ab/IgE total in Serum|
|Pear IgE level, blood|40764068|Pear IgE Ab/IgE total in Serum|
|Mitotane level, blood|3005578|Mitotane [Mass/volume] in Serum or Plasma|
|O_Garlic IgE level, blood|40763972|Garlic IgE Ab/IgE total in Serum|
|O_Pear IgE level, blood|40764068|Pear IgE Ab/IgE total in Serum|
|Urea level, plasma|3034204|Urea [Mass/volume] in Serum or Plasma|
|FHHb (BG))|3014646|Fractional oxyhemoglobin in Blood|
|IGF-1 level, blood|3007922|Insulin-like growth factor-I [Mass/volume] in Blood|
|O_IGF-1 level, blood|3007922|Insulin-like growth factor-I [Mass/volume] in Blood|
|Macadamia Nut IgE level, blood|40764044|Macadamia IgE Ab/IgE total in Serum|
|Creatinine clearance, urine|3047148|Creatinine renal clearance in Urine and Serum or Plasma collected for unspecified duration|
|O_Macadamia Nut IgE level, blood|40764044|Macadamia IgE Ab/IgE total in Serum|
|Peach IgE level, blood|3046343|Peach IgE Ab/IgE total in Serum|
|O_Creatinine clearance, urine|3047148|Creatinine renal clearance in Urine and Serum or Plasma collected for unspecified duration|
|O_Peach IgE level, blood|3046343|Peach IgE Ab/IgE total in Serum|
|O_Homocysteine level, blood|3042985|Homocysteine [Presence] in Blood|
|Glucose level 30min, plasma|36660135|Glucose [Mass/volume] in Serum or Plasma --30 min post meal|
|Amphiphysin Abs, blood|3045706|Amphiphysin Ab [Presence] in Serum|
|Homocysteine level, plasma|3046382|Homocysteine [Presence] in Serum or Plasma|
|Tuna fish IgE level, blood|3042626|Tuna IgE Ab/IgE total in Serum|
|O_Tuna fish IgE level, blood|3042626|Tuna IgE Ab/IgE total in Serum|
|Alanine aminotransferase level, blood|46235106|Alanine aminotransferase [Enzymatic activity/volume] in Blood|
|Albumin level, urine|3025987|Albumin [Presence] in Urine|
|O_Alanine aminotransferase level, blood|46235106|Alanine aminotransferase [Enzymatic activity/volume] in Blood|
|Smooth muscle IgG Ab level, blood|3053270|Smooth muscle IgG Ab [Titer] in Serum|
|O_Albumin level, urine|3025987|Albumin [Presence] in Urine|
|Theophylline level, blood|3009072|Theophylline [Mass/volume] in Blood|
|Amino acids level, plasma|3048820|Alanine/Amino acids.total in Serum or Plasma|
|Wheat IgE level, blood|3039291|Wheat IgE Ab/IgE total in Serum|
|Pigeon serum proteins IgG antibodies|3017063|Pigeon serum IgG Ab [Presence] in Serum|
|Crab IgE level, blood|3044567|Crab IgE Ab/IgE total in Serum|
|O_Theophylline level, blood|3009072|Theophylline [Mass/volume] in Blood|
|O_Wheat IgE level, blood|3039291|Wheat IgE Ab/IgE total in Serum|
|O_Crab IgE level, blood|3044567|Crab IgE Ab/IgE total in Serum|
|Paprika IgE level, blood|40764000|Paprika IgE Ab/IgE total in Serum|
|Haemoglobin D level, blood|3013179|Hemoglobin D/Hemoglobin.total in Blood|
|Apolipoprotein A-I level, plasma|3008364|Apolipoprotein A-I [Mass/volume] in Serum or Plasma|
|O_Paprika IgE level, blood|40764000|Paprika IgE Ab/IgE total in Serum|
|Monocyte %, blood|3001604|Monocytes [#/volume] in Blood|
|O_Lactate level, blood|40762125|Lactate [Mass/volume] in Blood|
|Haemoglobin S level, blood|3010418|Hemoglobin S [Presence] in Blood|
|Chromogranin A level, serum|3014702|Chromogranin A [Moles/volume] in Serum or Plasma|
|Lipase level, fluid|3026286|Lipase [Enzymatic activity/volume] in Body fluid|
|Voltage-gated K channel Ab, blood|1617124|Voltage-gated potassium channel IgG+IgM Ab [Moles/volume] in Serum by Immunoassay|
|O_Voltage-gated K channel Ab, blood|1617124|Voltage-gated potassium channel IgG+IgM Ab [Moles/volume] in Serum by Immunoassay|
|Kiwi fruit IgE level, blood|3046124|Kiwifruit IgE Ab/IgE total in Serum|
|C24 long chain fatty acid level, plasma|3039491|Fatty acids.very long chain C24:0 (Tetracosanoate) [Mass/volume] in Serum or Plasma|
|O_Kiwi fruit IgE level, blood|3046124|Kiwifruit IgE Ab/IgE total in Serum|
|Salicylate level, blood|3024989|Salicylates [Presence] in Blood|
|O_Vitamin B12 level, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|O_Salicylate level, blood|3024989|Salicylates [Presence] in Blood|
|Common ragweed IgE level, blood|40763975|Common Ragweed IgE Ab/IgE total in Serum|
|O_Common ragweed IgE level, blood|40763975|Common Ragweed IgE Ab/IgE total in Serum|
|Basophil %, blood|3006315|Basophils [#/volume] in Blood|
|Ketones (dipstick), urine|3028893|Ketones [Presence] in Urine|
|Tacrolimus level, blood|3026250|Tacrolimus [Mass/volume] in Blood|
|O_Tacrolimus level, blood|3026250|Tacrolimus [Mass/volume] in Blood|
|Cocaine metabolite level, urine|3016879|Cocaine [Presence] in Urine|
|Basil IgE level, blood|40764049|Basil IgE Ab/IgE total in Serum|
|O_Basil IgE level, blood|40764049|Basil IgE Ab/IgE total in Serum|
|Amylase level, blood|46235169|Amylase [Enzymatic activity/volume] in Blood|
|O_Amylase level, blood|46235169|Amylase [Enzymatic activity/volume] in Blood|
|O_Urea level, blood|3009810|Urea [Mass/volume] in Blood|
|O_Copper level, blood|3015239|Copper [Mass/volume] in Blood|
|IgG Kappa/ Lambda Heavy Chain Ratio|44816760|IgG.kappa/IgG.lambda [Mass Ratio] in Serum or Plasma|
|IgM Kappa/ Lambda Heavy Chain Ratio|44816762|IgM.kappa/IgM.lambda [Mass Ratio] in Serum or Plasma|
|Urine Dipstick Clarity|3008204|Clarity of Urine|
|Lactate level, plasma|3020138|Lactate [Mass/volume] in Serum or Plasma|
|Squid IgE level, blood|40764042|Squid IgE Ab/IgE total in Serum|
|Hu Ab level, CSF|3007692|Neuronal nuclear Ab [Titer] in Cerebral spinal fluid|
|O_Squid IgE level, blood|40764042|Squid IgE Ab/IgE total in Serum|
|C3 nephritic factor level, blood|3048069|C3 nephritic factor [Presence] in Serum or Plasma|
|O_C3 nephritic factor level, blood|3048069|C3 nephritic factor [Presence] in Serum or Plasma|
|Almond IgE level, blood|3041042|Almond IgE Ab/IgE total in Serum|
|O_Almond IgE level, blood|3041042|Almond IgE Ab/IgE total in Serum|
|Platelet ATP:ADP ratio, blood|43533700|Adenosine triphosphate/Adenosine diphosphate [Entitic molar ratio] in Platelets|
|Orange IgE level, blood|40764009|Orange IgE Ab/IgE total in Serum|
|O_Orange IgE level, blood|40764009|Orange IgE Ab/IgE total in Serum|
|Bicarbonate level, urine|3008251|Bicarbonate [Moles/volume] in Urine|
|O_Bicarbonate level, urine|3008251|Bicarbonate [Moles/volume] in Urine|
|Monocyte count, blood|3001604|Monocytes [#/volume] in Blood|
|rCor a 1 hazelnut f428 IgE level, blood|40767668|Hazelnut recombinant (rCor a) 1.0101 IgE Ab [Units/volume] in Serum|
|Raspberry IgE level, blood|3965432|Raspberry IgE Ab [Presence] in Serum by Radioallergosorbent test (RAST)|
|O_Raspberry IgE level, blood|3965432|Raspberry IgE Ab [Presence] in Serum by Radioallergosorbent test (RAST)|
|Immunofixation, blood|3037756|Immunofixation for Serum or Plasma|
|Vasoactive intestinal polypeptide,plasma|3028054|Vasoactive intestinal peptide [Mass/volume] in Serum or Plasma|
|C1 esterase inhibitor level, blood|3049801|Complement C1 esterase inhibitor actual/normal in Serum or Plasma|
|O_C1 esterase inhibitor level, blood|3049801|Complement C1 esterase inhibitor actual/normal in Serum or Plasma|
|Poultry feathers IgE level, blood|40764098|Chicken feather IgE Ab/IgE total in Serum|
|Mustard IgE level, blood|3029844|Mustard IgE Ab/IgE total in Serum|
|O_Mustard IgE level, blood|3029844|Mustard IgE Ab/IgE total in Serum|
|Apricot IgE level, blood|3012180|Apricot IgE Ab [Units/volume] in Serum|
|Anchovy IgE level, blood|3024613|Anchovy IgE Ab [Units/volume] in Serum|
|O_Poultry feathers IgE level, blood|40764098|Chicken feather IgE Ab/IgE total in Serum|
|O_Anchovy IgE level, blood|3024613|Anchovy IgE Ab [Units/volume] in Serum|
|O_Apricot IgE level, blood|3012180|Apricot IgE Ab [Units/volume] in Serum|
|Nucleated red blood cell count, blood|3001490|Nucleated erythrocytes [#/volume] in Blood|
|Free T3 level, blood|3026925|Triiodothyronine (T3) Free [Mass/volume] in Serum or Plasma|
|Haemoglobin F level, blood|3015745|Hemoglobin F [Presence] in Blood|
|Metamyelocyte count, blood|3024507|Metamyelocytes [#/volume] in Blood|
|O_Free T3 level, blood|3026925|Triiodothyronine (T3) Free [Mass/volume] in Serum or Plasma|
|Glycine receptor antibody, serum|36031528|Glycine receptor Ab [Presence] in Serum or Plasma by Immunoassay|
|Chloride level, urine|3007733|Chloride [Moles/volume] in Urine|
|ACT|3016948|Activated clotting time (ACT) of Blood by Coagulation assay|
|Haemoglobin C level, blood|3042060|Hemoglobin C [Presence] in Blood|
|O_Chloride level, urine|3007733|Chloride [Moles/volume] in Urine|
|Banana IgE level, blood|40764048|Banana IgE Ab/IgE total in Serum|
|C26 long chain fatty acid level, plasma|3044876|Fatty acids.very long chain C26:0 (Hexacosanoate) [Mass/volume] in Serum or Plasma|
|White bean IgE level, blood|40761022|White Bean IgE Ab/IgE total in Serum|
|Beef IgE level, blood|40764092|Beef IgE Ab/IgE total in Serum|
|O_Banana IgE level, blood|40764048|Banana IgE Ab/IgE total in Serum|
|Rice IgE level, blood|40764052|Rice IgE Ab/IgE total in Serum|
|O_Beef IgE level, blood|40764092|Beef IgE Ab/IgE total in Serum|
|O_White bean IgE level, blood|40761022|White Bean IgE Ab/IgE total in Serum|
|O_Rice IgE level, blood|40764052|Rice IgE Ab/IgE total in Serum|
|Alk phos level, blood|3001110|Alkaline phosphatase [Enzymatic activity/volume] in Blood|
|O_Alk phos level, blood|3001110|Alkaline phosphatase [Enzymatic activity/volume] in Blood|
|PCO2|3023024|Carbon dioxide [Partial pressure] in Capillary blood|
|IgG subclass 4 level, blood|3024980|IgG subclass 4 [Mass/volume] in Serum|
|Red blood cell folate, blood|3035569|Folate [Mass/volume] in Red Blood Cells|
|Barley IgE level, blood|40764034|Barley IgE Ab/IgE total in Serum|
|Chick pea IgE level, blood|40764005|Chick Pea IgE Ab/IgE total in Serum|
|O_Barley IgE level, blood|40764034|Barley IgE Ab/IgE total in Serum|
|O_Chick pea IgE level, blood|40764005|Chick Pea IgE Ab/IgE total in Serum|
|O_Red blood cell folate, blood|3035569|Folate [Mass/volume] in Red Blood Cells|
|Striated muscle Ab level, blood|3037986|Striated muscle IgG Ab [Titer] in Serum|
|O_Striated muscle Ab level, blood|3037986|Striated muscle IgG Ab [Titer] in Serum|
|Protein level, urine|3037121|Protein [Mass/volume] in Urine|
|O_Protein level, urine|3037121|Protein [Mass/volume] in Urine|
|Macroprolactin level, blood|43055514|Macroprolactin [Presence] in Serum or Plasma|
|Bilirubin level, urine|3011258|Bilirubin.total [Presence] in Urine|
|Naive B cells IgD+ CD27-, blood|21493675|CD27+IgD- cells/Cells.CD19+CD20+ in Blood|
|O_Bilirubin level, urine|3011258|Bilirubin.total [Presence] in Urine|
|Manganese level, serum|3013059|Manganese [Moles/volume] in Serum or Plasma|
|O_Ferritin level, blood|3014636|Ferritin [Interpretation] in Blood|
|Anti-beta2-glycoprotein 1 IgM, blood|3043181|Beta 2 glycoprotein 1 IgM Ab [Presence] in Serum|
|O_Aldosterone level, blood|3013915|Aldosterone [Mass/volume] in Blood|
|Reducing substance, faeces|3001683|Reducing substances [Presence] in Stool|
|O_Reducing substance, faeces|3001683|Reducing substances [Presence] in Stool|
|O_Fructosamine level, blood|3038305|Fructosamine/Protein [Ratio] in Serum or Plasma|
|Vancomycin timing, serum|1616334|Vancomycin [Mass/volume] in Serum or Plasma --2 hours post dose|
|SRP antibody (immunoblot), blood|40766285|Signal Recognition Particle (SRP) Ab [Presence] in Serum or Plasma by Immunoblot|
|rCor a 14 hazelnut f439 IgE level, blood|21494261|Hazelnut recombinant (rCor a) 14 IgE Ab [Units/volume] in Serum|
|O_Yeast IgE level, blood|3039011|Baker's yeast IgE Ab/IgE total in Serum|
|Red Cell Distribution width|3050032|Hemoglobin distribution width [Mass/volume] in Blood|
|Voltage-gated K channel Ab, CSF|40771459|Voltage-gated potassium channel Ab [Moles/volume] in Cerebral spinal fluid|
|Pork IgE level, blood|40764108|Pork IgE Ab/IgE total in Serum|
|Haddock IgE level, blood|3023863|Haddock IgE Ab [Units/volume] in Serum|
|CD21- CD38- %, blood|36659842|CD21lowCD38- cells [#/volume] in Blood|
|O_Pork IgE level, blood|40764108|Pork IgE Ab/IgE total in Serum|
|O_Haddock IgE level, blood|3023863|Haddock IgE Ab [Units/volume] in Serum|
|Sodium level, sweat|3004277|Sodium [Moles/volume] in Sweat|
|FCOHb (BG)|3014646|Fractional oxyhemoglobin in Blood|
|pH, fluid|3018672|pH of Body fluid|
|Cheese mould IgE level, blood|40761039|Cheese mold type IgE Ab/IgE total in Serum|
|O_Cheese mould IgE level, blood|40761039|Cheese mold type IgE Ab/IgE total in Serum|
|CEA level, fluid|3013735|Carcinoembryonic Ag [Mass/volume] in Body fluid|
|O_CEA level, fluid|3013735|Carcinoembryonic Ag [Mass/volume] in Body fluid|
|Protein level, fluid|3005029|Protein [Mass/volume] in Body fluid|
|O_Protein level, fluid|3005029|Protein [Mass/volume] in Body fluid|
|Egg yolk IgE level, blood|40764100|Egg yolk IgE Ab/IgE total in Serum|
|Apple IgE level, blood|3043254|Apple IgE Ab/IgE total in Serum|
|O_Egg yolk IgE level, blood|40764100|Egg yolk IgE Ab/IgE total in Serum|
|KRAS Mutation Analysis|1259464|KRAS Somatic mutation analysis in Tumor by Molecular genetics method|
|O_Apple IgE level, blood|3043254|Apple IgE Ab/IgE total in Serum|
|Protein per day, urine|3037121|Protein [Mass/volume] in Urine|
|Pea IgE level, blood|40764061|Pea IgE Ab/IgE total in Serum|
|Cherry IgE level, blood|40764067|Cherry IgE Ab/IgE total in Serum|
|O_Pea IgE level, blood|40764061|Pea IgE Ab/IgE total in Serum|
|O_Cherry IgE level, blood|40764067|Cherry IgE Ab/IgE total in Serum|
|Neurotensin level, blood|3002061|Neurotensin [Mass/volume] in Plasma|
|Sodium level, blood|3000285|Sodium [Moles/volume] in Blood|
|MetHb (BG)|3004831|Methemoglobin [Presence] in Blood|
|O_Sodium level, blood|3000285|Sodium [Moles/volume] in Blood|
|MDA5 antibody (immunoblot), blood|42529582|MDA5 Ab [Presence] in Serum by Line blot|
|Onion IgE level, blood|40763971|Onion IgE Ab/IgE total in Serum|
|Aldosterone:Renin ratio 0min|3011145|Aldosterone/Renin [Ratio] in Plasma|
|O_Onion IgE level, blood|40763971|Onion IgE Ab/IgE total in Serum|
|rCor a 8 hazelnut f425 IgE level, blood|40761847|Hazelnut recombinant (rCor a) 8 IgE Ab [Units/volume] in Serum|
|Birch IgE level, blood|40763988|White Birch IgE Ab/IgE total in Serum|
|O_Birch IgE level, blood|40763988|White Birch IgE Ab/IgE total in Serum|
|1,25-Dihydroxy Vitamin D3 level, plasma|3024390|25-hydroxyvitamin D3 [Moles/volume] in Serum or Plasma|
|Vancomycin level, serum|3005715|Vancomycin [Mass/volume] in Serum or Plasma|
|Glucose level, fluid|3019210|Glucose [Mass/volume] in Body fluid|
|O_Glucose level, fluid|3019210|Glucose [Mass/volume] in Body fluid|
|IgG subclass 1 level, blood|3027135|IgG subclass 1 [Mass/volume] in Serum|
|Total metadrenalines:creat ratio, urine|3011452|Metanephrines/Creatinine [Mass Ratio] in Urine|
|Galactose-1-phosphate level, blood|3042819|Galactose 1 phosphate [Mass/mass] in Red Blood Cells|
|O_Galactose-1-phosphate level, blood|3042819|Galactose 1 phosphate [Mass/mass] in Red Blood Cells|
|Creatinine level, blood|3051825|Creatinine [Mass/volume] in Blood|
|O_Creatinine level, Blood|3051825|Creatinine [Mass/volume] in Blood|
|O_Haemoglobin A1c level, blood|3004410|Hemoglobin A1c/Hemoglobin.total in Blood|
|Creatinine level, fluid|3016662|Creatinine [Mass/volume] in Body fluid|
|Cryoglobulin, blood|3028490|Cryoglobulin [Mass/volume] in Blood|
|O_Creatinine level, fluid|3016662|Creatinine [Mass/volume] in Body fluid|
|O_Cryoglobulin, blood|3028490|Cryoglobulin [Mass/volume] in Blood|
|Red Blood Cell Distribution Width|3050032|Hemoglobin distribution width [Mass/volume] in Blood|
|Urate level, blood|1989097|Urate [Mass/volume] in Blood|
|O_Urate level, blood|1989097|Urate [Mass/volume] in Blood|
|IgG subclass 3 level, blood|3024139|IgG subclass 3 [Mass/volume] in Serum|
|Protein:creatinine index, urine|36304575|Protein and creatinine panel - Urine|
|Insulin level, serum|40765155|Glucose/Insulin [Ratio] in Serum or Plasma|
|Triglycerides level, fluid|3000637|Triglyceride [Mass/volume] in Body fluid|
|O_Triglycerides level, fluid|3000637|Triglyceride [Mass/volume] in Body fluid|
|Potassium level, blood|21490733|Potassium [Mass/volume] in Blood|
|O_Potassium level, blood|21490733|Potassium [Mass/volume] in Blood|
|Lithium level, blood|3001823|Lithium, [Moles/volume] in Blood|
|IgG subclass 2 level, blood|3028192|IgG subclass 2 [Mass/volume] in Serum|
|O_Haemoglobin electrophoresis, blood|3032868|Hemoglobin electrophoresis panel in Blood|
|O_Lithium level, blood|3001823|Lithium, [Moles/volume] in Blood|
|IgD level, blood|3031696|IgD [Mass/volume] in Urine|
|Centromere Ab level, blood|3033099|Centromere Ab [Titer] in Serum|
|CXCR5+CD4 T Cells, blood|3006414|CD5+CD2- cells/cells in Blood|
|Myeloperoxidase Ab level, blood|3016080|Myeloperoxidase Ab [Presence] in Serum|
|Haptoglobin level, serum|3040752|Haptoglobin [Presence] in Serum or Plasma|
|O_Haptoglobin level, serum|3040752|Haptoglobin [Presence] in Serum or Plasma|
|Urea level, urine|3034734|Urea [Mass/volume] in Urine|
|Cod IgE level, blood|3043915|Codfish IgE Ab/IgE total in Serum|
|O_Urea level, urine|3034734|Urea [Mass/volume] in Urine|
|O_Cod IgE level, blood|3043915|Codfish IgE Ab/IgE total in Serum|
|O_Myeloperoxidase Ab level, blood|3016080|Myeloperoxidase Ab [Presence] in Serum|
|Eosinophil count, blood|3013115|Eosinophils [#/volume] in Blood|
|Triglycerides level, blood|3022038|Triglyceride [Mass/volume] in Blood|
|O_Triglycerides level, blood|3022038|Triglyceride [Mass/volume] in Blood|
|Cyclic citrullinated peptide Ab, blood|3041391|Cyclic citrullinated peptide Ab [Presence] in Serum|
|O_Cyclic citrullinated peptide Ab, blood|3041391|Cyclic citrullinated peptide Ab [Presence] in Serum|
|Phenytoin level, blood|3021595|Phenytoin [Presence] in Serum or Plasma|
|Plasma cell count, blood|3001362|Plasma cells [#/volume] in Blood|
|O_Phenytoin level, blood|3021595|Phenytoin [Presence] in Serum or Plasma|
|Light chain output per day, urine|3017831|Lambda light chains [Mass/volume] in 24 hour Urine|
|Acylcarnitine profile, blood spot|3046449|Acylcarnitine [Presence] in Blood|
|Mango IgE level, blood|3037381|Mango IgE Ab [Units/volume] in Serum|
|O_Mango IgE level, blood|3037381|Mango IgE Ab [Units/volume] in Serum|
|CD4RO+ Memory CD4 T Cells, blood|3034660|CD4+CD45RO+ cells/cells in Blood|
|NRBC count per 100 WBC, blood|3001490|Nucleated erythrocytes [#/volume] in Blood|
|Normetadrenaline level, plasma|3016851|Normetanephrine [Mass/volume] in Serum or Plasma|
|IgA Kappa/ Lambda Heavy Chain Ratio|44816761|IgA.kappa/IgA.lambda [Mass Ratio] in Serum or Plasma|
|Finch serum proteins IgG Abs, blood|3042317|Finch droppings IgG Ab [Presence] in Serum|
|ACTH pre-15min, plasma|3051366|Corticotropin [Mass/volume] in Plasma --15 minutes pre 1 ug/kg CRH IV|
|Cows milk IgE level, blood|40764093|Cow milk IgE Ab/IgE total in Serum|
|O_Cows milk IgE level, blood|40764093|Cow milk IgE Ab/IgE total in Serum|
|Live cell NMDA receptor antibody, CSF|42529119|NMDAR IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Eosinophil %, blood|3013115|Eosinophils [#/volume] in Blood|
|Natalizumab antibodies, blood|40761116|Natalizumab Ab [Presence] in Serum|
|Pigeon droppings IgE level, blood|3019658|Pigeon droppings IgE Ab [Units/volume] in Serum|
|O_Pigeon droppings IgE level, blood|3019658|Pigeon droppings IgE Ab [Units/volume] in Serum|
|Metamyelocyte %, blood|3024507|Metamyelocytes [#/volume] in Blood|
|Inorganic phosphate level, urine|3025766|Phosphate [Presence] in Urine|
|O_Inorganic phosphate level, urine|3025766|Phosphate [Presence] in Urine|
|C22 long chain fatty acid level, plasma|3051219|Fatty acids.very long chain C22:0 (Docosanoate) [Mass/volume] in Serum or Plasma|
|CD4RA+ Naïve CD4 T Cells, blood|3033943|CD4+CD45RA+ cells/cells in Blood|
|pCO2 POC|3023024|Carbon dioxide [Partial pressure] in Capillary blood|
|Anti-beta2-glycoprotein 1 IgG, blood|3045355|Beta 2 glycoprotein 1 IgG Ab [Presence] in Serum|
|Zinc transporter 8 (ZnT8) Ab, blood|46235190|Zinc transporter 8 Ab [Units/volume] in Serum or Plasma by Immunoassay|
|Kaolin clotting ratio, blood|21492964|Activated clotting time (ACT) of Blood induced by Kaolin|
|Oat IgE level, blood|40763987|Oat IgE Ab/IgE total in Serum|
|Pristanate level, blood|3020622|Pristanate (C15:0(CH3)4) [Moles/volume] in Serum or Plasma|
|O_Oat IgE level, blood|40763987|Oat IgE Ab/IgE total in Serum|
|Poppy seed IgE level, blood|3010495|Poppy Seed IgE Ab [Units/volume] in Serum|
|O_Poppy seed IgE level, blood|3010495|Poppy Seed IgE Ab [Units/volume] in Serum|
|Free T4 level, blood|3008598|Thyroxine (T4) free [Mass/volume] in Serum or Plasma|
|O_Free T4 level, blood|3008598|Thyroxine (T4) free [Mass/volume] in Serum or Plasma|
|Alpha-1-antitrypsin level, blood|3031800|Alpha 1 antitrypsin actual/normal in Serum or Plasma|
|O_Alpha-1-antitrypsin level, blood|3031800|Alpha 1 antitrypsin actual/normal in Serum or Plasma|
|Egg white IgE level, blood|40764099|Egg white IgE Ab/IgE total in Serum|
|O_Egg white IgE level, blood|40764099|Egg white IgE Ab/IgE total in Serum|
|Recoverin Abs, blood|42529131|Recoverin IgG Ab [Presence] in Serum or Plasma by Line blot|
|Aluminium level, serum|3000578|Aluminum [Moles/volume] in Serum or Plasma|
|rTri a 14 wheat f433 IgE level, blood|40767666|Wheat recombinant (rTri a) 14 IgE Ab [Units/volume] in Serum|
|CD8RA+ Naïve CD8 T Cells, blood|36204492|CD8+CD45RA+ cells/CD8 Cells in Blood|
|O_Differential white cell count, blood|3053331|Differential cell count method - Blood|
|CD4 Effector T Cells, blood|3014037|CD3+CD4+ (T4 helper) cells/cells in Blood|
|Parrot serum proteins IgG antibodies|3039957|Parrot serum proteins+feathers+droppings IgG Ab [Presence] in Serum|
|O_Proinsulin level, blood|3046058|Proinsulin/Insulin [Ratio] in Serum or Plasma|
|O_Liver kidney microsomal Abs, blood|3046118|Liver kidney microsomal 1 IgG Ab [Presence] in Serum|
|Adrenocorticotrophic hormone, plasma|3038090|Corticotropin Canine [Mass/volume] in Plasma|
|Protein C level, blood|3004923|Protein C [Mass/volume] in Plasma|
|Tomato IgE level, blood|3040762|Tomato IgE Ab/IgE total in Serum|
|O_Tomato IgE level, blood|3040762|Tomato IgE Ab/IgE total in Serum|
|Leucocytes dipstick, urine|3045414|Leukocytes [Presence] in Urine|
|CD3 T cell count|3022533|CD3 cells/cells in Blood|
|Lipase level, blood|3004905|Lipase [Enzymatic activity/volume] in Serum or Plasma|
|O_Lipase level, blood|3004905|Lipase [Enzymatic activity/volume] in Serum or Plasma|
|Cat dander IgE level, blood|3035514|Cat dander IgE Ab/IgE total in Serum|
|O_Cat dander IgE level, blood|3035514|Cat dander IgE Ab/IgE total in Serum|
|Ionised calcium|3036426|Calcium.ionized [Mass/volume] in Blood|
|Mean cell volume, blood|3039385|Mean sphered cell volume [Entitic volume] in Red Blood Cells|
|Mackerel IgE level, blood|3014946|Mackerel IgE Ab [Units/volume] in Serum|
|O_Mackerel IgE level, blood|3014946|Mackerel IgE Ab [Units/volume] in Serum|
|Ecarin clotting time, blood|40758476|Ecarin clotting time (ECT) in Blood by Coagulation assay|
|ACTH level 30min, plasma|3026147|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|Prothrombin time and INR, blood|3002417|Prothrombin time (PT) in Blood by Coagulation assay|
|O_Prothrombin time and INR, blood|3002417|Prothrombin time (PT) in Blood by Coagulation assay|
|Haemoglobin A level, blood|3020428|Hemoglobin A/Hemoglobin.total in Blood|
|pH|3010421|pH of Blood|
|Volume (referral lab), urine|3036603|Volume of Urine|
|Recoverin, CSF|3965645|Recoverin Ab [Presence] in Cerebral spinal fluid by Immunoblot|
|Galactose-1-phosphate/Hb level, blood|3042819|Galactose 1 phosphate [Mass/mass] in Red Blood Cells|
|Dexamethasone level, serum|3002440|Dexamethasone [Mass/volume] in Serum or Plasma|
|Sodium level, fluid|3022810|Sodium [Moles/volume] in Body fluid|
|O_Sodium level, fluid|3022810|Sodium [Moles/volume] in Body fluid|
|Glucose level, plasma|44816672|Glucose [Mass/volume] in Serum, Plasma or Blood|
|Iron level, serum|3046728|Iron [Presence] in Serum or Plasma|
|Glucose (dipstick), urine|3020650|Glucose [Presence] in Urine|
|TIF1 gamma antibody (immunoblot), blood|42528593|TIF1-gamma Ab [Presence] in Serum by Line blot|
|Hen serum proteins IgG antibodies|3050281|Chicken serum proteins IgG Ab [Presence] in Serum|
|Myelocyte count, blood|3021120|Myelocytes [#/volume] in Blood|
|Thyroglobulin level, serum|3036535|Thyroglobulin [Mass/volume] in Serum or Plasma|
|Alpha-1-antitrypsin Pi phenotype, blood|3046867|Alpha 1 antitrypsin phenotype [Interpretation] in Serum or Plasma|
|Sweet Chestnut IgE level, blood|40761034|Chestnut IgE Ab/IgE total in Serum|
|Lead level, blood|3016252|Lead [Presence] in Blood|
|O_Sweet Chestnut IgE level, blood|40761034|Chestnut IgE Ab/IgE total in Serum|
|O_Alpha-1-antitrypsin Pi phenotype,blood|3046867|Alpha 1 antitrypsin phenotype [Interpretation] in Serum or Plasma|
|O_Lead level, blood|3016252|Lead [Presence] in Blood|
|C-peptide level 120min, blood|36660671|C peptide [Mass/volume] in Serum or Plasma --4.5 hours post meal|
|Triglyceride|3014600|Triglyceride [Percentile]|
|Folate level, serum|3036987|Folate [Mass/volume] in Serum or Plasma|
|Ganglioside GM1 antibody, blood|3044375|Ganglioside GM1 IgM Ab [Presence] in Serum|
|O_Vitamin B1 level, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|Cholesterol level, fluid|3015232|Cholesterol [Mass/volume] in Body fluid|
|O_Ganglioside GM1 Ab, blood|3044375|Ganglioside GM1 IgM Ab [Presence] in Serum|
|O_Cholesterol level, fluid|3015232|Cholesterol [Mass/volume] in Body fluid|
|Blackberry IgE level, blood|3046813|Blackberry IgE Ab/IgE total in Serum|
|Coffee IgE level, blood|40764011|Coffee IgE Ab/IgE total in Serum|
|O_Blackberry IgE level, blood|3046813|Blackberry IgE Ab/IgE total in Serum|
|O_Coffee IgE level, blood|40764011|Coffee IgE Ab/IgE total in Serum|
|C-peptide level, blood|3010084|C peptide [Mass/volume] in Serum or Plasma|
|Aspergillus fumigatus IgG, blood|3019410|Aspergillus fumigatus IgG Ab [Presence] in Serum|
|O_C-peptide level, blood|3010084|C peptide [Mass/volume] in Serum or Plasma|
|O_Aspergillus fumigatus IgG, blood|3019410|Aspergillus fumigatus IgG Ab [Presence] in Serum|
|O_Glycine receptor antibody, blood|36031870|Glycine receptor Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Carboxyhaemoglobin level, blood|3023081|Carboxyhemoglobin/Hemoglobin.total in Blood|
|Pumpkin IgE level, blood|3041898|Pumpkin IgE Ab/IgE total in Serum|
|Memory B cells CD19+ CD27+, blood|36303676|CD27 cells/Cells.CD19 in Blood|
|O_Carboxyhaemoglobin level, blood|3023081|Carboxyhemoglobin/Hemoglobin.total in Blood|
|Ferritin level, serum|3001122|Ferritin [Mass/volume] in Serum or Plasma|
|Pecan nut IgE level, blood|3039563|Pecan or Hickory Nut IgE Ab/IgE total in Serum|
|O_Pecan nut IgE level, blood|3039563|Pecan or Hickory Nut IgE Ab/IgE total in Serum|
|IGLON5 Antibodies, Blood|36031929|IgLON5 IgG Ab [Presence] in Serum by Immunofluorescence|
|pH, faeces|3015198|pH of Stool|
|Mosquito IgE level, blood|40763969|Aedes mosquito IgE Ab/IgE total in Serum|
|O_Mosquito IgE level, blood|40763969|Aedes mosquito IgE Ab/IgE total in Serum|
|Platelets|1092269|Platelets [Presence] in Blood|
|AMPA1/2 receptor antibody, serum|42529111|AMPAR2 IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Prothrombin time reference|3034426|Prothrombin time (PT)|
|CD8RO+ Memory CD8 T Cells, blood|36304873|CD45RO cells/CD3+CD8+ (T8 suppressor cells) cells in Blood|
|% Hypochromic Red Cells|3034824|Hypochromia [Presence] in Blood|
|Carbamazepine level, blood|3028415|carBAMazepine [Presence] in Serum or Plasma|
|O_Carbamazepine level, blood|3028415|carBAMazepine [Presence] in Serum or Plasma|
|Platelet count, blood|3007461|Platelets [#/volume] in Blood|
|O_Actual bicarbonate level, blood|3006576|Bicarbonate [Moles/volume] in Blood|
|Proteinase 3 Ab level, blood|3020955|Proteinase 3 [Presence] in Serum by Immunoassay|
|Aquaporin-4 Ab level, blood|3046426|Aquaporin 4 water channel IgG Ab [Presence] in Serum or Plasma|
|O_Aquaporin-4 Ab level, blood|3046426|Aquaporin 4 water channel IgG Ab [Presence] in Serum or Plasma|
|Yo Abs (blot), blood|36659959|PCA-1 IgG Ab [Presence] in Serum by Line blot|
|Fixed cell NMDA receptor antibody, CSF|42529119|NMDAR IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Horse dander IgE level, blood|3040612|Horse dander IgE Ab/IgE total in Serum|
|O_Proteinase 3 Ab level, blood|3020955|Proteinase 3 [Presence] in Serum by Immunoassay|
|O_Horse dander IgE level, blood|3040612|Horse dander IgE Ab/IgE total in Serum|
|Direct antiglobulin test baby, blood|1260040|Direct antiglobulin test.polyspecific reagent [Presence] on Red Blood Cells from Fetus|
|Adjusted calcium level, blood|3048816|Calcium.ionized [Moles/volume] adjusted to pH 7.4 in Blood|
|Thyroid stimulating hormone, blood|3011450|Thyrotropin [Presence] in Blood|
|O_Thyroid stimulating hormone, blood|3011450|Thyrotropin [Presence] in Blood|
|Calprotectin level, faeces|42529010|Calprotectin [Mass/volume] in Stool|
|O_Calprotectin level, faeces|42529010|Calprotectin [Mass/volume] in Stool|
|Intrinsic factor Ab level, blood|3021356|Intrinsic factor [Mass/volume] in Serum|
|O_Intrinsic factor Ab level, blood|3021356|Intrinsic factor [Mass/volume] in Serum|
|25-hydroxy vitamin D3 level, serum|3024390|25-hydroxyvitamin D3 [Moles/volume] in Serum or Plasma|
|O_Platelet function, blood|3966559|Platelet function profile in plasma|
|Urea level 240min, blood|3038227|Urea [Moles/time] in 24 hour Body fluid|
|Lactate dehydrogenase level, blood|46235370|Lactate dehydrogenase in body fluid/Lactate dehydrogenase in serum|
|O_Lactate dehydrogenase level, blood|46235370|Lactate dehydrogenase in body fluid/Lactate dehydrogenase in serum|
|Peanut IgE level, blood|40763980|Peanut IgE Ab/IgE total in Serum|
|Albumin level, fluid|3025313|Albumin [Mass/volume] in Body fluid|
|O_Peanut IgE level, blood|40763980|Peanut IgE Ab/IgE total in Serum|
|rCor a 9 hazelnut f440 IgE level, blood|40767664|Hazelnut recombinant (rCor a) 1.0401 IgE Ab [Units/volume] in Serum|
|O_Albumin level, fluid|3025313|Albumin [Mass/volume] in Body fluid|
|Urea level, fluid|40760504|Urea [Mass/volume] in Body fluid|
|7-alpha cholestenone level, blood|37021300|7-Alpha hydroxy-4-cholesten-3-one [Moles/volume] in Blood|
|Total Protein level, urine|3037121|Protein [Mass/volume] in Urine|
|Chlorhexidine c8 IgE level, blood|40769377|Chlorhexidine IgE Ab [Units/volume] in Serum|
|O_Urea level, fluid|40760504|Urea [Mass/volume] in Body fluid|
|Ginger IgE level, blood|40764089|Ginger IgE Ab/IgE total in Serum|
|O_Alder tree IgE level, blood|40763973|Grey Alder IgE Ab/IgE total in Serum|
|O_Ginger IgE level, blood|40764089|Ginger IgE Ab/IgE total in Serum|
|Bilirubin level, fluid|3045256|Bilirubin.total [Presence] in Body fluid|
|Adalimumab Serum-Drug level, blood|1617227|Adalimumab [Mass/volume] in Serum or Plasma --trough|
|O_Amino acids level, blood|3011743|Amino acids [Identifier] in Blood|
|O_Bilirubin level, fluid|3045256|Bilirubin.total [Presence] in Body fluid|
|Free fatty acid level, serum|3002225|Fatty acids [Mass/volume] in Serum or Plasma|
|Soya bean IgE level, blood|40764032|Soybean IgE Ab/IgE total in Serum|
|O_Soya bean IgE level, blood|40764032|Soybean IgE Ab/IgE total in Serum|
|Maize/Corn IgE level, blood|40764088|Corn IgE Ab/IgE total in Serum|
|vWF multimers, blood|3034186|von Willebrand factor (vWf) multimers [Presence] in Platelet poor plasma|
|O_Maize/Corn IgE level, blood|40764088|Corn IgE Ab/IgE total in Serum|
|O_vWF multimers, blood|3034186|von Willebrand factor (vWf) multimers [Presence] in Platelet poor plasma|
|TCR alpha and beta %, blood|3030679|TCR alpha beta cells [#/volume] in Blood|
|Aspartate aminotransferase|3010587|Aspartate aminotransferase [Presence] in Serum or Plasma|
|O_Lamotrigine level, blood|3039052|lamoTRIgine [Presence] in Serum or Plasma|
|Chicken IgE level, blood|3047420|Chicken IgE Ab/IgE total in Serum|
|O_Chicken IgE level, blood|3047420|Chicken IgE Ab/IgE total in Serum|
|Folate level, whole blood|3005794|Folate [Presence] in Blood|
|Leucocyte Immunophenotyping Analysis|40758359|Immunophenotyping study|
|Dehydroepiandrosterone sulphate, blood|3015884|Dehydroepiandrosterone sulfate (DHEA-S) [Mass/volume] in Serum or Plasma|
|O_Dehydroepiandrosterone sulphate, blood|3015884|Dehydroepiandrosterone sulfate (DHEA-S) [Mass/volume] in Serum or Plasma|
|Osteocalcin level, blood|3028772|Osteocalcin [Mass/volume] in Serum or Plasma|
|Estimated Osmolality (BG)|3004663|Osmolality of Body fluid|
|Urine Dipstick Colour|3027162|Color of Urine|
|O_Vitamin B12 and folate level, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|MCHC|46235811|Reticulocyte corpuscular hemoglobin concentration mean [Mass/volume] in Blood|
|CA-19-9 level, blood|3027495|Calcium [Presence] in Blood|
|O_CA-19-9 level, blood|3027495|Calcium [Presence] in Blood|
|Glomerular basement membrane Ab, blood|40770973|Glomerular basement membrane Ab [Presence] in Serum|
|Gamma glutamyl transferase|1761624|Gamma glutamyl transferase.macromolecular [Presence] in Serum or Plasma|
|O_Glomerular basement membrane Ab, blood|40770973|Glomerular basement membrane Ab [Presence] in Serum|
|Granulocyte %, blood|3035715|Granulocytes [#/volume] in Blood|
|rAra h 8 peanut f352 IgE level, blood|40766207|Peanut recombinant (rAra h) 8 IgE Ab [Units/volume] in Serum|
|O_Serum for Oligoclonal banding|3034248|Oligoclonal bands [#] in Serum or Plasma|
|Adrenal cortex Ab level, blood|40759789|Adrenal cortex IgG Ab [Units/volume] in Serum|
|O_Adrenal cortex Ab level, blood|40759789|Adrenal cortex IgG Ab [Units/volume] in Serum|
|CD8 Effector T Cells, blood|3037816|CD4+CD8+ cells/cells in Blood|
|O_Renin level, blood|3037310|Renin [Mass/volume] in Plasma|
|Alpha-galactosidase enzyme level, blood|3004671|Alpha galactosidase A [Enzymatic activity/volume] in Serum or Plasma|
|O_Alpha-galactosidase enzyme level,blood|3004671|Alpha galactosidase A [Enzymatic activity/volume] in Serum or Plasma|
|Neutrophil count, blood|3017732|Neutrophils [#/volume] in Blood|
|Sodium level, urine|3003181|Sodium [Moles/volume] in Urine|
|Potassium level, urine|3043518|Potassium/Creatinine [Ratio] in Urine|
|PM/Scl-75antibody by Immunoblot|21494115|PM-SCL-75 Ab [Presence] in Serum by Line blot|
|Calcitonin level, blood|3018840|Calcitonin [Moles/volume] in Serum or Plasma|
|O_Budgerigar (serum) IgG Ab, blood|3040960|Budgerigar droppings IgG Ab [Presence] in Serum|
|O_Calcitonin level, blood|3018840|Calcitonin [Moles/volume] in Serum or Plasma|
|Cockatiel serum proteins IgG antibodies|3042606|Cockatiel droppings IgG Ab [Presence] in Serum|
|IGLON5 Titre, Blood|36032064|IgLON5 IgG Ab [Titer] in Serum by Immunofluorescence|
|Specimen type (BG)|40769406|Specimen type|
|Cryoglobulin immunofixation, blood|3048538|Cryoglobulin type [Identifier] in Serum by Immunofixation|
|O_Glucose level 30min, blood|36660135|Glucose [Mass/volume] in Serum or Plasma --30 min post meal|
|Prolactin level, serum|3004722|Prolactin [Mass/volume] in Serum or Plasma|
|Gastric parietal cell Ab level,blood|3008717|Parietal cell Ab [Titer] in Serum|
|MuSK antibody level, blood|3039955|Muscle specific receptor tyrosine kinase Ab [Titer] in Serum or Plasma|
|O_MuSK Ab level, blood|3039955|Muscle specific receptor tyrosine kinase Ab [Titer] in Serum or Plasma|
|APTT reference, blood|3036489|Thrombin time|
|Vitamin B12 level, serum|3009035|Cobalamin (Vitamin B12) [Moles/volume] in Serum or Plasma|
|HbA1c|3034639|Hemoglobin A1c [Mass/volume] in Blood|
|O_Smooth muscle antibodies level, blood|3053270|Smooth muscle IgG Ab [Titer] in Serum|
|IgG Kappa Heavy Chain Measurement, blood|3019812|Kappa light chains [Mass/volume] in Serum or Plasma|
|Pepper IgE level, blood|3032718|Black Pepper IgE Ab/IgE total in Serum|
|O_Pepper IgE level, blood|3032718|Black Pepper IgE Ab/IgE total in Serum|
|Sugar chromatography, urine|3039379|Sucrose [Presence] in Urine|
|Turkey serum proteins IgG Ab|40763466|Turkey IgG Ab [Mass/volume] in Serum|
|ACTH level 60min, plasma|3026147|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|Rapeseed IgE level, blood|3005379|Rapeseed IgE Ab [Units/volume] in Serum|
|O_Rapeseed IgE level, blood|3005379|Rapeseed IgE Ab [Units/volume] in Serum|
|C-reactive protein level, blood|3000965|C reactive protein [Presence] in Serum or Plasma|
|O_C-reactive protein level, blood|3000965|C reactive protein [Presence] in Serum or Plasma|
|17-alphahydroxyprogesterone level, blood|3028718|17-Hydroxyprogesterone [Mass/volume] in Serum or Plasma|
|Additional Paraneoplastic Abs, CSF|3051230|Paraneoplastic Ab [Presence] in Cerebral spinal fluid by Immunoblot|
|Mannose binding lectin level, blood|3021997|Mannose-binding protein [Mass/volume] in Serum|
|Transferrin level, blood|3004789|Transferrin [Mass/volume] in Serum or Plasma|
|O_Transferrin level, blood|3004789|Transferrin [Mass/volume] in Serum or Plasma|
|Hu Ab (blot), blood|36660090|Neuronal nuclear type 1 IgG Ab [Presence] in Serum by Line blot|
|Glucose level, dialysate|3023572|Glucose [Mass/volume] in Dialysis fluid|
|1,25-dihydroxy Vitamin D level, serum|40765038|1,25-Dihydroxyvitamin D [Mass/volume] in Serum or Plasma|
|Complement C1q level, blood|3046458|Immune complex [Presence] in Serum or Plasma by C1q binding assay|
|Potassium level, fluid|3036243|Potassium [Moles/volume] in Body fluid|
|O_Glucose level, dialysate|3023572|Glucose [Mass/volume] in Dialysis fluid|
|Cryofibrinogen immunofixation, blood|3023504|Cryofibrinogen [Presence] in Plasma|
|O_Potassium level, fluid|3036243|Potassium [Moles/volume] in Body fluid|
|Total bilirubin level, blood|3028833|Bilirubin.total [Mass/volume] in Blood|
|Haematocrit|3050746|Hematocrit [Volume Fraction] of Blood by Estimated|
|O_Total bilirubin level, blood|3028833|Bilirubin.total [Mass/volume] in Blood|
|Creatinine level 240min, blood|3040071|Creatinine [Moles/time] in 24 hour Body fluid|
|Ciclosporin level, blood|3010375|cycloSPORINE [Mass/volume] in Blood|
|O_Ciclosporin level, blood|3010375|cycloSPORINE [Mass/volume] in Blood|
|O_Immunodeficiency panel, blood|3044481|Immunodeficiency panel - Blood by Flow cytometry (FC)|
|Jo-1 antibody (immunoblot), blood|40759850|Jo-1 extractable nuclear Ab [Presence] in Serum by Immunoblot|
|ANCA pattern titre, blood|3026712|Neutrophil cytoplasmic Ab [Titer] in Serum|
|Yo Ab level, blood|3038593|PCA-1 Ab [Titer] in Serum|
|rAra h 1 peanut f422 IgE level, blood|40766207|Peanut recombinant (rAra h) 8 IgE Ab [Units/volume] in Serum|
|Platelet glycoprotein Ib, blood|40766208|Platelet glycoprotein Ib/Ix Ab [Presence] in Blood by Immunoassay|
|Albumin level, blood|3010072|Albumin concentration given|
|O_Albumin level, blood|3010072|Albumin concentration given|
|pH Urine Dipstick|3015736|pH of Urine|
|rAra h 3 peanut f424 IgE level, blood|40761871|Peanut recombinant (rAra h) 3 IgE Ab [Units/volume] in Serum|
|Potato IgE level, blood|3009883|Potato IgE Ab [Units/volume] in Serum|
|CD62L shedding|3004188|CD62L cells/cells in Blood|
|O_Potato IgE level, blood|3009883|Potato IgE Ab [Units/volume] in Serum|
|Inorganic phosphate level, blood|3018913|Phosphate [Moles/volume] in Blood|
|O_Inorganic phosphate level, blood|3018913|Phosphate [Moles/volume] in Blood|
|rAra h 9 peanut f427 IgE level, blood|40767665|Peanut recombinant (rAra h) 9 IgE Ab [Units/volume] in Serum|
|Rape pollen IgE level, blood|3021944|Rape Pollen IgE Ab [Units/volume] in Serum|
|NPM1, blood|43055275|NPM1 gene c.960insCATG transcript/control transcript [# Ratio] in Blood or Tissue by Molecular genetics method|
|O_Rape pollen IgE level, blood|3021944|Rape Pollen IgE Ab [Units/volume] in Serum|
|O_Gastrin level, blood|3009927|Gastrin [Mass/volume] in Serum or Plasma|
|O_Urea and electrolytes, blood|3009810|Urea [Mass/volume] in Blood|
|Shrimp IgE level, blood|3021226|Shrimp IgE Ab [Units/volume] in Serum|
|Wasp venom IgE level, blood|3004274|Wasp venom IgE Ab [Units/volume] in Serum|
|Levetiracetam level, blood|3020666|levETIRAcetam [Mass/volume] in Serum or Plasma|
|O_Shrimp IgE level, blood|3021226|Shrimp IgE Ab [Units/volume] in Serum|
|O_Wasp venom IgE level, blood|3004274|Wasp venom IgE Ab [Units/volume] in Serum|
|O_Levetiracetam level, blood|3020666|levETIRAcetam [Mass/volume] in Serum or Plasma|
|Melon IgE level, blood|40761058|Honeydew melon IgE Ab/IgE total in Serum|
|Neutrophil %, blood|3017732|Neutrophils [#/volume] in Blood|
|O_Melon IgE level, blood|40761058|Honeydew melon IgE Ab/IgE total in Serum|
|rGly m 4 soy f353 IgE level, blood|40766206|Soybean recombinant (rGly m) 4 IgE Ab [Units/volume] in Serum|
|Desmethylclobazam level, blood|40762688|cloBAZam [Mass/volume] in Blood|
|Factor VIII level chromogenic, blood|3032768|Coagulation factor VIII activity actual/normal in Platelet poor plasma by Chromogenic method|
|Phenobarbitone level, blood|3024886|PHENobarbital [Presence] in Serum or Plasma|
|zzzOxalate:creatinine ratio, urine|3026806|Azelate/Creatinine [Molar ratio] in Urine|
|Aldosterone level 240min, plasma|3016953|Aldosterone renal clearance in 24 hour Urine and Serum or Plasma|
|EJ antibody (immunoblot), blood|42529529|Ej Ab [Presence] in Serum by Line blot|
|O_Thyroglobulin level, blood|3036535|Thyroglobulin [Mass/volume] in Serum or Plasma|
|Gluten IgE level, blood|40764031|Gluten IgE Ab/IgE total in Serum|
|O_Gluten IgE level, blood|40764031|Gluten IgE Ab/IgE total in Serum|
|ACTH level 45min, plasma|3009084|Cortisol [Mass/volume] in Serum or Plasma --56 hours post 40 ug corticotropin IM BID 3 day|
|O_ACTH pre-15min, blood|40761652|Corticotropin [Moles/volume] in Plasma --15 minutes pre dose insulin IV|
|Troponin I level, serum|3021337|Troponin I.cardiac [Mass/volume] in Serum or Plasma|
|Sodium level 240min, blood|3000285|Sodium [Moles/volume] in Blood|
|Cucumber IgE, blood|40764090|Cucumber IgE Ab/IgE total in Serum|
|Fondaparinux level, blood|3053342|Fondaparinux [Mass/volume] in Serum or Plasma|
|Glucose level 90min, plasma|3020260|Glucose [Mass/volume] in Serum or Plasma --45 minutes post 100 g glucose PO|
|O_Cucumber IgE, blood|40764090|Cucumber IgE Ab/IgE total in Serum|
|O_Troponin I level, blood|3033745|Troponin I.cardiac [Mass/volume] in Blood|
|Protein (dipstick), urine|36304575|Protein and creatinine panel - Urine|
|Blast cell count, blood|3025159|Blasts/Leukocytes in Blood|
|Thyroglobulin Ab level, serum|3024857|Thyroglobulin Ab [Presence] in Serum|
|Lymphocyte count by flow cytometry|3026710|Lymphocytes [#/volume] in Blood by Flow cytometry (FC)|
|Tubular reabsorption phosphate|3964988|Tubular reabsorption of phosphorus/Glomerular filtration rate [Mass/volume] in Urine and Serum or Plasma|
|C-peptide level 0min, blood|36659681|C peptide [Mass/volume] in Serum or Plasma --15 min post meal|
|Non-HDL cholesterol, blood|3044491|Cholesterol non HDL [Mass/volume] in Serum or Plasma|
|Free protein S level, blood|3026591|Protein S Free Ag [Units/volume] in Platelet poor plasma by Immunoassay|
|Cacao (chocolate) IgE level, blood|40761041|Chocolate IgE Ab/IgE total in Serum|
|O_Cacao (chocolate) IgE level, blood|40761041|Chocolate IgE Ab/IgE total in Serum|
|pCO2(T)c|3023024|Carbon dioxide [Partial pressure] in Capillary blood|
|O_Bilirubin level, blood|3028833|Bilirubin.total [Mass/volume] in Blood|
|Liver and kidney microsomal Ab|3046118|Liver kidney microsomal 1 IgG Ab [Presence] in Serum|
|Hu Ab level, blood|3009400|Neuronal nuclear Ab [Titer] in Serum|
|Amoxycilloyl IgE level, blood|3031955|Amoxicillin IgE Ab/IgE total in Serum|
|O_Amoxycilloyl IgE level, blood|3031955|Amoxicillin IgE Ab/IgE total in Serum|
|Platelet ADP level, blood|40759127|Platelet aggregation ADP induced in Blood --10 umol/L|
|Bile acid level, blood|3043231|Bile acid [Presence] in Bile fluid|
|O_Bile acid level, blood|3043231|Bile acid [Presence] in Bile fluid|
|Glucose level 60min, serum|3023186|Glucose [Mass/volume] in Serum or Plasma --45 minutes post dose glucose|
|Lipoprotein (a) level, blood|40763399|Lipoprotein a/total Lipoprotein in Serum or Plasma|
|O_Lipoprotein (a) level, blood|40763399|Lipoprotein a/total Lipoprotein in Serum or Plasma|
|CD4 Naïve T Cells, blood|3014037|CD3+CD4+ (T4 helper) cells/cells in Blood|
|ACTH level 90min, plasma|3026147|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|Budgerigar serum IgG Ab level, blood|40763998|Budgerigar feather IgE Ab/IgE total in Serum|
|Caged bird feathers IgE level, blood|40764098|Chicken feather IgE Ab/IgE total in Serum|
|O_Caged bird feathers IgE level, blood|40764098|Chicken feather IgE Ab/IgE total in Serum|
|Cortisol pre-15min, serum|3052619|Cortisol [Moles/volume] in Serum or Plasma --15 minutes pre 1 ug/kg CRH IV|
|rAra h 2 peanut f423 IgE level, blood|40761872|Peanut recombinant (rAra h) 2 IgE Ab [Units/volume] in Serum|
|THSD7A Ab, blood|1001604|THSD7A IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Day 1 ACTH level, plasma|40757368|Corticotropin [Mass/volume] in Plasma --9 AM 2nd day specimen|
|O_Cardiolipin Ab level, blood|3020259|Cardiolipin IgG Ab [Titer] in Serum|
|Haemophilus influenzae B Ab level, blood|3044398|Haemophilus influenzae B Ag [Presence] in Serum|
|IgA Kappa Heavy Chain Measurement, blood|44816756|IgA.kappa [Mass/volume] in Serum or Plasma|
|O_Myelin associated glycoprotein Abblood|3028891|Myelin associated glycoprotein IgG Ab [Titer] in Serum|
|Lentil IgE level, blood|3011523|Lentils IgE Ab [Units/volume] in Serum|
|O_Lentil IgE level, blood|3011523|Lentils IgE Ab [Units/volume] in Serum|
|House dust mite IgE level, blood|3018381|European house dust mite IgG Ab [Presence] in Blood|
|O_House dust mite IgE level, blood|3018381|European house dust mite IgG Ab [Presence] in Blood|
|Urea level, dialysate|3966666|Urea [Mass/volume] in Dialysis fluid|
|BRAF Mutation Analysis|3039156|BRAF gene targeted mutation analysis in Blood or Tissue by Molecular genetics method|
|rVes v5 wasp i209 IgE level, blood|40763295|Common wasp recombinant (rVes v) 5 IgE Ab [Units/volume] in Serum|
|O_Urea level, dialysate|3966666|Urea [Mass/volume] in Dialysis fluid|
|O_17alphahydroxyprogesterone level,blood|3028718|17-Hydroxyprogesterone [Mass/volume] in Serum or Plasma|
|Rheumatoid factor activity, blood|3022120|Rheumatoid factor [Presence] in Body fluid|
|Canary Ab level, blood|40762010|Canary feather IgG Ab [Mass/volume] in Serum|
|Calculated LDL cholesterol level, blood|3028288|Cholesterol in LDL [Mass/volume] in Serum or Plasma by calculation|
|GABAB antibody, serum|42529108|GABABR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Collagen and ADP platelet func, blood|3027391|Platelet function (closure time) collagen+ADP induced [Time] in Blood|
|rVes v1 wasp i211 IgE level, blood|40769374|Common wasp recombinant (rVes v) 1 IgE Ab [Units/volume] in Serum|
|IGF-1 level 0min, blood|3007922|Insulin-like growth factor-I [Mass/volume] in Blood|
|CD8 Naïve T Cells, blood|3020470|CD8+CD28+ cells/cells in Blood|
|Date IgE level, blood|3022086|Dates IgE Ab [Units/volume] in Serum|
|O_Date IgE level, blood|3022086|Dates IgE Ab [Units/volume] in Serum|
|Myelin associated glycoprotein Ab, blood|3017005|Myelin associated glycoprotein Ab [Presence] in Serum|
|O_Cockatiel Ab level, blood|40764110|Cockatiel feather IgE Ab/IgE total in Serum|
|Testosterone level, serum|3008893|Testosterone [Mass/volume] in Serum or Plasma|
|Endomysial IgA Ab level, blood|3020961|Endomysium IgA Ab [Titer] in Serum|
|vWF collagen binding level, blood|3029847|von Willebrand factor (vWf).collagen binding activity actual/normal in Platelet poor plasma by Immunoassay|
|Cortisol level 30min, serum|3010523|Cortisol [Moles/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|O_vWF collagen binding level, blood|3029847|von Willebrand factor (vWf).collagen binding activity actual/normal in Platelet poor plasma by Immunoassay|
|O_Endomysial IgA Ab level, blood|3020961|Endomysium IgA Ab [Titer] in Serum|
|r Gly m 5 soy f431 IgE level, blood|43533744|Soybean native (nGly m) 5 IgE Ab [Units/volume] in Serum|
|Edoxaban level, blood|42528613|Edoxaban [Mass/volume] in Serum or Plasma by LC/MS/MS|
|Glucose level 60min, plasma|36660135|Glucose [Mass/volume] in Serum or Plasma --30 min post meal|
|Blood Ketones, POC|3041426|Ketones [Moles/volume] in Blood|
|Protein electrophoresis, blood|3032868|Hemoglobin electrophoresis panel in Blood|
|O_Protein electrophoresis, blood|3032868|Hemoglobin electrophoresis panel in Blood|
|Gentamicin level, blood|3035510|Gentamicin [Mass/volume] in Serum or Plasma|
|O_Gentamicin level, blood|3035510|Gentamicin [Mass/volume] in Serum or Plasma|
|Cortisol level 45min, serum|40759705|Cortisol [Mass/volume] in Serum or Plasma --45 minutes post XXX challenge|
|Egg IgE level, blood|40764099|Egg white IgE Ab/IgE total in Serum|
|Blast cell %, blood|3025159|Blasts/Leukocytes in Blood|
|CA-15-3 level, blood|3027495|Calcium [Presence] in Blood|
|O_CA-15-3 level, blood|3027495|Calcium [Presence] in Blood|
|ACTH level 120min, plasma|3049123|Corticotropin [Mass/volume] in Plasma --12 AM specimen|
|Creatinine|3007081|Creatinine [Interpretation] in Urine|
|Procalcitonin level, blood|3046279|Procalcitonin [Mass/volume] in Serum or Plasma|
|r Gly m 6 soy f432 IgE level, blood|40768460|Soybean native (nGly m) 6 IgE Ab [Units/volume] in Serum|
|ACTH level 15min, plasma|3026147|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|Elastase 1 level, faeces|3034965|Elastase.pancreatic [Presence] in Stool|
|O_Elastase 1 level, faeces|3034965|Elastase.pancreatic [Presence] in Stool|
|O_Urine Metadrenalines|3006956|Metanephrines [Mass/volume] in Urine|
|NMDA receptor antibody, blood|42529112|NMDAR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|O_NMDA receptor antibody, blood|42529112|NMDAR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Serum transferrin receptor, blood|3046569|Transferrin receptor.soluble [Moles/volume] in Serum or Plasma|
|Conjugated bilirubin level, blood|3005772|Bilirubin.conjugated [Moles/volume] in Serum or Plasma|
|CD3 T cell percentage|3011412|CD3 cells [#/volume] in Blood|
|O_Conjugated bilirubin level, blood|3005772|Bilirubin.conjugated [Moles/volume] in Serum or Plasma|
|Acetylcholine receptor Ab level, blood|3006257|Acetylcholine receptor Ab [Moles/volume] in Serum|
|O_Bone marrow aspirate exam|3048879|Bone marrow aspiration report|
|O_Acetylcholine receptor Ab level, blood|3006257|Acetylcholine receptor Ab [Moles/volume] in Serum|
|Hyaluronic acid level, serum|3009931|Hyaluronate [Mass/volume] in Serum or Plasma|
|gp210 antibody by Immunoblot|40759835|Nuclear pore protein gp210 Ab [Presence] in Serum by Immunoblot|
|Creatinine level (referral lab), urine|3007081|Creatinine [Interpretation] in Urine|
|O_CA-19-9 level, fluid|3000822|Calcium [Mass/volume] in Body fluid|
|CA-19-9 level, fluid|3000822|Calcium [Mass/volume] in Body fluid|
|Candida Ab level, blood|3039290|Candida sp IgG Ab [Titer] in Serum|
|Bet v 1 birch t215 IgE level, blood|40768464|Silver birch native (nBet v) 1 IgE Ab [Units/volume] in Serum|
|Cystatin C level, blood|3051083|Cystatin C [Mass/volume] in Urine|
|O_Cystatin C level, blood|3051083|Cystatin C [Mass/volume] in Urine|
|O_Leucocyte immunophenotyping, blood|40758359|Immunophenotyping study|
|Lupine seed IgE level, blood|3029411|Lupin seed IgE Ab [Units/volume] in Serum|
|Lymphocyte %, blood|3019198|Lymphocytes [#/volume] in Blood|
|O_Lupine seed IgE level, blood|3029411|Lupin seed IgE Ab [Units/volume] in Serum|
|Leucocyte immunophenotyping, blood|40758359|Immunophenotyping study|
|O_Gastric parietal cell Abs, blood|3000399|Parietal cell IgG Ab [Presence] in Serum|
|Holotranscobalamin, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|O_Farm birds feather mix IgE level,blood|40764098|Chicken feather IgE Ab/IgE total in Serum|
|Troponin I|3033745|Troponin I.cardiac [Mass/volume] in Blood|
|Tryptase level, blood|3042655|Tryptase [Mass/volume] in Body fluid|
|Glucose level 0min, plasma|3004723|Glucose [Mass/volume] in Serum or Plasma --1 minute post 0.5 g/kg glucose IV|
|O_Tryptase level, blood|3042655|Tryptase [Mass/volume] in Body fluid|
|Amikacin level, blood|3030247|Amikacin [Moles/volume] in Serum or Plasma --trough|
|O_Amikacin level, blood|3030247|Amikacin [Moles/volume] in Serum or Plasma --trough|
|% PT normal plasma correction, blood|3033658|Prothrombin time (PT) actual/Normal|
|Aldosterone level 0min, plasma|3011145|Aldosterone/Renin [Ratio] in Plasma|
|CD4 TReg Cells, blood|3014037|CD3+CD4+ (T4 helper) cells/cells in Blood|
|Lymphocyte count, blood|3019198|Lymphocytes [#/volume] in Blood|
|CA-125 level, blood|3027495|Calcium [Presence] in Blood|
|Rheumatoid factor, blood|3043745|Rheumatoid factor [Presence] in Serum|
|CALC Haemoglobin|3027484|Hemoglobin [Mass/volume] in Blood by calculation|
|CD19 B cells count|36303804|IgM cells/Cells.CD19 in Blood|
|O_Rheumatoid factor, blood|3043745|Rheumatoid factor [Presence] in Serum|
|O_CA-125 level, blood|3027495|Calcium [Presence] in Blood|
|Timothy grass IgE level, blood|40764057|Timothy IgE Ab/IgE total in Serum|
|O_Haemophilus influenzae B Ab levelblood|3044398|Haemophilus influenzae B Ag [Presence] in Serum|
|O_Timothy grass IgE level, blood|40764057|Timothy IgE Ab/IgE total in Serum|
|Bet v 2 birch t216 IgE level, blood|40763988|White Birch IgE Ab/IgE total in Serum|
|IgM Kappa Heavy Chain Measurement, blood|44816758|IgM.kappa [Mass/volume] in Serum or Plasma|
|Iohexol half life|3032437|Iohexol renal clearance in Urine and Serum or Plasma|
|Day 3 Cortisol level, serum|3033285|Cortisol [Mass/volume] in Serum or Plasma --3 PM specimen|
|Rat mix IgE level, blood|3020228|Rat muliialgro IgE Ab [Units/volume] in Serum|
|Haematocrit level, blood|3050746|Hematocrit [Volume Fraction] of Blood by Estimated|
|Occult blood detection, faeces|3030153|Occult blood panel - Stool|
|O_Lupus anticoagulant screen, blood|1259791|Lupus anticoagulant aPTT screening panel - Platelet poor plasma by Coagulation assay|
|O_Occult blood detection, faeces|3030153|Occult blood panel - Stool|
|O_IgG subclasses level, blood|3024139|IgG subclass 3 [Mass/volume] in Serum|
|Creatinine level, dialysate|3043954|Creatinine in dialysis fluid/Creatinine in serum or plasma|
|O_Creatinine level, dialysate|3043954|Creatinine in dialysis fluid/Creatinine in serum or plasma|
|O_Anti-factor Xa, blood|3045452|LMW Heparin [Units/volume] in Platelet poor plasma|
|O_Glucagon level, blood|3023436|Glucagon [Mass/volume] in Serum or Plasma|
|O_ACTH level 60min,blood|3026147|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post dose corticotropin|
|cLAC (BG)|3025022|Lactate [Mass/volume] in Cerebral spinal fluid|
|Nitrites Urine Dipstick|3021601|Nitrite [Presence] in Urine by Test strip|
|RET-He|3023520|Reticulocytes [#/volume] in Blood|
|Mean cell volume|3039385|Mean sphered cell volume [Entitic volume] in Red Blood Cells|
|Potassium|21490733|Potassium [Mass/volume] in Blood|
|Lactate|3036579|Lactate [Presence] in Urine|
|O_Interferon gamma release, blood|3010105|Interferon gamma [Mass/volume] in Serum or Plasma|
|Vitamin E:lipid ratio|40762341|Tocopherols/Cholesterol [Molar ratio] in Serum or Plasma|
|Alkaline phosphatase|3035756|Alkaline phosphatase [Enzymatic activity/mass] in Tissue|
|APTT 50:50 mix, blood|3036489|Thrombin time|
|O_APTT 50:50 mix, blood|3036489|Thrombin time|
|Growth hormone level 90min, serum|40760101|Somatotropin [Mass/volume] in Serum or Plasma --90 minutes post resting|
|Growth hormone level 30min, serum|40760100|Somatotropin [Mass/volume] in Serum or Plasma --30 minutes post resting|
|Cortisol level 15min, serum|3018080|Cortisol [Mass/volume] in Serum or Plasma --15 minutes post XXX challenge|
|Hct (BG)|1092441|Hematocrit [Pure volume fraction] of Blood by calculation|
|Infliximab Serum-Drug level, blood|3042299|inFLIXimab [Mass/volume] in Serum or Plasma|
|Bet v 6 birch t225 IgE level, blood|40763988|White Birch IgE Ab/IgE total in Serum|
|O_Glucose level, blood|3000483|Glucose [Mass/volume] in Blood|
|Anti-neutrophil cytoplasmic Ab, blood|3009628|Neutrophil cytoplasmic Ab [Presence] in Serum|
|O_Platelet aggregation, blood|36660133|Platelet aggregation [Interpretation] in Platelet rich plasma|
|Tr, CSF|3040228|PCA-Tr Ab [Titer] in Cerebral spinal fluid|
|Methaemoglobin level, blood|3005147|Methemoglobin [Mass/volume] in Blood|
|CALC LDL|3038988|Cholesterol in LDL [Moles/volume] in Serum or Plasma by calculation|
|Haemoglobin|3005872|Hemoglobin [Presence] in Blood|
|G6PD level, blood|44787112|Glucose-6-Phosphate dehydrogenase/Pyruvate kinase [Ratio] in Blood|
|O_G6PD level, blood|44787112|Glucose-6-Phosphate dehydrogenase/Pyruvate kinase [Ratio] in Blood|
|O_Vancomycin level, blood|3039257|Vancomycin [Moles/volume] in Serum or Plasma --trough|
|Glutamic acid decarboxylase Ab, blood|42528825|Glutamate decarboxylase Ab [Presence] in Serum or Plasma by Immunofluorescence|
|O_Glutamic acid decarboxylase Ab, blood|42528825|Glutamate decarboxylase Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Valproate level, blood|3009466|Valproate [Moles/volume] in Serum or Plasma|
|Phospholipase A2 Ab, Blood|42529060|Phospholipase A2 receptor IgG Ab [Presence] in Serum by Line blot|
|Urate level, urine|3033526|Urate [Mass/volume] in Urine|
|O_Valproate level, blood|3009466|Valproate [Moles/volume] in Serum or Plasma|
|O_Urate level, urine|3033526|Urate [Mass/volume] in Urine|
|CV2/CRMP5, CSF|3037012|CV2 IgG Ab [Titer] in Cerebral spinal fluid|
|ACTH level 0min, plasma|40763734|Cortisol Free [Mass/volume] in Serum or Plasma --1 hour post dose corticotropin|
|CEA level, blood|3013444|Carcinoembryonic Ag [Units/volume] in Serum or Plasma|
|O_CEA level, blood|3013444|Carcinoembryonic Ag [Units/volume] in Serum or Plasma|
|Ri (blot), CSF|1175769|Ma+Ta Ab [Units/volume] in Cerebral spinal fluid by Line blot|
|Insulin IgG Ab level, blood|40759653|Insulin IgG Ab [Units/volume] in Serum|
|O_Insulin IgG Ab level, blood|40759653|Insulin IgG Ab [Units/volume] in Serum|
|Mouse IgE level, blood|3012904|Mouse multi IgE Ab [Units/volume] in Serum|
|Alpha-fetoprotein level, blood|3025053|Alpha-1-Fetoprotein [Presence] in Serum or Plasma|
|O_Alpha-fetoprotein level, blood|3025053|Alpha-1-Fetoprotein [Presence] in Serum or Plasma|
|Apixaban level, blood|43055442|Apixaban [Mass/volume] in Serum or Plasma|
|Titin Abs, blood|42529128|Titin IgG Ab [Presence] in Serum or Plasma by Line blot|
|Cortisol level 60min, serum|3009084|Cortisol [Mass/volume] in Serum or Plasma --56 hours post 40 ug corticotropin IM BID 3 day|
|Phytanic acid level, plasma|3021664|Phytanate (C16:0(CH3)4) [Moles/volume] in Serum or Plasma|
|Thiopentone level, blood|3011070|Thiopental [Mass/volume] in Urine|
|O_Growth hormone level 30min, blood|40760100|Somatotropin [Mass/volume] in Serum or Plasma --30 minutes post resting|
|O_PML-RARA gene screen, blood|3022546|t(15;17)(q24.1;q21.1)(PML,RARA) cells/Cells.total in Blood or Tissue by Molecular genetics method|
|Chromogranin A level|3014702|Chromogranin A [Moles/volume] in Serum or Plasma|
|PML-RARA gene screen, blood|3022546|t(15;17)(q24.1;q21.1)(PML,RARA) cells/Cells.total in Blood or Tissue by Molecular genetics method|
|Creat (BG)|3051825|Creatinine [Mass/volume] in Blood|
|Glucose level 120min, plasma|36660183|Glucose [Mass/volume] in Serum or Plasma --15 min post meal|
|rApi m1 bee i208 IgE level, blood|42528783|Honey bee recombinant (rApi m) 10 IgE Ab [Units/volume] in Serum|
|Renin level 0min, plasma|3037310|Renin [Mass/volume] in Plasma|
|O_Growth hormone level 90min, blood|40760101|Somatotropin [Mass/volume] in Serum or Plasma --90 minutes post resting|
|Cryoglobulin type, blood|3000429|Cryoglobulin type [Identifier] in Serum by Electrophoresis|
|O_Caffeine level, blood|3028609|Caffeine [Moles/volume] in Serum or Plasma|
|Gamma-glutamyl transpeptidase, blood|1761624|Gamma glutamyl transferase.macromolecular [Presence] in Serum or Plasma|
|O_Gamma-glutamyl transpeptidase, blood|1761624|Gamma glutamyl transferase.macromolecular [Presence] in Serum or Plasma|
|CALC Base Excess|3012501|Base excess in Blood by calculation|
|Methotrexate level, blood|3017115|Methotrexate [Moles/volume] in Serum or Plasma|
|O_Methotrexate level, blood|3017115|Methotrexate [Moles/volume] in Serum or Plasma|
|Dabigatran level, blood|43055459|Dabigatran [Mass/volume] in Serum or Plasma|
|Chloride|40757501|Chloride [Mass/volume] in Body fluid|
|O_Cholesterol level, blood|3009160|Cholesterol [Percentile]|
|vWF Protease Inhibitor, blood|3045206|von Willebrand factor (vWf) cleaving protease inhibitor [Presence] in Platelet poor plasma|
|Alder pollen IgE, blood|1469839|Japanese alder IgE Ab [Presence] in Serum or Plasma by Radioallergosorbent test (RAST)|
|ANA pattern titre, blood|3037503|Homogenous nuclear Ab pattern [Titer] in Serum|
|Urea|3009810|Urea [Mass/volume] in Blood|
|O_Prolactin level, blood|3004722|Prolactin [Mass/volume] in Serum or Plasma|
|Islet cell Ab level, blood|3005593|Pancreatic islet cell Ab [Titer] in Serum|
|Albumin|3025268|Albumin [Mass/volume] in Semen|
|O_Islet cell Ab level, blood|3005593|Pancreatic islet cell Ab [Titer] in Serum|
|Neutrophil function by flow cytometry|36203200|Neutrophils [#/volume] in Control Blood by Flow cytometry (FC)|
|Day 1 Cortisol level, serum|40757367|Cortisol [Mass/volume] in Serum or Plasma --9 AM 2nd day specimen|
|Apolipoprotein B level, blood|3014791|Apolipoprotein B [Mass/volume] in Serum or Plasma|
|O_Apolipoprotein B level, blood|3014791|Apolipoprotein B [Mass/volume] in Serum or Plasma|
|O_Other specific IgE (RAST) test|3966278|Miscellaneous allergen IgE Ab [Presence] in Serum by Radioallergosorbent test (RAST)|
|Bet v 4 birch t220 IgE level, blood|40763988|White Birch IgE Ab/IgE total in Serum|
|Platelet ATP, blood|43533700|Adenosine triphosphate/Adenosine diphosphate [Entitic molar ratio] in Platelets|
|Insulin level 0min, blood|3029871|Glucose [Mass/volume] in Serum or Plasma --15 minutes post 0.1 U/kg insulin|
|pO2 ABG|3027801|Oxygen [Partial pressure] in Arterial blood|
|Cortisol level 90min, serum|3028229|Cortisol [Mass/volume] in Serum or Plasma --8 hours post 40 ug corticotropin IM BID 3 day|
|O_Cortisol level 45min, blood|40759705|Cortisol [Mass/volume] in Serum or Plasma --45 minutes post XXX challenge|
|Amylase|3043024|Amylase [Presence] in Body fluid|
|Total protein level, blood|1469680|Protein [Mass/volume] in Blood|
|Total IgE level, blood|3039291|Wheat IgE Ab/IgE total in Serum|
|O_Haemoglobinopathy screen, blood|1989112|Hemoglobinopathy panel|
|Chilli pepper IgE level, blood|3966718|Chili Pepper IgE Ab [Presence] in Serum by Radioallergosorbent test (RAST)|
|Haemoglobinopathy screen, blood|1989112|Hemoglobinopathy panel|
|O_Chilli pepper IgE level, blood|3966718|Chili Pepper IgE Ab [Presence] in Serum by Radioallergosorbent test (RAST)|
|Non-HDL|3044491|Cholesterol non HDL [Mass/volume] in Serum or Plasma|
|Vitamin E level, serum|3006398|Tocopherols [Moles/volume] in Serum or Plasma|
|O_Parrot Ab level, blood|40762007|Parrot feather IgG Ab [Mass/volume] in Serum|
|Black olive IgE level, blood|40761121|Olive Pollen IgE Ab/IgE total in Serum|
|O_Black olive IgE level, blood|40761121|Olive Pollen IgE Ab/IgE total in Serum|
|O_ACTH level 120min,blood|3049123|Corticotropin [Mass/volume] in Plasma --12 AM specimen|
|Cholesterol:HDL ratio, blood|3011163|Cholesterol.total/Cholesterol in HDL [Mass Ratio] in Serum or Plasma|
|Iohexol GFR|3966002|Iohexol renal clearance in Serum or Plasma or Urine|
|Cortisol level 240min, serum|40761623|Corticosterone [Moles/volume] in Serum or Plasma --30 minutes post 250 ug corticotropin|
|Transferrin Saturation|3004789|Transferrin [Mass/volume] in Serum or Plasma|
|High molecular weight kininogen, blood|3027049|Kininogen HMW [Mass/volume] in Platelet poor plasma by Immunoassay|
|Glucose (BG)|3000483|Glucose [Mass/volume] in Blood|
|CRP|3000965|C reactive protein [Presence] in Serum or Plasma|
|Myelin oligodendrocyte (MOG) ab, serum|3005139|Myelin IgG Ab [Titer] in Serum|
|Live cell NMDA receptor antibody, blood|42529112|NMDAR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Ri Ab level, CSF|3007368|IgG [Mass/volume] in Cerebral spinal fluid|
|Ganglionic AChR antibody, blood|1617214|Acetylcholine receptor ganglionic neuronal IgG+IgM Ab [Moles/volume] in Serum by Immunoassay|
|Meningococcal C Ab level, blood|3023956|Neisseria meningitidis serogroup C IgG Ab [Units/volume] in Serum|
|BE Act (BG)|3016948|Activated clotting time (ACT) of Blood by Coagulation assay|
|Cortisol level, serum|3009682|Cortisol [Mass/volume] in Serum or Plasma|
|Dog dander IgE, blood|40764094|Dog dander IgE Ab/IgE total in Serum|
|Absolute Monocytes|3001604|Monocytes [#/volume] in Blood|
|O_Dog dander IgE, blood|40764094|Dog dander IgE Ab/IgE total in Serum|
|Bilirubin|40762888|Bilirubin.total [Mass/volume] in Arterial blood|
|O_Thyroglobulin Ab level, blood|3024857|Thyroglobulin Ab [Presence] in Serum|
|Potassium level 240min, blood|3040170|Potassium [Mass/time] in 24 hour Urine|
|O_Pristanic acid level, blood|3020622|Pristanate (C15:0(CH3)4) [Moles/volume] in Serum or Plasma|
|Blood (dipstick), urine|3037467|Urinalysis macro (dipstick) panel - Urine|
|Mixed moulds IgE level, blood|3002073|Dry-rot Fungus IgE Ab [Units/volume] in Serum|
|O_Vitamin B6 level, blood|21494411|Vitamin B6 intake 24 hour Measured|
|O_Mixed moulds IgE level, blood|3002073|Dry-rot Fungus IgE Ab [Units/volume] in Serum|
|CD4 Central Memory T Cells, blood|3014037|CD3+CD4+ (T4 helper) cells/cells in Blood|
|Nut mix FX22 IgE level, blood|3052099|Cashew nut IgE Ab/IgE total in Serum|
|Metadrenaline level, plasma|3046750|Metanephrine and Normetanephrine [Interpretation] in Serum or Plasma|
|O_Cortisol level 30min, blood|3007363|Cortisol [Mass/volume] in Serum or Plasma --30 minutes post XXX challenge|
|O_Haemoglobin S genotype screen, blood|37020465|Hemoglobin S inferred phenotype [Presence] in Blood or Tissue from Donor by Molecular genetics method|
|Cl- (BG)|3018572|Chloride [Moles/volume] in Blood|
|Mitochondrial Ab level, blood|43055284|Mitochondria M2-3E IgG Ab [Presence] in Serum by Immunoassay|
|Fat level, faeces|3016508|Fat [Mass/volume] in Stool|
|Endomysial IgG Ab level, blood|3032773|Endomysium IgG Ab [Titer] in Serum|
|Rivaroxaban level, blood|43055458|Rivaroxaban [Mass/volume] in Serum or Plasma|
|O_Fat level, faeces|3016508|Fat [Mass/volume] in Stool|
|IgH gene rearrangement screen, blood|21492159|IGH gene rearrangements [Presence] in Blood or Tissue by FISH|
|Ca+ + (BG)|3036426|Calcium.ionized [Mass/volume] in Blood|
|C26:C22 ratio serum level, blood|36305043|Palmitoylcarnitine (C16)/Acetylcarnitine (C2) [Molar ratio] in Serum or Plasma|
|CD8 Central Memory T Cells, blood|3007449|CD3+CD8+ (T8 suppressor) cells/cells in Blood|
|Honey IgE level, blood|3043963|Honey bee IgE Ab/IgE total in Serum|
|O_Honey IgE level, blood|3043963|Honey bee IgE Ab/IgE total in Serum|
|Bilirubin Urine Dipstick|3030477|Bilirubin.total [Presence] in Urine by Automated test strip|
|Brain natriuretic peptide level, blood|3031569|Natriuretic peptide B [Mass/volume] in Blood|
|O_Brain natriuretic peptide level, blood|3031569|Natriuretic peptide B [Mass/volume] in Blood|
|O_Cortisol level 60min, blood|3009084|Cortisol [Mass/volume] in Serum or Plasma --56 hours post 40 ug corticotropin IM BID 3 day|
|Vitamin D2 level, blood|36031776|25-hydroxyvitamin D2 [Mass/volume] in Capillary blood|
|FIO2|1469741|Inspired oxygen information panel|
|Absolute Eosinophils|3013115|Eosinophils [#/volume] in Blood|
|O_Insulin level, blood|3046058|Proinsulin/Insulin [Ratio] in Serum or Plasma|
|GABA(a)R antibody, blood|42529108|GABABR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|% APTT normal plasma correction|42870499|Thrombin time actual/Normal|
|INR Therapeutic range|3034426|Prothrombin time (PT)|
|CALC Saturated O2|3039986|Oxygen saturation Calculated from oxygen partial pressure in Capillary blood|
|Ferret IgE level, blood|40764104|Ferret epithelium IgE Ab/IgE total in Serum|
|O_Ferret IgE level, blood|40764104|Ferret epithelium IgE Ab/IgE total in Serum|
|Vitamin D level, blood|36031776|25-hydroxyvitamin D2 [Mass/volume] in Capillary blood|
|O_Vitamin D level, blood|36031776|25-hydroxyvitamin D2 [Mass/volume] in Capillary blood|
|Hepcidin level, serum|3052622|Pro-hepcidin [Mass/volume] in Serum or Plasma|
|Sodium level 0min, blood|3000285|Sodium [Moles/volume] in Blood|
|F-Actin antibody by Immunoblot|43055089|Myosin Ab [Presence] in Serum or Plasma by Immunoblot|
|Alpha-1-antitrypsin genotype, blood|3046867|Alpha 1 antitrypsin phenotype [Interpretation] in Serum or Plasma|
|CALC Bicarbonate|3011510|Bicarbonate [Moles/volume] in Water|
|O_Ganglionic Achr Abs, blood|1617214|Acetylcholine receptor ganglionic neuronal IgG+IgM Ab [Moles/volume] in Serum by Immunoassay|
|Urea level 0min, blood|3009810|Urea [Mass/volume] in Blood|
|Switched memory (IgD- CD27+) - % B cells|21493679|CD27-IgD+ cells/Cells.CD19+CD20+ in Blood|
|Total cholesterol level, blood|1091261|Total cholesterol from lipid profile|
|O_Total cholesterol level, blood|1091261|Total cholesterol from lipid profile|
|Digoxin level, blood|3005999|Digoxin [Mass] of Dose|
|O_Digoxin level, blood|3005999|Digoxin [Mass] of Dose|
|Bee venom IgE level, blood|3043963|Honey bee IgE Ab/IgE total in Serum|
|O_Bee venom IgE level, blood|3043963|Honey bee IgE Ab/IgE total in Serum|
|Fish mix FX2 IgE level, blood|3043915|Codfish IgE Ab/IgE total in Serum|
|O_Cortisol level 90min, blood|3018286|Cortisol [Mass/volume] in Serum or Plasma --11 PM specimen|
|O_Cortisol level 240min, blood|40761623|Corticosterone [Moles/volume] in Serum or Plasma --30 minutes post 250 ug corticotropin|
|SLA/LP antibody by Immunoblot|40759864|PL-12 Ab [Presence] in Serum by Immunoblot|
|Food mix FX5 IgE level, blood|3007307|Food Allergen Mix fx73 (Beef+Chicken+Pork) IgE Ab [Presence] in Serum by Multidisk|
|CD8 T cell count|3026340|CD5+CD8+ cells/cells in Blood|
|ANA Titre, Blood|3037522|Nuclear Ab [Titer] in Serum|
|Absolute Basophils|3006315|Basophils [#/volume] in Blood|
|Na+ (BG)|3000285|Sodium [Moles/volume] in Blood|
|O_Vitamin E level, blood|21494526|Vitamin E intake 24 hour Measured|
|Omega-5 Gliadin IgE level, blood|36031415|Gliadin IgE Ab [Units/volume] in Serum|
|Growth hormone level 60min, serum|3052612|Somatotropin [Units/volume] in Serum or Plasma --45 minutes post dose growth hormone releasing factor|
|Vitamin A level, blood|3006352|Retinol [Mass/volume] in Blood|
|O_Vitamin A level, blood|3006352|Retinol [Mass/volume] in Blood|
|Amyloid level, Serum|3049126|Amyloid A [Mass/volume] in Serum or Plasma|
|Prothrombin time 50:50 mix, blood|3034426|Prothrombin time (PT)|
|Cortisol level 120min, serum|3049457|Cortisol [Mass/volume] in Serum or Plasma --12 AM specimen|
|O_ANCA screen, blood|3009628|Neutrophil cytoplasmic Ab [Presence] in Serum|
|vWF activity level, blood|43534000|von Willebrand factor (vWf).activity [Units/volume] in Platelet poor plasma by Immunoassay|
|O_Cytospin, CSF|40771469|Cytokeratin 19 [Mass/volume] in Cerebral spinal fluid|
|O_vWF activity level, blood|43534000|von Willebrand factor (vWf).activity [Units/volume] in Platelet poor plasma by Immunoassay|
|Ristocetin cofactor assay, blood|36306070|von Willebrand factor.ristocetin cofactor inhibitor [Units/volume] in Platelet poor plasma by Coagulation assay|
|Mutton IgE level, blood|3041637|Turkey meat IgE Ab/IgE total in Serum|
|O_Mutton IgE level, blood|3041637|Turkey meat IgE Ab/IgE total in Serum|
|O_Growth hormone level 60min, blood|40760100|Somatotropin [Mass/volume] in Serum or Plasma --30 minutes post resting|
|Platelet genetics full sequencing Band 3|1761870|Platelet disorders multigene analysis in Blood or Tissue by Sequencing|
|Paracetamol level, blood|40763107|Acetaminophen [Mass/volume] in Blood|
|O_Paracetamol level, blood|40763107|Acetaminophen [Mass/volume] in Blood|
|ADP platelet agglutination, blood|3017055|Platelet aggregation ADP induced in Platelet rich plasma|
|O_Complement function, blood|3035351|Complement+Immunoglobulin [Presence] in Red Blood Cells|
|IgG Lambda Heavy Chain Measurement, bloo|3004640|Lambda light chains [Mass/volume] in Serum or Plasma|
|Insulin level 120min, blood|36660450|Insulin [Units/volume] in Serum or Plasma --15 min post meal|
|Gentamicin timing,blood|3053140|Gentamicin [Moles/volume] in Serum or Plasma|
|O_Glucose level 90min, blood|3020260|Glucose [Mass/volume] in Serum or Plasma --45 minutes post 100 g glucose PO|
|O_Mitochondrial Abs, blood|43055284|Mitochondria M2-3E IgG Ab [Presence] in Serum by Immunoassay|
|C24:C22 ratio serum level, blood|36303549|Tetradecenoylcarnitine (C14:1)/Acetylcarnitine (C2) [Molar ratio] in Serum or Plasma|
|Pneumococcal serotype S14 antibody|3031278|Streptococcus pneumoniae 14 serotypes IgG panel A [Mass/volume] - Serum|
|Jo-1 Ab level, blood|1092250|Jo sup(a) Ab [Titer] in Serum or Plasma|
|O_PNH cell marker analysis, blood|1175525|PNH GPI-Linked WBC and RBC Ag Panel - Blood|
|Red blood cell vitamin B1, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|Band forms count, blood|3018199|Band form neutrophils [#/volume] in Blood|
|Ristocetin 1.2 mg/ml, blood|3006916|Magnesium [Mass/volume] in Blood|
|Dexamethasone level(Overnight Dex Supp)|3026486|Cortisol [Moles/volume] in Serum or Plasma --17 hours post 1 mg dexamethasone PO overnight|
|O_Growth hormone level 150min, blood|40760003|Somatotropin [Mass/volume] in Serum or Plasma --160 minutes post exercise|
|pO2 (BG)|3027315|Oxygen [Partial pressure] in Blood|
|Growth hormone level, serum|3023709|Somatotropin [Mass/volume] in Serum or Plasma|
|Factor IX level, blood|3021326|Factor IX given [Volume]|
|O_Paraneoplastic Ab level, blood|3031964|Paraneoplastic Ab panel - Serum|
|Ristocetin 0.6 mg/ml, blood|3006916|Magnesium [Mass/volume] in Blood|
|O_Factor IX level, blood|3021326|Factor IX given [Volume]|
|O_Glucose level 60min, blood|36660135|Glucose [Mass/volume] in Serum or Plasma --30 min post meal|
|Growth hormone level 150min, serum|40760101|Somatotropin [Mass/volume] in Serum or Plasma --90 minutes post resting|
|Chromogranin B level, blood|3014702|Chromogranin A [Moles/volume] in Serum or Plasma|
|P3NP level, serum|3038143|Amylase.P3/Amylase.total in Serum or Plasma|
|Suxamethonium IgE level, blood|3005103|Succinylcholine IgE Ab [Units/volume] in Serum|
|O_Suxamethonium IgE level, blood|3005103|Succinylcholine IgE Ab [Units/volume] in Serum|
|PO2|3003246|Oxygen [Partial pressure] in Exhaled gas|
|Total protein|3035472|Albumin/Protein.total in Serum or Plasma|
|O_Sickle cell screen, blood|1091979|Sickle cells [Presence] in Blood|
|nGal d 1 ovomucoid f233 IgE level, blood|40761901|Conalbumin native (nGal d) 3 IgE Ab [Units/volume] in Serum|
|O_Porphyrin screen, blood|1002300|Porphyrin fractions panel - Urine|
|Urine period|3007876|Appearance of Urine|
|Cortisol level 0min, serum|3008497|Cortisol [Mass/volume] in Serum or Plasma --1 minute post XXX challenge|
|AMPA2 receptor antibody|42529111|AMPAR2 IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Factor VIII inhibitor level, blood|3011699|Coagulation factor VIII inhibitor [Presence] in Platelet poor plasma by Coagulation assay|
|O_Factor VIII inhibitor level, blood|3011699|Coagulation factor VIII inhibitor [Presence] in Platelet poor plasma by Coagulation assay|
|Creatinine level 0min, blood|3040510|Creatinine [Moles/time] in 1 hour Urine|
|Platelet genetics full sequencing Band 1|1761870|Platelet disorders multigene analysis in Blood or Tissue by Sequencing|
|Platelet genetics full sequencing Band 2|1761870|Platelet disorders multigene analysis in Blood or Tissue by Sequencing|
|Factor XIII level, blood|3013178|Coagulation factor XIII Ag actual/normal in Platelet poor plasma by Immunoassay|
|O_Factor XIII level, blood|3013178|Coagulation factor XIII Ag actual/normal in Platelet poor plasma by Immunoassay|
|O_Thyroid function, blood|3011450|Thyrotropin [Presence] in Blood|
|Fibrinogen level, blood|1616312|Fibrinogen [Mass/volume] in Blood by calculation|
|CD4 T cell count|3028167|CD3+CD4+ (T4 helper) cells [#/volume] in Blood|
|O_Fibrinogen level, blood|1616312|Fibrinogen [Mass/volume] in Blood by calculation|
|Pneumococcal serotype S6B antibody|3038550|Streptococcus pneumoniae Danish serotype 6B IgG Ab [Mass/volume] in Serum by Immunoassay|
|O_Growth hormone level 120min, blood|40771483|Somatotropin [Mass/volume] in Serum or Plasma --130 minutes post exercise|
|Parathyroid hormone level, plasma|3024040|Parathyrin [Interpretation] in Serum or Plasma|
|Glucose|3000483|Glucose [Mass/volume] in Blood|
|Sodium|3029627|Sodium [Mass/mass] in Hair|
|O_Full Blood Count|3002317|Cells Counted Total [#] in Blood|
|O2 Sat (BG)|3013502|Oxygen saturation in Blood|
|Anti-Mullerian hormone level, serum|3049799|Mullerian inhibiting substance [Moles/volume] in Serum or Plasma|
|Lymphocyte function test, flow cytometry|3012323|Lymphocytes/Leukocytes in Blood by Flow cytometry (FC)|
|Myelin oligodendrocyte (MOG) ab, CSF|46234774|IgG [Moles/volume] in Cerebral spinal fluid|
|Quail serum proteins IgG antibodies|3050281|Chicken serum proteins IgG Ab [Presence] in Serum|
|Nut mix IgE level, blood|3052099|Cashew nut IgE Ab/IgE total in Serum|
|O_Nut mix IgE level, blood|3052099|Cashew nut IgE Ab/IgE total in Serum|
|O_Platelet nucleotides, blood|43533700|Adenosine triphosphate/Adenosine diphosphate [Entitic molar ratio] in Platelets|
|Growth hormone level 120min, serum|40760101|Somatotropin [Mass/volume] in Serum or Plasma --90 minutes post resting|
|Growth hormone level 240min, serum|40760100|Somatotropin [Mass/volume] in Serum or Plasma --30 minutes post resting|
|Plasmablasts %, blood|3001362|Plasma cells [#/volume] in Blood|
|Factor IX sequencing, blood|1002139|F9 gene full mutation analysis in Blood or Tissue by Sequencing|
|Other bird serum proteins IgG antibodies|3017063|Pigeon serum IgG Ab [Presence] in Serum|
|O_Aminophylline level, blood|3009072|Theophylline [Mass/volume] in Blood|
|Fixed cell NMDA receptor antibody, blood|42529112|NMDAR IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|Total CO2|3001288|Carbon dioxide, total [Moles/volume] in Body fluid|
|ADAMTS13 activity, blood|1989260|ADAMTS13 gene full mutation analysis in Blood or Tissue by Sequencing|
|Ovarian Ab level, blood|3044866|Ovary Ab [Titer] in Serum|
|O_Phytanic acid level, blood|3021664|Phytanate (C16:0(CH3)4) [Moles/volume] in Serum or Plasma|
|Factor VIII Inhibitor screen, blood|3011699|Coagulation factor VIII inhibitor [Presence] in Platelet poor plasma by Coagulation assay|
|O_Factor VIII Inhibitor screen, blood|3011699|Coagulation factor VIII inhibitor [Presence] in Platelet poor plasma by Coagulation assay|
|Rare Inherited Anaemia panel|1989577|Hemolytic anemia panel|
|APTT inhibitor screen,blood|3016948|Activated clotting time (ACT) of Blood by Coagulation assay|
|Progesterone screen, blood|3022188|Progesterone [Moles/volume] in Serum or Plasma --3rd specimen post XXX challenge|
|O_Progesterone screen, blood|3022188|Progesterone [Moles/volume] in Serum or Plasma --3rd specimen post XXX challenge|
|ELF Score, serum|36305723|Liver fibrosis score in Serum or Plasma by Calculated by ELF|
|AML MRD|3965536|Acute myeloid leukemia minimal residual disease in Bone marrow by Flow cytometry (FC) Narrative|
|Mixed trees IgE level, blood|40764045|Cajeput tree IgE Ab/IgE total in Serum|
|O_Hen (serum) antibodies, blood|3038781|Chicken feather IgG Ab [Presence] in Serum|
|O_Iron level, blood|3046728|Iron [Presence] in Serum or Plasma|
|IgA Lambda Heavy Chain Measurement, bloo|21493214|Lambda light chains.free [Mass/volume] in Serum by Nephelometry|
|O_Glucose level 120min, blood|3034530|Glucose [Mass/volume] in Blood --2 hours post meal|
|LGI1 antibody, CSF|3008278|IgA [Mass/volume] in Cerebral spinal fluid|
|Pemphigoid Ab level, blood|1470029|P200 pemphigoid IgG Ab [Presence] in Serum or Plasma by Immunofluorescence|
|50:50 normal plasma DRVVT, blood|3027112|dRVVT actual/normal [Presence] in Platelet poor plasma by Coagulation assay|
|nGal d 2 ovalbumin f232 IgE level, blood|40761901|Conalbumin native (nGal d) 3 IgE Ab [Units/volume] in Serum|
|O_Fat globules detection, faeces|3043695|Oval fat bodies (globules) [#/area] in Urine sediment by Automated count|
|Immunoglobulin G level, blood|3040832|Hemoglobin G/Hemoglobin.total in Blood|
|dsDNA Ab level, blood|40766112|DNA double strand IgG Ab [Titer] in Serum|
|O_Testosterone level, blood|3008893|Testosterone [Mass/volume] in Serum or Plasma|
|O_Immunoglobulin G level, blood|3040832|Hemoglobin G/Hemoglobin.total in Blood|
|O_dsDNA Ab level, blood|40766112|DNA double strand IgG Ab [Titer] in Serum|
|Tr Abs, blood|40768035|Tr sup(a) Ab [Presence] in Serum or Plasma|
|Cortisol level (Overnight Dex Supp Test|3048821|Cortisol [Moles/volume] in Serum or Plasma --post 1 mg dexamethasone PO overnight|
|Factor XII level, blood|3002348|Coagulation factor XII activity actual/normal in Platelet poor plasma by Coagulation assay|
|Grass pollen IgE level, blood|40761121|Olive Pollen IgE Ab/IgE total in Serum|
|Aubergine IgE level, blood|40763994|Cabbage IgE Ab/IgE total in Serum|
|O_Factor XII level, blood|3002348|Coagulation factor XII activity actual/normal in Platelet poor plasma by Coagulation assay|
|O_Aubergine IgE level, blood|40763994|Cabbage IgE Ab/IgE total in Serum|
|PRP platelet count, blood|1092269|Platelets [Presence] in Blood|
|K+ (BG)|21490733|Potassium [Mass/volume] in Blood|
|Glycated haemoglobin reference, blood|3039720|Glucose mean value [Moles/volume] in Blood Estimated from glycated hemoglobin|
|Pneumococcal serotype S18C antibody|3039571|Streptococcus pneumoniae Danish serotype 18C IgG Ab [Mass/volume] in Serum by Immunoassay|
|Tree mix tx8 IgE level, blood|40764065|Cottonwood IgE Ab/IgE total in Serum|
|Collagen platelet agg, whole blood|40759129|Platelet aggregation collagen induced in Blood --1 ug/mL|
|Ristocetin 1.25 mg/ml level, blood|3006916|Magnesium [Mass/volume] in Blood|
|CD40L (Hyper IgM) Assay|3051946|CD40 cells [#/volume] in Blood|
|Factor XIII sequencing, blood|42870548|TNFRSF13B gene full mutation analysis in Blood or Tissue by Sequencing|
|Red blood cell count, blood|3026361|Erythrocytes [#/volume] in Blood|
|ABL transcript ratio ratio, blood|3029271|t(9;22)(q34.1;q11)(ABL1,BCR) fusion transcript/control transcript [Log Number Ratio] in Blood or Tissue by Molecular genetics method|
|P53 sequencing, blood|3965027|Copy number variation analysis in Blood or Tissue by Sequencing|
|Linseed IgE level, blood|1617718|Flaxseed IgE Ab [Units/volume] in Serum|
|O_Linseed IgE level, blood|1617718|Flaxseed IgE Ab [Units/volume] in Serum|
|IgM Lambda Heavy Chain Measurement, bloo|3002067|Lambda light chains [Mass/time] in 24 hour Urine|
|Factor IX Post dose level|3021326|Factor IX given [Volume]|
|O_Factor XIII screen, blood|3029727|Coagulation factor XIII inhibitor [Presence] in Platelet poor plasma by Chromogenic method|
|Cardiac muscle Ab level, blood|3032053|Myocardium IgG Ab [Presence] in Serum|
|O_Cardiac muscle Ab level, blood|3032053|Myocardium IgG Ab [Presence] in Serum|
|O_Cortisol level 120min, blood|3049457|Cortisol [Mass/volume] in Serum or Plasma --12 AM specimen|
|CD19 B cells percentage|3010503|CD19 cells [#/volume] in Blood|
|Heparin Assay|3024856|Heparin unfractionated [Units/volume] in Platelet poor plasma by Coagulation assay|
|Grass mix GX1 IgE level, blood|3032672|Canary grass IgE Ab/IgE total in Serum|
|O_Factor VIII level, blood|3000104|Factor VIII given [Volume]|
|O_Adrenocorticotrophic hormone, blood|3035637|Corticotropin [Mass/volume] in Plasma|
|Factor VIII level, blood|3000104|Factor VIII given [Volume]|
|Haemoglobinopathy interpretation|3015697|Hemoglobin pattern [Interpretation] in Blood|
|Pneumococcal serotype S19A antibody|3041719|Streptococcus pneumoniae Danish serotype 19A IgG Ab [Mass/volume] in Serum by Immunoassay|
|Myeloid panel|3031639|Reticulocytes panel - Blood|
|Leucocyte immunophenotyping interp|40758359|Immunophenotyping study|
|Sox-1 Abs, blood|1469635|SOX11 [Presence] in Tissue by Immune stain|
|Chol/HDL|3011884|Cholesterol in HDL [Presence] in Serum or Plasma|
|Absolute Lymphocytes|3019198|Lymphocytes [#/volume] in Blood|
|O_Cortisol level 0min, blood|3008497|Cortisol [Mass/volume] in Serum or Plasma --1 minute post XXX challenge|
|Dihydrotestosterone, blood|3028569|Dehydrochlormethyltestosterone [Mass/volume] in Urine|
|Potassium level 0min, blood|21490733|Potassium [Mass/volume] in Blood|
|Growth hormone level 0min, serum|21492324|Somatotropin [Units/volume] in Serum or Plasma --45 minutes post XXX challenge|
|Unswitched memory (IgD+ CD27+), blood|21493675|CD27+IgD- cells/Cells.CD19+CD20+ in Blood|
|O_Dihydrotestosterone, blood|3028569|Dehydrochlormethyltestosterone [Mass/volume] in Urine|
|Cholesterol|3009160|Cholesterol [Percentile]|
|Bcr-abl gene level, blood|3011913|t(9;22)(q34.1;q11)(ABL1,BCR) fusion transcript major break points [Presence] in Blood or Tissue by Molecular genetics method|
|Ristocetin 0.5 mg/ml level, blood|3006916|Magnesium [Mass/volume] in Blood|
|O_Bcr-abl gene level, blood|3011913|t(9;22)(q34.1;q11)(ABL1,BCR) fusion transcript major break points [Presence] in Blood or Tissue by Molecular genetics method|
|U-snRNP Ab level, blood|3047813|U1 small nuclear ribonucleoprotein IgG Ab [Presence] in Serum|
|Arachidonic acid plat agg, blood|3039998|Platelet aggregation arachidonate induced [Units/volume] in Blood|
|AMA-M2 antibody by Immunoblot|40759839|Ma+Ta Ab [Presence] in Serum by Immunoblot|
|CASPR2 antibody, CSF|1175876|PCA-2 Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Adalimumab Anti-Drug Ab, blood|37020142|Adalimumab neutralizing antibody [Titer] in Serum by Bioassay|
|Iron panel|46235471|Iron panel - Serum or Plasma|
|CD8 Term. Diff. T Cells, blood|3026340|CD5+CD8+ cells/cells in Blood|
|Oestradiol level, serum|3027646|Estrogen [Mass/volume] in Serum or Plasma|
|O_Cortisol level, blood|3009682|Cortisol [Mass/volume] in Serum or Plasma|
|O_Growth hormone level 180min, blood|40760003|Somatotropin [Mass/volume] in Serum or Plasma --160 minutes post exercise|
|O_Cytochemistry, specimen|3049361|Cytology report of Specimen Cyto stain|
|Cytochemistry, specimen|3049361|Cytology report of Specimen Cyto stain|
|Cryocrit, blood|3037070|Cryocrit of Serum by Spun Westergren|
|IgA Ab level, blood|3007164|IgA [Mass/volume] in Serum or Plasma|
|CD4 Term. Diff. T Cells, blood|3014037|CD3+CD4+ (T4 helper) cells/cells in Blood|
|O_IgA Ab level, blood|3007164|IgA [Mass/volume] in Serum or Plasma|
|CD8 T cell percentage|21494814|CD8 cells/Lymphocytes in Specimen|
|Pneumococcal serotype S19F antibody|36204002|Streptococcus pneumoniae Danish serotype 19F IgG Ab [Mass/volume] in Serum by Immunoassay|
|Pneumococcal serotype S7F antibody|3041896|Streptococcus pneumoniae Danish serotype 7F IgG Ab [Mass/volume] in Serum by Immunoassay|
|Factor IX Inhibitor screen|36031637|Coagulation factor IX activity and inhibitor panel - Platelet poor plasma by Coagulation assay|
|Emicizumab level, blood|1989376|Emicizumab [Mass/volume] in Platelet poor plasma by Coagulation assay|
|50:50 NP DRVVT correction, blood|46235125|dRVVT with 1:1 PNP actual/normal (normalized LA mix)|
|O_Factor IX Inhibitor screen|36031637|Coagulation factor IX activity and inhibitor panel - Platelet poor plasma by Coagulation assay|
|50:50 normal plasma PTT-LA, blood|3033658|Prothrombin time (PT) actual/Normal|
|Factor VIII full sequencing|21493137|IVD gene full mutation analysis in Blood or Tissue by Sequencing|
|Growth hormone level 180min, serum|40760003|Somatotropin [Mass/volume] in Serum or Plasma --160 minutes post exercise|
|Haemoglobin A1c DCCT aligned, blood|36304734|Hemoglobin A1c/Hemoglobin.total goal Blood|
|O_Pneumococcal IgG level, blood|3045274|Streptococcus pneumoniae IgG Ab [Mass/volume] in Serum|
|Factor XI level, blood|3001850|Coagulation factor XI activity actual/normal in Platelet poor plasma by Coagulation assay|
|O_Factor XI level, blood|3001850|Coagulation factor XI activity actual/normal in Platelet poor plasma by Coagulation assay|
|MuSK abs IIF, blood|36660504|Muscle specific receptor tyrosine kinase IgG Ab [Moles/volume] in Serum by Immunoassay|
|Zic-4, CSF|40761141|Zinc [Mass/volume] in Cerebral spinal fluid|
|Animal mix EX1 IgE level, blood|3011777|Horse meat IgE Ab [Units/volume] in Serum|
|Pneumococcal serotype S23F antibody|36204091|Streptococcus pneumoniae Danish serotype 23F IgG Ab [Mass/volume] in Serum by Immunoassay|
|Pneumococcal serotype S4 antibody|3031967|Streptococcus pneumoniae 4 serotypes IgG panel [Mass/volume] - Serum|
|O_Sweat screen, sweat|1092143|Chloride [Presence] in Sweat by Screen method|
|Pituitary Ab level, blood|40766277|Pituitary Ab [Titer] in Serum by Immunofluorescence|
|O_Pituitary Ab level, blood|40766277|Pituitary Ab [Titer] in Serum by Immunofluorescence|
|Animal (rodent) mix EX70 IgE level|3020228|Rat muliialgro IgE Ab [Units/volume] in Serum|
|Pneumococcal serotype S9V antibody|3041754|Streptococcus pneumoniae Danish serotype 9V IgG Ab [Mass/volume] in Serum by Immunoassay|
|O_Thalassaemia screen, blood|3009995|Carboxyhemoglobin [Presence] in Blood by Screen method|
|Transitional B cells %, blood|3000060|B lymphocytes [#/volume] in Blood|
|O_Renal profile, blood|40762887|Creatinine [Moles/volume] in Blood|
|Factor VIII inhibitor porcine, blood|3011699|Coagulation factor VIII inhibitor [Presence] in Platelet poor plasma by Coagulation assay|
|CD4 T cell percentage|21494815|CD4 cells/Lymphocytes in Specimen|
|Caeruloplasmin level, blood|3040880|Ceruloplasmin actual/normal in Serum or Plasma|
|O_Caeruloplasmin level, blood|3040880|Ceruloplasmin actual/normal in Serum or Plasma|
|Factor V sequencing, blood|21493137|IVD gene full mutation analysis in Blood or Tissue by Sequencing|
|TSH receptor Ab level, blood|42528824|Thyrotropin receptor Ab [Presence] in Serum|
|O_Malarial parasite screen, blood|3002978|Plasmodium sp identified in Blood by Thin film|
|O_TSH receptor Ab level, blood|42528824|Thyrotropin receptor Ab [Presence] in Serum|
|Red blood cell vitamin B2, blood|3009438|Cobalamin (Vitamin B12) [Presence] in Blood|
|Factor X sequencing, blood|36660693|F12 gene full mutation analysis in Blood or Tissue by Sequencing|
|Mean cell haemoglobin conc, blood|3011550|Carboxyhemoglobin [Mass/volume] in Blood|
|Absolute Neutrophils|3017732|Neutrophils [#/volume] in Blood|
|Total white cell count, blood|3002317|Cells Counted Total [#] in Blood|
|DRVVT correction, blood|46235124|dRVVT W excess phospholipid percent correction|
|Heparin Induced Thrombocytopenia, Blood|3032948|Heparin induced platelet Ab [Presence] in Serum|
|Other haematology test result|44786642|Hemoglobin.other [Type] in Blood|
|Conductivity level, sweat|3008848|Chloride [Moles/volume] in Sweat|
|vWF plt-type, blood|3049242|von Willebrand panel - Platelet poor plasma|
|DPPX Antibodies, CSF|42529120|Dipeptidyl aminopeptidase-like protein 6 IgG Ab [Presence] in Cerebral spinal fluid by Immunofluorescence|
|Jak-2 Exon 12 by HRM, blood|1988162|JAK2 gene exon 12 full mutation analysis in Blood or Tissue by Sequencing|
|HDL cholesterol level, blood|3011884|Cholesterol in HDL [Presence] in Serum or Plasma|
|Temperature POCT|21490788|Temperature difference|
|pO2(T)c|1617274|Carbon dioxide, total [Moles/volume] in Central venous blood|
|O_HDL cholesterol level, blood|3011884|Cholesterol in HDL [Presence] in Serum or Plasma|
|Factor VII level, blood|3011547|Coagulation factor VII activity actual/normal in Platelet poor plasma by Coagulation assay|
|O_Factor VII level, blood|3011547|Coagulation factor VII activity actual/normal in Platelet poor plasma by Coagulation assay|
|CALC Total CO2|3031147|Carbon dioxide, total [Moles/volume] in Blood by calculation|
|Acetylcholine receptor abs IIF, blood|3019856|Acetylcholine receptor blocking Ab [Titer] in Serum by Immunofluorescence|
|Salmonella typhi IgG antibodies|3012862|Salmonella enteritidis IgG Ab [Presence] in Serum|
|White blood cell count, blood|3010813|Leukocytes [#/volume] in Blood|
|Anti-nuclear Ab level (Hep-2), blood|3022307|Neuronal nuclear type 2 Ab [Titer] in Serum|
|O_Anti-nuclear Ab level (Hep-2), blood|3022307|Neuronal nuclear type 2 Ab [Titer] in Serum|
|Beta-interferon neutralising antibody|3011083|Interferon.beta 1 neutralizing antibody [Titer] in Serum or Plasma by Neutralization test|
|O_Neutrophil function screen, blood|1091593|Neutrophil Ab screen panel - Serum or Plasma|
|Prostate specific Ag, blood|3052038|Prostate specific Ag [Mass/volume] in Body fluid|
|O_Prostate specific Ag, blood|3052038|Prostate specific Ag [Mass/volume] in Body fluid|
|Collagen/epinephrine platelet fnc, blood|3005807|Platelet function (closure time) collagen+EPINEPHrine induced [Time] in Blood|
|Diphtheria Ab level, blood|3035832|Corynebacterium diphtheriae Ab [Titer] in Serum|
|Red cell count|3027017|Erythrocytes [#/volume] in Blood by Manual count|
|CV2/CRMP5 Abs, blood|3030855|CV2 Ab [Presence] in Serum or Plasma|
|O_Ovarian antibodies, blood|3018359|Ovary Ab [Presence] in Serum|
|Blood Glucose POC|3020491|Glucose [Moles/volume] in Blood|
|Coriander IgE level, blood|3001591|Cilantro IgE Ab [Units/volume] in Serum|
|O_Coriander IgE level, blood|3001591|Cilantro IgE Ab [Units/volume] in Serum|
|O_Parathyroid hormone level, blood|3024040|Parathyrin [Interpretation] in Serum or Plasma|
|hCG level, blood|3004536|Choriogonadotropin [Interpretation] in Serum or Plasma|
|O_hCG level, blood|3004536|Choriogonadotropin [Interpretation] in Serum or Plasma|
|Factor V level, blood|40758469|V Ab [Titer] in Serum or Plasma|
|O_Factor V level, blood|40758469|V Ab [Titer] in Serum or Plasma|
|Factor VIII binding level, blood|3019250|Coagulation factor VIII activity actual/normal in Platelet poor plasma by Coagulation assay|
|Hb (BG)|3041888|Hemoglobin H [Presence] in Blood|
|Factor VIII Timed level|3019250|Coagulation factor VIII activity actual/normal in Platelet poor plasma by Coagulation assay|
|Infliximab Anti-Drug Ab, blood|43055457|inFLIXimab Ab [Mass/volume] in Serum or Plasma|
|Warfarin Dose Next Test|3024105|Warfarin [Mass] of Dose|
|Factor VIII Post dose level|3000104|Factor VIII given [Volume]|
|Factor IX Timed level|3021326|Factor IX given [Volume]|
|Urgent PR3 Antibody|42868446|Proteinase 3 IgG Ab [Presence] in Serum by Immunoassay|
|Bicarb (BG)|3006576|Bicarbonate [Moles/volume] in Blood|
|Prekallikrein assay, blood|3003422|Prekallikrein (Fletcher Factor) [Mass/volume] in Platelet poor plasma by Chromogenic method|
|Thyroid peroxidase Ab level, blood|3043429|Thyroperoxidase Ab [Titer] in Serum or Plasma|
|O_Thyroid peroxidase Ab level, blood|3043429|Thyroperoxidase Ab [Titer] in Serum or Plasma|
|D-dimer, blood|37021210|Fibrin D-dimer [Mass/volume] in Blood by Immunoassay.DDU|
|O_D-dimer, blood|37021210|Fibrin D-dimer [Mass/volume] in Blood by Immunoassay.DDU|
|Fibrinogen alpha gene, blood|3002937|Fibrinogen [Presence] in Platelet poor plasma|
|Fibrinogen beta gene, blood|3002937|Fibrinogen [Presence] in Platelet poor plasma|
|Immunoglobulin A level, blood|3045975|IgA [Presence] in Serum|
|O_Immunoglobulin A level, blood|3045975|IgA [Presence] in Serum|
|pH(T)c|1616438|pH of Central venous blood|


* `EVENT` Lab test event []()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20Oxford%20Lab%20Measurement%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Integrated Stage
* Constant value set to `2000500018`. TNMCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement TNM Category Final Pre Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Integrated Stage
* Constant value set to `2000500012`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement T Category Final Pre Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement Primary Pathway Metastasis
* Constant value set to `2000500007`. PrimaryPathwayMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Recurrence Metastasis
* Constant value set to `2000500010`. NonPrimaryPathwayRecurrenceMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement Non Primary Pathway Progression Metastasis
* Constant value set to `2000500009`. NonPrimaryPathwayProgressionMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Integrated Stage
* Constant value set to `2000500017`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement N Category Final Pre Treatment Stage
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Integrated Stage
* Constant value set to `2000500016`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Lung Measurement M Category Final Pre Treatment Stage
* Constant value set to `2000500014`. MCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Lung%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Integrated Stage
* Constant value set to `2000500013`. TNMCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement TNM Category Final Pre Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Integrated Stage
* Constant value set to `2000500012`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement T Category Final Pre Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement N Category Integrated Stage
* Constant value set to `2000500011`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Lung Measurement N Category (Final Pretreatment)
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20N%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Integrated Stage)
* Constant value set to `2000500010`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Integrated%20Stage)%20mapping){: .btn }
### COSD V8 Lung Measurement M Category (Final Pretreatment)
* Constant value set to `2000500014`. MCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Lung%20Measurement%20M%20Category%20(Final%20Pretreatment)%20mapping){: .btn }
### COSD V9 Measurement TNM Category Integrated Stage
* Constant value set to `2000500013`. TNMCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement TNM Category Final Pre Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Integrated Stage
* Constant value set to `2000500012`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement T Category Final Pre Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement Primary Pathway Metastasis
* Constant value set to `2000500007`. PrimaryPathwayMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Recurrence Metastasis
* Constant value set to `2000500008`. NonPrimaryPathwayRecurrenceMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement Non Primary Pathway Progression Metastasis
* Constant value set to `2000500009`. NonPrimaryPathwayProgressionMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Measurement N Category Integrated Stage
* Constant value set to `2000500011`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement N Category Final Pre Treatment Stage
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Integrated Stage
* Constant value set to `2000500010`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Measurement M Category Final Pre Treatment Stage
* Constant value set to `2000500014`. MCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement TNM Category Integrated Stage
* Constant value set to `2000500013`. TNMCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement TNM Category Final Pre Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Integrated Stage
* Constant value set to `2000500012`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement T Category Final Pre Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement N Category Integrated Stage
* Constant value set to `2000500011`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement N Category Final Pre Treatment Stage
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Integrated Stage
* Constant value set to `2000500010`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Measurement M Category Final Pre Treatment Stage
* Constant value set to `2000500014`. MCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Integrated Stage
* Constant value set to `2000500013`. TNMCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement TNM Category Final Pre-Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20TNM%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Integrated Stage
* Constant value set to `2000500019`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement T Category Final Pre-Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20T%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Primary Pathway Metastasis
* Constant value set to `2000500007`. PrimaryPathwayMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Primary%20Pathway%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Recurrence Metastasis
* Constant value set to `2000500010`. NonPrimaryPathwayRecurrenceMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Recurrence%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement Non Primary Pathway Progression Metastasis
* Constant value set to `2000500008`. NonPrimaryPathwayProgressionMetastasis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Non%20Primary%20Pathway%20Progression%20Metastasis%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Integrated Stage
* Constant value set to `2000500016`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement N Category Final Pre-Treatment Stage
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20N%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Integrated Stage
* Constant value set to `2000500018`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement M Category Final Pre-Treatment Stage
* Constant value set to `2000500017`. MCategoryFinalPretreatment

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20M%20Category%20Final%20Pre-Treatment%20Stage%20mapping){: .btn }
### COSD V9 Breast Measurement Grade of Differentiation
* Constant value set to `2000500003`. GradeOfDifferentiationAtDiagnosis

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V9%20Breast%20Measurement%20Grade%20of%20Differentiation%20mapping){: .btn }
### COSD V8 Breast Measurement TNM Category Final Pre Treatment Stage
* Constant value set to `2000500017`. TNMCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20TNM%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Integrated Stage
* Constant value set to `2000500007`. TCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement T Category Final Pre Treatment Stage
* Constant value set to `2000500016`. TCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20T%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Integrated Stage
* Constant value set to `2000500019`. NCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement N Category Final Pre Treatment Stage
* Constant value set to `2000500015`. NCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20N%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Integrated Stage
* Constant value set to `2000500018`. MCategoryIntegratedStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Integrated%20Stage%20mapping){: .btn }
### COSD V8 Breast Measurement M Category Final Pre Treatment Stage
* Constant value set to `2000500014`. MCategoryFinalPreTreatmentStage

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20measurement_source_concept_id%20field%20COSD%20V8%20Breast%20Measurement%20M%20Category%20Final%20Pre%20Treatment%20Stage%20mapping){: .btn }
