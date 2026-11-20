using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsBmi.Measurement;

[Description("Maps weight, height and BMI event names to standard Measurement concepts.")]
internal class OxfordClinicalObservationsBmiEventLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } = new()
    {
        { "Weight", new ValueWithNote("4099154", "Body weight") },
        { "Weight (kg)", new ValueWithNote("4099154", "Body weight") },
        { "Weight Measured", new ValueWithNote("4099154", "Body weight") },
        { "Height/Length Measured", new ValueWithNote("607590", "Body height") },
        { "Booking Height/Length Measured", new ValueWithNote("607590", "Body height") },
        { "Height", new ValueWithNote("607590", "Body height") },
        { "Body Mass Index", new ValueWithNote("3038553", "Body mass index (BMI) [Ratio]") },
        { "Booking Body Mass Index", new ValueWithNote("3038553", "Body mass index (BMI) [Ratio]") },
        { "Body Mass Index (Generic)", new ValueWithNote("3038553", "Body mass index (BMI) [Ratio]") }
    };

    public string[] ColumnNotes => [];
}
