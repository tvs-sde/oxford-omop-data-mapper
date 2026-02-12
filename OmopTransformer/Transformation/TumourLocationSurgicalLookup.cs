using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("TUMOUR LOCATION (SURGICAL)")]
internal class TumourLocationSurgicalLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Frontal lobe") },
            { "02", new ValueWithNote(null, "Temporal lobe") },
            { "03", new ValueWithNote(null, "Parietal lobe") },
            { "04", new ValueWithNote(null, "Occipital lobe") },
            { "05", new ValueWithNote(null, "Pineal region") },
            { "06", new ValueWithNote(null, "Hypothalamic") },
            { "07", new ValueWithNote(null, "Basal ganglia/thalamic") },
            { "08", new ValueWithNote(null, "Cerebellar") },
            { "09", new ValueWithNote(null, "Midbrain") },
            { "10", new ValueWithNote(null, "Pons") },
            { "11", new ValueWithNote(null, "Medulla") },
            { "12", new ValueWithNote(null, "Fourth ventricle") },
            { "13", new ValueWithNote(null, "Third ventricle") },
            { "14", new ValueWithNote(null, "Lateral ventricle") },
            { "15", new ValueWithNote(null, "Parasagittal/parafalcine dura") },
            { "16", new ValueWithNote(null, "Posterior fossa convexity dura") },
            { "17", new ValueWithNote(null, "Convexity dura") },
            { "18", new ValueWithNote(null, "Petrous temporal bone") },
            { "19", new ValueWithNote(null, "Orbital roof") },
            { "20", new ValueWithNote(null, "Skull vault") },
            { "21", new ValueWithNote(null, "Scalp") },
            { "22", new ValueWithNote(null, "Anterior cranial fossa") },
            { "23", new ValueWithNote(null, "Middle cranial fossa") },
            { "24", new ValueWithNote(null, "Orbital roof (Retired 1 April 2020)") },
            { "25", new ValueWithNote(null, "Infratemporal fossa") },
            { "26", new ValueWithNote(null, "Pterygopalatine fossa") },
            { "27", new ValueWithNote(null, "Anterior clinoid dura") },
            { "28", new ValueWithNote(null, "Sphenoid wing dura") },
            { "29", new ValueWithNote(null, "Subfrontal dura") },
            { "30", new ValueWithNote(null, "Suprasellar dura") },
            { "31", new ValueWithNote(null, "Clival dura") },
            { "32", new ValueWithNote(null, "Cavernous sinus") },
            { "33", new ValueWithNote(null, "Cerebellopontine angle") },
            { "34", new ValueWithNote(null, "Jugular bulb") },
            { "35", new ValueWithNote(null, "Venous angle dura") },
            { "36", new ValueWithNote(null, "Foramen magnum") },
            { "37", new ValueWithNote(null, "Cervical intramedullary") },
            { "38", new ValueWithNote(null, "Cervical intradural") },
            { "39", new ValueWithNote(null, "Cervical extradural") },
            { "40", new ValueWithNote(null, "Cervical bony") },
            { "41", new ValueWithNote(null, "Thoracic intramedullary") },
            { "42", new ValueWithNote(null, "Thoracic intradural") },
            { "43", new ValueWithNote(null, "Thoracic extradural") },
            { "44", new ValueWithNote(null, "Thoracic bony") },
            { "45", new ValueWithNote(null, "Lumbar intramedullary") },
            { "46", new ValueWithNote(null, "Lumbar intradural") },
            { "47", new ValueWithNote(null, "Lumbar extradural") },
            { "48", new ValueWithNote(null, "Lumbar bony") },
            { "98", new ValueWithNote(null, "Other (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
