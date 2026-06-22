using Microsoft.Extensions.Logging;
using OmopTransformer.Omop;
using OmopTransformer.Omop.CareSite;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.Provider;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.SACT.CareSite;
using OmopTransformer.SACT.ConditionOccurrence;
using OmopTransformer.SACT.DrugExposure;
using OmopTransformer.SACT.Location;
using OmopTransformer.SACT.Measurements.SactMeasurementHeight;
using OmopTransformer.SACT.Measurements.SactMeasurementWeightAtStartOfCycle;
using OmopTransformer.SACT.Measurements.SactMeasurementWeightAtStartOfRegimen;
using OmopTransformer.SACT.Observation;
using OmopTransformer.SACT.Person;
using OmopTransformer.SACT.Provider;
using OmopTransformer.SACT.VisitOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.SACT;
internal class SactTransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IDrugExposureRecorder _drugExposureRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IVisitOccurrenceRecorder _visitOccurrenceRecorder;
    private readonly IProviderRecorder _providerRecorder;
    private readonly ICareSiteRecorder _careSiteRecorder;
    private readonly IMeasurementRecorder _measurementRecorder;
    private readonly IObservationRecorder _observationRecorder;

    public SactTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        ILocationRecorder locationRecorder,
        IPersonRecorder personRecorder,
        IDrugExposureRecorder drugExposureRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IVisitOccurrenceRecorder visitOccurrenceRecorder,
        IMeasurementRecorder measurementRecorder,
        IProviderRecorder providerRecorder,
        ICareSiteRecorder careSiteRecorder,
        IObservationRecorder observationRecorder,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory)
        : base(
            recordTransformer,
            transformOptions,
            recordProvider,
            "SACT",
            runAnalysisRecorder,
            loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _drugExposureRecorder = drugExposureRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _visitOccurrenceRecorder = visitOccurrenceRecorder;
        _measurementRecorder = measurementRecorder;
        _providerRecorder = providerRecorder;
        _careSiteRecorder = careSiteRecorder;
        _observationRecorder = observationRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid newId = Guid.NewGuid();

        await Transform<SactPersonRecord, SactPerson>(
            _personRecorder.InsertUpdatePersons,
            "SACT Person",
            newId,
            cancellationToken);

        await Transform<SactLocationRecord, SactLocation>(
            _locationRecorder.InsertUpdateLocations,
            "SACT Locations",
            newId,
            cancellationToken);

        await Transform<SactDrugExposureRecord, SactDrugExposure>(
            _drugExposureRecorder.InsertUpdateDrugExposure,
            "SACT Drug Exposure",
            newId,
            cancellationToken);

        await Transform<SactConditionOccurrenceRecord, SactConditionOccurrence>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "SACT Condition Occurrence",
            newId,
            cancellationToken);

        await Transform<SactVisitOccurrenceRecord, SactVisitOccurrence>(
            _visitOccurrenceRecorder.InsertUpdateVisitOccurrence,
            "SACT Visit Occurrence",
            newId,
            cancellationToken);

        await Transform<SactMeasurementHeightRecord, SactMeasurementHeight>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SACT Measurement Height",
            newId,
            cancellationToken);

        await Transform<SactMeasurementWeightAtStartOfCycleRecord, SactMeasurementWeightAtStartOfCycle>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SACT Measurement Weight at Start of Cycle",
            newId,
            cancellationToken);

        await Transform<SactMeasurementWeightAtStartOfRegimenRecord, SactMeasurementWeightAtStartOfRegimen>(
            _measurementRecorder.InsertUpdateMeasurements,
            "SACT Measurement Weight at Start of Regimen",
            newId,
            cancellationToken);

        await Transform<SactProviderRecord, SactProvider>(
            _providerRecorder.InsertUpdateProvider,
            "SACT Provider",
            newId,
            cancellationToken);

        await Transform<SactCareSiteRecord, SactCareSite>(
            _careSiteRecorder.InsertUpdateCareSite,
            "SACT Care Site",
            newId,
            cancellationToken);

        await Transform<SactAdministrationRouteRecord, SactAdministrationRoute>(
            _observationRecorder.InsertUpdateObservations,
            "SACT Observation - Drug Administration Route",
            newId,
            cancellationToken);

        await Transform<SactAdjunctiveTherapyTypeRecord, SactAdjunctiveTherapyType>(
            _observationRecorder.InsertUpdateObservations,
            "SACT Observation - Adjunctive Therapy Type",
            newId,
            cancellationToken);

        await Transform<SactTreatmentIntentRecord, SactTreatmentIntent>(
            _observationRecorder.InsertUpdateObservations,
            "SACT Observation - Treatment Intent",
            newId,
            cancellationToken);
        
        await Transform<SactClinicalTrialRecord, SactClinicalTrial>(
            _observationRecorder.InsertUpdateObservations,
            "SACT Observation - Clinical Trial",
            newId,
            cancellationToken);
    }
}