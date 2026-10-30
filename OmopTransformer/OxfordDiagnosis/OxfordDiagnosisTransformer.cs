using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceIcd10;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceOpcs4;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceSnomed;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis;

internal class OxfordDiagnosisTransformer : Transformer
{
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly ILogger<OxfordDiagnosisTransformer> _logger;

    public OxfordDiagnosisTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder) : base(
        recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Diagnosis",
        runAnalysisRecorder,
        loggerFactory)
    {
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _logger = loggerFactory.CreateLogger<OxfordDiagnosisTransformer>();
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        var runId = Guid.NewGuid();

        _logger.LogWarning("Only SNOMED CT, ICD-10/ICD10 and OPCS4 diagnoses are mapped. IMO, Patient Care, HRG and rows with a missing or unrecognised diagnosis_code_system are not selected.");

        await Transform<OxfordDiagnosisSnomedRecord, OxfordDiagnosisConditionOccurrenceSnomed>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Diagnosis SNOMED Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisIcd10Record, OxfordDiagnosisConditionOccurrenceIcd10>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Diagnosis ICD10 Condition Occurrence", runId, cancellationToken);

        await Transform<OxfordDiagnosisOpcs4Record, OxfordDiagnosisConditionOccurrenceOpcs4>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford Diagnosis OPCS4 Condition Occurrence", runId, cancellationToken);
    }
}
