using Microsoft.Extensions.Logging;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrencePrimaryDiagnosis;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrencePrimaryDiagnosisHistologyTopography;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceProgression;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceRecurrence;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdConditionOccurrenceSecondaryDiagnosis;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV8ConditionOccurrencePrimaryDiagnosis;
using OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopography;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrencePrimaryDiagnosis;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopography;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV8BreastConditionOccurrenceProgression;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrencePrimaryDiagnosis;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopography;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrenceSecondaryDiagnosis;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrenceProgression;
using OmopTransformer.COSD.Breast.ConditionOccurrence.CosdV9BreastConditionOccurrenceRecurrence;
using OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV8BreastProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV9BreastProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Breast.ProcedureOccurrence.CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastAdultComorbidityEvaluation;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastFamilialCancerSyndromeIndicator;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosis;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastSmokingStatusCode;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathway;
using OmopTransformer.COSD.Breast.Observation.CosdV8BreastSourceOfReferralOutPatients;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastAdultComorbidityEvaluation;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastAsaScore;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastFamilialCancerSyndrome;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastFamilialCancerSyndromeSubsidiaryComment;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastHistoryOfAlcoholCurrent;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastHistoryOfAlcoholPast;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastMenopausalStatus;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastPerformanceStatusAdult;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway;
using OmopTransformer.COSD.Breast.Observation.CosdV9BreastSourceOfReferralForOutpatients;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNonPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTumourLaterality;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasis;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasis;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTNMcategoryIntegratedStage;
using OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTumourLaterality;
using OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrencePrimaryDiagnosis;
using OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopography;
using OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV8LungConditionOccurrenceProgression;
using OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV9LungConditionOccurrenceProgression;
using OmopTransformer.COSD.Lung.ConditionOccurrence.CosdV9LungConditionOccurrenceRecurrence;
using OmopTransformer.COSD.Core.Death.v8Death;
using OmopTransformer.COSD.Core.Death.v9DeathBasisOfDiagnosisCancer;
using OmopTransformer.COSD.Core.Death.v9DeathDischargeDestination;
using OmopTransformer.COSD.Core.DemographicsV8;
using OmopTransformer.COSD.Core.DemographicsV9;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNonPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementSynchronousTumourIndicator;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTNMcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTumourHeightAboveAnalVerge;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTumourLaterality;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNonPrimaryPathwayProgressionMetastasis;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasis;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementSynchronousTumourIndicator;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTNMcategoryIntegratedStage;
using OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTumourLaterality;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNonPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTNMcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTumourLaterality;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementGradeOfDifferentiation;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementMcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasis;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasis;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementPrimaryPathwayMetastasis;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTNMcategoryIntegratedStage;
using OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTumourLaterality;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8AdultComorbidityEvaluation;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8AdultPerformanceStatus;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerBeforeLastThreeMonths;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerInLastThreeMonths;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8FamilialCancerSyndromeIndicator;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8PersonStatedSexualOrientationCodeAtDiagnosis;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8SmokingStatusCode;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway;
using OmopTransformer.COSD.Colorectal.Observation.CosdV8SourceOfReferralOutPatients;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9AdultComorbidityEvaluation;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9AsaScore;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9FamilialCancerSyndrome;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9FamilialCancerSyndromeSubsidiaryComment;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9HistoryOfAlcoholCurrent;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9HistoryOfAlcoholPast;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9MenopausalStatus;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9PerformanceStatusAdult;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9PersonSexualOrientationCodeAtDiagnosis;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9SourceOfReferralForNonPrimaryCancerPathway;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9SourceOfReferralForOutpatients;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9TobaccoSmokingCessation;
using OmopTransformer.COSD.Colorectal.Observation.CosdV9TobaccoSmokingStatus;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungAdultComorbidityEvaluation;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungAdultPerformanceStatus;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungAlcoholHistoryCancerInLastThreeMonths;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungFamilialCancerSyndromeIndicator;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungSmokingStatusCode;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungSourceOfReferralOutPatients;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungAdultComorbidityEvaluation;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungAsaScore;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungFamilialCancerSyndrome;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungFamilialCancerSyndromeSubsidiaryComment;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungHistoryOfAlcoholCurrent;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungHistoryOfAlcoholPast;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungMenopausalStatus;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungPerformanceStatusAdult;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungSourceOfReferralForNonPrimaryCancerPathway;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungSourceOfReferralForOutpatients;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungTobaccoSmokingCessation;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungTobaccoSmokingStatus;
using OmopTransformer.COSD.Lung.Observation.CosdV8LungSurgicalAccessType;
using OmopTransformer.COSD.Lung.Observation.CosdV9LungSurgicalAccessType;
using OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV8ProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV8ProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV9ProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Colorectal.ProcedureOccurrence.CosdV9ProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrenceRelapseMethodOfDetection;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrencePrimaryProcedureOpcs;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrenceProcedureOpcs;
using OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrenceRelapseMethodOfDetection;
using OmopTransformer.Omop;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Death;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD;

