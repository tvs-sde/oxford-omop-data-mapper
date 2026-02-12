using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("DEATH LOCATION TYPE CODE (ACTUAL)")]
internal class DeathLocationTypeCodeActualLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "10", new ValueWithNote(null, "Hospital") },
            { "20", new ValueWithNote(null, "Private Residence") },
            { "21", new ValueWithNote(null, "Patient's own home") },
            { "22", new ValueWithNote(null, "Other private residence (e.g. relative's home, carer's home)") },
            { "30", new ValueWithNote(null, "Hospice") },
            { "40", new ValueWithNote(null, "Care Home") },
            { "41", new ValueWithNote(null, "Care Home Services with Nursing") },
            { "42", new ValueWithNote(null, "Care Home Services without Nursing") },
            { "50", new ValueWithNote(null, "Other (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
