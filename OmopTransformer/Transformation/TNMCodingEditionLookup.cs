using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("TNM CODING EDITION")]
internal class TNMCodingEditionLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Union for International Cancer Control (UICC)") },
            { "2", new ValueWithNote(null, "American Joint Committee on Cancer (AJCC)") },
            { "3", new ValueWithNote(null, "European Neuroendocrine Tumor Society (ENETS)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}