using Microsoft.Extensions.Logging;
using OmopTransformer.ConceptResolution;
using OmopTransformer.Omop;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.OxfordPrescribing.DrugExposure;
using OmopTransformer.OxfordPrescribing.DrugExposureWithSnomed;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordPrescribing;

internal class OxfordPrescribingTransformer : Transformer
{
    private readonly StandardConceptResolver _conceptResolver;
    private readonly IDrugExposureRecorder _drugExposureRecorder;

    public OxfordPrescribingTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        IDrugExposureRecorder drugExposureRecorder,
        StandardConceptResolver conceptResolver,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory) : base(recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-Prescribing",
        runAnalysisRecorder,
        loggerFactory)
    {
        _drugExposureRecorder = drugExposureRecorder;
        _conceptResolver = conceptResolver;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<OxfordPrescribingDrugExposureWithSnomedRecord, OxfordPrescribingDrugExposureWithSnomed>(
            _drugExposureRecorder.InsertUpdateDrugExposure,
            "Oxford Prescribing Drugs (With Snomed)",
            runId,
            cancellationToken);

        await Transform<OxfordPrescribingDrugExposureRecord, OxfordPrescribingDrugExposure>(
          _drugExposureRecorder.InsertUpdateDrugExposure,
          "Oxford Prescribing Drugs",
          runId,
          cancellationToken);
    }
}
