using System.Data;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.SUS.Staging.Inpatient.APC;

internal class SusApcInserter : ISusAPCInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<SusApcInserter> _logger;
    private readonly IDataOptOut _dataOptOut;

    public SusApcInserter(IOptions<Configuration> configuration, ILogger<SusApcInserter> logger, IDataOptOut dataOptOut)
    {
        _logger = logger;
        _dataOptOut = dataOptOut;
        _configuration = configuration.Value;
    }

    public async Task Insert(IEnumerable<APCRecord> rows, CancellationToken cancellationToken)
    {
        if (rows == null) throw new ArgumentNullException(nameof(rows));

        _logger.LogInformation("Recording SUS rows.");

        var batches = rows.Batch(_configuration.BatchSize!.Value);
        int batchNumber = 1;

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            foreach (var batch in batches)
            {
                _logger.LogInformation("Batch {0}.", batchNumber++);

                InsertBatch(batch, connection, cancellationToken);
            }
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }

    private void InsertBatch(IEnumerable<APCRecord> rows, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var rowsList = rows.ToList();

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC.");
        InsertAPC(rowsList.Select(row => row.ApcRow).ToList(), connection);
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC CriticalCareItems.");
        InsertCriticalCare(rowsList.SelectMany(row => row.CriticalCareItems).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC Births.");
        InsertBirth(rowsList.SelectMany(row => row.Births).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC APCReadProcedure.");
        InsertReadProcedure(rowsList.SelectMany(row => row.ReadProcedure).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC CriticalCaOpcdProcedurereItems.");
        InsertOpcsProcedure(rowsList.SelectMany(row => row.OpcdProcedure).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC CareLocations.");
        InsertCareLocation(rowsList.SelectMany(row => row.CareLocations).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC ReadDiagnoses.");
        InsertReadDiagnosis(rowsList.SelectMany(row => row.ReadDiagnoses).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC IcdDiagnoses.");
        InsertIcdDiagnosis(rowsList.SelectMany(row => row.IcdDiagnoses).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APC OverseasVisitors.");
        InsertOverseasVisitor(rowsList.SelectMany(row => row.OverseasVisitors).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _dataOptOut.PrintStats();
    }

    private void InsertAPC(IReadOnlyCollection<APCRow> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_APC");
        {
            foreach (var row in rows)
            {
                if (_dataOptOut.PatientAllowed(row.NHSNumber) == false)
                    continue;

                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.GeneratedRecordIdentifier)
                    .AppendValue(row.PBRSpellID)
                    .AppendValue(row.ReasonForAccess)
                    .AppendValue(row.CDSType)
                    .AppendValue(row.ProtocolIdentifier)
                    .AppendValue(row.UniqueCDSIdentifier)
                    .AppendValue(row.UpdateType)
                    .AppendValue(row.BulkReplacementCDSGroup)
                    .AppendValue(row.TestIndicator)
                    .AppendValue(row.ApplicableDatetime)
                    .AppendValue(row.CensusDate)
                    .AppendValue(row.ExtractDatetime)
                    .AppendValue(row.ReportPeriodStartDate)
                    .AppendValue(row.ReportPeriodEndDate)
                    .AppendValue(row.OrganisationCodeSenderOfTransaction)
                    .AppendValue(row.OrganisationCodeTypeofSender)
                    .AppendValue(row.SubmissionDate)
                    .AppendValue(row.CDSInterchangeID)
                    .AppendValue(row.LocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeLocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeTypeLocalPatientIdentifier)
                    .AppendValue(row.NHSNumber)
                    .AppendValue(row.DateofBirth)
                    .AppendValue(row.BirthWeight)
                    .AppendValue(row.LiveOrStillBirth)
                    .AppendValue(row.CarerSupportIndicator)
                    .AppendValue(row.LegalStatusClassificationOnAdmissionPsychiatricCensusOnly)
                    .AppendValue(row.EthnicGroup)
                    .AppendValue(row.MaritalStatusPsychiatricCensusOnly)
                    .AppendValue(row.NHSNumberTraceStatus)
                    .AppendValue(row.WithheldIdentityReason)
                    .AppendValue(row.Sex)
                    .AppendValue(row.PregnancyTotalPreviousPregnancies)
                    .AppendValue(row.NameFormatCode)
                    .AppendValue(row.PatientName)
                    .AppendValue(row.PersonTitle)
                    .AppendValue(row.PersonGivenName)
                    .AppendValue(row.PersonFamilyName)
                    .AppendValue(row.PersonNameSuffix)
                    .AppendValue(row.PersonInitials)
                    .AppendValue(row.AddressFormatCode)
                    .AppendValue(row.PatientUsualAddress)
                    .AppendValue(row.Postcode)
                    .AppendValue(row.OrganisationCodeResidenceResponsibility)
                    .AppendValue(row.PCTofResidence)
                    .AppendValue(row.OrganisationCodeTypePCTofResidence)
                    .AppendValue(row.OSVClassificationatCDSActivityDate)
                    .AppendValue(row.HospitalProviderSpellNumber)
                    .AppendValue(row.AdministrativeCategory)
                    .AppendValue(row.PatientClassification)
                    .AppendValue(row.AdmissionMethodHospitalProviderSpell)
                    .AppendValue(row.DischargeDestinationHospitalProviderSpell)
                    .AppendValue(row.DischargeMethodHospitalProviderSpell)
                    .AppendValue(row.SourceOfAdmissionHospitalProviderSpell)
                    .AppendValue(row.StartDateHospitalProviderSpell)
                    .AppendValue(row.StartTimeHospitalProviderSpell)
                    .AppendValue(row.DischargeDateFromHospitalProviderSpell)
                    .AppendValue(row.DischargeTimeHospitalProviderSpell)
                    .AppendValue(row.DischargeToHospitalAtHomeServiceIndicator)
                    .AppendValue(row.EpisodeNumber)
                    .AppendValue(row.FirstRegularDayNightAdmission)
                    .AppendValue(row.LastEpisodeInSpellIndicator)
                    .AppendValue(row.NeonatalLevelOfCare)
                    .AppendValue(row.OperationStatus)
                    .AppendValue(row.PsychiatricPatientStatus)
                    .AppendValue(row.StartDateConsultantEpisode)
                    .AppendValue(row.StartTimeEpisode)
                    .AppendValue(row.EndDateConsultantEpisode)
                    .AppendValue(row.EndTimeEpisode)
                    .AppendValue(row.LengthOfStayAdjustmentRehabilitation)
                    .AppendValue(row.LengthOfStayAdjustmentSpecialistPalliativeCare)
                    .AppendValue(row.CommissioningSerialNumber)
                    .AppendValue(row.NHSServiceAgreementLineNumber)
                    .AppendValue(row.ProviderReferenceNumber)
                    .AppendValue(row.CommissionerReferenceNumber)
                    .AppendValue(row.OrganisationCodeCodeOfProvider)
                    .AppendValue(row.OrganisationCodeTypeOfProvider)
                    .AppendValue(row.OrganisationCodeCodeOfCommissioner)
                    .AppendValue(row.OrganisationCodeTypeofCommissioner)
                    .AppendValue(row.ConsultantCode)
                    .AppendValue(row.MainSpecialtyCode)
                    .AppendValue(row.TreatmentFunctionCode)
                    .AppendValue(row.LocalSubSpecialtyCode)
                    .AppendValue(row.MultiProfessionalOrMultidisciplinaryIndCode)
                    .AppendValue(row.RehabilitationAssessmentTeamType)
                    .AppendValue(row.DiagnosisSchemeInUseICD)
                    .AppendValue(row.DiagnosisSchemeInUseRead)
                    .AppendValue(row.ProcedureSchemeInUseOPCS)
                    .AppendValue(row.ProcedureSchemeInUseREAD)
                    .AppendValue(row.WardCodeAtEpisodeStartDate)
                    .AppendValue(row.WardSecurityLevelAtEpisodeStartDate)
                    .AppendValue(row.LocationClassAtEpisodeStartDate)
                    .AppendValue(row.SiteCodeOfTreatmentAtEpisodeStartDate)
                    .AppendValue(row.OrganisationCodeTypeSiteCodeOfTreatmentAtStartOfEpisode)
                    .AppendValue(row.IntendedClinicalCareIntensityAtStartOfEpisode)
                    .AppendValue(row.AgeGroupIntendedAtStartOfEpisode)
                    .AppendValue(row.SexOfPatientsAtStartOfEpisode)
                    .AppendValue(row.WardDayPeriodAvailability)
                    .AppendValue(row.WardNightPeriodAvailability)
                    .AppendValue(row.WardCodeAtEpisodeEndDate)
                    .AppendValue(row.WardSecurityLevelAtEpisodeEndDate)
                    .AppendValue(row.LocationClassAtEpisodeEndDate)
                    .AppendValue(row.SiteCodeOfTreatmentAtEpisodeEndDate)
                    .AppendValue(row.OrganisationCodeTypeSiteCodeOfTreatmentAtEpisodeEndDate)
                    .AppendValue(row.IntendedClinicalCareIntensityAtEpisodeEndDate)
                    .AppendValue(row.AgeGroupIntendedAtEpisodeEndDate)
                    .AppendValue(row.SexOfPatientsAtEpisodeEndDate)
                    .AppendValue(row.WardDayPeriodAvailabilityAtEpisodeEndDate)
                    .AppendValue(row.WardNightPeriodAvailabilityAtEpisodeEndDate)
                    .AppendValue(row.GeneralMedicalPractitionerCodeofRegisteredGMP)
                    .AppendValue(row.PracticeCodeOfRegisteredGP)
                    .AppendValue(row.OrganisationCodeTypeofRegisteredGP)
                    .AppendValue(row.ReferrerCode)
                    .AppendValue(row.ReferringOrganisationCode)
                    .AppendValue(row.OrganisationCodeTypeofReferrer)
                    .AppendValue(row.DirectAccessReferralIndicator)
                    .AppendValue(row.AmbulanceIncidentNumber)
                    .AppendValue(row.OrganisationCodeConveyingAmbulanceTrust)
                    .AppendValue(row.DurationofElectiveWait)
                    .AppendValue(row.IntendedManagement)
                    .AppendValue(row.DecidedToAdmitDateForThisProvider)
                    .AppendValue(row.WaitingTimeMeasurementType)
                    .AppendValue(row.LocationTypeCodeAtStartOfEpisode)
                    .AppendValue(row.HRGCode)
                    .AppendValue(row.HRGVersionNumber)
                    .AppendValue(row.ProcedureSchemeInUse)
                    .AppendValue(row.DominantGroupingVariableProcedure)
                    .AppendValue(row.FCEHRG)
                    .AppendValue(row.EpisodeHRGVersionNumber)
                    .AppendValue(row.SpellCoreHRG)
                    .AppendValue(row.SpellHRGVersionNumber)
                    .AppendValue(row.NumberOfBabies)
                    .AppendValue(row.FirstAntenatalAssessmentDate)
                    .AppendValue(row.GMPCodeofGMPResponsibleforAntenatalCare)
                    .AppendValue(row.CodeofGPPracticeRegisteredGMPAntenatalCare)
                    .AppendValue(row.OrganisationCodeTypeGPPracticeRegisteredGMPAntenatalCare)
                    .AppendValue(row.LocationClassOfDeliveryPlaceIntended)
                    .AppendValue(row.LocationTypeofDeliveryPlaceIntended)
                    .AppendValue(row.DeliveryPlaceChangeReason)
                    .AppendValue(row.DeliveryPlaceTypeIntended)
                    .AppendValue(row.AnaestheticGivenDuringLabourDelivery)
                    .AppendValue(row.AnaestheticGivenPostDelivery)
                    .AppendValue(row.GestationLengthLabourOnset)
                    .AppendValue(row.LabourDeliveryOnsetMethod)
                    .AppendValue(row.DeliveryDate)
                    .AppendValue(row.GestationLengthAssessmentBaby)
                    .AppendValue(row.LocalPatientIdentifierMother)
                    .AppendValue(row.OrganisationCodeLocalPatientIdentifierMother)
                    .AppendValue(row.OrganisationCodeTypeMother)
                    .AppendValue(row.NHSNumberMother)
                    .AppendValue(row.NHSNumberStatusIndicatorMother)
                    .AppendValue(row.BirthDateMother)
                    .AppendValue(row.AddressFormatCodeMother)
                    .AppendValue(row.PatientUsualAddressMother)
                    .AppendValue(row.PostcodeOfUsualAddressMother)
                    .AppendValue(row.OrganisationCodePCTofResidenceMother)
                    .AppendValue(row.OrganisationCodeTypePCTofResidenceMother)
                    .AppendValue(row.UniqueBookingReferenceNumberConverted)
                    .AppendValue(row.PatientPathwayIdentifier)
                    .AppendValue(row.OrganisationCodePatientPathwayIdentifierIssuer)
                    .AppendValue(row.ReferralToTreatmentPeriodStatus)
                    .AppendValue(row.ReferralToTreatmentPeriodStartDate)
                    .AppendValue(row.ReferralToTreatmentPeriodEndDate)
                    .AppendValue(row.LeadCareActivityIndicator)
                    .AppendValue(row.AgeatCDSActivityDate)
                    .AppendValue(row.NHSServiceAgreementChangeDate)
                    .AppendValue(row.CDSActivityDate)
                    .AppendValue(row.AgeAsOnAdmission)
                    .AppendValue(row.AdminCategoryAtStart)
                    .AppendValue(row.HospitalProviderSpellDischargeReadyDate)
                    .AppendValue(row.LocationType)
                    .AppendValue(row.XMLVersion)
                    .AppendValue(row.ConfidentialityCategoryDerived)
                    .AppendValue(row.ReferralToTreatmentLengthDerived)
                    .AppendValue(row.AgeRangePatientdDerivedFromDOB)
                    .AppendValue(row.AgeRangeMotherDerivedFromDOB)
                    .AppendValue(row.AreaCodeDerivedFromPostcode)
                    .AppendValue(row.CDSGroup)
                    .AppendValue(row.FinishedIndicator)
                    .AppendValue(row.PCTDerivedfromGP)
                    .AppendValue(row.PCTTypeDerivedfromGP)
                    .AppendValue(row.GPPracticeDerived)
                    .AppendValue(row.GPPracticeMotherDerived)
                    .AppendValue(row.PCTDerivedfromderivedGPPractice)
                    .AppendValue(row.PCTMotherDerivedfromderivedGPPractice)
                    .AppendValue(row.SHAfromGPPractice)
                    .AppendValue(row.SHATypefromGPPractice)
                    .AppendValue(row.HospitalSpellDuration)
                    .AppendValue(row.MonthOfBirth)
                    .AppendValue(row.HomeBirthOrDelivery)
                    .AppendValue(row.ElectoralWardFromPostcode)
                    .AppendValue(row.PCTFromPostcode)
                    .AppendValue(row.PCTTypefromPostcode)
                    .AppendValue(row.SHAfromPostcode)
                    .AppendValue(row.SHATypefromPostcode)
                    .AppendValue(row.AreacodeFromProviderPostcode)
                    .AppendValue(row.AgeAtEndOfEpisode)
                    .AppendValue(row.AgeAtStartOfEpisode)
                    .AppendValue(row.YearOfBirth)
                    .AppendValue(row.YearOfBirthMother)
                    .AppendValue(row.MonthOfBirthMother)
                    .AppendValue(row.CensusArea)
                    .AppendValue(row.Country)
                    .AppendValue(row.CountyCode)
                    .AppendValue(row.CensusED)
                    .AppendValue(row.EDDistrictCode)
                    .AppendValue(row.ElectoralWardCode)
                    .AppendValue(row.GORCode)
                    .AppendValue(row.LocalUnitaryAuthority)
                    .AppendValue(row.OldSHACode)
                    .AppendValue(row.ElectoralArea)
                    .AppendValue(row.PrimeRecipient)
                    .AppendValue(row.CopyRecipients)
                    .EndRow();
            }
        }
    }

    private void InsertOverseasVisitor(IReadOnlyCollection<OverseasVisitor> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OverseasVisitor");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.OverseasVisitorStatusClassification)
                    .AppendValue(row.OverseasVisitorStatusStartDate)
                    .EndRow();
            }
        }
    }

    private void InsertIcdDiagnosis(IReadOnlyCollection<IcdDiagnosis> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_ICDDiagnosis");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.DiagnosisICD)
                    .AppendValue(row.PresentOnAdmissionIndicatorDiagnosis)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryDiagnosis))
                    .EndRow();
            }
        }
    }

    private void InsertReadDiagnosis(IReadOnlyCollection<ReadDiagnosis> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_ReadDiagnosis");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.DiagnosisRead)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryDiagnosis))
                    .EndRow();
            }
        }
    }

    private void InsertCareLocation(IReadOnlyCollection<APCCareLocation> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_CareLocation");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.WardCode)
                    .AppendValue(row.WardSecurityLevel)
                    .AppendValue(row.LocationClass)
                    .AppendValue(row.SiteCodeOfTreatment)
                    .AppendValue(row.OrganisationCodeTypeSiteCodeOfTreatment)
                    .AppendValue(row.IntendedClinicalCareIntensity)
                    .AppendValue(row.AgeGroupIntended)
                    .AppendValue(row.SexOfPatients)
                    .AppendValue(row.WardDayPeriodAvailability)
                    .AppendValue(row.WardNightPeriodAvailability)
                    .AppendValue(row.StartDate)
                    .AppendValue(row.StartTimeWardStay)
                    .AppendValue(row.EndDate)
                    .AppendValue(row.EndTimeWardStay) 
                    .EndRow();
            }
        }
    }

    private void InsertOpcsProcedure(IReadOnlyCollection<SusAPCOpcsProcedure> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OPCSProcedure");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.ProcedureOPCS)
                    .AppendValue(row.ProcedureDateOPCS)
                    .AppendValue(row.MainOperatingHealthcareProfessionalCodeOpcs)
                    .AppendValue(row.ProfessionalRegistrationIssuerCodeOpcs)
                    .AppendValue(row.ResponsibleAnaesthetistCodeOpcs)
                    .AppendValue(row.ResponsibleAnaesthetistRegBodyOpcs)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryProcedure)) 
                    .EndRow();
            }
        }
    }

    private void InsertReadProcedure(IReadOnlyCollection<APCReadProcedure> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_ReadProcedure");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.ProcedureRead)
                    .AppendValue(row.ProcedureDateRead)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryProcedure))
                    .EndRow();
            }
        }
    }

    private void InsertBirth(IReadOnlyCollection<APCBirth> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_Birth");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.BirthOrderBaby)
                    .AppendValue(row.DeliveryMethodBaby)
                    .AppendValue(row.GestationLengthAssessmentBaby)
                    .AppendValue(row.ResuscitationMethodBaby)
                    .AppendValue(row.StatusOfPersonConductingDeliveryBaby)
                    .AppendValue(row.LocalPatientIdentifierBaby)
                    .AppendValue(row.OrganisationCodeLocalPatientIDBaby)
                    .AppendValue(row.OrganisationCodeTypeLocalPatientIDBaby)
                    .AppendValue(row.NHSNumberBaby)
                    .AppendValue(row.NHSNumberStatusIndicatorBaby)
                    .AppendValue(row.BirthDateBabyBaby)
                    .AppendValue(row.BirthWeightBaby)
                    .AppendValue(row.LiveOrStillBirthBaby)
                    .AppendValue(row.SexBaby)
                    .AppendValue(row.BirthLocationType)
                    .AppendValue(row.LocationClassDeliveryPlaceActual)
                    .AppendValue(row.DeliveryPlaceTypeActual)
                    .EndRow();
            }
        }
    }

    private void InsertCriticalCare(IReadOnlyCollection<APCCriticalCare> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_CriticalCare");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.CriticalCareLocalIdentifier)
                    .AppendValue(row.CriticalCareStartDate)
                    .AppendValue(row.CriticalCareUnitFunction)
                    .AppendValue(row.AdvancedRespiratorySupportDays)
                    .AppendValue(row.BasicRespiratorySupportDays)
                    .AppendValue(row.AdvancedCardiovascularSupportDays)
                    .AppendValue(row.BasicCardiovascularSupportDays)
                    .AppendValue(row.RenalSupportDays)
                    .AppendValue(row.NeurologicalSupportDays)
                    .AppendValue(row.DermatologicalSupportDays)
                    .AppendValue(row.LiverSupportDays)
                    .AppendValue(row.CriticalCareLevel2Days)
                    .AppendValue(row.CriticalCareLevel3Days)
                    .AppendValue(row.CriticalCareDischargeDate)
                    .AppendValue(row.CriticalCareUnitBedConfiguration)
                    .AppendValue(row.CriticalCareAdmissionSource)
                    .AppendValue(row.CriticalCareSourceLocation)
                    .AppendValue(row.CriticalCareAdmissionType)
                    .AppendValue(row.GastroIntestinalSupportDays)
                    .AppendValue(row.OrganSupportMaximum)
                    .AppendValue(row.CriticalCareDischargeReadyDate)
                    .AppendValue(row.CriticalCareDischargeReadyTime)
                    .AppendValue(row.CriticalCareDischargeStatus)
                    .AppendValue(row.CriticalCareDischargeDestination)
                    .AppendValue(row.CriticalCareDischargeLocation)
                    .AppendValue(row.CriticalCareDischargeTime)
                    .AppendValue(row.CriticalCareActivityToEpisodeRelationshipDerived)
                    .AppendValue(row.CriticalCarePeriodSequenceNumber)
                    .AppendValue(row.CriticalCareStartTime)
                    .AppendValue(row.CriticalCarePeriodType)
                    .EndRow();
            }
        }
    }
}