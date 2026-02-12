using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ADDITIONAL UNPLANNED PROCEDURE REQUIRED INDICATOR")]
internal class AdditionalUnplannedProcedureRequiredIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient required an additional unplanned operation") },
            { "N", new ValueWithNote(null, "No - the patient did not require an additional unplanned operation") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
