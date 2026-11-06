using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceIcd10;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceOpcs4;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceSnomed;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures;

internal class OxfordProceduresTransformer : Transformer
{
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly ILogger<OxfordProceduresTransformer> _logger;

    public OxfordProceduresTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder) : base(
        recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Procedures",
        runAnalysisRecorder,
        loggerFactory)
    {
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _logger = loggerFactory.CreateLogger<OxfordProceduresTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        var runId = Guid.NewGuid();

        _logger.LogWarning("Only SNOMED CT, ICD-10/ICD10 and OPCS4 procedures are mapped. Patient Care, IMO and rows with a missing or unrecognised clinical_code_system are not selected.");

        await Transform<OxfordProceduresProcedureOccurrenceSnomedRecord, OxfordProceduresProcedureOccurrenceSnomed>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Procedures SNOMED Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresProcedureOccurrenceIcd10Record, OxfordProceduresProcedureOccurrenceIcd10>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Procedures ICD10 Procedure Occurrence", runId, cancellationToken);

        await Transform<OxfordProceduresProcedureOccurrenceOpcs4Record, OxfordProceduresProcedureOccurrenceOpcs4>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford Procedures OPCS4 Procedure Occurrence", runId, cancellationToken);

    }
}
