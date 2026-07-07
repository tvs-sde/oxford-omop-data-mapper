using System.Data;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.SUS.Staging.OP;

internal class SusOPInserter : ISusOPInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<SusOPInserter> _logger;
    private readonly IDataOptOut _dataOptOut;

    public SusOPInserter(IOptions<Configuration> configuration, ILogger<SusOPInserter> logger, IDataOptOut dataOptOut)
    {
        _logger = logger;
        _dataOptOut = dataOptOut;
        _configuration = configuration.Value;
    }

    public async Task Insert(IEnumerable<OPRecord> rows, CancellationToken cancellationToken)
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

    private void InsertBatch(IEnumerable<OPRecord> rows, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var rowsList = rows.ToList();

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting OPRow.");
        InsertOP(rowsList.Select(row => row.OPRow).ToList(), connection);
        
        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting OPRow ReadProcedure.");
        InsertReadProcedure(rowsList.SelectMany(row => row.OPReadProcedures).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting OPRow OpcdProcedure.");
        InsertOpcsProcedure(rowsList.SelectMany(row => row.OpcdProcedure).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting APCRow ReadDiagnoses.");
        InsertReadDiagnosis(rowsList.SelectMany(row => row.ReadDiagnoses).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _logger.LogInformation("Inserting OPRow IcdDiagnoses.");
        InsertIcdDiagnosis(rowsList.SelectMany(row => row.IcdDiagnoses).ToList(), connection);

        cancellationToken.ThrowIfCancellationRequested();

        _dataOptOut.PrintStats();
    }

    private void InsertOP(IReadOnlyCollection<OPRow> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OP");
        {
            foreach (var row in rows)
            {
                if (_dataOptOut.PatientAllowed(row.NHSNumber) == false)
                    continue;

                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.GeneratedRecordIdentifier)
                    .AppendValue(row.ReasonforAccess)
                    .AppendValue(row.CDStype)
                    .AppendValue(row.Protocolidentifier)
                    .AppendValue(row.UniqueCDSidentifier)
                    .AppendValue(row.SUSgeneratedspellID)
                    .AppendValue(row.Updatetype)
                    .AppendValue(row.BulkreplacementCDSgroup)
                    .AppendValue(row.Testindicator)
                    .AppendValue(row.Applicabledatetime)
                    .AppendValue(row.Censusdate)
                    .AppendValue(row.Extractdatetime)
                    .AppendValue(row.ReportperiodStartDate)
                    .AppendValue(row.ReportperiodEndDate)
                    .AppendValue(row.OrganisationcodeSenderoftransaction)
                    .AppendValue(row.OrganisationCodeTypeofSender)
                    .AppendValue(row.SubmissionDate)
                    .AppendValue(row.CDSInterchangeID)
                    .AppendValue(row.LocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeLocalPatientIdentifier)
                    .AppendValue(row.OrganisationCodeTypeLocalPatientIdentifier)
                    .AppendValue(row.NHSNumber)
                    .AppendValue(row.DateofBirth)
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
                    .AppendValue(row.ConsultantCode)
                    .AppendValue(row.MainSpecialtyCode)
                    .AppendValue(row.TreatmentFunctionCode)
                    .AppendValue(row.LocalSubSpecialtyCode)
                    .AppendValue(row.MultiProfessionalOrMultidisciplinaryIndCode)
                    .AppendValue(row.RehabilitationAssessmentTeamType)
                    .AppendValue(row.DiagnosisSchemeInUseICD)
                    .AppendValue(row.DiagnosisSchemeInUseRead)
                    .AppendValue(row.AttendanceIdentifier)
                    .AppendValue(row.AdministrativeCategory)
                    .AppendValue(row.AttendedorDidNotAttend)
                    .AppendValue(row.FirstAttendance)
                    .AppendValue(row.MedicalStaffTypeSeeingPatient)
                    .AppendValue(row.OperationStatusPerAttendance)
                    .AppendValue(row.OutcomeofAttendance)
                    .AppendValue(row.AppointmentDate)
                    .AppendValue(row.AppointmentTime)
                    .AppendValue(row.ExpectedDurationOfAppointment)
                    .AppendValue(row.ConsultationMediumUsed)
                    .AppendValue(row.WaitingTimeMeasurementType)
                    .AppendValue(row.ActivityLocationTypeCode)
                    .AppendValue(row.EarliestClinicallyAppropriateDate)
                    .AppendValue(row.ClinicCode)
                    .AppendValue(row.CommissioningSerialNumber)
                    .AppendValue(row.NHSServiceAgreementLineNumber)
                    .AppendValue(row.ProviderReferenceNumber)
                    .AppendValue(row.CommissionerReferenceNumber)
                    .AppendValue(row.OrganisationCodeCodeofProvider)
                    .AppendValue(row.OrganisationCodeTypeCodeofProvider)
                    .AppendValue(row.OrganisationCodeCodeofCommissioner)
                    .AppendValue(row.OrganisationCodeTypeCodeofCommissioner)
                    .AppendValue(row.ProcedureSchemeInUseOPCS)
                    .AppendValue(row.ProcedureSchemeInUseRead)
                    .AppendValue(row.LocationClassatAttendance)
                    .AppendValue(row.SiteCodeofTreatment)
                    .AppendValue(row.OrganisationCodeTypeSiteCodeofTreatmentAtAttendance)
                    .AppendValue(row.GeneralMedicalPractitionerCodeofRegisteredGMP)
                    .AppendValue(row.PracticeCodeofRegisteredGP)
                    .AppendValue(row.OrganisationCodeTypeofRegisteredGP)
                    .AppendValue(row.PriorityType)
                    .AppendValue(row.ServiceTypeRequested)
                    .AppendValue(row.SourceofReferralForOutpatients)
                    .AppendValue(row.ReferralRequestReceivedDate)
                    .AppendValue(row.DirectAccessReferralIndicator)
                    .AppendValue(row.ReferrerCode)
                    .AppendValue(row.ReferringOrganisationCode)
                    .AppendValue(row.OrganisationCodeTypeofReferrer)
                    .AppendValue(row.LastDNAOrPatientCancelledDate)
                    .AppendValue(row.HRGCode)
                    .AppendValue(row.HRGVersionNumber)
                    .AppendValue(row.ProcedureSchemeInUse)
                    .AppendValue(row.DominantGroupingVariableProcedure)
                    .AppendValue(row.CoreHRG)
                    .AppendValue(row.HRGVersionCalculated)
                    .AppendValue(row.SUSHRG)
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
                    .AppendValue(row.EarliestReasonableOfferedDate)
                    .AppendValue(row.LocationType)
                    .AppendValue(row.XMLVersion)
                    .AppendValue(row.ConfidentialityCategoryDerived)
                    .AppendValue(row.ReferralToTreatmentLengthDerived)
                    .AppendValue(row.AgerangepatientderivedfromDOB)
                    .AppendValue(row.Areacodederivedfrompostcode)
                    .AppendValue(row.AttenderTypeDerived)
                    .AppendValue(row.CDSGroup)
                    .AppendValue(row.FinishedIndicator)
                    .AppendValue(row.PCTDerivedfromGP)
                    .AppendValue(row.PCTTypeDerivedfromGP)
                    .AppendValue(row.GPPracticeDerived)
                    .AppendValue(row.PCTDerivedfromderivedGPPractice)
                    .AppendValue(row.SHAfromGPPractice)
                    .AppendValue(row.SHATypefromGPPractice)
                    .AppendValue(row.MonthofBirth)
                    .AppendValue(row.ElectoralWardfrompostcode)
                    .AppendValue(row.PCTfrompostcode)
                    .AppendValue(row.PCTTypefromPostcode)
                    .AppendValue(row.SHAfromPostcode)
                    .AppendValue(row.SHATypefromPostcode)
                    .AppendValue(row.AreacodefromProviderPostcode)
                    .AppendValue(row.AgeatEndofEpisode)
                    .AppendValue(row.AgeatStartofEpisode)
                    .AppendValue(row.YearofBirth)
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
                    .AppendValue(row.IsValidUBRN)
                    .AppendValue(row.UBRNOccurrenceCount)
                    .EndRow();
            }
        }
    }

    private void InsertIcdDiagnosis(IReadOnlyCollection<IcdDiagnosis> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OP_ICDDiagnosis");
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
        using var appender = connection.CreateAppender("omop_staging", "sus_OP_ReadDiagnosis");
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
    
    private void InsertOpcsProcedure(IReadOnlyCollection<SusOPOpcsProcedure> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OP_OPCSProcedure");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.ProcedureOPCS)
                    .AppendValue(row.MainOperatingHealthcareProfessionalCodeOpcs)
                    .AppendValue(row.ProfessionalRegistrationIssuerCodeOpcs)
                    .AppendValue(row.ResponsibleAnaesthetistCodeOpcs)
                    .AppendValue(row.ResponsibleAnaesthetistRegBodyOpcs)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryProcedure))
                    .EndRow();
            }
        }
    }

    private void InsertReadProcedure(IReadOnlyCollection<OPReadProcedure> rows, DuckDBConnection connection)
    {
        using var appender = connection.CreateAppender("omop_staging", "sus_OP_ReadProcedure");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(row.MessageId)
                    .AppendValue(row.ProcedureRead)
                    .AppendValue(Convert.ToInt32(row.IsPrimaryProcedure))
                    .EndRow();
            }
        }
    }
}