internal class CosdTransformer : Transformer
{
    private readonly ILocationRecorder _locationRecorder;
    private readonly IPersonRecorder _personRecorder;
    private readonly IDeathRecorder _deathRecorder;
    private readonly IConditionOccurrenceRecorder _conditionOccurrenceRecorder;
    private readonly IProcedureOccurrenceRecorder _procedureOccurrenceRecorder;
    private readonly IObservationRecorder _observationRecorder;
    private readonly IMeasurementRecorder _measurementRecorder;

    public CosdTransformer(
        IRecordTransformer recordTransformer,
        TransformOptions transformOptions,
        IRecordProvider recordProvider,
        ILocationRecorder locationRecorder,
        IPersonRecorder personRecorder,
        IDeathRecorder deathRecorder,
        IConditionOccurrenceRecorder conditionOccurrenceRecorder,
        IProcedureOccurrenceRecorder procedureOccurrenceRecorder,
        IObservationRecorder observationRecorder,
        IMeasurementRecorder measurementRecorder,
        IRunAnalysisRecorder runAnalysisRecorder,
        ILoggerFactory loggerFactory)
        :
        base(
            recordTransformer,
            transformOptions,
            recordProvider,
            "COSD",
            runAnalysisRecorder,
            loggerFactory)
    {
        _locationRecorder = locationRecorder;
        _personRecorder = personRecorder;
        _deathRecorder = deathRecorder;
        _conditionOccurrenceRecorder = conditionOccurrenceRecorder;
        _procedureOccurrenceRecorder = procedureOccurrenceRecorder;
        _observationRecorder = observationRecorder;
        _measurementRecorder = measurementRecorder;
    }

    public async Task Transform(CancellationToken cancellationToken)
    {
        Guid runId = Guid.NewGuid();

        await Transform<CosdDemographicsV9, CosdPersonV9>(
            _personRecorder.InsertUpdatePersons,
            "COSD V9 Person",
            runId,
            cancellationToken);

        await Transform<CosdDemographicsV8, CosdPersonV8>(
            _personRecorder.InsertUpdatePersons,
            "COSD V8 Person",
            runId,
            cancellationToken);
        
        await Transform<CosdDemographicsV8, CosdV8Location>(
            _locationRecorder.InsertUpdateLocations,
            "COSD V8 Location",
            runId,
            cancellationToken);

        await Transform<CosdDemographicsV9, CosdLocationV9>(
            _locationRecorder.InsertUpdateLocations,
            "COSD V9 Location",
            runId,
            cancellationToken);

        await Transform<CosdV8DeathRecord, CosdV8Death>(
            _deathRecorder.InsertUpdateDeaths,
            "COSD V8 Death",
            runId,
            cancellationToken);

        await Transform<CosdV9DeathDischargeDestinationRecord, CosdDeathV9DeathDischargeDestination>(
            _deathRecorder.InsertUpdateDeaths,
            "COSD V9 DeathDischargeDestination Death",
            runId,
            cancellationToken);

        await Transform<CosdV9BasisOfDiagnosisCancerRecord, CosdV9DeathBasisOfDiagnosisCancer>(
            _deathRecorder.InsertUpdateDeaths,
            "COSD V9 BasisOfDiagnosisCancer Death",
            runId,
            cancellationToken);

        await Transform<CosdV9ConditionOccurrencePrimaryDiagnosisRecord, CosdConditionOccurrencePrimaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Condition Occurrence Primary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV9ConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord, CosdConditionOccurrencePrimaryDiagnosisHistologyTopography>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd Condition Occurrence Primary Diagnosis Histology Topography",
            runId,
            cancellationToken);

