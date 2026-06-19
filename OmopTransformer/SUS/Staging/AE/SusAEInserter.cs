using System.Data;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.SUS.Staging.AE;

internal class SusAEInserter : ISusAEInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<SusAEInserter> _logger;
    private readonly IDataOptOut _dataOptOut;

    public SusAEInserter(IOptions<Configuration> configuration, ILogger<SusAEInserter> logger, IDataOptOut dataOptOut)
    {
        _logger = logger;
        _dataOptOut = dataOptOut;
        _configuration = configuration.Value;
    }

    public async Task Insert(IEnumerable<AERecord> rows, CancellationToken cancellationToken)
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

    private void InsertBatch(IEnumerable<AERecord> rows, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var rowsList = rows.ToList();

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting AERow.");
        InsertAE(rowsList.Select(row => row.AERow).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting AERow Diagnosis.");
        InsertDiagnosis(rowsList.SelectMany(row => row.SusAEDiagnosis).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting AERow Investigation.");
        InsertInvestigation(rowsList.SelectMany(row => row.SusAEInvestigation).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting AERow Treatment."); 
        InsertTreatment(rowsList.SelectMany(row => row.SusAETreatment).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _dataOptOut.PrintStats();
    }

    private void InsertAE(IReadOnlyCollection<AERow> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_AE");
        {
            foreach (var row in rows)
            {
                if (_dataOptOut.PatientAllowed(row.NHSNumber) == false)
                    continue;

                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.GeneratedRecordIdentifier)
                    .AppendValue(row.ReasonForAccess)
                    .AppendValue(row.CDStype)
                    .AppendValue(row.ProtocolIdentifier)
                    .AppendValue(row.UniqueCDSidentifier)
                    .AppendValue(row.UpdateType)
                    .AppendValue(row.BulkreplacementCDSgroup)
                    .AppendValue(row.TestIndicator)
                    .AppendValue(row.ApplicableDatetime)
                    .AppendValue(row.CensusDate)
                    .AppendValue(row.ExtractDatetime)
                    .AppendValue(row.ReportPeriodStartDate)
                    .AppendValue(row.ReportPeriodEndDate)
                    .AppendValue(row.OrganisationCodeSenderOfTransaction)
                    .AppendValue(row.OrganisationCodeTypeofSender)
                    .AppendValue(row.CDSInterchangeID)
                    .AppendValue(row.LocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeLocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeTypeLocalPatientIdentifier)
                    .AppendValue(row.NHSNumber)
                    .AppendValue(row.DateOfBirth)
                    .AppendValue(row.CarerSupportIndicator)
                    .AppendValue(row.NHSNumberTraceStatus)
                    .AppendValue(row.WithheldIdentityReason)
                    .AppendValue(row.Sex)
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
                    .AppendValue(row.EthnicCategory)
                    .AppendValue(row.OSVClassificationatCDSActivityDate)
                    .AppendValue(row.GeneralMedicalPractitionerCodeofRegisteredGMP)
                    .AppendValue(row.PracticeCodeofRegisteredGP)
                    .AppendValue(row.OrganisationCodeTypeofRegisteredGP)
                    .AppendValue(row.AEAttendanceNumber)
                    .AppendValue(row.AEArrivalMode)
                    .AppendValue(row.AEAttendanceCategory)
                    .AppendValue(row.AEAttendanceDisposal)
                    .AppendValue(row.AEIncidentLocationType)
                    .AppendValue(row.AEPatientGroup)
                    .AppendValue(row.SourceofReferralForAE)
                    .AppendValue(row.ArrivalDate)
                    .AppendValue(row.ArrivalTime)
                    .AppendValue(row.AEAttendanceConclusionTime)
                    .AppendValue(row.AEAttendanceConclusionDate)
                    .AppendValue(row.AEDepartureTime)
                    .AppendValue(row.AEDepartureDate)
                    .AppendValue(row.AEInitialAssessmentTimefirstandunplannedfollowupattendancesonly)
                    .AppendValue(row.AEInitialAssessmentDate)
                    .AppendValue(row.AETimeSeenForTreatment)
                    .AppendValue(row.SiteCodeOfTreatment)
                    .AppendValue(row.WaitingTimeMeasurementType)
                    .AppendValue(row.AmbulanceIncidentNumber)
                    .AppendValue(row.OrganisationCodeConveyingAmbulanceTrust)
                    .AppendValue(row.CommissioningSerialNumber)
                    .AppendValue(row.NHSServiceAgreementLineNumber)
                    .AppendValue(row.ProviderReferenceNumber)
                    .AppendValue(row.CommissionerReferenceNumber)
                    .AppendValue(row.OrganisationCodeCodeOfProvider)
                    .AppendValue(row.OrganisationCodeTypeOfProvider)
                    .AppendValue(row.OrganisationCodeCodeOfCommissioner)
                    .AppendValue(row.OrganisationCodeTypeOfCommissioner)
                    .AppendValue(row.AEStaffMemberCode)
                    .AppendValue(row.DiagnosisSchemeInUse)
                    .AppendValue(row.InvestigationSchemeInUse)
                    .AppendValue(row.TreatmentSchemeInUse)
                    .AppendValue(row.HRGCode)
                    .AppendValue(row.HRGVersionNumber)
                    .AppendValue(row.ProcedureSchemeInUse)
                    .AppendValue(row.DominantGroupingVariableProcedure)
                    .AppendValue(row.FCEHRG)
                    .AppendValue(row.SpellCOREHRGVersionNo)
                    .AppendValue(row.PBRGeneratedCoreHRGforInformation)
                    .AppendValue(row.PBRGeneratedCoreHRGVersionforInformation)
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
                    .AppendValue(row.AEDepartmentType)
                    .AppendValue(row.XMLVersion)
                    .AppendValue(row.ConfidentialityCategoryDerived)
                    .AppendValue(row.ReferralToTreatmentLengthDerived)
                    .AppendValue(row.AEAssessmentWaitTime)
                    .AppendValue(row.AEConclusionWaitTime)
                    .AppendValue(row.AEDuration)
                    .AppendValue(row.AETreatmentWait)
                    .AppendValue(row.AgerangepatientderivedfromDOB)
                    .AppendValue(row.AreaCodeDerivedFromPostcode)
                    .AppendValue(row.CDSGroup)
                    .AppendValue(row.FinishedIndicator)
                    .AppendValue(row.PCTDerivedfromGP)
                    .AppendValue(row.PCTTypeDerivedfromGP)
                    .AppendValue(row.GPPracticeDerived)
                    .AppendValue(row.PCTDerivedfromderivedGPPractice)
                    .AppendValue(row.SHAfromGPPractice)
                    .AppendValue(row.SHATypefromGPPractice)
                    .AppendValue(row.MonthOfBirth)
                    .AppendValue(row.ElectoralWardFromPostcode)
                    .AppendValue(row.PCTfrompostcode)
                    .AppendValue(row.PCTTypefromPostcode)
                    .AppendValue(row.SHAfromPostcode)
                    .AppendValue(row.SHATypefromPostcode)
                    .AppendValue(row.AreaCodeFromProviderPostcode)
                    .AppendValue(row.AgeAtEndOfEpisode)
                    .AppendValue(row.AgeAtStartOfEpisode)
                    .AppendValue(row.YearOfBirth)
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

    private static void InsertDiagnosis(IReadOnlyCollection<SusAEDiagnosis> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_AE_diagnosis");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.AccidentAndEmergencyDiagnosis)
                    .EndRow();
            }
        }
    }

    private static void InsertInvestigation(IReadOnlyCollection<SusAEInvestigation> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_AE_investigation");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.AccidentAndEmergencyInvestigation)
                    .EndRow();
            }
        }
    }

    private static void InsertTreatment(IReadOnlyCollection<SusAETreatment> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_AE_treatment");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.AccidentAndEmergencyTreatment)
                    .EndRow();
            }
        }
    }
}