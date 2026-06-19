using System.Data;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmopTransformer.RTDS.Parser;

namespace OmopTransformer.RTDS.Staging;

internal class RtdsInserter : IRtdsInserter
{
    private readonly Configuration _configuration;
    private readonly ILogger<RtdsInserter> _logger;

    public RtdsInserter(IOptions<Configuration> configuration, ILogger<RtdsInserter> logger)
    {
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));
        
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration.Value;
    }
    
    public async Task Insert(RtdsRecords records, CancellationToken cancellationToken)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            _logger.LogInformation("Inserting {0} Rtds Demographics.", records.Demographics.Count);
            InsertRTDS_1_Demographics(records.Demographics, records.SourceFileName, connection, cancellationToken);

            _logger.LogInformation("Inserting {0} Rtds Attendances.", records.Attendances.Count);
            InsertRTDS_2a_Attendances(records.Attendances, records.SourceFileName, connection, cancellationToken);

            _logger.LogInformation("Inserting {0} Rtds Plans.", records.Plans.Count);
            InsertRTDS_2b_Plan(records.Plans, records.SourceFileName, connection, cancellationToken);

            _logger.LogInformation("Inserting {0} Rtds Prescriptions.", records.Prescriptions.Count);
            InsertRTDS_3_Prescription(records.Prescriptions, records.SourceFileName, connection, cancellationToken);

            _logger.LogInformation("Inserting {0} Rtds Exposures.", records.Exposures.Count);
            InsertRTDS_4_Exposures(records.Exposures, records.SourceFileName, connection, cancellationToken);

            _logger.LogInformation("Inserting {0} Rtds Diagnosis/Course.", records.Diagnoses_Courses.Count);
            InsertRTDS_5_Diagnosis_Course(records.Diagnoses_Courses, records.SourceFileName, connection, cancellationToken);

            if (records.PasData != null)
            {
                _logger.LogInformation("Inserting {0} Rtds PassData.", records.PasData.Count);
                InsertRTDS_PASDATA(records.PasData, records.SourceFileName, connection, cancellationToken);
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }
    
    private void InsertRTDS_1_Demographics(IReadOnlyCollection<Rtds1Demographics> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_1_Demographics");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.PatientId)
                    .AppendValue(row.PatientId2)
                    .AppendValue(row.UniversalPatientId)
                    .AppendValue(row.SSN)
                    .AppendValue(row.FirstName)
                    .AppendValue(row.LastName)
                    .AppendValue(row.DateOfBirth)
                    .AppendValue(row.Sex)
                    .AppendValue(row.DoctorId)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.Expression1)
                    .AppendValue(row.StartDateTime)
                    .AppendValue(row.CompletedDateTime)
                    .AppendValue(row.End_date)
                    .AppendValue(row.Start_date)
                    .EndRow();
            }
        }
    }

    private void InsertRTDS_2a_Attendances(IReadOnlyCollection<Rtds2AAttendances> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_2a_Attendances");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.ScheduledActivitySer)
                    .AppendValue(row.ScheduledStartTime)
                    .AppendValue(row.AttributeValue)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.ProcedureCode)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.ScheduledActivityCode)
                    .AppendValue(row.Description)
                    .AppendValue(row.ActualStartDateTime_s)
                    .AppendValue(row.ActualEndDateTime_s)
                    .AppendValue(row.Start_date)
                    .AppendValue(row.End_date)
                    .EndRow();
            }
        }
    }

    private void InsertRTDS_2b_Plan(IReadOnlyCollection<Rtds2BPlan> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_2b_Plan");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.ProcedureCode)
                    .AppendValue(row.AttributeValue)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.DueDateTime)
                    .AppendValue(row.NonScheduledActivityCode)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.NonScheduledActivitySer)
                    .AppendValue(row.ActivityName)
                    .AppendValue(row.Description)
                    .AppendValue(row.Start_date)
                    .AppendValue(row.End_date)
                    .AppendValue(row.ProcedureCodeSer)
                    .EndRow();
            }
        }
    }
    
    private void InsertRTDS_3_Prescription(IReadOnlyCollection<Rtds3Prescription> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_3_Prescription");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.TreatmentType)
                    .AppendValue(row.NoFields)
                    .AppendValue(row.PreDescribedDose)
                    .AppendValue(row.PlanSetupSer)
                    .AppendValue(row.StartDateTime)
                    .AppendValue(row.TotDeliveredActualDose)
                    .AppendValue(row.NoFracs)
                    .AppendValue(row.PlanNameUpper)
                    .AppendValue(row.Start_date)
                    .AppendValue(row.End_date)
                    .AppendValue(row.Expression1)
                    .EndRow();
            }
        }
    }

    private void InsertRTDS_4_Exposures(IReadOnlyCollection<Rtds4Exposures> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_4_Exposures");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.RadiationSer)
                    .AppendValue(row.NominalEnergy)
                    .AppendValue(row.RadiationType)
                    .AppendValue(row.PlanSetupSer)
                    .AppendValue(row.EventNumber)
                    .AppendValue(row.MachineId)
                    .AppendValue(row.PlanName)
                    .AppendValue(row.Start_date)
                    .AppendValue(row.End_date)
                    .AppendValue(row.TreatmentDateTime)
                    .AppendValue(row.storedprocedure_version)
                    .EndRow();
            }
        }
    }

    private void InsertRTDS_5_Diagnosis_Course(IReadOnlyCollection<Rtds5DiagnosisCourse> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_5_Diagnosis_Course");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.PatientSer)
                    .AppendValue(row.CourseSer)
                    .AppendValue(row.DateStamp)
                    .AppendValue(row.DiagnosisCode)
                    .AppendValue(row.DiagnosisTableName)
                    .AppendValue(row.DiagnosisType)
                    .AppendValue(row.End_date)
                    .AppendValue(row.Start_date)
                    .EndRow();
            }
        }
    }

    private void InsertRTDS_PASDATA(IReadOnlyCollection<RtdsPasData> rows, string sourceFileName, DuckDBConnection connection, CancellationToken cancellationToken)
    {
        using var appender = connection.CreateAppender("omop_staging", "RTDS_PASDATA");
        {
            foreach (var row in rows)
            {
                var dbRow = appender.CreateRow();

                dbRow
                    .AppendValue(sourceFileName)
                    .AppendValue(row.Expr1)
                    .AppendValue(row.Expr2)
                    .AppendValue(row.Expr3)
                    .AppendValue(row.Expr4)
                    .AppendValue(row.Expr5)
                    .AppendValue(row.Expr6)
                    .AppendValue(row.PatientID2)
                    .AppendValue(row.FirstOfNHSNUMBER)
                    .AppendValue(row.NHSNUMBERTRACESTATUS)
                    .AppendValue(row.Expr7)
                    .AppendValue(row.Expr8)
                    .AppendValue(row.FirstOfPOSTCODE)
                    .AppendValue(row.Expr9)
                    .AppendValue(row.BIRTHDATE)
                    .AppendValue(row.GENDER)
                    .AppendValue(row.Expr10)
                    .AppendValue(row.Expr11)
                    .AppendValue(row.Expr12)
                    .AppendValue(row.Expr13)
                    .AppendValue(row.Expr14)
                    .AppendValue(row.FirstOfGPNATIONALCODE)
                    .AppendValue(row.FirstOfPRACTICECODE)
                    .EndRow();
            }
        }

    }
}