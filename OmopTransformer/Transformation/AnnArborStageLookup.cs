using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ANN ARBOR STAGE")]
internal class AnnArborStageLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Stage I: one region of lymph nodes, or spleen or thymus or Waldeyer's ring enlarged") },
            { "2", new ValueWithNote(null, "Stage II: 2 regions of lymph nodes enlarged on the same side of the diaphragm") },
            { "3", new ValueWithNote(null, "Stage III: lymph nodes enlarged on both sides of the diaphragm") },
            { "4", new ValueWithNote(null, "Stage IV: disease outside lymph nodes (e.g. liver, bone marrow), excluding \"E\"") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
