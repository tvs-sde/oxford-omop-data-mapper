using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup Databricks ethnic group as an OMOP race concept.")]
internal class DatabricksEthnicityLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Asian - Any Other Asian Background", new ValueWithNote("1546078", "Asian - Any Other Asian Background") },
            { "Asian or Asian British - Bangladeshi", new ValueWithNote("1546103", "Asian or Asian British - Bangladeshi") },
            { "Asian or Asian British - Indian", new ValueWithNote("1546166", "Asian or Asian British - Indian") },
            { "Asian or Asian British - Pakistani", new ValueWithNote("1546967", "Asian or Asian British - Pakistani") },
            { "Black - Any Other Black Background", new ValueWithNote("38003598", "Black or Black British - Any other Black background") },
            { "Black or Black British - African", new ValueWithNote("1546143", "Black or Black British - African") },
            { "Black or Black British - Caribbean", new ValueWithNote("1546145", "Black or Black British - Caribbean") },
            { "Mixed - Any Other Mixed Background", new ValueWithNote("1546847", "Mixed - Any other mixed background") },
            { "Mixed - White and Asian", new ValueWithNote("1546847", "Mixed - White and Asian [Athena mapping]") },
            { "Mixed - White and Black African", new ValueWithNote("1546847", "Mixed - White and Black African") },
            { "Mixed - White and Black Caribbean", new ValueWithNote("1546847", "Mixed - White and Black Caribbean") },
            { "Other - Any Other Ethnic Group", new ValueWithNote("0", "Other Ethnic Groups - Any other ethnic group") },
            { "Other - Chinese", new ValueWithNote("38003579", "Other Ethnic Groups - Chinese") },
            { "Other - Not Known", new ValueWithNote("0", "Not known") },
            { "Other - Not Stated", new ValueWithNote("0", "Not stated") },
            { "White - Any Other White Background", new ValueWithNote("8527", "White - Any other White background") },
            { "White - British", new ValueWithNote("8527", "White - British") },
            { "White - Irish", new ValueWithNote("8527", "White - Irish") },
            { "", new ValueWithNote("0", "No data") }
        };

    public string[] ColumnNotes =>
    [
        "[NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)",
        "[OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)"
    ];
}
