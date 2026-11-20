using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.OxfordClinicalObservationsBmi.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsBmi;

internal class OxfordClinicalObservationsBmiTransformer : Transformer
{
    private readonly IMeasurementRecorder _measurementRecorder;
    private readonly ILogger<OxfordClinicalObservationsBmiTransformer> _logger;

    public OxfordClinicalObservationsBmiTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IMeasurementRecorder measurementRecorder) : base(
        recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Clinical-Observations-BMI",
        runAnalysisRecorder,
        loggerFactory)
    {
        _measurementRecorder = measurementRecorder;
        _logger = loggerFactory.CreateLogger<OxfordClinicalObservationsBmiTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        await Transform<OxfordClinicalObservationsBmiMeasurementRecord, OxfordClinicalObservationsBmiMeasurement>(
            _measurementRecorder.InsertUpdateMeasurements,
            "Oxford Clinical Observations BMI Measurement", Guid.NewGuid(), cancellationToken);
    }
}
