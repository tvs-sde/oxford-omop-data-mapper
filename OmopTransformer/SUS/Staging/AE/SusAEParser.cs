namespace OmopTransformer.SUS.Staging.AE;

internal class SusAEParser : ISusAEParser
{
    public IEnumerable<AERecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var investigations = new List<SusAEInvestigation> ();
            var diagnoses = new List<SusAEDiagnosis> ();
            var treatments = new List<SusAETreatment>();

            Guid messageId = Guid.NewGuid();

            var record = new AERow
            {
                MessageId = messageId,
                GeneratedRecordIdentifier = csv.GetString("Generated Record Identifier").GetTrimmedValueOrNull(),
                ReasonForAccess = csv.GetString("Reason for Access").GetTrimmedValueOrNull(),
                CDStype = csv.GetString("CDS type").GetTrimmedValueOrNull(),
                ProtocolIdentifier = csv.GetString("Protocol identifier").GetTrimmedValueOrNull(),
                UniqueCDSidentifier = csv.GetString("Unique CDS identifier").GetTrimmedValueOrNull(),
                UpdateType = csv.GetString("Update type").GetTrimmedValueOrNull(),
                BulkreplacementCDSgroup = csv.GetString("Bulk replacement CDS group").GetTrimmedValueOrNull(),
                TestIndicator = csv.GetString("Test indicator").GetTrimmedValueOrNull(),
                ApplicableDatetime = csv.GetString("Applicable date/time").GetTrimmedValueOrNull(),
                CensusDate = csv.GetString("Census date").GetTrimmedValueOrNull(),
                ExtractDatetime = csv.GetString("Extract date/time").GetTrimmedValueOrNull(),
                ReportPeriodStartDate = csv.GetString("Report period Start Date").GetTrimmedValueOrNull(),
                ReportPeriodEndDate = csv.GetString("Report period End Date").GetTrimmedValueOrNull(),
                OrganisationCodeSenderOfTransaction = csv.GetString("Organisation code: Sender of transaction").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofSender = csv.GetString("Organisation Code Type of Sender").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetString("CDS Interchange ID").GetTrimmedValueOrNull(),
                LocalPatientIdentifier = csv.GetString("Local Patient Identifier").GetTrimmedValueOrNull(),
                OrganisationCodeLocalPatientIdentifier = csv.GetString("Organisation Code (Local Patient Identifier)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeLocalPatientIdentifier = csv.GetString("Organisation Code Type (Local Patient Identifier)").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetString("NHS Number").GetTrimmedValueOrNull(),
                DateOfBirth = csv.GetString("Date of Birth").GetTrimmedValueOrNull(),
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
                GeneralMedicalPractitionerCodeofRegisteredGMP = csv.GetString("General Medical Practitioner Code of Registered GMP").GetTrimmedValueOrNull(),
                PracticeCodeofRegisteredGP = csv.GetString("Practice Code of Registered GP").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofRegisteredGP = csv.GetString("Organisation Code Type of Registered GP").GetTrimmedValueOrNull(),
                AEAttendanceNumber = csv.GetString("A&E Attendance Number").GetTrimmedValueOrNull(),
                AEArrivalMode = csv.GetString("A&E Arrival Mode").GetTrimmedValueOrNull(),
                AEAttendanceCategory = csv.GetString("A&E Attendance Category").GetTrimmedValueOrNull(),
                AEAttendanceDisposal = csv.GetString("A&E Attendance Disposal").GetTrimmedValueOrNull(),
                AEIncidentLocationType = csv.GetString("A&E Incident Location Type").GetTrimmedValueOrNull(),
                AEPatientGroup = csv.GetString("A&E Patient Group").GetTrimmedValueOrNull(),
                SourceofReferralForAE = csv.GetString("Source of Referral For A&E").GetTrimmedValueOrNull(),
                ArrivalDate = csv.GetString("Arrival Date").GetTrimmedValueOrNull(),
                ArrivalTime = csv.GetString("Arrival Time").GetTrimmedValueOrNull(),
                AEAttendanceConclusionTime = csv.GetString("A&E Attendance Conclusion Time").GetTrimmedValueOrNull(),
                AEAttendanceConclusionDate = csv.GetString("A&E Attendance Conclusion Date").GetTrimmedValueOrNull(),
                AEDepartureTime = csv.GetString("A&E Departure Time").GetTrimmedValueOrNull(),
                AEDepartureDate = csv.GetString("A&E Departure Date").GetTrimmedValueOrNull(),
                AEInitialAssessmentTimefirstandunplannedfollowupattendancesonly = csv.GetString("A&E Initial Assessment Time (first and unplanned follow-up attendances only)").GetTrimmedValueOrNull(),
                AEInitialAssessmentDate = csv.GetString("A&E Initial Assessment Date").GetTrimmedValueOrNull(),
                AETimeSeenForTreatment = csv.GetString("A&E Time Seen For Treatment").GetTrimmedValueOrNull(),
                SiteCodeOfTreatment = csv.GetString("Site Code (Of Treatment)").GetTrimmedValueOrNull(),
                WaitingTimeMeasurementType = csv.GetString("Waiting Time Measurement Type").GetTrimmedValueOrNull(),
                AmbulanceIncidentNumber = csv.GetString("Ambulance Incident Number").GetTrimmedValueOrNull(),
                OrganisationCodeConveyingAmbulanceTrust = csv.GetString("Organisation Code (Conveying Ambulance Trust)").GetTrimmedValueOrNull(),
                CommissioningSerialNumber = csv.GetString("Commissioning Serial Number").GetTrimmedValueOrNull(),
                NHSServiceAgreementLineNumber = csv.GetString("NHS Service Agreement Line Number").GetTrimmedValueOrNull(),
                ProviderReferenceNumber = csv.GetString("Provider Reference Number").GetTrimmedValueOrNull(),
                CommissionerReferenceNumber = csv.GetString("Commissioner Reference Number").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfProvider = csv.GetString("Organisation Code (Code of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeOfProvider = csv.GetString("Organisation Code Type (of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfCommissioner = csv.GetString("Organisation Code (Code of Commissioner)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeOfCommissioner = csv.GetString("Organisation Code Type (of Commissioner)").GetTrimmedValueOrNull(),
                AEStaffMemberCode = csv.GetString("A&E Staff Member Code").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUse = csv.GetString("Diagnosis Scheme In Use").GetTrimmedValueOrNull(),
                InvestigationSchemeInUse = csv.GetString("Investigation Scheme In Use").GetTrimmedValueOrNull(),
                TreatmentSchemeInUse = csv.GetString("Treatment Scheme In Use").GetTrimmedValueOrNull(),
                HRGCode = csv.GetString("HRG Code").GetTrimmedValueOrNull(),
                HRGVersionNumber = csv.GetString("HRG Version Number").GetTrimmedValueOrNull(),
                ProcedureSchemeInUse = csv.GetString("Procedure Scheme In Use").GetTrimmedValueOrNull(),
                DominantGroupingVariableProcedure = csv.GetString("Dominant Grouping Variable - Procedure").GetTrimmedValueOrNull(),
                FCEHRG = csv.GetString("FCE HRG").GetTrimmedValueOrNull(),
                SpellCOREHRGVersionNo = csv.GetString("Spell CORE HRG Version No").GetTrimmedValueOrNull(),
                PBRGeneratedCoreHRGforInformation = csv.GetString("PBR Generated Core HRG (for Information)").GetTrimmedValueOrNull(),
                PBRGeneratedCoreHRGVersionforInformation = csv.GetString("PBR Generated Core HRG Version (for Information)").GetTrimmedValueOrNull(),
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
                AEDepartmentType = csv.GetString("A&E Department Type").GetTrimmedValueOrNull(),
                XMLVersion = csv.GetString("XML Version").GetTrimmedValueOrNull(),
                ConfidentialityCategoryDerived = csv.GetString("Confidentiality Category (Derived)").GetTrimmedValueOrNull(),
                ReferralToTreatmentLengthDerived = csv.GetString("Referral To Treatment Length (Derived)").GetTrimmedValueOrNull(),
                AEAssessmentWaitTime = csv.GetString("AE Assessment Wait Time").GetTrimmedValueOrNull(),
                AEConclusionWaitTime = csv.GetString("AE Conclusion Wait Time").GetTrimmedValueOrNull(),
                AEDuration = csv.GetString("AE Duration").GetTrimmedValueOrNull(),
                AETreatmentWait = csv.GetString("AE Treatment Wait").GetTrimmedValueOrNull(),
                AgerangepatientderivedfromDOB = csv.GetString("Age range patient derived from DOB").GetTrimmedValueOrNull(),
                AreaCodeDerivedFromPostcode = csv.GetString("Area code derived from postcode.").GetTrimmedValueOrNull(),
                CDSGroup = csv.GetString("CDS Group").GetTrimmedValueOrNull(),
                FinishedIndicator = csv.GetString("Finished Indicator").GetTrimmedValueOrNull(),
                PCTDerivedfromGP = csv.GetString("PCT (Derived from GP)").GetTrimmedValueOrNull(),
                PCTTypeDerivedfromGP = csv.GetString("PCT Type (Derived from GP)").GetTrimmedValueOrNull(),
                GPPracticeDerived = csv.GetString("GP Practice (Derived)").GetTrimmedValueOrNull(),
                PCTDerivedfromderivedGPPractice = csv.GetString("PCT (Derived from derived GP Practice)").GetTrimmedValueOrNull(),
                SHAfromGPPractice = csv.GetString("SHA from GP Practice").GetTrimmedValueOrNull(),
                SHATypefromGPPractice = csv.GetString("SHA Type from GP Practice").GetTrimmedValueOrNull(),
                MonthOfBirth = csv.GetString("Month of Birth").GetTrimmedValueOrNull(),
                ElectoralWardFromPostcode = csv.GetString("Electoral Ward from postcode").GetTrimmedValueOrNull(),
                PCTfrompostcode = csv.GetString("PCT from postcode").GetTrimmedValueOrNull(),
                PCTTypefromPostcode = csv.GetString("PCT Type from Postcode").GetTrimmedValueOrNull(),
                SHAfromPostcode = csv.GetString("SHA from Postcode").GetTrimmedValueOrNull(),
                SHATypefromPostcode = csv.GetString("SHA Type from Postcode").GetTrimmedValueOrNull(),
                AreaCodeFromProviderPostcode = csv.GetString("Area code from Provider Postcode").GetTrimmedValueOrNull(),
                AgeAtEndOfEpisode = csv.GetString("Age at End of Episode").GetTrimmedValueOrNull(),
                AgeAtStartOfEpisode = csv.GetString("Age at Start of Episode").GetTrimmedValueOrNull(),
                YearOfBirth = csv.GetString("Year of Birth").GetTrimmedValueOrNull(),
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

            int index = 73;

            for (int i = 0; i < 24; i++)
            {
                var diagnosis = new SusAEDiagnosis
                {
                    MessageId = messageId,
                    AccidentAndEmergencyDiagnosis = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (diagnosis.IsEmpty)
                    break;

                diagnoses.Add(diagnosis);
            }

            index = 98;

            for (int i = 0; i < 24; i++)
            {
                var investigation = new SusAEInvestigation
                {
                    MessageId = messageId,
                    AccidentAndEmergencyInvestigation = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (investigation.IsEmpty)
                    break;

                investigations.Add(investigation);
            }

            index = 123;

            for (int i = 0; i < 24; i++)
            {
                var treatment = new SusAETreatment
                {
                    MessageId = messageId,
                    AccidentAndEmergencyTreatment = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (treatment.IsEmpty)
                    break;

                treatments.Add(treatment);
            }

            yield return
                new AERecord(
                    record,
                    investigations,
                    diagnoses,
                    treatments);
        }
    }
}