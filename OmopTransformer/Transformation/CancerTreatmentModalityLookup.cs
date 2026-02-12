using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER TREATMENT MODALITY")]
internal class CancerTreatmentModalityLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Surgery (Retired 1 October 2020)") },
            { "02", new ValueWithNote(null, "Anti-Cancer Drug Regimen (Cytotoxic Chemotherapy)") },
            { "03", new ValueWithNote(null, "Anti-Cancer Drug Regimen (Hormone Therapy)") },
            { "04", new ValueWithNote(null, "Chemoradiotherapy") },
            { "05", new ValueWithNote(null, "Teletherapy (Beam Radiation excluding Proton Therapy)") },
            { "06", new ValueWithNote(null, "Brachytherapy") },
            { "07", new ValueWithNote(null, "Specialist Palliative Care") },
            { "08", new ValueWithNote(null, "Active Monitoring (excluding Non-Specialist Palliative Care)") },
            { "09", new ValueWithNote(null, "Non-Specialist Palliative Care (excluding Active Monitoring)") },
            { "10", new ValueWithNote(null, "Radiofrequency Ablation (RFA)") },
            { "11", new ValueWithNote(null, "High Intensity Focused Ultrasound (HIFU)") },
            { "12", new ValueWithNote(null, "Cryotherapy") },
            { "13", new ValueWithNote(null, "Proton Therapy") },
            { "14", new ValueWithNote(null, "Anti-Cancer Drug Regimen (other)") },
            { "15", new ValueWithNote(null, "Anti-Cancer Drug Regimen (Immunotherapy)") },
            { "16", new ValueWithNote(null, "Light Therapy (including Photodynamic Therapy and PUVA)") },
            { "17", new ValueWithNote(null, "Hyperbaric Oxygen Therapy") },
            { "18", new ValueWithNote(null, "Other Treatment (Retired 1 July 2012)") },
            { "19", new ValueWithNote(null, "Radioisotope Therapy (including Radioiodine)") },
            { "20", new ValueWithNote(null, "Laser Treatment (including Argon Beam therapy)") },
            { "21", new ValueWithNote(null, "Biological Therapies (excluding Immunotherapy)") },
            { "22", new ValueWithNote(null, "Radiosurgery") },
            { "23", new ValueWithNote(null, "Surgery (excluding enabling treatment)") },
            { "24", new ValueWithNote(null, "Surgery (enabling treatment)") },
            { "97", new ValueWithNote(null, "Other treatment (not listed)") },
            { "98", new ValueWithNote(null, "All treatment declined") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
