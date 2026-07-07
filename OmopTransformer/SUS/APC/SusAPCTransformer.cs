using Microsoft.Extensions.Logging;
using OmopTransformer.ConceptResolution;
using OmopTransformer.Omop;
using OmopTransformer.Omop.CareSite;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Death;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.Provider;
using OmopTransformer.Omop.VisitDetail;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.SUS.APC.CareSite;
using OmopTransformer.SUS.APC.ConditionOccurrence;
using OmopTransformer.SUS.APC.Death;
using OmopTransformer.SUS.APC.DeviceExposure;
using OmopTransformer.SUS.APC.Location;
using OmopTransformer.SUS.APC.Measurements.SusAPCMeasurement;
using OmopTransformer.SUS.APC.Observation.AnaestheticDuringLabourDelivery;
using OmopTransformer.SUS.APC.Observation.AnaestheticGivenPostLabourDelivery;
using OmopTransformer.SUS.APC.Observation.BirthWeight;
using OmopTransformer.SUS.APC.Observation.CarerSupportIndicator;
using OmopTransformer.SUS.APC.Observation.GestationLengthLabourOnset;
using OmopTransformer.SUS.APC.Observation.ICDDiagnosis;
using OmopTransformer.SUS.APC.Observation.NumberOfBabies;
using OmopTransformer.SUS.APC.Observation.ProcedureObservations;
using OmopTransformer.SUS.APC.Observation.ReferralReceivedDateForInpatients;
using OmopTransformer.SUS.APC.Observation.SourceOfReferralForInpatients;
using OmopTransformer.SUS.APC.Observation.TotalPreviousPregnancies;
using OmopTransformer.SUS.APC.ProcedureOccurrence;
using OmopTransformer.SUS.APC.Provider;
using OmopTransformer.SUS.APC.VisitDetails;
using OmopTransformer.SUS.APC.VisitOccurrenceWithSpell;
using OmopTransformer.SUS.CCMDS.DeviceExposure;
using OmopTransformer.SUS.CCMDS.Measurements.GestationLengthAtDelivery;
using OmopTransformer.SUS.CCMDS.Measurements.PersonWeight;
using OmopTransformer.SUS.CCMDS.Observation.HighCostDrugs;
using OmopTransformer.SUS.CCMDS.Observation.HighCostDrugs.SusCCMDSHighCostDrugs;
using OmopTransformer.SUS.CCMDS.ProcedureOccurrence;
using OmopTransformer.SUS.CCMDS.VisitDetails;
using OmopTransformer.Transformation;

namespace OmopTransformer.SUS.APC;

