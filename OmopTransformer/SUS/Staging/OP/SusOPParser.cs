namespace OmopTransformer.SUS.Staging.OP;

internal class SusOPParser : ISusOPParser
{
    public IEnumerable<OPRecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var icdDiagnoses = new List<IcdDiagnosis>();
            var readDiagnoses = new List<ReadDiagnosis>();
            var opcdProcedure = new List<SusOPOpcsProcedure>();
            var readProcedure = new List<OPReadProcedure>();

            Guid messageId = Guid.NewGuid();

            var record = new OPRow
            {
                MessageId = messageId,
                GeneratedRecordIdentifier = csv.GetString("Generated Record Identifier").GetTrimmedValueOrNull(),
                ReasonforAccess = csv.GetString("Reason for Access").GetTrimmedValueOrNull(),
                CDStype = csv.GetString("CDS type").GetTrimmedValueOrNull(),
                Protocolidentifier = csv.GetString("Protocol identifier").GetTrimmedValueOrNull(),
                UniqueCDSidentifier = csv.GetString("Unique CDS identifier").GetTrimmedValueOrNull(),
                SUSgeneratedspellID = csv.GetString("SUS generated spell ID").GetTrimmedValueOrNull(),
                Updatetype = csv.GetString("Update type").GetTrimmedValueOrNull(),
                BulkreplacementCDSgroup = csv.GetString("Bulk replacement CDS group").GetTrimmedValueOrNull(),
                Testindicator = csv.GetString("Test indicator").GetTrimmedValueOrNull(),
                Applicabledatetime = csv.GetString("Applicable date/time").GetTrimmedValueOrNull(),
                Censusdate = csv.GetString("Census date").GetTrimmedValueOrNull(),
                Extractdatetime = csv.GetString("Extract date/time").GetTrimmedValueOrNull(),
                ReportperiodStartDate = csv.GetString("Report period Start Date").GetTrimmedValueOrNull(),
                ReportperiodEndDate = csv.GetString("Report period End Date").GetTrimmedValueOrNull(),
                OrganisationcodeSenderoftransaction = csv.GetString("Organisation code: Sender of transaction").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofSender = csv.GetString("Organisation Code Type of Sender").GetTrimmedValueOrNull(),
                SubmissionDate = csv.GetString("Submission Date").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetString("CDS Interchange ID").GetTrimmedValueOrNull(),
                LocalPatientIdentifier = csv.GetString("Local Patient Identifier").GetTrimmedValueOrNull(),
                OrganisationCodeLocalPatientIdentifier = csv.GetString("Organisation Code (Local Patient Identifier)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeLocalPatientIdentifier = csv.GetString("Organisation Code Type (Local Patient Identifier)").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetString("NHS Number").GetTrimmedValueOrNull(),
                DateofBirth = csv.GetString("Date of Birth").GetTrimmedValueOrNull(),
                CarerSupportIndicator = csv.GetString("Carer Support Indicator").GetTrimmedValueOrNull(),
                NHSNumberTraceStatus = csv.GetString("NHS Number Trace Status").GetTrimmedValueOrNull(),
                WithheldIdentityReason = csv.GetString("Withheld Identity Reason").GetTrimmedValueOrNull(),
                Sex = csv.GetString("Sex").GetTrimmedValueOrNull(),
                NameFormatCode = csv.GetString("Name Format Code").GetTrimmedValueOrNull(),
                PatientName = csv.GetString("Patient Name").GetTrimmedValueOrNull(),
                PersonTitle = csv.GetString("Person Title").GetTrimmedValueOrNull(),
                PersonGivenName = csv.GetString("Person Given Name").GetTrimmedValueOrNull(),
                PersonFamilyName = csv.GetString("Person Family Name").GetTrimmedValueOrNull(),
                PersonNameSuffix = csv.GetString("Person Name Suffix").GetTrimmedValueOrNull(),
                PersonInitials = csv.GetString("Person Initials").GetTrimmedValueOrNull(),
                AddressFormatCode = csv.GetString("Address Format Code").GetTrimmedValueOrNull(),
                PatientUsualAddress = csv.GetString("Patient Usual Address").GetTrimmedValueOrNull(),
                Postcode = csv.GetString("Postcode").GetTrimmedValueOrNull(),
                OrganisationCodeResidenceResponsibility = csv.GetString("Organisation Code (Residence Responsibility)").GetTrimmedValueOrNull(),
                PCTofResidence = csv.GetString("PCT of Residence").GetTrimmedValueOrNull(),
                OrganisationCodeTypePCTofResidence = csv.GetString("Organisation Code Type (PCT of Residence)").GetTrimmedValueOrNull(),
                EthnicCategory = csv.GetString("Ethnic Category").GetTrimmedValueOrNull(),
                OSVClassificationatCDSActivityDate = csv.GetString("OSV Classification at CDS Activity Date").GetTrimmedValueOrNull(),
                ConsultantCode = csv.GetString("Consultant Code").GetTrimmedValueOrNull(),
                MainSpecialtyCode = csv.GetString("Main Specialty Code").GetTrimmedValueOrNull(),
                TreatmentFunctionCode = csv.GetString("Treatment Function Code").GetTrimmedValueOrNull(),
                LocalSubSpecialtyCode = csv.GetString("Local Sub Specialty Code").GetTrimmedValueOrNull(),
                MultiProfessionalOrMultidisciplinaryIndCode = csv.GetString("Multi-Professional Or Multidisciplinary Ind Code").GetTrimmedValueOrNull(),
                RehabilitationAssessmentTeamType = csv.GetString("Rehabilitation Assessment Team Type").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUseICD = csv.GetString("Diagnosis Scheme In Use (ICD)").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUseRead = csv.GetString("Diagnosis Scheme In Use (Read)").GetTrimmedValueOrNull(),
                AttendanceIdentifier = csv.GetString("Attendance Identifier").GetTrimmedValueOrNull(),
                AdministrativeCategory = csv.GetString("Administrative Category").GetTrimmedValueOrNull(),
                AttendedorDidNotAttend = csv.GetString("Attended or Did Not Attend").GetTrimmedValueOrNull(),
                FirstAttendance = csv.GetString("First Attendance").GetTrimmedValueOrNull(),
                MedicalStaffTypeSeeingPatient = csv.GetString("Medical Staff Type Seeing Patient").GetTrimmedValueOrNull(),
                OperationStatusPerAttendance = csv.GetString("Operation Status (Per Attendance)").GetTrimmedValueOrNull(),
                OutcomeofAttendance = csv.GetString("Outcome of Attendance").GetTrimmedValueOrNull(),
                AppointmentDate = csv.GetString("Appointment Date").GetTrimmedValueOrNull(),
                AppointmentTime = csv.GetString("Appointment Time").GetTrimmedValueOrNull(),
                ExpectedDurationOfAppointment = csv.GetString("Expected Duration Of Appointment").GetTrimmedValueOrNull(),
                ConsultationMediumUsed = csv.GetString("Consultation Medium Used").GetTrimmedValueOrNull(),
                WaitingTimeMeasurementType = csv.GetString("Waiting Time Measurement Type").GetTrimmedValueOrNull(),
                ActivityLocationTypeCode = csv.GetString("Activity Location Type Code").GetTrimmedValueOrNull(),
                EarliestClinicallyAppropriateDate = csv.GetString("Earliest Clinically Appropriate Date").GetTrimmedValueOrNull(),
                ClinicCode = csv.GetString("Clinic Code").GetTrimmedValueOrNull(),
                CommissioningSerialNumber = csv.GetString("Commissioning Serial Number").GetTrimmedValueOrNull(),
                NHSServiceAgreementLineNumber = csv.GetString("NHS Service Agreement Line Number").GetTrimmedValueOrNull(),
                ProviderReferenceNumber = csv.GetString("Provider Reference Number").GetTrimmedValueOrNull(),
                CommissionerReferenceNumber = csv.GetString("Commissioner Reference Number").GetTrimmedValueOrNull(),
                OrganisationCodeCodeofProvider = csv.GetString("Organisation Code (Code of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeCodeofProvider = csv.GetString("Organisation Code Type (Code of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeCodeofCommissioner = csv.GetString("Organisation Code (Code of Commissioner)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeCodeofCommissioner = csv.GetString("Organisation Code Type (Code of Commissioner)").GetTrimmedValueOrNull(),
                ProcedureSchemeInUseOPCS = csv.GetString("Procedure Scheme In Use (OPCS)").GetTrimmedValueOrNull(),
                ProcedureSchemeInUseRead = csv.GetString("Procedure Scheme In Use (Read)").GetTrimmedValueOrNull(),
                LocationClassatAttendance = csv.GetString("Location Class at Attendance").GetTrimmedValueOrNull(),
                SiteCodeofTreatment = csv.GetString("Site Code (of Treatment)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeSiteCodeofTreatmentAtAttendance = csv.GetString("Organisation Code Type (Site Code of Treatment) (At Attendance)").GetTrimmedValueOrNull(),
                GeneralMedicalPractitionerCodeofRegisteredGMP = csv.GetString("General Medical Practitioner Code of Registered GMP").GetTrimmedValueOrNull(),
                PracticeCodeofRegisteredGP = csv.GetString("Practice Code of Registered GP").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofRegisteredGP = csv.GetString("Organisation Code Type of Registered GP").GetTrimmedValueOrNull(),
                PriorityType = csv.GetString("Priority Type").GetTrimmedValueOrNull(),
                ServiceTypeRequested = csv.GetString("Service Type Requested").GetTrimmedValueOrNull(),
                SourceofReferralForOutpatients = csv.GetString("Source of Referral For Outpatients").GetTrimmedValueOrNull(),
                ReferralRequestReceivedDate = csv.GetString("Referral Request Received Date").GetTrimmedValueOrNull(),
                DirectAccessReferralIndicator = csv.GetString("Direct Access Referral Indicator").GetTrimmedValueOrNull(),
                ReferrerCode = csv.GetString("Referrer Code").GetTrimmedValueOrNull(),
                ReferringOrganisationCode = csv.GetString("Referring Organisation Code").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofReferrer = csv.GetString("Organisation Code Type of Referrer").GetTrimmedValueOrNull(),
                LastDNAOrPatientCancelledDate = csv.GetString("Last DNA Or Patient Cancelled Date").GetTrimmedValueOrNull(),
                HRGCode = csv.GetString("HRG Code").GetTrimmedValueOrNull(),
                HRGVersionNumber = csv.GetString("HRG Version Number").GetTrimmedValueOrNull(),
                ProcedureSchemeInUse = csv.GetString("Procedure Scheme In Use").GetTrimmedValueOrNull(),
                DominantGroupingVariableProcedure = csv.GetString("Dominant Grouping Variable - Procedure").GetTrimmedValueOrNull(),
                CoreHRG = csv.GetString("Core HRG").GetTrimmedValueOrNull(),
                HRGVersionCalculated = csv.GetString("HRG Version (Calculated)").GetTrimmedValueOrNull(),
                SUSHRG = csv.GetString("SUS HRG").GetTrimmedValueOrNull(),
                UniqueBookingReferenceNumberConverted = csv.GetString("Unique Booking Reference Number Converted").GetTrimmedValueOrNull(),
                PatientPathwayIdentifier = csv.GetString("Patient Pathway Identifier").GetTrimmedValueOrNull(),
                OrganisationCodePatientPathwayIdentifierIssuer = csv.GetString("Organisation Code Patient Pathway Identifier Issuer").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodStatus = csv.GetString("Referral To Treatment Period Status").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodStartDate = csv.GetString("Referral To Treatment Period Start Date").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodEndDate = csv.GetString("Referral To Treatment Period End Date").GetTrimmedValueOrNull(),
                LeadCareActivityIndicator = csv.GetString("Lead Care Activity Indicator").GetTrimmedValueOrNull(),
                AgeatCDSActivityDate = csv.GetString("Age at CDS Activity Date").GetTrimmedValueOrNull(),
                NHSServiceAgreementChangeDate = csv.GetString("NHS Service Agreement Change Date").GetTrimmedValueOrNull(),
                CDSActivityDate = csv.GetString("CDS Activity Date").GetTrimmedValueOrNull(),
                EarliestReasonableOfferedDate = csv.GetString("Earliest Reasonable Offered Date").GetTrimmedValueOrNull(),
                LocationType = csv.GetString("Location Type").GetTrimmedValueOrNull(),
                XMLVersion = csv.GetString("XML Version").GetTrimmedValueOrNull(),
                ConfidentialityCategoryDerived = csv.GetString("Confidentiality Category (Derived)").GetTrimmedValueOrNull(),
                ReferralToTreatmentLengthDerived = csv.GetString("Referral To Treatment Length (Derived)").GetTrimmedValueOrNull(),
                AgerangepatientderivedfromDOB = csv.GetString("Age range patient derived from DOB").GetTrimmedValueOrNull(),
                Areacodederivedfrompostcode = csv.GetString("Area code derived from postcode").GetTrimmedValueOrNull(),
                AttenderTypeDerived = csv.GetString("Attender Type (Derived)").GetTrimmedValueOrNull(),
                CDSGroup = csv.GetString("CDS Group").GetTrimmedValueOrNull(),
                FinishedIndicator = csv.GetString("Finished Indicator").GetTrimmedValueOrNull(),
                PCTDerivedfromGP = csv.GetString("PCT (Derived from GP)").GetTrimmedValueOrNull(),
                PCTTypeDerivedfromGP = csv.GetString("PCT Type (Derived from GP)").GetTrimmedValueOrNull(),
                GPPracticeDerived = csv.GetString("GP Practice (Derived)").GetTrimmedValueOrNull(),
                PCTDerivedfromderivedGPPractice = csv.GetString("PCT (Derived from derived GP Practice)").GetTrimmedValueOrNull(),
                SHAfromGPPractice = csv.GetString("SHA from GP Practice").GetTrimmedValueOrNull(),
                SHATypefromGPPractice = csv.GetString("SHA Type from GP Practice").GetTrimmedValueOrNull(),
                MonthofBirth = csv.GetString("Month of Birth").GetTrimmedValueOrNull(),
                ElectoralWardfrompostcode = csv.GetString("Electoral Ward from postcode").GetTrimmedValueOrNull(),
                PCTfrompostcode = csv.GetString("PCT from postcode").GetTrimmedValueOrNull(),
                PCTTypefromPostcode = csv.GetString("PCT Type from Postcode").GetTrimmedValueOrNull(),
                SHAfromPostcode = csv.GetString("SHA from Postcode").GetTrimmedValueOrNull(),
                SHATypefromPostcode = csv.GetString("SHA Type from Postcode").GetTrimmedValueOrNull(),
                AreacodefromProviderPostcode = csv.GetString("Area code from Provider Postcode").GetTrimmedValueOrNull(),
                AgeatEndofEpisode = csv.GetString("Age at End of Episode").GetTrimmedValueOrNull(),
                AgeatStartofEpisode = csv.GetString("Age at Start of Episode").GetTrimmedValueOrNull(),
                YearofBirth = csv.GetString("Year of Birth").GetTrimmedValueOrNull(),
                CensusArea = csv.GetString("2001 Census Area").GetTrimmedValueOrNull(),
                Country = csv.GetString("Country").GetTrimmedValueOrNull(),
                CountyCode = csv.GetString("County Code").GetTrimmedValueOrNull(),
                CensusED = csv.GetString("1991 Census ED").GetTrimmedValueOrNull(),
                EDDistrictCode = csv.GetString("ED District Code").GetTrimmedValueOrNull(),
                ElectoralWardCode = csv.GetString("Electoral Ward Code").GetTrimmedValueOrNull(),
                GORCode = csv.GetString("GOR Code").GetTrimmedValueOrNull(),
                LocalUnitaryAuthority = csv.GetString("Local Unitary Authority").GetTrimmedValueOrNull(),
                OldSHACode = csv.GetString("Old SHA Code").GetTrimmedValueOrNull(),
                ElectoralArea = csv.GetString("1998 Electoral Area").GetTrimmedValueOrNull(),
                PrimeRecipient = csv.GetString("Prime Recipient").GetTrimmedValueOrNull(),
                CopyRecipients = csv.GetString("Copy Recipients").GetTrimmedValueOrNull(),
                IsValidUBRN = csv.GetString("Is Valid UBRN").GetTrimmedValueOrNull(),
                UBRNOccurrenceCount = csv.GetString("UBRN Occurrence Count").GetTrimmedValueOrNull(),

            };

            int index = 48;

            bool isPrimaryDiagnosis = true;

            for (int i = 0; i < 24; i++)
            {
                var icdDiagnosis = new IcdDiagnosis
                {
                    MessageId = messageId,
                    DiagnosisICD = csv.GetString(++index).GetTrimmedValueOrNull(),
                    PresentOnAdmissionIndicatorDiagnosis = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IsPrimaryDiagnosis = isPrimaryDiagnosis
                };

                isPrimaryDiagnosis = false;

                if (icdDiagnosis.IsEmpty)
                    break;

                icdDiagnoses.Add(icdDiagnosis);
            }

            index = 98;

            isPrimaryDiagnosis = true;

            for (int i = 0; i < 24; i++)
            {
                var readDiagnosis = new ReadDiagnosis
                {
                    MessageId = messageId,
                    DiagnosisRead = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IsPrimaryDiagnosis = isPrimaryDiagnosis
                };

                isPrimaryDiagnosis = false;

                if (readDiagnosis.IsEmpty)
                    break;

                readDiagnoses.Add(readDiagnosis);
            }

            index = 145;

            bool isPrimaryProcedure = true;

            for (int i = 0; i < 24; i++)
            {
                var procedure = new SusOPOpcsProcedure
                {
                    MessageId = messageId,
                    ProcedureOPCS = csv.GetString(++index).GetTrimmedValueOrNull(),
                    MainOperatingHealthcareProfessionalCodeOpcs = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ProfessionalRegistrationIssuerCodeOpcs = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ResponsibleAnaesthetistCodeOpcs = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ResponsibleAnaesthetistRegBodyOpcs = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IsPrimaryProcedure = isPrimaryProcedure
                };

                isPrimaryProcedure = false;

                if (procedure.IsEmpty)
                    break;

                opcdProcedure.Add(procedure);
            }

            index = 267;
            isPrimaryProcedure = true;

            for (int i = 0; i < 24; i++)
            {
                var procedure = new OPReadProcedure
                {
                    MessageId = messageId,
                    ProcedureRead = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IsPrimaryProcedure = isPrimaryProcedure
                };

                isPrimaryProcedure = false;

                if (procedure.IsEmpty)
                    break;

                readProcedure.Add(procedure);
            }

            yield return
                new OPRecord(
                    record,
                    icdDiagnoses,
                    readDiagnoses,
                    readProcedure,
                    opcdProcedure);
        }
    }
}