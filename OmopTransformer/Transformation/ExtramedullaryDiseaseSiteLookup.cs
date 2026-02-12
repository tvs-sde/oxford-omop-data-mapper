using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("EXTRAMEDULLARY DISEASE SITE")]
internal class ExtramedullaryDiseaseSiteLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "T", new ValueWithNote(null, "Testes (Retired 01 April 2017)") },
            { "C", new ValueWithNote(null, "CNS (Central Nervous System) (Retired 01 April 2017)") },
            { "O", new ValueWithNote(null, "Other (Retired 01 April 2017)") },
            { "1", new ValueWithNote(null, "CNS1 (Central Nervous System) (less than 5 WBC in the CSF without blasts)") },
            { "2", new ValueWithNote(null, "CNS2 (Central Nervous System) (less than 5 WBC in the CSF with blasts)") },
            { "3", new ValueWithNote(null, "CNS3 (Central Nervous System) (greater than or equal to 5 WBC in the CSF with blasts)") },
            { "4", new ValueWithNote(null, "Testes") },
            { "9", new ValueWithNote(null, "Other (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
