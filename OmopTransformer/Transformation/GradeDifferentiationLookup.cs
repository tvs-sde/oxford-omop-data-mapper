using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup GradeDifferentiation concepts.")]
internal class GradeDifferentiationLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "GX", new ValueWithNote("0",    "GX grade") },
            { "G1", new ValueWithNote("36768162",   "Grade 1: Well differentiated") },
            { "G2", new ValueWithNote("36770626",   "Grade 2: Moderately differentiated") },
            { "G3", new ValueWithNote("36769666",   "Grade 3: Poorly differentiated") },
            { "G4", new ValueWithNote("36769737",   "Grade 4: Undifferentiated") }
        };

    public string[] ColumnNotes =>
    [
        "[OMOP Grade Differentiation](https://athena.ohdsi.org/search-terms/terms?vocabulary=Cancer+Modifier&conceptClass=Histopattern&page=1&pageSize=500&query=grade&boosts)",
        "[NHS - Grade of Differentiation (At Diagnosis)](https://www.datadictionary.nhs.uk/data_elements/grade_of_differentiation__at_diagnosis_.html?hl=grade%2Cdifferentiation)"
    ];
}