        await Transform<CosdV9ConditionOccurrenceProgressionRecord, CosdV9ConditionOccurrenceProgression>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Condition Occurrence Progression",
            runId,
            cancellationToken);

        await Transform<CosdV9ConditionOccurrenceRecurrenceRecord, CosdV9ConditionOccurrenceRecurrence>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Condition Occurrence Recurrence",
            runId,
            cancellationToken);

        await Transform<CosdV9ConditionOccurrenceSecondaryDiagnosisRecord, CosdV9ConditionOccurrenceSecondaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Condition Occurrence Secondary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8ConditionOccurrencePrimaryDiagnosisRecord, CosdV8ConditionOccurrencePrimaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Condition Occurrence Primary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord, CosdV8ConditionOccurrencePrimaryDiagnosisHistologyTopography>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastConditionOccurrencePrimaryDiagnosisRecord, CosdV8BreastConditionOccurrencePrimaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Breast Condition Occurrence Primary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord, CosdV8BreastConditionOccurrencePrimaryDiagnosisHistologyTopography>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastConditionOccurrenceProgressionRecord, CosdV8BreastConditionOccurrenceProgression>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Breast Condition Occurrence Progression",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastConditionOccurrencePrimaryDiagnosisRecord, CosdV9BreastConditionOccurrencePrimaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Breast Condition Occurrence Primary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord, CosdV9BreastConditionOccurrencePrimaryDiagnosisHistologyTopography>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Breast Condition Occurrence Primary Diagnosis Histology Topography",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastConditionOccurrenceSecondaryDiagnosisRecord, CosdV9BreastConditionOccurrenceSecondaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Breast Condition Occurrence Secondary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastConditionOccurrenceProgressionRecord, CosdV9BreastConditionOccurrenceProgression>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Breast Condition Occurrence Progression",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastConditionOccurrenceRecurrenceRecord, CosdV9BreastConditionOccurrenceRecurrence>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Breast Condition Occurrence Recurrence",
            runId,
            cancellationToken);

        await Transform<CosdV8LungConditionOccurrencePrimaryDiagnosisRecord, CosdV8LungConditionOccurrencePrimaryDiagnosis>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Lung Condition Occurrence Primary Diagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopographyRecord, CosdV8LungConditionOccurrencePrimaryDiagnosisHistologyTopography>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Lung Condition Occurrence Primary Diagnosis Histology Topography",
            runId,
            cancellationToken);

        await Transform<CosdV8LungConditionOccurrenceProgressionRecord, CosdV8LungConditionOccurrenceProgression>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V8 Lung Condition Occurrence Progression",
            runId,
            cancellationToken);

        await Transform<CosdV9LungConditionOccurrenceProgressionRecord, CosdV9LungConditionOccurrenceProgression>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Lung Condition Occurrence Progression",
            runId,
            cancellationToken);

        await Transform<CosdV9LungConditionOccurrenceRecurrenceRecord, CosdV9LungConditionOccurrenceRecurrence>(
            _conditionOccurrenceRecorder.InsertUpdateConditionOccurrence,
            "Cosd V9 Lung Condition Occurrence Recurrence",
            runId,
            cancellationToken);

        await Transform<CosdV8ProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV8ProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8ProcedureOccurrenceProcedureOpcsRecord, CosdV8ProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9ProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV9ProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9ProcedureOccurrenceProcedureOpcsRecord, CosdV9ProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV8BreastProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Breast Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastProcedureOccurrenceProcedureOpcsRecord, CosdV8BreastProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Breast Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV9BreastProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Breast Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastProcedureOccurrenceProcedureOpcsRecord, CosdV9BreastProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Breast Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8LungProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV8LungProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Lung Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8LungProcedureOccurrenceProcedureOpcsRecord, CosdV8LungProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Lung Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9LungProcedureOccurrencePrimaryProcedureOpcsRecord, CosdV9LungProcedureOccurrencePrimaryProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV9LungProcedureOccurrenceProcedureOpcsRecord, CosdV9LungProcedureOccurrenceProcedureOpcs>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Lung Procedure Occurrence Procedure Opcs",
            runId,
            cancellationToken);

        await Transform<CosdV8LungProcedureOccurrenceRelapseMethodOfDetectionRecord, CosdV8LungProcedureOccurrenceRelapseMethodOfDetection>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V8 Lung Procedure Occurrence Relapse Method Of Detection",
            runId,
            cancellationToken);

        await Transform<CosdV9LungProcedureOccurrenceRelapseMethodOfDetectionRecord, CosdV9LungProcedureOccurrenceRelapseMethodOfDetection>(
            _procedureOccurrenceRecorder.InsertUpdateProcedureOccurrence,
            "Cosd V9 Lung Procedure Occurrence Relapse Method Of Detection",
            runId,
            cancellationToken);

        await Transform<CosdV9TobaccoSmokingStatusRecord, CosdV9TobaccoSmokingStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9TobaccoSmokingStatus",
            runId,
            cancellationToken);

        await Transform<CosdV8SmokingStatusCodeRecord, CosdV8SmokingStatusCode>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8SmokingStatusCode",
            runId,
            cancellationToken);

        await Transform<CosdV9TobaccoSmokingCessationRecord, CosdV9TobaccoSmokingCessation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9TobaccoSmokingCessation",
            runId,
            cancellationToken);

        await Transform<CosdV9HistoryOfAlcoholCurrentRecord, CosdV9HistoryOfAlcoholCurrent>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9HistoryOfAlcoholCurrent",
            runId,
            cancellationToken);

        await Transform<CosdV8AlcoholHistoryCancerInLastThreeMonthsRecord, CosdV8AlcoholHistoryCancerInLastThreeMonths>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8AlcoholHistoryCancerInLastThreeMonths",
            runId,
            cancellationToken);

        await Transform<CosdV9HistoryOfAlcoholPastRecord, CosdV9HistoryOfAlcoholPast>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9HistoryOfAlcoholPast",
            runId,
            cancellationToken);

        await Transform<CosdV8AlcoholHistoryCancerBeforeLastThreeMonthsRecord, CosdV8AlcoholHistoryCancerBeforeLastThreeMonths>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8AlcoholHistoryCancerBeforeLastThreeMonths",
            runId,
            cancellationToken);

        await Transform<CosdV9MenopausalStatusRecord, CosdV9MenopausalStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9MenopausalStatus",
            runId,
            cancellationToken);

        await Transform<CosdV9PersonSexualOrientationCodeAtDiagnosisRecord, CosdV9PersonSexualOrientationCodeAtDiagnosis>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9PersonSexualOrientationCodeAtDiagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8PersonStatedSexualOrientationCodeAtDiagnosisRecord, CosdV8PersonStatedSexualOrientationCodeAtDiagnosis>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8PersonStatedSexualOrientationCodeAtDiagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV9SourceOfReferralForOutpatientsRecord, CosdV9SourceOfReferralForOutpatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9SourceOfReferralForOutpatients",
            runId,
            cancellationToken);

        await Transform<CosdV8SourceOfReferralOutPatientsRecord, CosdV8SourceOfReferralOutPatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8SourceOfReferralOutPatients",
            runId,
            cancellationToken);

        await Transform<CosdV9SourceOfReferralForNonPrimaryCancerPathwayRecord, CosdV9SourceOfReferralForNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9SourceOfReferralForNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord, CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV9PerformanceStatusAdultRecord, CosdV9PerformanceStatusAdult>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9PerformanceStatusAdult",
            runId,
            cancellationToken);

        await Transform<CosdV8AdultPerformanceStatusRecord, CosdV8AdultPerformanceStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8AdultPerformanceStatus",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastAdultComorbidityEvaluationRecord, CosdV8BreastAdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastAdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastFamilialCancerSyndromeIndicatorRecord, CosdV8BreastFamilialCancerSyndromeIndicator>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastFamilialCancerSyndromeIndicator",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosisRecord, CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosis>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastPersonStatedSexualOrientationCodeAtDiagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastSmokingStatusCodeRecord, CosdV8BreastSmokingStatusCode>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastSmokingStatusCode",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord, CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastSourceOfReferralForOutPatientsNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastSourceOfReferralOutPatientsRecord, CosdV8BreastSourceOfReferralOutPatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8BreastSourceOfReferralOutPatients",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastAdultComorbidityEvaluationRecord, CosdV9BreastAdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastAdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastAsaScoreRecord, CosdV9BreastAsaScore>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastAsaScore",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastFamilialCancerSyndromeRecord, CosdV9BreastFamilialCancerSyndrome>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastFamilialCancerSyndrome",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastFamilialCancerSyndromeSubsidiaryCommentRecord, CosdV9BreastFamilialCancerSyndromeSubsidiaryComment>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastFamilialCancerSyndromeSubsidiaryComment",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastHistoryOfAlcoholCurrentRecord, CosdV9BreastHistoryOfAlcoholCurrent>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastHistoryOfAlcoholCurrent",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastHistoryOfAlcoholPastRecord, CosdV9BreastHistoryOfAlcoholPast>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastHistoryOfAlcoholPast",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMenopausalStatusRecord, CosdV9BreastMenopausalStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastMenopausalStatus",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastPerformanceStatusAdultRecord, CosdV9BreastPerformanceStatusAdult>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastPerformanceStatusAdult",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastSourceOfReferralForNonPrimaryCancerPathwayRecord, CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastSourceOfReferralForOutpatientsRecord, CosdV9BreastSourceOfReferralForOutpatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9BreastSourceOfReferralForOutpatients",
            runId,
            cancellationToken);

        await Transform<CosdV8LungAdultComorbidityEvaluationRecord, CosdV8LungAdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungAdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV8LungAdultPerformanceStatusRecord, CosdV8LungAdultPerformanceStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungAdultPerformanceStatus",
            runId,
            cancellationToken);

        await Transform<CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonthsRecord, CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths",
            runId,
            cancellationToken);

        await Transform<CosdV8LungAlcoholHistoryCancerInLastThreeMonthsRecord, CosdV8LungAlcoholHistoryCancerInLastThreeMonths>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungAlcoholHistoryCancerInLastThreeMonths",
            runId,
            cancellationToken);

        await Transform<CosdV8LungFamilialCancerSyndromeIndicatorRecord, CosdV8LungFamilialCancerSyndromeIndicator>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungFamilialCancerSyndromeIndicator",
            runId,
            cancellationToken);

        await Transform<CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosisRecord, CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis",
            runId,
            cancellationToken);

        await Transform<CosdV8LungSmokingStatusCodeRecord, CosdV8LungSmokingStatusCode>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungSmokingStatusCode",
            runId,
            cancellationToken);

        await Transform<CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathwayRecord, CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV8LungSourceOfReferralOutPatientsRecord, CosdV8LungSourceOfReferralOutPatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8LungSourceOfReferralOutPatients",
            runId,
            cancellationToken);

        await Transform<CosdV9LungAdultComorbidityEvaluationRecord, CosdV9LungAdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungAdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV9LungAsaScoreRecord, CosdV9LungAsaScore>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungAsaScore",
            runId,
            cancellationToken);

        await Transform<CosdV9LungFamilialCancerSyndromeRecord, CosdV9LungFamilialCancerSyndrome>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungFamilialCancerSyndrome",
            runId,
            cancellationToken);

        await Transform<CosdV9LungFamilialCancerSyndromeSubsidiaryCommentRecord, CosdV9LungFamilialCancerSyndromeSubsidiaryComment>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungFamilialCancerSyndromeSubsidiaryComment",
            runId,
            cancellationToken);

        await Transform<CosdV9LungHistoryOfAlcoholCurrentRecord, CosdV9LungHistoryOfAlcoholCurrent>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungHistoryOfAlcoholCurrent",
            runId,
            cancellationToken);

        await Transform<CosdV9LungHistoryOfAlcoholPastRecord, CosdV9LungHistoryOfAlcoholPast>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungHistoryOfAlcoholPast",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMenopausalStatusRecord, CosdV9LungMenopausalStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungMenopausalStatus",
            runId,
            cancellationToken);

        await Transform<CosdV9LungPerformanceStatusAdultRecord, CosdV9LungPerformanceStatusAdult>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungPerformanceStatusAdult",
            runId,
            cancellationToken);

        await Transform<CosdV9LungSourceOfReferralForNonPrimaryCancerPathwayRecord, CosdV9LungSourceOfReferralForNonPrimaryCancerPathway>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungSourceOfReferralForNonPrimaryCancerPathway",
            runId,
            cancellationToken);

        await Transform<CosdV9LungSourceOfReferralForOutpatientsRecord, CosdV9LungSourceOfReferralForOutpatients>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungSourceOfReferralForOutpatients",
            runId,
            cancellationToken);

        await Transform<CosdV9LungTobaccoSmokingCessationRecord, CosdV9LungTobaccoSmokingCessation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungTobaccoSmokingCessation",
            runId,
            cancellationToken);

        await Transform<CosdV9LungTobaccoSmokingStatusRecord, CosdV9LungTobaccoSmokingStatus>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9LungTobaccoSmokingStatus",
            runId,
            cancellationToken);

        await Transform<CosdV8LungSurgicalAccessTypeRecord, CosdV8LungSurgicalAccessType>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd V8 Lung Surgical Access Type",
            runId,
            cancellationToken);

        await Transform<CosdV9LungSurgicalAccessTypeRecord, CosdV9LungSurgicalAccessType>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd V9 Lung Surgical Access Type",
            runId,
            cancellationToken);

        await Transform<CosdV9AdultComorbidityEvaluationRecord, CosdV9AdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9AdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV8AdultComorbidityEvaluationRecord, CosdV8AdultComorbidityEvaluation>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8AdultComorbidityEvaluation",
            runId,
            cancellationToken);

        await Transform<CosdV9AsaScoreRecord, CosdV9AsaScore>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9AsaScore",
            runId,
            cancellationToken);

        await Transform<CosdV9FamilialCancerSyndromeRecord, CosdV9FamilialCancerSyndrome>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9FamilialCancerSyndrome",
            runId,
            cancellationToken);

        await Transform<CosdV8FamilialCancerSyndromeIndicatorRecord, CosdV8FamilialCancerSyndromeIndicator>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV8FamilialCancerSyndromeIndicator",
            runId,
            cancellationToken);

        await Transform<CosdV9FamilialCancerSyndromeSubsidiaryCommentRecord, CosdV9FamilialCancerSyndromeSubsidiaryComment>(
            _observationRecorder.InsertUpdateObservations,
            "Cosd CosdV9FamilialCancerSyndromeSubsidiaryComment",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementGradeOfDifferentiationRecord, CosdV8MeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementMcategoryFinalPreTreatmentStageRecord, CosdV8MeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementMcategoryIntegratedStageRecord, CosdV8MeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementNcategoryFinalPreTreatmentStageRecord, CosdV8MeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementNcategoryIntegratedStageRecord, CosdV8MeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementNonPrimaryPathwayMetastasisRecord, CosdV8MeasurementNonPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementNonPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementPrimaryPathwayMetastasisRecord, CosdV8MeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementSynchronousTumourIndicatorRecord, CosdV8MeasurementSynchronousTumourIndicator>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementSynchronousTumourIndicator",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTcategoryFinalPreTreatmentStageRecord, CosdV8MeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTcategoryIntegratedStageRecord, CosdV8MeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV8MeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTNMcategoryIntegratedStageRecord, CosdV8MeasurementTNMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTNMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTumourHeightAboveAnalVergeRecord, CosdV8MeasurementTumourHeightAboveAnalVerge>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTumourHeightAboveAnalVerge",
            runId,
            cancellationToken);

        await Transform<CosdV8MeasurementTumourLateralityRecord, CosdV8MeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8MeasurementTumourLaterality",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementGradeOfDifferentiationRecord, CosdV9MeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementMcategoryFinalPreTreatmentStageRecord, CosdV9MeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementMcategoryIntegratedStageRecord, CosdV9MeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementNcategoryFinalPreTreatmentStageRecord, CosdV9MeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementNcategoryIntegratedStageRecord, CosdV9MeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementNonPrimaryPathwayProgressionMetastasisRecord, CosdV9MeasurementNonPrimaryPathwayProgressionMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementNonPrimaryPathwayProgressionMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasisRecord, CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementPrimaryPathwayMetastasisRecord, CosdV9MeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementSynchronousTumourIndicatorRecord, CosdV9MeasurementSynchronousTumourIndicator>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementSynchronousTumourIndicator",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementTcategoryFinalPreTreatmentStageRecord, CosdV9MeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementTcategoryIntegratedStageRecord, CosdV9MeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV9MeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementTNMcategoryIntegratedStageRecord, CosdV9MeasurementTNMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementTNMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9MeasurementTumourLateralityRecord, CosdV9MeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9MeasurementTumourLaterality",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementGradeOfDifferentiationRecord, CosdV8LungMeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementMcategoryFinalPreTreatmentStageRecord, CosdV8LungMeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementMcategoryIntegratedStageRecord, CosdV8LungMeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementNcategoryFinalPreTreatmentStageRecord, CosdV8LungMeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementNcategoryIntegratedStageRecord, CosdV8LungMeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementNonPrimaryPathwayMetastasisRecord, CosdV8LungMeasurementNonPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementNonPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementPrimaryPathwayMetastasisRecord, CosdV8LungMeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementTcategoryFinalPreTreatmentStageRecord, CosdV8LungMeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementTcategoryIntegratedStageRecord, CosdV8LungMeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementTNMcategoryIntegratedStageRecord, CosdV8LungMeasurementTNMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementTNMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8LungMeasurementTumourLateralityRecord, CosdV8LungMeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8LungMeasurementTumourLaterality",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementGradeOfDifferentiationRecord, CosdV9LungMeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementMcategoryFinalPreTreatmentStageRecord, CosdV9LungMeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementMcategoryIntegratedStageRecord, CosdV9LungMeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementNcategoryFinalPreTreatmentStageRecord, CosdV9LungMeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementNcategoryIntegratedStageRecord, CosdV9LungMeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasisRecord, CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasisRecord, CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementPrimaryPathwayMetastasisRecord, CosdV9LungMeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementTcategoryFinalPreTreatmentStageRecord, CosdV9LungMeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementTcategoryIntegratedStageRecord, CosdV9LungMeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementTNMcategoryIntegratedStageRecord, CosdV9LungMeasurementTNMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementTNMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9LungMeasurementTumourLateralityRecord, CosdV9LungMeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9LungMeasurementTumourLaterality",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementGradeOfDifferentiationRecord, CosdV8BreastMeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementMcategoryFinalPreTreatmentStageRecord, CosdV8BreastMeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementMcategoryIntegratedStageRecord, CosdV8BreastMeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementNcategoryFinalPreTreatmentStageRecord, CosdV8BreastMeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementNcategoryIntegratedStageRecord, CosdV8BreastMeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementNonPrimaryPathwayMetastasisRecord, CosdV8BreastMeasurementNonPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementNonPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementPrimaryPathwayMetastasisRecord, CosdV8BreastMeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementTcategoryFinalPreTreatmentStageRecord, CosdV8BreastMeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementTcategoryIntegratedStageRecord, CosdV8BreastMeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV8BreastMeasurementTumourLateralityRecord, CosdV8BreastMeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV8BreastMeasurementTumourLaterality",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementGradeOfDifferentiationRecord, CosdV9BreastMeasurementGradeOfDifferentiation>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementGradeOfDifferentiation",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementMcategoryFinalPreTreatmentStageRecord, CosdV9BreastMeasurementMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementMcategoryIntegratedStageRecord, CosdV9BreastMeasurementMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementNcategoryFinalPreTreatmentStageRecord, CosdV9BreastMeasurementNcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementNcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementNcategoryIntegratedStageRecord, CosdV9BreastMeasurementNcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementNcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasisRecord, CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasisRecord, CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementPrimaryPathwayMetastasisRecord, CosdV9BreastMeasurementPrimaryPathwayMetastasis>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementPrimaryPathwayMetastasis",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementTcategoryFinalPreTreatmentStageRecord, CosdV9BreastMeasurementTcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementTcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementTcategoryIntegratedStageRecord, CosdV9BreastMeasurementTcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementTcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStageRecord, CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementTNMcategoryIntegratedStageRecord, CosdV9BreastMeasurementTNMcategoryIntegratedStage>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementTNMcategoryIntegratedStage",
            runId,
            cancellationToken);

        await Transform<CosdV9BreastMeasurementTumourLateralityRecord, CosdV9BreastMeasurementTumourLaterality>(
            _measurementRecorder.InsertUpdateMeasurements,
            "CosdV9BreastMeasurementTumourLaterality",
            runId,
            cancellationToken);
    }
}