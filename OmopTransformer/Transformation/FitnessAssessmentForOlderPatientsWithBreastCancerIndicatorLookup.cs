using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("FITNESS ASSESSMENT FOR OLDER PATIENTS WITH BREAST CANCER INDICATOR")]
internal class FitnessAssessmentForOlderPatientsWithBreastCancerIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - a Fitness Assessment for Older Patients with Breast Cancer was carried out") },
            { "N", new ValueWithNote(null, "No - a Fitness Assessment for Older Patients with Breast Cancer was not carried out") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
