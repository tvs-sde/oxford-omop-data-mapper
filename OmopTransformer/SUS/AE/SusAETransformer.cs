using Microsoft.Extensions.Logging;
using OmopTransformer.ConceptResolution;
using OmopTransformer.Omop;
using OmopTransformer.Omop.CareSite;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Death;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.VisitDetail;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.SUS.AE.CareSite;
using OmopTransformer.SUS.AE.ConditionOccurrence;
using OmopTransformer.SUS.AE.Death;
using OmopTransformer.SUS.AE.DeviceExposure.InvestigationDevice;
using OmopTransformer.SUS.AE.DeviceExposure.ProcedureDevice;
using OmopTransformer.SUS.AE.Location;
using OmopTransformer.SUS.AE.Observation.AsthmaticPatient;
using OmopTransformer.SUS.AE.Observation.DiabeticPatient;
using OmopTransformer.SUS.AE.Observation.SourceOfReferralForAE;
using OmopTransformer.SUS.AE.ProcedureOccurrence;
using OmopTransformer.SUS.AE.VisitDetails;
using OmopTransformer.SUS.AE.VisitOccurrenceWithSpell;
using OmopTransformer.Transformation;

namespace OmopTransformer.SUS.AE;

internal class SusAETransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IVisitOccurrenceRecorder _visitOccurrenceRecorder;
    private readonly IVisitDetailRecorder _visitDetailRecorder;
    private readonly IDeathRecorder _deathRecorder;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IDeviceExposureRecorder _deviceExposureRecorder;
    private readonly IObservationRecorder _observationRecorder;
    private readonly StandardConceptResolver _conceptResolver;
    private readonly ICareSiteRecorder _careSiteRecorder;

    public SusAETransformer(
        ICareSiteRecorder careSiteRecorder,
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        ILocationRecorder locationRecorder,
        IPersonRecorder personRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IVisitOccurrenceRecorder visitOccurrenceRecorder,
        IVisitDetailRecorder visitDetailRecorder,
        IDeathRecorder deathRecorder,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder, 
        StandardConceptResolver conceptResolver,
        IDeviceExposureRecorder deviceExposureRecorder,
        IObservationRecorder observationRecorder,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory) : base(recordTransformer,
        transformOptions,
        recordProvider,
        "SUSAE",
        runAnalysisRecorder,
        loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _visitOccurrenceRecorder = visitOccurrenceRecorder;
        _visitDetailRecorder = visitDetailRecorder;
        _deathRecorder = deathRecorder;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _conceptResolver = conceptResolver;
        _deviceExposureRecorder = deviceExposureRecorder;
        _observationRecorder = observationRecorder;
        _careSiteRecorder = careSiteRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<SusAEPersonRecord, SusAEPerson>(
          _personRecorder.InsertUpdatePersons,
          "Sus AE Person",
          runId,
          cancellationToken);

        await Transform<SusAEDeathRecord, SusAEDeath>(
          _deathRecorder.InsertUpdateDeaths,
          "SUS AE Death",
          runId,
          cancellationToken);

        await Transform<SusAEProcedureOccurrenceRecord, SusAEProcedureOccurrence>(
          _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
          "SUS AE Procedure Occurrence",
          runId,
          cancellationToken);

        await Transform<SusAEConditionOccurrenceRecord, SusAEConditionOccurrence>(
          _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
          "SUS AE Condition Occurrence",
          runId,
          cancellationToken);

        await Transform<SusAELocationRecord, SusAELocation>(
          _locationRecorder.InsertUpdateLocations,
          "SUS AE Location",
          runId,
          cancellationToken);

        await Transform<SusAEVisitOccurrenceWithSpellRecord, SusAEVisitOccurrenceWithSpell>(
          _visitOccurrenceRecorder.InsertUpdateVisitOccurrence,
          "SUS AE VisitOccurrenceWithSpell",
          runId,
          cancellationToken);

        await Transform<SusAEDiabeticPatientRecord, SusAEDiabeticPatient>(
          _observationRecorder.InsertUpdateObservations,
          "SUS AE DiabeticPatient",
          runId,
          cancellationToken);

        await Transform<SusAEAsthmaticPatientRecord, SusAEAsthmaticPatient>(
          _observationRecorder.InsertUpdateObservations,
          "SUS AE AsthmaticPatient",
          runId, 
          cancellationToken);

        await Transform<SusAESourceOfReferralForAERecord, SusAESourceOfReferralForAE>(
          _observationRecorder.InsertUpdateObservations,
          "SUS AE SourceOfReferralForAE",
          runId,
          cancellationToken);

        await Transform<SusAEVisitDetailsRecord, SusAEVisitDetail>(
          _visitDetailRecorder.InsertUpdateVisitDetail,
          "SUS AE VisitDetail",
          runId,
          cancellationToken);

        await Transform<SusAEInvestigationDeviceRecord, SusAEInvestigationDevice>(
           _deviceExposureRecorder.InsertUpdateDeviceExposure,
           "SUS AE Investigation Device Exposure",
           runId,
           cancellationToken);

        await Transform<SusAEProcedureDeviceRecord, SusAEProcedureDevice>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "Sus AE Procedure Device Exposure",
            runId,
            cancellationToken);

        await Transform<SusAECareSiteRecord, SusAECareSite>(
           _careSiteRecorder.InsertUpdateCareSite,
           "SUS AE CareSite",
           runId,
           cancellationToken);
    }
}
