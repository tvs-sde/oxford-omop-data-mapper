namespace OmopTransformer.OxfordGP.Staging;

internal class OxfordGPParser : IOxfordGPParser
{
    public IEnumerable<GPAppointment> ReadAppointmentFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPAppointment
            {
                GPAppointmentsPrimaryKey = csv.GetString("GP Appointments Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetString("Patient Identifier").GetTrimmedValueOrNull(),
                AppointmentDate = csv.GetString("Appointment Date").GetTrimmedValueOrNull(),
                AppointmentStatus = csv.GetString("Appointment Status").GetTrimmedValueOrNull(),
                AppointmentBookedDate = csv.GetString("Appointment Booked Date").GetTrimmedValueOrNull(),
                ClinicianCode = csv.GetString("Clinician Code").GetTrimmedValueOrNull(),
                AppointmentCancelledDate = csv.GetString("Appointment Cancelled Date").GetTrimmedValueOrNull(),
                OrganisationName = csv.GetString("Organisation Name").GetTrimmedValueOrNull(),
                SourceName = csv.GetString("Source Name").GetTrimmedValueOrNull(),
                StatusDescription = csv.GetString("StatusDescription").GetTrimmedValueOrNull(),
                DNAFlag = csv.GetString("DNAFlag").GetTrimmedValueOrNull(),
                OrganisationNationalCode = csv.GetString("OrganisationNationalCode").GetTrimmedValueOrNull(),
                ClinicianType = csv.GetString("ClinicianType").GetTrimmedValueOrNull(),
                OrganisationIdentifier = csv.GetString("OrganisationIdentifier").GetTrimmedValueOrNull(),
                Location = csv.GetString("Location").GetTrimmedValueOrNull(),
                LocationType = csv.GetString("LocationType").GetTrimmedValueOrNull(),
                Type = csv.GetString("Type").GetTrimmedValueOrNull(),
                Specialty = csv.GetString("Specialty").GetTrimmedValueOrNull(),
                ClinicName = csv.GetString("ClinicName").GetTrimmedValueOrNull(),
                BookingSource = csv.GetString("BookingSource").GetTrimmedValueOrNull(),
                BookingMethod = csv.GetString("BookingMethod").GetTrimmedValueOrNull(),
                PatientArrivedDateTime = csv.GetString("PatientArrivedDateTime").GetTrimmedValueOrNull(),
                PatientSeenDateTime = csv.GetString("PatientSeenDateTime").GetTrimmedValueOrNull(),
                DeliveryMethodText = csv.GetString("DeliveryMethodText").GetTrimmedValueOrNull(),
                PlannedMinutesDuration = csv.GetString("PlannedMinutesDuration").GetTrimmedValueOrNull(),
                ActualMinutesDuration = csv.GetString("ActualMinutesDuration").GetTrimmedValueOrNull(),
                NationalSlotDesc = csv.GetString("NationalSlotDesc").GetTrimmedValueOrNull(),
                NationalSlotName = csv.GetString("NationalSlotName").GetTrimmedValueOrNull(),
                NationalContext = csv.GetString("NationalContext").GetTrimmedValueOrNull(),
                NationalService = csv.GetString("NationalService").GetTrimmedValueOrNull(),
                UrgentFlag = csv.GetString("UrgentFlag").GetTrimmedValueOrNull(),
                FollowUp = csv.GetString("FollowUp").GetTrimmedValueOrNull(),
                ExternalPatient = csv.GetString("ExternalPatient").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationIdentifierSystem = csv.GetString("ExternalPatientOrganisationIdentifierSystem").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationIdentifierValue = csv.GetString("ExternalPatientOrganisationIdentifierValue").GetTrimmedValueOrNull(),
                ExternalPatientOrganisationDisplay = csv.GetString("ExternalPatientOrganisationDisplay").GetTrimmedValueOrNull(),
                CancellationReasonText = csv.GetString("CancellationReasonText").GetTrimmedValueOrNull(),
                SessionIdentifierValue = csv.GetString("Session Identifier Value").GetTrimmedValueOrNull(),
                ClinicianIdentifierValue = csv.GetString("ClinicianIdentifierValue").GetTrimmedValueOrNull(),
                SlotEndDateTime = csv.GetString("Slot EndDateTime").GetTrimmedValueOrNull()
            };
        }
    }

    public IEnumerable<GPMedication> ReadMedicationFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPMedication
            {
                GPMedicationsPrimaryKey = csv.GetString("GP Medications Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetString("Patient Identifier").GetTrimmedValueOrNull(),
                GeneralPracticeCode = csv.GetString("General Practice Code").GetTrimmedValueOrNull(),
                RegisteredGP = csv.GetString("Registered GP").GetTrimmedValueOrNull(),
                GPPracticeCode = csv.GetString("GP Practice Code").GetTrimmedValueOrNull(),
                SuppliedCode = csv.GetString("Supplied Code").GetTrimmedValueOrNull(),
                CodeSet = csv.GetString("Code Set").GetTrimmedValueOrNull(),
                MedicationDescription = csv.GetString("Medication Description").GetTrimmedValueOrNull(),
                Quantity = csv.GetString("Quantity").GetTrimmedValueOrNull(),
                Dosage = csv.GetString("Dosage").GetTrimmedValueOrNull(),
                LastIssueDate = csv.GetString("Last Issue Date").GetTrimmedValueOrNull(),
                MixtureID = csv.GetString("Mixture ID").GetTrimmedValueOrNull(),
                Constituent = csv.GetString("Constituent").GetTrimmedValueOrNull(),
                Units = csv.GetString("Units").GetTrimmedValueOrNull(),
                RepeatMedicationFlag = csv.GetString("Repeat Medication Flag").GetTrimmedValueOrNull(),
                MedicationNo = csv.GetString("Medication No").GetTrimmedValueOrNull(),
                MaxIssues = csv.GetString("MaxIssues").GetTrimmedValueOrNull(),
                UpdateKey = csv.GetString("Update Key").GetTrimmedValueOrNull(),
                UniqueKey = csv.GetString("Unique Key").GetTrimmedValueOrNull(),
                AuthorisingUserDisplay = csv.GetString("Authorising User Display").GetTrimmedValueOrNull(),
                CourseLengthPerIssue = csv.GetString("CourseLengthPerIssue").GetTrimmedValueOrNull()
            };
        }
    }

    public IEnumerable<GPDemographic> ReadDemographicFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPDemographic
            {
                PatientIdentifier = csv.GetString("Patient Identifier").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetString("NHS Number").GetTrimmedValueOrNull(),
                Forename = csv.GetString("Forename").GetTrimmedValueOrNull(),
                Surname = csv.GetString("Surname").GetTrimmedValueOrNull(),
                DOB = csv.GetString("DOB").GetTrimmedValueOrNull(),
                Postcode = csv.GetString("Postcode").GetTrimmedValueOrNull(),
                DateofDeath = csv.GetString("DateofDeath").GetTrimmedValueOrNull(),
            };
        }
    }

    public IEnumerable<GPEvent> ReadEventFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            yield return new GPEvent
            {
                GPEventsPrimaryKey = csv.GetString("GP Events Primary Key").GetTrimmedValueOrNull(),
                PatientIdentifier = csv.GetString("Patient Identifier").GetTrimmedValueOrNull(),
                GeneralPractitionerCode = csv.GetString("General Practitioner Code").GetTrimmedValueOrNull(),
                RegisteredGP = csv.GetString("Registered GP").GetTrimmedValueOrNull(),
                GPPracticeCode = csv.GetString("GP Practice Code").GetTrimmedValueOrNull(),
                EventDate = csv.GetString("Event Date").GetTrimmedValueOrNull(),
                SuppliedCode = csv.GetString("Supplied Code").GetTrimmedValueOrNull(),
                CodeSet = csv.GetString("Code Set").GetTrimmedValueOrNull(),
                EventDescription = csv.GetString("Event Description").GetTrimmedValueOrNull(),
                Episodicity = csv.GetString("Episodicity").GetTrimmedValueOrNull(),
                Units = csv.GetString("Units").GetTrimmedValueOrNull(),
                Value = csv.GetString("Value").GetTrimmedValueOrNull(),
                SensitivityDormant = csv.GetString("SensitivityDormant").GetTrimmedValueOrNull(),
                EventNo = csv.GetString("Event No").GetTrimmedValueOrNull(),
                AlternateReadEMISCode = csv.GetString("Alternate Read/EMIS Code").GetTrimmedValueOrNull(),
                JournalUpdateFlag = csv.GetString("Journal Update Flag").GetTrimmedValueOrNull(),
                UpdateKey = csv.GetString("Update Key").GetTrimmedValueOrNull(),
                UniqueKey = csv.GetString("Unique Key").GetTrimmedValueOrNull(),
            };
        }
    }
}