using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsHeartRate;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsSystolicBloodPressure;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsDiastolicBloodPressure;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsMeanArterialPressure;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsRespiratoryRate;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsTemperature;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsOxygenSaturation;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsOxygenConcentration;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsGlasgowComaScore;
using OmopTransformer.OxfordClinicalObservationsVitalSigns.ConditionOccurrence.OxfordVitalSignsTracheostomy;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns;

internal class OxfordClinicalObservationsVitalSignsTransformer : Transformer
{
    private readonly IMeasurementRecorder _measurementRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly ILogger<OxfordClinicalObservationsVitalSignsTransformer> _logger;

    public OxfordClinicalObservationsVitalSignsTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IMeasurementRecorder measurementRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder) : base(
        recordTransformer, transformOptions, recordProvider, "Oxford-Clinical-Observations-Vital-Signs",
        runAnalysisRecorder, loggerFactory)
    {
        _measurementRecorder = measurementRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _logger = loggerFactory.CreateLogger<OxfordClinicalObservationsVitalSignsTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        var runId = Guid.NewGuid();

        await Transform<OxfordVitalSignsHeartRateRecord, OxfordVitalSignsHeartRate>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Heart Rate", runId, cancellationToken);
        await Transform<OxfordVitalSignsSystolicBloodPressureRecord, OxfordVitalSignsSystolicBloodPressure>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Systolic Blood Pressure", runId, cancellationToken);
        await Transform<OxfordVitalSignsDiastolicBloodPressureRecord, OxfordVitalSignsDiastolicBloodPressure>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Diastolic Blood Pressure", runId, cancellationToken);
        await Transform<OxfordVitalSignsMeanArterialPressureRecord, OxfordVitalSignsMeanArterialPressure>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Mean Arterial Pressure", runId, cancellationToken);
        await Transform<OxfordVitalSignsRespiratoryRateRecord, OxfordVitalSignsRespiratoryRate>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Respiratory Rate", runId, cancellationToken);
        await Transform<OxfordVitalSignsTemperatureRecord, OxfordVitalSignsTemperature>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Temperature", runId, cancellationToken);
        await Transform<OxfordVitalSignsOxygenSaturationRecord, OxfordVitalSignsOxygenSaturation>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Oxygen Saturation", runId, cancellationToken);
        await Transform<OxfordVitalSignsOxygenConcentrationRecord, OxfordVitalSignsOxygenConcentration>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Oxygen Concentration", runId, cancellationToken);
        await Transform<OxfordVitalSignsGlasgowComaScoreRecord, OxfordVitalSignsGlasgowComaScore>(
            _measurementRecorder.InsertUpdateMeasurements, "Oxford Vital Signs Glasgow Coma Score", runId, cancellationToken);
        await Transform<OxfordVitalSignsTracheostomyRecord, OxfordVitalSignsTracheostomy>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence, "Oxford Vital Signs Tracheostomy Condition", runId, cancellationToken);
    }
}
