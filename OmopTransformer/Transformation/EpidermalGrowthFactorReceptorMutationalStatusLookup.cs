using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("EPIDERMAL GROWTH FACTOR RECEPTOR MUTATIONAL STATUS")]
internal class EpidermalGrowthFactorReceptorMutationalStatusLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Wild Type (Retired 01 April 2017)") },
            { "2", new ValueWithNote(null, "Mutation (Retired 01 April 2017)") },
            { "3", new ValueWithNote(null, "Failed Analysis (Retired 1 April 2020)") },
            { "4", new ValueWithNote(null, "Not Assessed (Retired 1 April 2020)") },
            { "5", new ValueWithNote(null, "Wild type/non-sensitising mutation (Retired 1 April 2020)") },
            { "6", new ValueWithNote(null, "Sensitising/activating mutation (Retired 1 April 2020)") },
            { "07", new ValueWithNote(null, "Wild type") },
            { "08", new ValueWithNote(null, "Sensitising/activating mutation(s) only") },
            { "09", new ValueWithNote(null, "Resistance mutation (to 1st generation Tyrosine Kinase Inhibitors (TKIs)) - with or without other mutation") },
            { "98", new ValueWithNote(null, "Not Applicable (Not Assessed)") },
            { "99", new ValueWithNote(null, "Not Known (Failed Analysis)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
