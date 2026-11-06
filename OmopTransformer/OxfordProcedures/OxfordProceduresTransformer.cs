using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.Omop.Observation;
using OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceOpcs4;
using OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceSnomed;
using OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureOpcs4;
using OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureSnomed;
using OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureOpcs4;
using OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureSnomed;
using OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationOpcs4;
using OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationSnomed;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceOpcs4;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceSnomed;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures;

internal class OxfordProceduresTransformer : Transformer
{
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IDeviceExposureRecorder _deviceExposureRecorder;
    private readonly IDrugExposureRecorder _drugExposureRecorder;
    private readonly IObservationRecorder _observationRecorder;
    private readonly ILogger<OxfordProceduresTransformer> _logger;

    public OxfordProceduresTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IDeviceExposureRecorder deviceExposureRecorder,
        IDrugExposureRecorder drugExposureRecorder,
        IObservationRecorder observationRecorder) : base(
        recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Procedures",
        runAnalysisRecorder,
        loggerFactory)
    {
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _deviceExposureRecorder = deviceExposureRecorder;
        _drugExposureRecorder = drugExposureRecorder;
        _observationRecorder = observationRecorder;
        _logger = loggerFactory.CreateLogger<OxfordProceduresTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        var runId = Guid.NewGuid();

        _logger.LogWarning("Only SNOMED CT and OPCS4 procedures are mapped. ICD10, Patient Care, IMO and rows with a missing or unrecognised clinical_code_system are not selected.");
        _logger.LogWarning("Domains without recorders are not mapped: Meas Value, Spec Anatomic Site, Specimen, Unit and Route.");
        _logger.LogWarning("Measurement-domain procedures are not mapped because the source does not provide measurement results or units.");

        await Transform<OxfordProceduresProcedureOccurrenceSnomedRecord, OxfordProceduresProcedureOccurrenceSnomed>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Procedures SNOMED Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresProcedureOccurrenceOpcs4Record, OxfordProceduresProcedureOccurrenceOpcs4>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Procedures OPCS4 Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresObservationSnomedRecord, OxfordProceduresObservationSnomed>(
            _observationRecorder.InsertUpdateObservations,
            "Oxford Procedures SNOMED Observation", runId, cancellationToken);

        await Transform<OxfordProceduresObservationOpcs4Record, OxfordProceduresObservationOpcs4>(
            _observationRecorder.InsertUpdateObservations,
            "Oxford Procedures OPCS4 Observation", runId, cancellationToken);

        await Transform<OxfordProceduresConditionOccurrenceSnomedRecord, OxfordProceduresConditionOccurrenceSnomed>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Procedures SNOMED Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresConditionOccurrenceOpcs4Record, OxfordProceduresConditionOccurrenceOpcs4>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Procedures OPCS4 Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresDeviceExposureSnomedRecord, OxfordProceduresDeviceExposureSnomed>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "Oxford Procedures SNOMED Device Exposure", runId, cancellationToken);

        await Transform<OxfordProceduresDeviceExposureOpcs4Record, OxfordProceduresDeviceExposureOpcs4>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "Oxford Procedures OPCS4 Device Exposure", runId, cancellationToken);

        await Transform<OxfordProceduresDrugExposureSnomedRecord, OxfordProceduresDrugExposureSnomed>(
            _drugExposureRecorder.InsertUpdateDrugExposure,
            "Oxford Procedures SNOMED Drug Exposure", runId, cancellationToken);

        await Transform<OxfordProceduresDrugExposureOpcs4Record, OxfordProceduresDrugExposureOpcs4>(
            _drugExposureRecorder.InsertUpdateDrugExposure,
            "Oxford Procedures OPCS4 Drug Exposure", runId, cancellationToken);
    }
}
