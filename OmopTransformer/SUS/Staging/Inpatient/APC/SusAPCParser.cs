namespace OmopTransformer.SUS.Staging.Inpatient.APC;

internal class SusAPCParser : ISusAPCParser
{
    public IEnumerable<APCRecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var visitors = new List<OverseasVisitor>();
            var icdDiagnoses = new List<IcdDiagnosis>();
            var readDiagnoses = new List<ReadDiagnosis>();
            var opcdProcedure = new List<SusAPCOpcsProcedure>();
            var readProcedure = new List<APCReadProcedure>();
            var careLocations = new List<APCCareLocation>();
            var births = new List<APCBirth>();
            var criticalCareItems = new List<APCCriticalCare>();

            Guid messageId = Guid.NewGuid();

            var record = new APCRow
            {
                MessageId = messageId,
                GeneratedRecordIdentifier = csv.GetString("Generated Record Identifier").GetTrimmedValueOrNull(),
                PBRSpellID = csv.GetString("PBR Spell ID").GetTrimmedValueOrNull(),
                ReasonForAccess = csv.GetString("Reason for Access").GetTrimmedValueOrNull(),
                CDSType = csv.GetString("CDS type").GetTrimmedValueOrNull(),
                ProtocolIdentifier = csv.GetString("Protocol identifier").GetTrimmedValueOrNull(),
                UniqueCDSIdentifier = csv.GetString("Unique CDS identifier").GetTrimmedValueOrNull(),
                UpdateType = csv.GetString("Update type").GetTrimmedValueOrNull(),
                BulkReplacementCDSGroup = csv.GetString("Bulk replacement CDS group").GetTrimmedValueOrNull(),
                TestIndicator = csv.GetString("Test indicator").GetTrimmedValueOrNull(),
                ApplicableDatetime = csv.GetString("Applicable date/time").GetTrimmedValueOrNull(),
                CensusDate = csv.GetString("Census date").GetTrimmedValueOrNull(),
                ExtractDatetime = csv.GetString("Extract date/time").GetTrimmedValueOrNull(),
                ReportPeriodStartDate = csv.GetString("Report period Start Date").GetTrimmedValueOrNull(),
                ReportPeriodEndDate = csv.GetString("Report period End Date").GetTrimmedValueOrNull(),
                OrganisationCodeSenderOfTransaction = csv.GetString("Organisation code: Sender of transaction").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofSender = csv.GetString("Organisation Code Type of Sender").GetTrimmedValueOrNull(),
                SubmissionDate = csv.GetString("Submission Date").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetString("CDS Interchange ID").GetTrimmedValueOrNull(),
                LocalPatientIdentifier = csv.GetString("Local Patient Identifier").GetTrimmedValueOrNull(),
                OrganisationCodeLocalPatientIdentifier = csv.GetString("Organisation Code (Local Patient Identifier)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeLocalPatientIdentifier = csv.GetString("Organisation Code Type (Local Patient Identifier)").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetString("NHS Number").GetTrimmedValueOrNull(),
                DateofBirth = csv.GetString("Date of Birth").GetTrimmedValueOrNull(),
                BirthWeight = csv.GetString("Birth Weight").GetTrimmedValueOrNull(),
                LiveOrStillBirth = csv.GetString("Live or Still Birth").GetTrimmedValueOrNull(),
                CarerSupportIndicator = csv.GetString("Carer Support Indicator").GetTrimmedValueOrNull(),
                LegalStatusClassificationOnAdmissionPsychiatricCensusOnly = csv.GetString("Legal Status Classification on Admission (Psychiatric Census Only)").GetTrimmedValueOrNull(),
                EthnicGroup = csv.GetString("Ethnic Group").GetTrimmedValueOrNull(),
                MaritalStatusPsychiatricCensusOnly = csv.GetString("Marital Status (Psychiatric Census Only)").GetTrimmedValueOrNull(),
                NHSNumberTraceStatus = csv.GetString("NHS Number Trace Status").GetTrimmedValueOrNull(),
                WithheldIdentityReason = csv.GetString("Withheld Identity Reason").GetTrimmedValueOrNull(),
                Sex = csv.GetString("Sex").GetTrimmedValueOrNull(),
                PregnancyTotalPreviousPregnancies = csv.GetString("Pregnancy Total Previous Pregnancies").GetTrimmedValueOrNull(),
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
                OSVClassificationatCDSActivityDate = csv.GetString("OSV Classification at CDS Activity Date").GetTrimmedValueOrNull(),
                HospitalProviderSpellNumber = csv.GetString("Hospital Provider Spell Number").GetTrimmedValueOrNull(),
                AdministrativeCategory = csv.GetString("Administrative Category").GetTrimmedValueOrNull(),
                PatientClassification = csv.GetString("Patient Classification").GetTrimmedValueOrNull(),
                AdmissionMethodHospitalProviderSpell = csv.GetString("Admission Method (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                DischargeDestinationHospitalProviderSpell = csv.GetString("Discharge Destination (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                DischargeMethodHospitalProviderSpell = csv.GetString("Discharge Method (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                SourceOfAdmissionHospitalProviderSpell = csv.GetString("Source of Admission (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                StartDateHospitalProviderSpell = csv.GetString("Start Date (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                StartTimeHospitalProviderSpell = csv.GetString("Start Time (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                DischargeDateFromHospitalProviderSpell = csv.GetString("Discharge Date (From Hospital Provider Spell)").GetTrimmedValueOrNull(),
                DischargeTimeHospitalProviderSpell = csv.GetString("Discharge Time (Hospital Provider Spell)").GetTrimmedValueOrNull(),
                DischargeToHospitalAtHomeServiceIndicator = csv.GetString("Discharge To Hospital At Home Service Indicator").GetTrimmedValueOrNull(),
                EpisodeNumber = csv.GetString("Episode Number").GetTrimmedValueOrNull(),
                FirstRegularDayNightAdmission = csv.GetString("First Regular Day Night Admission").GetTrimmedValueOrNull(),
                LastEpisodeInSpellIndicator = csv.GetString("Last Episode In Spell Indicator").GetTrimmedValueOrNull(),
                NeonatalLevelOfCare = csv.GetString("Neonatal Level of Care").GetTrimmedValueOrNull(),
                OperationStatus = csv.GetString("Operation Status").GetTrimmedValueOrNull(),
                PsychiatricPatientStatus = csv.GetString("Psychiatric Patient Status").GetTrimmedValueOrNull(),
                StartDateConsultantEpisode = csv.GetString("Start Date (Consultant Episode)").GetTrimmedValueOrNull(),
                StartTimeEpisode = csv.GetString("Start Time (Episode)").GetTrimmedValueOrNull(),
                EndDateConsultantEpisode = csv.GetString("End Date (Consultant Episode)").GetTrimmedValueOrNull(),
                EndTimeEpisode = csv.GetString("End Time (Episode)").GetTrimmedValueOrNull(),
                LengthOfStayAdjustmentRehabilitation = csv.GetString("Length Of Stay Adjustment (Rehabilitation)").GetTrimmedValueOrNull(),
                LengthOfStayAdjustmentSpecialistPalliativeCare = csv.GetString("Length Of Stay Adjustment (Specialist Palliative Care)").GetTrimmedValueOrNull(),
                CommissioningSerialNumber = csv.GetString("Commissioning Serial Number").GetTrimmedValueOrNull(),
                NHSServiceAgreementLineNumber = csv.GetString("NHS Service Agreement Line Number").GetTrimmedValueOrNull(),
                ProviderReferenceNumber = csv.GetString("Provider Reference Number").GetTrimmedValueOrNull(),
                CommissionerReferenceNumber = csv.GetString("Commissioner Reference Number").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfProvider = csv.GetString("Organisation Code Code of Provider").GetTrimmedValueOrNull(),
                OrganisationCodeTypeOfProvider = csv.GetString("Organisation Code Type of Provider").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfCommissioner = csv.GetString("Organisation Code Code of Commissioner").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofCommissioner = csv.GetString("Organisation Code Type of Commissioner").GetTrimmedValueOrNull(),
                ConsultantCode = csv.GetString("Consultant Code").GetTrimmedValueOrNull(),
                MainSpecialtyCode = csv.GetString("Main Specialty Code").GetTrimmedValueOrNull(),
                TreatmentFunctionCode = csv.GetString("Treatment Function Code").GetTrimmedValueOrNull(),
                LocalSubSpecialtyCode = csv.GetString("Local Sub Specialty Code").GetTrimmedValueOrNull(),
                MultiProfessionalOrMultidisciplinaryIndCode = csv.GetString("Multi-Professional Or Multidisciplinary Ind Code").GetTrimmedValueOrNull(),
                RehabilitationAssessmentTeamType = csv.GetString("Rehabilitation Assessment Team Type").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUseICD = csv.GetString("Diagnosis Scheme In Use (ICD)").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUseRead = csv.GetString("Diagnosis Scheme In Use (Read)").GetTrimmedValueOrNull(),
                ProcedureSchemeInUseOPCS = csv.GetString("Procedure Scheme In Use (OPCS)").GetTrimmedValueOrNull(),
                ProcedureSchemeInUseREAD = csv.GetString("Procedure Scheme In Use (READ)").GetTrimmedValueOrNull(),
                WardCodeAtEpisodeStartDate = csv.GetString("Ward Code at Episode Start Date").GetTrimmedValueOrNull(),
                WardSecurityLevelAtEpisodeStartDate = csv.GetString("Ward Security Level at Episode Start Date").GetTrimmedValueOrNull(),
                LocationClassAtEpisodeStartDate = csv.GetString("Location Class at Episode Start Date").GetTrimmedValueOrNull(),
                SiteCodeOfTreatmentAtEpisodeStartDate = csv.GetString("Site Code (of Treatment) At Episode Start Date").GetTrimmedValueOrNull(),
                OrganisationCodeTypeSiteCodeOfTreatmentAtStartOfEpisode = csv.GetString("Organisation Code Type (Site Code of Treatment) (At Start of Episode)").GetTrimmedValueOrNull(),
                IntendedClinicalCareIntensityAtStartOfEpisode = csv.GetString("Intended Clinical Care Intensity(At Start of Episode)").GetTrimmedValueOrNull(),
                AgeGroupIntendedAtStartOfEpisode = csv.GetString("Age Group Intended (At Start of Episode)").GetTrimmedValueOrNull(),
                SexOfPatientsAtStartOfEpisode = csv.GetString("Sex of Patients (At Start of Episode)").GetTrimmedValueOrNull(),
                WardDayPeriodAvailability = csv.GetString("Ward Day Period Availability").GetTrimmedValueOrNull(),
                WardNightPeriodAvailability = csv.GetString("Ward Night Period Availability").GetTrimmedValueOrNull(),
                WardCodeAtEpisodeEndDate = csv.GetString("Ward Code at Episode End Date").GetTrimmedValueOrNull(),
                WardSecurityLevelAtEpisodeEndDate = csv.GetString("Ward Security Level at Episode End Date").GetTrimmedValueOrNull(),
                LocationClassAtEpisodeEndDate = csv.GetString("Location Class at Episode End Date").GetTrimmedValueOrNull(),
                SiteCodeOfTreatmentAtEpisodeEndDate = csv.GetString("Site Code (of Treatment) at Episode End Date").GetTrimmedValueOrNull(),
                OrganisationCodeTypeSiteCodeOfTreatmentAtEpisodeEndDate = csv.GetString("Organisation Code Type Site Code (of Treatment) at Episode End Date").GetTrimmedValueOrNull(),
                IntendedClinicalCareIntensityAtEpisodeEndDate = csv.GetString("Intended Clinical Care Intensity at Episode End Date").GetTrimmedValueOrNull(),
                AgeGroupIntendedAtEpisodeEndDate = csv.GetString("Age Group Intended at Episode End Date").GetTrimmedValueOrNull(),
                SexOfPatientsAtEpisodeEndDate = csv.GetString("Sex of Patients at Episode End Date").GetTrimmedValueOrNull(),
                WardDayPeriodAvailabilityAtEpisodeEndDate = csv.GetString("Ward Day Period Availability at Episode End Date").GetTrimmedValueOrNull(),
                WardNightPeriodAvailabilityAtEpisodeEndDate = csv.GetString("Ward Night Period Availability at Episode End Date").GetTrimmedValueOrNull(),
                GeneralMedicalPractitionerCodeofRegisteredGMP = csv.GetString("General Medical Practitioner Code of Registered GMP").GetTrimmedValueOrNull(),
                PracticeCodeOfRegisteredGP = csv.GetString("Practice Code of Registered GP").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofRegisteredGP = csv.GetString("Organisation Code Type of Registered GP").GetTrimmedValueOrNull(),
                ReferrerCode = csv.GetString("Referrer Code").GetTrimmedValueOrNull(),
                ReferringOrganisationCode = csv.GetString("Referring Organisation Code").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofReferrer = csv.GetString("Organisation Code Type of Referrer").GetTrimmedValueOrNull(),
                DirectAccessReferralIndicator = csv.GetString("Direct Access Referral Indicator").GetTrimmedValueOrNull(),
                AmbulanceIncidentNumber = csv.GetString("Ambulance Incident Number").GetTrimmedValueOrNull(),
                OrganisationCodeConveyingAmbulanceTrust = csv.GetString("Organisation Code (Conveying Ambulance Trust)").GetTrimmedValueOrNull(),
                DurationofElectiveWait = csv.GetString("Duration of Elective Wait").GetTrimmedValueOrNull(),
                IntendedManagement = csv.GetString("Intended Management").GetTrimmedValueOrNull(),
                DecidedToAdmitDateForThisProvider = csv.GetString("Decided To Admit Date (For This Provider)").GetTrimmedValueOrNull(),
                WaitingTimeMeasurementType = csv.GetString("Waiting Time Measurement Type").GetTrimmedValueOrNull(),
                LocationTypeCodeAtStartOfEpisode = csv.GetString("Location Type Code at Start of Episode").GetTrimmedValueOrNull(),
                HRGCode = csv.GetString("HRG Code").GetTrimmedValueOrNull(),
                HRGVersionNumber = csv.GetString("HRG Version Number").GetTrimmedValueOrNull(),
                ProcedureSchemeInUse = csv.GetString("Procedure Scheme In Use").GetTrimmedValueOrNull(),
                DominantGroupingVariableProcedure = csv.GetString("Dominant Grouping Variable - Procedure").GetTrimmedValueOrNull(),
                FCEHRG = csv.GetString("FCE HRG").GetTrimmedValueOrNull(),
                EpisodeHRGVersionNumber = csv.GetString("Episode HRG Version Number").GetTrimmedValueOrNull(),
                SpellCoreHRG = csv.GetString("Spell Core HRG").GetTrimmedValueOrNull(),
                SpellHRGVersionNumber = csv.GetString("Spell HRG Version Number").GetTrimmedValueOrNull(),
                NumberOfBabies = csv.GetString("Number of Babies").GetTrimmedValueOrNull(),
                FirstAntenatalAssessmentDate = csv.GetString("First Antenatal Assessment Date").GetTrimmedValueOrNull(),
                GMPCodeofGMPResponsibleforAntenatalCare = csv.GetString("GMP (Code of GMP Responsible for Antenatal Care)").GetTrimmedValueOrNull(),
                CodeofGPPracticeRegisteredGMPAntenatalCare = csv.GetString("Code of GP Practice (Registered GMP- Antenatal Care)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeGPPracticeRegisteredGMPAntenatalCare = csv.GetString("Organisation Code Type GP Practice (Registered GMP- Antenatal Care)").GetTrimmedValueOrNull(),
                LocationClassOfDeliveryPlaceIntended = csv.GetString("Location Class of Delivery Place (Intended)").GetTrimmedValueOrNull(),
                LocationTypeofDeliveryPlaceIntended = csv.GetString("Location Type of Delivery Place (Intended)").GetTrimmedValueOrNull(),
                DeliveryPlaceChangeReason = csv.GetString("Delivery Place Change Reason").GetTrimmedValueOrNull(),
                DeliveryPlaceTypeIntended = csv.GetString("Delivery Place Type (Intended)").GetTrimmedValueOrNull(),
                AnaestheticGivenDuringLabourDelivery = csv.GetString("Anaesthetic Given During Labour/Delivery").GetTrimmedValueOrNull(),
                AnaestheticGivenPostDelivery = csv.GetString("Anaesthetic Given Post Delivery").GetTrimmedValueOrNull(),
                GestationLengthLabourOnset = csv.GetString("Gestation Length (Labour Onset)").GetTrimmedValueOrNull(),
                LabourDeliveryOnsetMethod = csv.GetString("Labour/Delivery Onset Method").GetTrimmedValueOrNull(),
                DeliveryDate = csv.GetString("Delivery Date").GetTrimmedValueOrNull(),
                GestationLengthAssessmentBaby = csv.GetString("Gestation Length (Assessment) Baby").GetTrimmedValueOrNull(),
                LocalPatientIdentifierMother = csv.GetString("Local Patient Identifier (Mother)").GetTrimmedValueOrNull(),
                OrganisationCodeLocalPatientIdentifierMother = csv.GetString("Organisation Code (Local Patient Identifier (Mother))").GetTrimmedValueOrNull(),
                OrganisationCodeTypeMother = csv.GetString("Organisation Code Type (Mother)").GetTrimmedValueOrNull(),
                NHSNumberMother = csv.GetString("NHS Number (Mother)").GetTrimmedValueOrNull(),
                NHSNumberStatusIndicatorMother = csv.GetString("NHS Number Status Indicator (Mother)").GetTrimmedValueOrNull(),
                BirthDateMother = csv.GetString("Birth Date (Mother)").GetTrimmedValueOrNull(),
                AddressFormatCodeMother = csv.GetString("Address Format Code (Mother)").GetTrimmedValueOrNull(),
                PatientUsualAddressMother = csv.GetString("Patient Usual Address (Mother)").GetTrimmedValueOrNull(),
                PostcodeOfUsualAddressMother = csv.GetString("Postcode of Usual Address (Mother)").GetTrimmedValueOrNull(),
                OrganisationCodePCTofResidenceMother = csv.GetString("Organisation Code (PCT of Residence) (Mother)").GetTrimmedValueOrNull(),
                OrganisationCodeTypePCTofResidenceMother = csv.GetString("Organisation Code Type (PCT of Residence) (Mother)").GetTrimmedValueOrNull(),
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
                AgeAsOnAdmission = csv.GetString("Age as on Admission").GetTrimmedValueOrNull(),
                AdminCategoryAtStart = csv.GetString("Admin Category at Start").GetTrimmedValueOrNull(),
                HospitalProviderSpellDischargeReadyDate = csv.GetString("Hospital Provider Spell Discharge Ready Date").GetTrimmedValueOrNull(),
                LocationType = csv.GetString("Location Type").GetTrimmedValueOrNull(),
                XMLVersion = csv.GetString("XML Version").GetTrimmedValueOrNull(),
                ConfidentialityCategoryDerived = csv.GetString("Confidentiality Category (Derived)").GetTrimmedValueOrNull(),
                ReferralToTreatmentLengthDerived = csv.GetString("Referral To Treatment Length (Derived)").GetTrimmedValueOrNull(),
                AgeRangePatientdDerivedFromDOB = csv.GetString("Age range patient derived from DOB").GetTrimmedValueOrNull(),
                AgeRangeMotherDerivedFromDOB = csv.GetString("Age range mother derived from DOB").GetTrimmedValueOrNull(),
                AreaCodeDerivedFromPostcode = csv.GetString("Area code derived from postcode.").GetTrimmedValueOrNull(),
                CDSGroup = csv.GetString("CDS Group").GetTrimmedValueOrNull(),
                FinishedIndicator = csv.GetString("Finished Indicator").GetTrimmedValueOrNull(),
                PCTDerivedfromGP = csv.GetString("PCT (Derived from GP)").GetTrimmedValueOrNull(),
                PCTTypeDerivedfromGP = csv.GetString("PCT Type (Derived from GP)").GetTrimmedValueOrNull(),
                GPPracticeDerived = csv.GetString("GP Practice (Derived)").GetTrimmedValueOrNull(),
                GPPracticeMotherDerived = csv.GetString("GP Practice Mother (Derived)").GetTrimmedValueOrNull(),
                PCTDerivedfromderivedGPPractice = csv.GetString("PCT (Derived from derived GP Practice)").GetTrimmedValueOrNull(),
                PCTMotherDerivedfromderivedGPPractice = csv.GetString("PCT Mother (Derived from derived GP Practice)").GetTrimmedValueOrNull(),
                SHAfromGPPractice = csv.GetString("SHA from GP Practice").GetTrimmedValueOrNull(),
                SHATypefromGPPractice = csv.GetString("SHA Type from GP Practice").GetTrimmedValueOrNull(),
                HospitalSpellDuration = csv.GetString("Hospital Spell Duration").GetTrimmedValueOrNull(),
                MonthOfBirth = csv.GetString("Month of Birth").GetTrimmedValueOrNull(),
                HomeBirthOrDelivery = csv.GetString("Home Birth or Delivery").GetTrimmedValueOrNull(),
                ElectoralWardFromPostcode = csv.GetString("Electoral Ward from postcode").GetTrimmedValueOrNull(),
                PCTFromPostcode = csv.GetString("PCT from postcode").GetTrimmedValueOrNull(),
                PCTTypefromPostcode = csv.GetString("PCT Type from Postcode").GetTrimmedValueOrNull(),
                SHAfromPostcode = csv.GetString("SHA from Postcode").GetTrimmedValueOrNull(),
                SHATypefromPostcode = csv.GetString("SHA Type from Postcode").GetTrimmedValueOrNull(),
                AreacodeFromProviderPostcode = csv.GetString("Area code from Provider Postcode").GetTrimmedValueOrNull(),
                AgeAtEndOfEpisode = csv.GetString("Age at End of Episode").GetTrimmedValueOrNull(),
                AgeAtStartOfEpisode = csv.GetString("Age at Start of Episode").GetTrimmedValueOrNull(),
                YearOfBirth = csv.GetString("Year of Birth").GetTrimmedValueOrNull(),
                YearOfBirthMother = csv.GetString("Year of Birth Mother").GetTrimmedValueOrNull(),
                MonthOfBirthMother = csv.GetString("Month of Birth Mother").GetTrimmedValueOrNull(),
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
            };

            int index = 46;

            for (int i = 0; i < 5; i++)
            {
                var visitor = new OverseasVisitor
                {
                    MessageId = messageId,
                    OverseasVisitorStatusClassification = csv.GetString(++index).GetTrimmedValueOrNull(),
                    OverseasVisitorStatusStartDate = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (visitor.IsEmpty)
                    break;

                visitors.Add(visitor);
            }

            index = 100;

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

            index = 149;

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

            index = 174;

            bool isPrimaryProcedure = true;

            for (int i = 0; i < 24; i++)
            {
                var procedure = new SusAPCOpcsProcedure
                {
                    MessageId = messageId,
                    ProcedureOPCS = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ProcedureDateOPCS = csv.GetString(++index).GetTrimmedValueOrNull(),
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

            index = 319;
            isPrimaryProcedure = true;

            for (int i = 0; i < 24; i++)
            {
                var procedure = new APCReadProcedure
                {
                    MessageId = messageId,
                    ProcedureRead = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ProcedureDateRead = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IsPrimaryProcedure = isPrimaryProcedure
                };

                isPrimaryProcedure = false;

                if (procedure.IsEmpty)
                    break;

                readProcedure.Add(procedure);
            }

            index = 377;

            for (int i = 0; i < 24; i++)
            {
                var careLocation = new APCCareLocation
                {
                    MessageId = messageId,
                    WardCode = csv.GetString(++index).GetTrimmedValueOrNull(),
                    WardSecurityLevel = csv.GetString(++index).GetTrimmedValueOrNull(),
                    LocationClass = csv.GetString(++index).GetTrimmedValueOrNull(),
                    SiteCodeOfTreatment = csv.GetString(++index).GetTrimmedValueOrNull(),
                    OrganisationCodeTypeSiteCodeOfTreatment = csv.GetString(++index).GetTrimmedValueOrNull(),
                    IntendedClinicalCareIntensity = csv.GetString(++index).GetTrimmedValueOrNull(),
                    AgeGroupIntended = csv.GetString(++index).GetTrimmedValueOrNull(),
                    SexOfPatients = csv.GetString(++index).GetTrimmedValueOrNull(),
                    WardDayPeriodAvailability = csv.GetString(++index).GetTrimmedValueOrNull(),
                    WardNightPeriodAvailability = csv.GetString(++index).GetTrimmedValueOrNull(),
                    StartDate = csv.GetString(++index).GetTrimmedValueOrNull(),
                    StartTimeWardStay = csv.GetString(++index).GetTrimmedValueOrNull(),
                    EndDate = csv.GetString(++index).GetTrimmedValueOrNull(),
                    EndTimeWardStay = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (careLocation.IsEmpty)
                    break;

                careLocations.Add(careLocation);
            }


            index = 759;

            for (int i = 0; i < 9; i++)
            {
                var birth = new APCBirth
                {
                    MessageId = messageId,
                    BirthOrderBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    DeliveryMethodBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    GestationLengthAssessmentBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    ResuscitationMethodBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    StatusOfPersonConductingDeliveryBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    LocalPatientIdentifierBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    OrganisationCodeLocalPatientIDBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    OrganisationCodeTypeLocalPatientIDBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    NHSNumberBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    NHSNumberStatusIndicatorBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    BirthDateBabyBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    BirthWeightBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    LiveOrStillBirthBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    SexBaby = csv.GetString(++index).GetTrimmedValueOrNull(),
                    BirthLocationType = csv.GetString(++index).GetTrimmedValueOrNull(),
                    LocationClassDeliveryPlaceActual = csv.GetString(++index).GetTrimmedValueOrNull(),
                    DeliveryPlaceTypeActual = csv.GetString(++index).GetTrimmedValueOrNull(),
                };

                if (birth.IsEmpty)
                    break;

                births.Add(birth);
            }


            index = 978;

            for (int i = 0; i < 9; i++)
            {
                var criticalCare = new APCCriticalCare
                {
                    MessageId = messageId,
                    CriticalCareLocalIdentifier = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareStartDate = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareUnitFunction = csv.GetString(++index).GetTrimmedValueOrNull(),
                    AdvancedRespiratorySupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    BasicRespiratorySupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    AdvancedCardiovascularSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    BasicCardiovascularSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    RenalSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    NeurologicalSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    DermatologicalSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    LiverSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareLevel2Days = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareLevel3Days = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeDate = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareUnitBedConfiguration = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareAdmissionSource = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareSourceLocation = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareAdmissionType = csv.GetString(++index).GetTrimmedValueOrNull(),
                    GastroIntestinalSupportDays = csv.GetString(++index).GetTrimmedValueOrNull(),
                    OrganSupportMaximum = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeReadyDate = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeReadyTime = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeStatus = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeDestination = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeLocation = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareDischargeTime = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareActivityToEpisodeRelationshipDerived = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCarePeriodSequenceNumber = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCareStartTime = csv.GetString(++index).GetTrimmedValueOrNull(),
                    CriticalCarePeriodType = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (criticalCare.IsEmpty)
                    break;

                criticalCareItems.Add(criticalCare);
            }

            yield return
                new APCRecord(
                    record,
                    visitors,
                    icdDiagnoses,
                    readDiagnoses,
                    opcdProcedure,
                    readProcedure,
                    careLocations,
                    births,
                    criticalCareItems);
        }
    }
}