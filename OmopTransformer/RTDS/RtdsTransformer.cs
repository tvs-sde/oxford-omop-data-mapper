using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.Provider;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.RTDS.ConditionOccurrence;
using OmopTransformer.RTDS.Location;
using OmopTransformer.RTDS.Observation;
using OmopTransformer.RTDS.Person;
using OmopTransformer.RTDS.ProcedureOccurrence;
using OmopTransformer.RTDS.Provider;
using OmopTransformer.RTDS.VisitOccurrence;
using OmopTransformer.Transformation;
//using OmopTransformer.RTDS.VisitOccurrence;

namespace OmopTransformer.RTDS;

internal class RtdsTransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IVisitOccurrenceRecorder _visitOccurrenceRecorder;
    private readonly IProviderRecorder _providerRecorder;
    private readonly IObservationRecorder _observationRecorder;

    public RtdsTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        ILocationRecorder locationRecorder,
        IPersonRecorder personRecorder,
        IProviderRecorder providerRecorder,
        IObservationRecorder observationRecorder,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IVisitOccurrenceRecorder visitOccurrenceRecorder,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory)
        : base(
            recordTransformer,
            transformOptions,
            recordProvider,
            "RTDS",
            runAnalysisRecorder,
            loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _visitOccurrenceRecorder = visitOccurrenceRecorder;
        _providerRecorder = providerRecorder;
        _observationRecorder = observationRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<RtdsPersonRecord, RtdsPerson>(
            _personRecorder.InsertUpdatePersons,
            "Rtds Person",
            runId,
            cancellationToken);

        await Transform<RtdsLocationRecord, RtdsLocation>(
            _locationRecorder.InsertUpdateLocations,
            "Rtds Location",
            runId,
            cancellationToken);

        await Transform<RtdsProcedureOccurrenceRecord, RtdsProcedureOccurrence>(
          _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
          "Rtds Procedure Occurrence",
          runId,
          cancellationToken);

        await Transform<RtdsConditionOccurrenceRecord, RtdsConditionOccurrence>(
          _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
          "Rtds Condition Occurrence",
          runId,
          cancellationToken);

        await Transform<RtdsVisitOccurrenceRecord, RtdsVisitOccurrence>(
         _visitOccurrenceRecorder.InsertUpdateVisitOccurrence,
         "Rtds Visit Occurrence",
         runId,
         cancellationToken);

        await Transform<RtdsProviderRecord, RtdsProvider>(
        _providerRecorder.InsertUpdateProvider,
        "Rtds Provider",
        runId,
        cancellationToken);

        await Transform<RtdsDecisionToPerformDateRecord, RtdsDecisionToPerformDate>(
            _observationRecorder.InsertUpdateObservations,
            "RTDS Observation - Decision To Perform Date",
            runId,
            cancellationToken);

        await Transform<RtdsExternalBeamEnergyRecord, RtdsExternalBeamEnergy>(
        _observationRecorder.InsertUpdateObservations,
        "RTDS Observation - External Beam Radiation Therapy Energy",
        runId,
        cancellationToken);

        await Transform<RtdsNumberOfFractionsRecord, RtdsNumberOfFractions>(
        _observationRecorder.InsertUpdateObservations,
        "RTDS Observation - Number Of Fractions",
        runId,
        cancellationToken);

        await Transform<RtdsTreatmentAnatomicalSiteRecord, RtdsTreatmentAnatomicalSite>(
        _observationRecorder.InsertUpdateObservations,
        "RTDS Observation - Treatment Anatomical Site",
        runId,
        cancellationToken);
            
        await Transform<RtdsReferralDateRecord, RtdsReferralDate>(
        _observationRecorder.InsertUpdateObservations,
        "RTDS Observation - Date of Referral",
        runId,
        cancellationToken);
    }
}