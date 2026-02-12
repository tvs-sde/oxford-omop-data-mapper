using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("HYDRONEPHROSIS CODE")]
internal class HydronephrosisCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote(null, "None (kidneys not affected)") },
            { "L", new ValueWithNote(null, "Left") },
            { "R", new ValueWithNote(null, "Right") },
            { "B", new ValueWithNote(null, "Bilateral") },
            { "8", new ValueWithNote(null, "Not Applicable (No kidneys)") },
            { "9", new ValueWithNote(null, "Not Known (Not recorded or test not done)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
