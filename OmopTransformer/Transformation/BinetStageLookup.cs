using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("BINET STAGE")]
internal class BinetStageLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "A", new ValueWithNote(null, "Stage A: platelet count greater than 99 and haemoglobin greater than 99 and 0, 1, or 2 areas of organ enlargement (number of lymph node groups plus score 1 for hepatomegaly, 1 for splenomegaly)") },
            { "B", new ValueWithNote(null, "Stage B: platelet count greater than 99 and haemoglobin greater than 99 and 3, 4, or 5 areas of organ enlargement") },
            { "C", new ValueWithNote(null, "Stage C: haemoglobin less than 100 or platelet count less than 100") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
