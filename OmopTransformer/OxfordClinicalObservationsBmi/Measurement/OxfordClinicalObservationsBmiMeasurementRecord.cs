using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordClinicalObservationsBmi.Measurement;

[DataOrigin("OxfordClinicalObservationsBmi")]
[Description("Oxford clinical observations: weight, height and body mass index from clinical_observations_bmi.parquet.")]
[SourceQuery("OxfordClinicalObservationsBmiMeasurement.xml")]
internal class OxfordClinicalObservationsBmiMeasurementRecord
{
    public string? nhs_number { get; set; }
    public string? EVENT_END_DT_TM { get; set; }
    public string? EVENT { get; set; }
    public string? RESULT_VALUE { get; set; }
    public string? RESULT_UNITS { get; set; }
    public string? NORMAL_LOW { get; set; }
    public string? NORMAL_HIGH { get; set; }
}
