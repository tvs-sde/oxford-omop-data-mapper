using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup SurgicalAccessType concepts for lung cancer procedures.")]
internal class SurgicalAccessTypeLungLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1",   new ValueWithNote("45882425", "Open approach") },
            { "2",   new ValueWithNote("45882426", "Laparoscopic/Thoracoscopic with planned conversion to open surgery") },
            { "3",   new ValueWithNote("45882426", "Laparoscopic/Thoracoscopic with unplanned conversion to open surgery") },
            { "4",   new ValueWithNote("45884447", "Laparoscopic/Thoracoscopic completed") },
            { "5",   new ValueWithNote("45884446", "Robotic surgery") },
            { "Z",   new ValueWithNote("", "Other") }
        };

    public string[] ColumnNotes =>
    [
        "[SURGICAL ACCESS TYPE](https://www.datadictionary.nhs.uk/data_elements/surgical_access_type.html)"
    ];
}
