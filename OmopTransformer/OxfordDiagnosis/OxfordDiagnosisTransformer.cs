using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceIcd10;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceSnomed;
using OmopTransformer.OxfordDiagnosis.DeviceExposure.OxfordDiagnosisDeviceExposureSnomed;
using OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementIcd10;
using OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementSnomed;
using OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationIcd10;
using OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationSnomed;
using OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceIcd10;
using OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceOpcs4;
using OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceSnomed;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis;

internal class OxfordDiagnosisTransformer : Transformer
{
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IObservationRecorder _observationRecorder;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IMeasurementRecorder _measurementRecorder;
    private readonly IDeviceExposureRecorder _deviceExposureRecorder;
    private readonly ILogger<OxfordDiagnosisTransformer> _logger;

    public OxfordDiagnosisTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IObservationRecorder observationRecorder,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder,
        IMeasurementRecorder measurementRecorder,
        IDeviceExposureRecorder deviceExposureRecorder) : base(
        recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Diagnosis",
        runAnalysisRecorder,
        loggerFactory)
    {
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _observationRecorder = observationRecorder;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _measurementRecorder = measurementRecorder;
        _deviceExposureRecorder = deviceExposureRecorder;
        _logger = loggerFactory.CreateLogger<OxfordDiagnosisTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        var runId = Guid.NewGuid();

        _logger.LogWarning("Only SNOMED CT, ICD-10/ICD10 and OPCS4 diagnoses are mapped. IMO, Patient Care, HRG and rows with a missing or unrecognised diagnosis_code_system are not selected.");
        _logger.LogWarning("Spec Anatomic Site concepts are not mapped: a diagnosis code alone does not identify a specimen event.");

        await Transform<OxfordDiagnosisSnomedRecord, OxfordDiagnosisConditionOccurrenceSnomed>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Diagnosis SNOMED Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisIcd10Record, OxfordDiagnosisConditionOccurrenceIcd10>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Diagnosis ICD10 Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisObservationSnomedRecord, OxfordDiagnosisObservationSnomed>(
            _observationRecorder.InsertUpdateObservations,
            "Oxford Diagnosis SNOMED Observation", runId, cancellationToken);

        await Transform<OxfordDiagnosisObservationIcd10Record, OxfordDiagnosisObservationIcd10>(
            _observationRecorder.InsertUpdateObservations,
            "Oxford Diagnosis ICD10 Observation", runId, cancellationToken);

        await Transform<OxfordDiagnosisProcedureOccurrenceSnomedRecord, OxfordDiagnosisProcedureOccurrenceSnomed>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Diagnosis SNOMED Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisProcedureOccurrenceIcd10Record, OxfordDiagnosisProcedureOccurrenceIcd10>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Diagnosis ICD10 Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisProcedureOccurrenceOpcs4Record, OxfordDiagnosisProcedureOccurrenceOpcs4>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Diagnosis OPCS4 Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisMeasurementSnomedRecord, OxfordDiagnosisMeasurementSnomed>(
            _measurementRecorder.InsertUpdateMeasurements,
            "Oxford Diagnosis SNOMED Measurement", runId, cancellationToken);

        await Transform<OxfordDiagnosisMeasurementIcd10Record, OxfordDiagnosisMeasurementIcd10>(
            _measurementRecorder.InsertUpdateMeasurements,
            "Oxford Diagnosis ICD10 Measurement", runId, cancellationToken);

        await Transform<OxfordDiagnosisDeviceExposureSnomedRecord, OxfordDiagnosisDeviceExposureSnomed>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "Oxford Diagnosis SNOMED Device Exposure", runId, cancellationToken);
    }
}