internal class SusAPCTransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IMeasurementRecorder _measurementRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IVisitOccurrenceRecorder _visitOccurrenceRecorder;
    private readonly IVisitDetailRecorder _visitDetailRecorder;
    private readonly IDeathRecorder _deathRecorder;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IObservationRecorder _observationRecorder;
    private readonly StandardConceptResolver _conceptResolver;
    private readonly ICareSiteRecorder _careSiteRecorder;
    private readonly IProviderRecorder _providerRecorder;
    private readonly IDeviceExposureRecorder _deviceExposureRecorder;

    public SusAPCTransformer(
        ICareSiteRecorder careSiteRecorder,
        IProviderRecorder providerRecorder,
        IMeasurementRecorder measurementRecorder,
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
        ILoggerFactory loggerFactory) :
        base(
            recordTransformer,
            transformOptions,
            recordProvider,
            "SUSAPC",
            runAnalysisRecorder,
            loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _measurementRecorder = measurementRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _visitOccurrenceRecorder = visitOccurrenceRecorder;
        _visitDetailRecorder = visitDetailRecorder;
        _deathRecorder = deathRecorder;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _conceptResolver = conceptResolver;
        _deviceExposureRecorder = deviceExposureRecorder;
        _observationRecorder = observationRecorder;
        _careSiteRecorder = careSiteRecorder;
        _providerRecorder = providerRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<SusAPCPersonRecord, SusAPCPerson>(
          _personRecorder.InsertUpdatePersons,
          "SUS APC Person",
          runId,
          cancellationToken);

        await Transform<SusAPCDeathRecord, SusAPCDeath>(
          _deathRecorder.InsertUpdateDeaths,
          "SUS APC Death",
          runId,
          cancellationToken);

        await Transform<SusAPCProcedureOccurrenceRecord, SusAPCProcedureOccurrence>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "SUS APC Procedure Occurrence",
            runId,
            cancellationToken);

        await Transform<SusAPCDeviceExposureRecord, SusAPCDeviceExposure>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "SUS APC Device Exposure",
            runId,
            cancellationToken);

        await Transform<SusAPCConditionOccurrenceRecord, SusAPCConditionOccurrence>(
          _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
          "SUS APC Condition Occurrence",
          runId,
          cancellationToken);

        await Transform<SusAPCLocationRecord, SusAPCLocation>(
          _locationRecorder.InsertUpdateLocations,
          "SUS APC Location",
          runId,
          cancellationToken);

        await Transform<SusAPCVisitOccurrenceWithSpellRecord, SusAPCVisitOccurrenceWithSpell>(
          _visitOccurrenceRecorder.InsertUpdateVisitOccurrence,
          "SUS APC VisitOccurrenceWithSpell",
          runId,
          cancellationToken);

        await Transform<SusAPCAnaestheticDuringLabourDeliveryRecord, SusAPCAnaestheticDuringLabourDelivery>(
          _observationRecorder.InsertUpdateObservations,
        "SUS APC AnaestheticDuringLabourDelivery",
          runId,
          cancellationToken);

        await Transform<SusAPCAnaestheticGivenPostLabourDeliveryRecord, SusAPCAnaestheticGivenPostLabourDelivery>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC AnaestheticGivenPostLabourDelivery",
          runId,
          cancellationToken);

        await Transform<SusAPCBirthWeightRecord, SusAPCBirthWeight>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC BirthWeight",
          runId,
          cancellationToken);

        await Transform<SusAPCCarerSupportIndicatorRecord, SusAPCCarerSupportIndicator>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC CarerSupportIndicator",
          runId,
          cancellationToken);

        await Transform<SusAPCGestationLengthLabourOnsetRecord, SusAPCGestationLengthLabourOnset>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC GestationLengthLabourOnset",
          runId,
          cancellationToken);

        await Transform<SusAPCNumberOfBabiesRecord, SusAPCNumberOfBabies>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC NumberOfBabies",
          runId,
          cancellationToken);

        await Transform<SusAPCTotalPreviousPregnanciesRecord, SusAPCTotalPreviousPregnancies>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC TotalPreviousPregnancies",
          runId,
          cancellationToken);

        await Transform<SusAPCSourceOfReferralForInpatientsRecord, SusAPCSourceOfReferralForInpatients>(
          _observationRecorder.InsertUpdateObservations,
          "SUS APC SourceOfReferralForInpatients",
          runId,
          cancellationToken);

        await Transform<SusAPCVisitDetailsRecord, SusAPCVisitDetail>(
          _visitDetailRecorder.InsertUpdateVisitDetail,
          "SUS APC VisitDetail",
          runId,
          cancellationToken);

        await Transform<SusAPCCareSiteRecord, SusAPCCareSite>(
           _careSiteRecorder.InsertUpdateCareSite,
           "SUS APC CareSite",
           runId,
           cancellationToken);

        await Transform<SusAPCProviderRecord, SusAPCProvider>(
           _providerRecorder.InsertUpdateProvider,
           "SUS APC Provider",
           runId,
           cancellationToken);

        await Transform<SusAPCMeasurementRecord, SusAPCMeasurement>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SUS APC Measurements",
            runId,
            cancellationToken);

        await Transform<SusCCMDSVisitDetailsRecord, SusCCMDSVisitDetail>(
            _visitDetailRecorder.InsertUpdateVisitDetail,
            "SUS CCMDS VisitDetail",
            runId,
            cancellationToken);

        await Transform<SusCCMDSProcedureOccurrenceRecord, SusCCMDSProcedureOccurrence>(
          _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
          "SUS CCMDS Procedure Occurrence",
          runId,
          cancellationToken);

        await Transform<SusCCMDSHighCostDrugsRecord, SusCCMDSHighCostDrugs>(
          _observationRecorder.InsertUpdateObservations,
            "SUS CCMDS Observation High Cost Drugs",
            runId,
            cancellationToken);

        await Transform<SusCCMDSMeasurementGestationLengthRecord, SusCCMDSMeasurementGestationLength>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SUS CCMDS Measurements Gestation Length at Delivery",
            runId,
            cancellationToken);

        await Transform<SusCCMDSMeasurementPersonWeightRecord, SusCCMDSMeasurementPersonWeight>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SUS CCMDS Measurements Person Weight",
            runId,
            cancellationToken);

        await Transform<SusCCMDSDeviceExposureRecord, SusCCMDSDeviceExposure>(
            _deviceExposureRecorder.InsertUpdateDeviceExposure,
            "SUS CCMDS Device Exposure",
            runId,
            cancellationToken);

        await Transform<SusAPCReferralReceivedDateForInpatientsRecord, SusAPCReferralReceivedDateForInpatients>(
           _observationRecorder.InsertUpdateObservations,
           "SUS APC ReferralReceivedDateForInpatients",
           runId,
           cancellationToken);

        await Transform<SusAPCProcedureObservationsRecord, SusAPCProcedureObservations>(
            _observationRecorder.InsertUpdateObservations,
            "SUS APC Diagnosis Observations",
            runId,
            cancellationToken);

        await Transform<SusAPCSusDiagnosisRecord, SusAPCSusDiagnosisObservation>(
            _observationRecorder.InsertUpdateObservations,
            "SUS APC sus_OP_OPCSProcedure Observations",
            runId,
            cancellationToken);
    }
}
