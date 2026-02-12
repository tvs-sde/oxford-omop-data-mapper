using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CHILDREN TEENAGERS AND YOUNG ADULTS AGE CATEGORY (CONSULTANT AT DIAGNOSIS)")]
internal class ChildrenTeenagersAndYoungAdultsAgeCategoryConsultantAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "P", new ValueWithNote(null, "Paediatric") },
            { "T", new ValueWithNote(null, "Teenage and Young Adult") },
            { "A", new ValueWithNote(null, "Adult") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
