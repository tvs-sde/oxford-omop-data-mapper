using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("FRENCH AMERICAN BRITISH CLASSIFICATION (ACUTE MYELOID LEUKAEMIA)")]
internal class FrenchAmericanBritishClassificationAcuteMyeloidLeukaemiaLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "M0", new ValueWithNote(null, "Undifferentiated acute myeloblastic leukaemia") },
            { "M1", new ValueWithNote(null, "Acute myeloblastic leukaemia with minimal maturation") },
            { "M2", new ValueWithNote(null, "Acute myeloblastic leukaemia with maturation") },
            { "M3", new ValueWithNote(null, "Acute promyelocytic leukaemia") },
            { "M4", new ValueWithNote(null, "Acute myelomonocytic leukaemia") },
            { "M4EOS", new ValueWithNote(null, "Acute myelomonocytic leukaemia with eosinophilia") },
            { "M5", new ValueWithNote(null, "Acute monocytic leukaemia") },
            { "M6", new ValueWithNote(null, "Acute erythroid leukaemia") },
            { "M7", new ValueWithNote(null, "Acute megakaryocytic leukaemia") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
