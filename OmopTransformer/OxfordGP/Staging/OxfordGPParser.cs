using System.Globalization;
using CsvHelper;

namespace OmopTransformer.OxfordGP.Staging;

internal class OxfordGPParser : IOxfordGPParser
{
    public IEnumerable<GPAppointment> ReadAppointmentFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPAppointment
            {
                GPAppointmentsPrimaryKey = csv.GetField<string>("GP Appointments Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetField<string>("Patient Identifier").GetTrimmedValueOrNull(),
                AppointmentDate = csv.GetField<string>("Appointment Date").GetTrimmedValueOrNull(),
                AppointmentStatus = csv.GetField<string>("Appointment Status").GetTrimmedValueOrNull(),
                AppointmentBookedDate = csv.GetField<string>("Appointment Booked Date").GetTrimmedValueOrNull(),
                ClinicianCode = csv.GetField<string>("Clinician Code").GetTrimmedValueOrNull(),
                AppointmentCancelledDate = csv.GetField<string>("Appointment Cancelled Date").GetTrimmedValueOrNull(),
                OrganisationName = csv.GetField<string>("Organisation Name").GetTrimmedValueOrNull(),
                SourceName = csv.GetField<string>("Source Name").GetTrimmedValueOrNull(),
                StatusDescription = csv.GetField<string>("StatusDescription").GetTrimmedValueOrNull(),
                DNAFlag = csv.GetField<string>("DNAFlag").GetTrimmedValueOrNull(),
                OrganisationNationalCode = csv.GetField<string>("OrganisationNationalCode").GetTrimmedValueOrNull(),
                ClinicianType = csv.GetField<string>("ClinicianType").GetTrimmedValueOrNull(),
                OrganisationIdentifier = csv.GetField<string>("OrganisationIdentifier").GetTrimmedValueOrNull(),
                Location = csv.GetField<string>("Location").GetTrimmedValueOrNull(),
                LocationType = csv.GetField<string>("LocationType").GetTrimmedValueOrNull(),
                Type = csv.GetField<string>("Type").GetTrimmedValueOrNull(),
                Specialty = csv.GetField<string>("Specialty").GetTrimmedValueOrNull(),
                ClinicName = csv.GetField<string>("ClinicName").GetTrimmedValueOrNull(),
                BookingSource = csv.GetField<string>("BookingSource").GetTrimmedValueOrNull(),
                BookingMethod = csv.GetField<string>("BookingMethod").GetTrimmedValueOrNull(),
                PatientArrivedDateTime = csv.GetField<string>("PatientArrivedDateTime").GetTrimmedValueOrNull(),
                PatientSeenDateTime = csv.GetField<string>("PatientSeenDateTime").GetTrimmedValueOrNull(),
                DeliveryMethodText = csv.GetField<string>("DeliveryMethodText").GetTrimmedValueOrNull(),
                PlannedMinutesDuration = csv.GetField<string>("PlannedMinutesDuration").GetTrimmedValueOrNull(),
                ActualMinutesDuration = csv.GetField<string>("ActualMinutesDuration").GetTrimmedValueOrNull(),
                NationalSlotDesc = csv.GetField<string>("NationalSlotDesc").GetTrimmedValueOrNull(),
                NationalSlotName = csv.GetField<string>("NationalSlotName").GetTrimmedValueOrNull(),
                NationalContext = csv.GetField<string>("NationalContext").GetTrimmedValueOrNull(),
                NationalService = csv.GetField<string>("NationalService").GetTrimmedValueOrNull(),
                UrgentFlag = csv.GetField<string>("UrgentFlag").GetTrimmedValueOrNull(),
                FollowUp = csv.GetField<string>("FollowUp").GetTrimmedValueOrNull(),
                ExternalPatient = csv.GetField<string>("ExternalPatient").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationIdentifierSystem = csv.GetField<string>("ExternalPatientOrganisationIdentifierSystem").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationIdentifierValue = csv.GetField<string>("ExternalPatientOrganisationIdentifierValue").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationDisplay = csv.GetField<string>("ExternalPatientOrganisationDisplay").GetTrimmedValueOrNull(),
                CancellationReasonText = csv.GetField<string>("CancellationReasonText").GetTrimmedValueOrNull(),
                SessionIdentifierValue = csv.GetField<string>("Session Identifier Value").GetTrimmedValueOrNull(),
                ClinicianIdentifierValue = csv.GetField<string>("ClinicianIdentifierValue").GetTrimmedValueOrNull(),
                SlotEndDateTime = csv.GetField<string>("Slot EndDateTime").GetTrimmedValueOrNull()
            };
        }
    }

    public IEnumerable<GPMedication> ReadMedicationFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPMedication
            {
                GPMedicationsPrimaryKey = csv.GetField<string>("GP Medications Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetField<string>("Patient Identifier").GetTrimmedValueOrNull(),
                GeneralPracticeCode = csv.GetField<string>("General Practice Code").GetTrimmedValueOrNull(),
                RegisteredGP = csv.GetField<string>("Registered GP").GetTrimmedValueOrNull(),
                GPPracticeCode = csv.GetField<string>("GP Practice Code").GetTrimmedValueOrNull(),
                SuppliedCode = csv.GetField<string>("Supplied Code").GetTrimmedValueOrNull(),
                CodeSet = csv.GetField<string>("Code Set").GetTrimmedValueOrNull(),
                MedicationDescription = csv.GetField<string>("Medication Description").GetTrimmedValueOrNull(),
                Quantity = csv.GetField<string>("Quantity").GetTrimmedValueOrNull(),
                Dosage = csv.GetField<string>("Dosage").GetTrimmedValueOrNull(),
                LastIssueDate = csv.GetField<string>("Last Issue Date").GetTrimmedValueOrNull(),
                MixtureID = csv.GetField<string>("Mixture ID").GetTrimmedValueOrNull(),
                Constituent = csv.GetField<string>("Constituent").GetTrimmedValueOrNull(),
                Units = csv.GetField<string>("Units").GetTrimmedValueOrNull(),
                RepeatMedicationFlag = csv.GetField<string>("Repeat Medication Flag").GetTrimmedValueOrNull(),
                MedicationNo = csv.GetField<string>("Medication No").GetTrimmedValueOrNull(),
                MaxIssues = csv.GetField<string>("MaxIssues").GetTrimmedValueOrNull(),
                UpdateKey = csv.GetField<string>("Update Key").GetTrimmedValueOrNull(),
                UniqueKey = csv.GetField<string>("Unique Key").GetTrimmedValueOrNull(),
                AuthorisingUserDisplay = csv.GetField<string>("Authorising User Display").GetTrimmedValueOrNull(),
                CourseLengthPerIssue = csv.GetField<string>("CourseLengthPerIssue").GetTrimmedValueOrNull()
            };
        }
    }

    public IEnumerable<GPDemographic> ReadDemographicFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPDemographic
            {
                PatientIdentifier = csv.GetField<string>("Patient Identifier").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetField<string>("NHS Number").GetTrimmedValueOrNull(),
                Forename = csv.GetField<string>("Forename").GetTrimmedValueOrNull(),
                Surname = csv.GetField<string>("Surname").GetTrimmedValueOrNull(),
                DOB = csv.GetField<string>("DOB").GetTrimmedValueOrNull(),
                Postcode = csv.GetField<string>("Postcode").GetTrimmedValueOrNull(),
                DateofDeath = csv.GetField<string>("DateofDeath").GetTrimmedValueOrNull(),
            };
        }
    }

    public IEnumerable<GPEvent> ReadEventFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPEvent
            {
                GPEventsPrimaryKey = csv.GetField<string>("GP Events Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetField<string>("Patient Identifier").GetTrimmedValueOrNull(),
                GeneralPractitionerCode = csv.GetField<string>("General Practitioner Code").GetTrimmedValueOrNull(),
                RegisteredGP = csv.GetField<string>("Registered GP").GetTrimmedValueOrNull(),
                GPPracticeCode = csv.GetField<string>("GP Practice Code").GetTrimmedValueOrNull(),
                EventDate = csv.GetField<string>("Event Date").GetTrimmedValueOrNull(),
                SuppliedCode = csv.GetField<string>("Supplied Code").GetTrimmedValueOrNull(),
                CodeSet = csv.GetField<string>("Code Set").GetTrimmedValueOrNull(),
                EventDescription = csv.GetField<string>("Event Description").GetTrimmedValueOrNull(),
                Episodicity = csv.GetField<string>("Episodicity").GetTrimmedValueOrNull(),
                Units = csv.GetField<string>("Units").GetTrimmedValueOrNull(),
                Value = csv.GetField<string>("Value").GetTrimmedValueOrNull(),
                SensitivityDormant = csv.GetField<string>("SensitivityDormant").GetTrimmedValueOrNull(),
                EventNo = csv.GetField<string>("Event No").GetTrimmedValueOrNull(),
                AlternateReadEMISCode = csv.GetField<string>("Alternate Read/EMIS Code").GetTrimmedValueOrNull(),
                JournalUpdateFlag = csv.GetField<string>("Journal Update Flag").GetTrimmedValueOrNull(),
                UpdateKey = csv.GetField<string>("Update Key").GetTrimmedValueOrNull(),
                UniqueKey = csv.GetField<string>("Unique Key").GetTrimmedValueOrNull(),
            };
        }
    }
}