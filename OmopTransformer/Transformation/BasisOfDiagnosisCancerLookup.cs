using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BASIS OF DIAGNOSIS (CANCER)")]
internal class BasisOfDiagnosisCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote(null, "Death Certificate only (DCO): information provided is from a death certificate") },
            { "1", new ValueWithNote(null, "Clinical: diagnosis made before death, but without any of the following codes") },
            { "2", new ValueWithNote(null, "Clinical investigation: all diagnostic techniques (X-ray, endoscopy, imaging, ultrasound, exploratory surgery, autopsy) without a tissue diagnosis") },
            { "4", new ValueWithNote(null, "Specific tumour markers: biochemical and/or immunological markers specific for a tumour site") },
            { "5", new ValueWithNote(null, "Cytology: examination of cells from a primary or secondary site, including fluids aspirated by endoscopy or needle; includes peripheral blood and bone marrow aspirates, immunophenotyping by flow cytometry, and a liquid biopsy in the absence of pathology") },
            { "6", new ValueWithNote(null, "Histology of a metastasis: histological examination of tissues from a metastasis, including autopsy specimens (retired 1 April 2024)") },
            { "7", new ValueWithNote(null, "Histology of a primary tumour: histological examination of tissue from the primary tumour, including all cutting techniques and bone marrow biopsies; includes autopsy specimens of a primary tumour (retired 1 April 2024)") },
            { "7.1", new ValueWithNote(null, "Histology of the primary tumour: histologic examination of tissue from the primary tumour, including all cutting techniques and bone marrow biopsies") },
            { "7.2", new ValueWithNote(null, "Histology of a metastasis: no histology of the primary tumour") },
            { "7.3", new ValueWithNote(null, "Histology at autopsy: no histology before autopsy") },
            { "8", new ValueWithNote(null, "Cytogenetic and/or molecular testing: detection of tumour-specific genetic abnormalities or genetic changes (karyotyping, FISH, PCR, DNA sequencing)") },
            { "9", new ValueWithNote(null, "Unknown: no information on how the patient diagnosis has been made (e.g., electronic health record only)") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
