using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ETHNIC CATEGORY")]
internal class EthnicCategoryLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "A", new ValueWithNote(null, "White - British") },
            { "B", new ValueWithNote(null, "White - Irish") },
            { "C", new ValueWithNote(null, "White - Any other White background") },
            { "D", new ValueWithNote(null, "Mixed - White and Black Caribbean") },
            { "E", new ValueWithNote(null, "Mixed - White and Black African") },
            { "F", new ValueWithNote(null, "Mixed - White and Asian") },
            { "G", new ValueWithNote(null, "Mixed - Any other mixed background") },
            { "H", new ValueWithNote(null, "Asian or Asian British - Indian") },
            { "J", new ValueWithNote(null, "Asian or Asian British - Pakistani") },
            { "K", new ValueWithNote(null, "Asian or Asian British - Bangladeshi") },
            { "L", new ValueWithNote(null, "Asian or Asian British - Any other Asian background") },
            { "M", new ValueWithNote(null, "Black or Black British - Caribbean") },
            { "N", new ValueWithNote(null, "Black or Black British - African") },
            { "P", new ValueWithNote(null, "Black or Black British - Any other Black background") },
            { "R", new ValueWithNote(null, "Other Ethnic Groups - Chinese") },
            { "S", new ValueWithNote(null, "Other Ethnic Groups - Any other ethnic group") },
            { "Z", new ValueWithNote(null, "Not stated") },
            { "99", new ValueWithNote(null, "Not known") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
