using Microsoft.Extensions.Logging;
using OmopTransformer.ConceptResolution;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Death;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.VisitDetail;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.OxfordGP.ConditionOccurrence;
using OmopTransformer.OxfordGP.Death;
using OmopTransformer.OxfordGP.DeviceExposure;
using OmopTransformer.OxfordGP.DrugExposure;
using OmopTransformer.OxfordGP.Location;
using OmopTransformer.OxfordGP.Person;
using OmopTransformer.OxfordGP.ProcedureOccurrence;
using OmopTransformer.OxfordGP.VisitDetail;
using OmopTransformer.OxfordGP.VisitOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordGP;

internal class OxfordGPTransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IDeathRecorder _deathRecorder;
    private readonly StandardConceptResolver _conceptResolver;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IVisitOccurrenceRecorder _visitOccurrenceRecorder;
    private readonly IVisitDetailRecorder _visitDetailRecorder;
    private readonly IDrugExposureRecorder _drugExposureRecorder;
    private readonly IDeviceExposureRecorder _deviceExposureRecorder;

    public OxfordGPTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        ILocationRecorder locationRecorder,
        IPersonRecorder personRecorder,
        IDeathRecorder deathRecorder,
        StandardConceptResolver conceptResolver,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IVisitOccurrenceRecorder visitOccurrenceRecorder,
        IVisitDetailRecorder visitDetailRecorder,
        IDrugExposureRecorder drugExposureRecorder,
        IDeviceExposureRecorder deviceExposureRecorder) : base(recordTransformer,
        transformOptions,
        recordProvider,
        "Oxford-GP",
        runAnalysisRecorder,
        loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _deathRecorder = deathRecorder;
        _conceptResolver = conceptResolver;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _visitOccurrenceRecorder = visitOccurrenceRecorder;
        _visitDetailRecorder = visitDetailRecorder;
        _drugExposureRecorder = drugExposureRecorder;
        _deviceExposureRecorder = deviceExposureRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<OxfordGPPersonRecord, OxfordGPPerson>(
          _personRecorder.InsertUpdatePersons,
          "Oxford GP Person",
          runId,
          cancellationToken);

        await Transform<OxfordGPDeathRecord, OxfordGPDeath>(
          _deathRecorder.InsertUpdateDeaths,
          "Oxford GP Death",
          runId,
          cancellationToken);

        await Transform<OxfordGPLocationRecord, OxfordGPLocation>(
          _locationRecorder.InsertUpdateLocations,
          "Oxford GP Location",
          runId,
          cancellationToken);

        await Transform<OxfordGPProcedureOccurrenceRecord, OxfordGPProcedureOccurrence>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Oxford GP Procedure Occurrence",
            runId,
            cancellationToken);

        await Transform<OxfordGPConditionOccurrenceRecord, OxfordGPConditionOccurrence>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Oxford GP Condition Occurrence",
            runId,
            cancellationToken);

        await Transform<OxfordGPVisitOccurrenceRecord, OxfordGPVisitOccurrence>(
            _visitOccurrenceRecorder.InsertUpdateVisitOccurrence,
            "Oxford GP Visit Occurrence",
            runId,
            cancellationToken);

        await Transform<OxfordGPVisitDetailRecord, OxfordGPVisitDetails>(
            _visitDetailRecorder.InsertUpdateVisitDetail,
            "Oxford GP Visit Detail",
            runId,
            cancellationToken);

        await Transform<OxfordGPDrugExposureRecord, OxfordGPDrugExposure>(
            _drugExposureRecorder.InsertUpdateDrugExposure,
            "Oxford GP Drug Exposure",
            runId,
            cancellationToken);

        await Transform<OxfordGPDeviceExposureRecord, OxfordGPDeviceExposure>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "Oxford GP Device Exposure",
            runId,
            cancellationToken);
    }
}
