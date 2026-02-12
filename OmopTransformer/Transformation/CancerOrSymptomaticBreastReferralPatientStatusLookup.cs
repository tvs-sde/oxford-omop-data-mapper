using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER OR SYMPTOMATIC BREAST REFERRAL PATIENT STATUS")]
internal class CancerOrSymptomaticBreastReferralPatientStatusLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "14", new ValueWithNote(null, "Suspected primary cancer") },
            { "09", new ValueWithNote(null, "Under investigation following symptomatic referral, cancer not suspected (breast referrals only)") },
            { "03", new ValueWithNote(null, "No new cancer diagnosis identified by the health care provider") },
            { "10", new ValueWithNote(null, "Diagnosis of new cancer confirmed - NHS funded first treatment not yet planned") },
            { "11", new ValueWithNote(null, "Diagnosis of new cancer confirmed - NHS funded first treatment planned") },
            { "07", new ValueWithNote(null, "Diagnosis of new cancer confirmed - no NHS funded treatment planned") },
            { "08", new ValueWithNote(null, "First NHS funded treatment commenced") },
            { "12", new ValueWithNote(null, "Diagnosis of new cancer confirmed - subsequent NHS funded treatment not yet planned") },
            { "13", new ValueWithNote(null, "Diagnosis of new cancer confirmed - subsequent NHS funded treatment planned") },
            { "21", new ValueWithNote(null, "Subsequent NHS funded treatment commenced") },
            { "15", new ValueWithNote(null, "Suspected recurrent cancer") },
            { "16", new ValueWithNote(null, "Diagnosis of recurrent cancer confirmed - first NHS funded treatment not yet planned") },
            { "17", new ValueWithNote(null, "Diagnosis of recurrent cancer confirmed - NHS funded first treatment planned") },
            { "18", new ValueWithNote(null, "Diagnosis of recurrent cancer confirmed - no NHS funded treatment planned") },
            { "19", new ValueWithNote(null, "Diagnosis of recurrent cancer confirmed - subsequent NHS funded treatment not yet planned") },
            { "20", new ValueWithNote(null, "Diagnosis of recurrent cancer confirmed - subsequent NHS funded treatment planned") },
            { "22", new ValueWithNote(null, "Recurrent cancer NHS funded treatment commenced") },
            { "23", new ValueWithNote(null, "Suspected cancer transformation") },
            { "24", new ValueWithNote(null, "Diagnosis of cancer transformation confirmed - NHS funded first treatment not yet planned") },
            { "25", new ValueWithNote(null, "Diagnosis of cancer transformation confirmed - NHS funded first treatment planned") },
            { "26", new ValueWithNote(null, "Diagnosis of cancer transformation confirmed - no NHS funded treatment planned") },
            { "27", new ValueWithNote(null, "Diagnosis of cancer transformation confirmed - subsequent NHS funded treatment not yet planned") },
            { "28", new ValueWithNote(null, "Diagnosis of cancer transformation confirmed - subsequent NHS funded treatment planned") },
            { "29", new ValueWithNote(null, "Cancer transformation NHS funded treatment commenced") },
            { "30", new ValueWithNote(null, "Suspected cancer progression") },
            { "31", new ValueWithNote(null, "Diagnosis of cancer progression confirmed - NHS funded first treatment not yet planned") },
            { "32", new ValueWithNote(null, "Diagnosis of cancer progression confirmed - NHS funded first treatment planned") },
            { "33", new ValueWithNote(null, "Diagnosis of cancer progression confirmed - no NHS funded treatment planned") },
            { "34", new ValueWithNote(null, "Diagnosis of cancer progression confirmed - subsequent NHS funded treatment not yet planned") },
            { "35", new ValueWithNote(null, "Diagnosis of cancer progression confirmed - subsequent NHS funded treatment planned") },
            { "36", new ValueWithNote(null, "Cancer progression NHS funded treatment commenced") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
