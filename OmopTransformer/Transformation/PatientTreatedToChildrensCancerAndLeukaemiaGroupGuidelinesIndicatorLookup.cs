using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PATIENT TREATED TO CHILDRENS CANCER AND LEUKAEMIA GROUP GUIDELINES INDICATOR")]
internal class PatientTreatedToChildrensCancerAndLeukaemiaGroupGuidelinesIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient was treated according to the Children's Cancer and Leukaemia Group guidelines") },
            { "N", new ValueWithNote(null, "No - the patient was not treated according to the Children's Cancer and Leukaemia Group guidelines") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
