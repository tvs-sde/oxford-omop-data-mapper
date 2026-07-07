using System.Globalization;
using CsvHelper;

namespace OmopTransformer.SUS.Staging.AE;

internal class SusAEParser : ISusAEParser
{
    public IEnumerable<AERecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

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
                GeneratedRecordIdentifier = csv.GetField<string>("Generated Record Identifier").GetTrimmedValueOrNull(),
                ReasonForAccess = csv.GetField<string>("Reason for Access").GetTrimmedValueOrNull(),
                CDStype = csv.GetField<string>("CDS type").GetTrimmedValueOrNull(),
                ProtocolIdentifier = csv.GetField<string>("Protocol identifier").GetTrimmedValueOrNull(),
                UniqueCDSidentifier = csv.GetField<string>("Unique CDS identifier").GetTrimmedValueOrNull(),
                UpdateType = csv.GetField<string>("Update type").GetTrimmedValueOrNull(),
                BulkreplacementCDSgroup = csv.GetField<string>("Bulk replacement CDS group").GetTrimmedValueOrNull(),
                TestIndicator = csv.GetField<string>("Test indicator").GetTrimmedValueOrNull(),
                ApplicableDatetime = csv.GetField<string>("Applicable date/time").GetTrimmedValueOrNull(),
                CensusDate = csv.GetField<string>("Census date").GetTrimmedValueOrNull(),
                ExtractDatetime = csv.GetField<string>("Extract date/time").GetTrimmedValueOrNull(),
                ReportPeriodStartDate = csv.GetField<string>("Report period Start Date").GetTrimmedValueOrNull(),
                ReportPeriodEndDate = csv.GetField<string>("Report period End Date").GetTrimmedValueOrNull(),
                OrganisationCodeSenderOfTransaction = csv.GetField<string>("Organisation code: Sender of transaction").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofSender = csv.GetField<string>("Organisation Code Type of Sender").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetField<string>("CDS Interchange ID").GetTrimmedValueOrNull(),
                LocalPatientIdentifier = csv.GetField<string>("Local Patient Identifier").GetTrimmedValueOrNull(),
                OrganisationCodeLocalPatientIdentifier = csv.GetField<string>("Organisation Code (Local Patient Identifier)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeLocalPatientIdentifier = csv.GetField<string>("Organisation Code Type (Local Patient Identifier)").GetTrimmedValueOrNull(),
                NHSNumber = csv.GetField<string>("NHS Number").GetTrimmedValueOrNull(),
                DateOfBirth = csv.GetField<string>("Date of Birth").GetTrimmedValueOrNull(),
                CarerSupportIndicator = csv.GetField<string>("Carer Support Indicator").GetTrimmedValueOrNull(),
                NHSNumberTraceStatus = csv.GetField<string>("NHS Number Trace Status").GetTrimmedValueOrNull(),
                WithheldIdentityReason = csv.GetField<string>("Withheld Identity Reason").GetTrimmedValueOrNull(),
                Sex = csv.GetField<string>("Sex").GetTrimmedValueOrNull(),
                NameFormatCode = csv.GetField<string>("Name Format Code").GetTrimmedValueOrNull(),
                PatientName = csv.GetField<string>("Patient Name").GetTrimmedValueOrNull(),
                PersonTitle = csv.GetField<string>("Person Title").GetTrimmedValueOrNull(),
                PersonGivenName = csv.GetField<string>("Person Given Name").GetTrimmedValueOrNull(),
                PersonFamilyName = csv.GetField<string>("Person Family Name").GetTrimmedValueOrNull(),
                PersonNameSuffix = csv.GetField<string>("Person Name Suffix").GetTrimmedValueOrNull(),
                PersonInitials = csv.GetField<string>("Person Initials").GetTrimmedValueOrNull(),
                AddressFormatCode = csv.GetField<string>("Address Format Code").GetTrimmedValueOrNull(),
                PatientUsualAddress = csv.GetField<string>("Patient Usual Address").GetTrimmedValueOrNull(),
                Postcode = csv.GetField<string>("Postcode").GetTrimmedValueOrNull(),
                OrganisationCodeResidenceResponsibility = csv.GetField<string>("Organisation Code (Residence Responsibility)").GetTrimmedValueOrNull(),
                PCTofResidence = csv.GetField<string>("PCT of Residence").GetTrimmedValueOrNull(),
                OrganisationCodeTypePCTofResidence = csv.GetField<string>("Organisation Code Type (PCT of Residence)").GetTrimmedValueOrNull(),
                EthnicCategory = csv.GetField<string>("Ethnic Category").GetTrimmedValueOrNull(),
                OSVClassificationatCDSActivityDate = csv.GetField<string>("OSV Classification at CDS Activity Date").GetTrimmedValueOrNull(),
                GeneralMedicalPractitionerCodeofRegisteredGMP = csv.GetField<string>("General Medical Practitioner Code of Registered GMP").GetTrimmedValueOrNull(),
                PracticeCodeofRegisteredGP = csv.GetField<string>("Practice Code of Registered GP").GetTrimmedValueOrNull(),
                OrganisationCodeTypeofRegisteredGP = csv.GetField<string>("Organisation Code Type of Registered GP").GetTrimmedValueOrNull(),
                AEAttendanceNumber = csv.GetField<string>("A&E Attendance Number").GetTrimmedValueOrNull(),
                AEArrivalMode = csv.GetField<string>("A&E Arrival Mode").GetTrimmedValueOrNull(),
                AEAttendanceCategory = csv.GetField<string>("A&E Attendance Category").GetTrimmedValueOrNull(),
                AEAttendanceDisposal = csv.GetField<string>("A&E Attendance Disposal").GetTrimmedValueOrNull(),
                AEIncidentLocationType = csv.GetField<string>("A&E Incident Location Type").GetTrimmedValueOrNull(),
                AEPatientGroup = csv.GetField<string>("A&E Patient Group").GetTrimmedValueOrNull(),
                SourceofReferralForAE = csv.GetField<string>("Source of Referral For A&E").GetTrimmedValueOrNull(),
                ArrivalDate = csv.GetField<string>("Arrival Date").GetTrimmedValueOrNull(),
                ArrivalTime = csv.GetField<string>("Arrival Time").GetTrimmedValueOrNull(),
                AEAttendanceConclusionTime = csv.GetField<string>("A&E Attendance Conclusion Time").GetTrimmedValueOrNull(),
                AEAttendanceConclusionDate = csv.GetField<string>("A&E Attendance Conclusion Date").GetTrimmedValueOrNull(),
                AEDepartureTime = csv.GetField<string>("A&E Departure Time").GetTrimmedValueOrNull(),
                AEDepartureDate = csv.GetField<string>("A&E Departure Date").GetTrimmedValueOrNull(),
                AEInitialAssessmentTimefirstandunplannedfollowupattendancesonly = csv.GetField<string>("A&E Initial Assessment Time (first and unplanned follow-up attendances only)").GetTrimmedValueOrNull(),
                AEInitialAssessmentDate = csv.GetField<string>("A&E Initial Assessment Date").GetTrimmedValueOrNull(),
                AETimeSeenForTreatment = csv.GetField<string>("A&E Time Seen For Treatment").GetTrimmedValueOrNull(),
                SiteCodeOfTreatment = csv.GetField<string>("Site Code (Of Treatment)").GetTrimmedValueOrNull(),
                WaitingTimeMeasurementType = csv.GetField<string>("Waiting Time Measurement Type").GetTrimmedValueOrNull(),
                AmbulanceIncidentNumber = csv.GetField<string>("Ambulance Incident Number").GetTrimmedValueOrNull(),
                OrganisationCodeConveyingAmbulanceTrust = csv.GetField<string>("Organisation Code (Conveying Ambulance Trust)").GetTrimmedValueOrNull(),
                CommissioningSerialNumber = csv.GetField<string>("Commissioning Serial Number").GetTrimmedValueOrNull(),
                NHSServiceAgreementLineNumber = csv.GetField<string>("NHS Service Agreement Line Number").GetTrimmedValueOrNull(),
                ProviderReferenceNumber = csv.GetField<string>("Provider Reference Number").GetTrimmedValueOrNull(),
                CommissionerReferenceNumber = csv.GetField<string>("Commissioner Reference Number").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfProvider = csv.GetField<string>("Organisation Code (Code of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeOfProvider = csv.GetField<string>("Organisation Code Type (of Provider)").GetTrimmedValueOrNull(),
                OrganisationCodeCodeOfCommissioner = csv.GetField<string>("Organisation Code (Code of Commissioner)").GetTrimmedValueOrNull(),
                OrganisationCodeTypeOfCommissioner = csv.GetField<string>("Organisation Code Type (of Commissioner)").GetTrimmedValueOrNull(),
                AEStaffMemberCode = csv.GetField<string>("A&E Staff Member Code").GetTrimmedValueOrNull(),
                DiagnosisSchemeInUse = csv.GetField<string>("Diagnosis Scheme In Use").GetTrimmedValueOrNull(),
                InvestigationSchemeInUse = csv.GetField<string>("Investigation Scheme In Use").GetTrimmedValueOrNull(),
                TreatmentSchemeInUse = csv.GetField<string>("Treatment Scheme In Use").GetTrimmedValueOrNull(),
                HRGCode = csv.GetField<string>("HRG Code").GetTrimmedValueOrNull(),
                HRGVersionNumber = csv.GetField<string>("HRG Version Number").GetTrimmedValueOrNull(),
                ProcedureSchemeInUse = csv.GetField<string>("Procedure Scheme In Use").GetTrimmedValueOrNull(),
                DominantGroupingVariableProcedure = csv.GetField<string>("Dominant Grouping Variable - Procedure").GetTrimmedValueOrNull(),
                FCEHRG = csv.GetField<string>("FCE HRG").GetTrimmedValueOrNull(),
                SpellCOREHRGVersionNo = csv.GetField<string>("Spell CORE HRG Version No").GetTrimmedValueOrNull(),
                PBRGeneratedCoreHRGforInformation = csv.GetField<string>("PBR Generated Core HRG (for Information)").GetTrimmedValueOrNull(),
                PBRGeneratedCoreHRGVersionforInformation = csv.GetField<string>("PBR Generated Core HRG Version (for Information)").GetTrimmedValueOrNull(),
                UniqueBookingReferenceNumberConverted = csv.GetField<string>("Unique Booking Reference Number Converted").GetTrimmedValueOrNull(),
                PatientPathwayIdentifier = csv.GetField<string>("Patient Pathway Identifier").GetTrimmedValueOrNull(),
                OrganisationCodePatientPathwayIdentifierIssuer = csv.GetField<string>("Organisation Code Patient Pathway Identifier Issuer").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodStatus = csv.GetField<string>("Referral To Treatment Period Status").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodStartDate = csv.GetField<string>("Referral To Treatment Period Start Date").GetTrimmedValueOrNull(),
                ReferralToTreatmentPeriodEndDate = csv.GetField<string>("Referral To Treatment Period End Date").GetTrimmedValueOrNull(),
                LeadCareActivityIndicator = csv.GetField<string>("Lead Care Activity Indicator").GetTrimmedValueOrNull(),
                AgeatCDSActivityDate = csv.GetField<string>("Age at CDS Activity Date").GetTrimmedValueOrNull(),
                NHSServiceAgreementChangeDate = csv.GetField<string>("NHS Service Agreement Change Date").GetTrimmedValueOrNull(),
                CDSActivityDate = csv.GetField<string>("CDS Activity Date").GetTrimmedValueOrNull(),
                AEDepartmentType = csv.GetField<string>("A&E Department Type").GetTrimmedValueOrNull(),
                XMLVersion = csv.GetField<string>("XML Version").GetTrimmedValueOrNull(),
                ConfidentialityCategoryDerived = csv.GetField<string>("Confidentiality Category (Derived)").GetTrimmedValueOrNull(),
                ReferralToTreatmentLengthDerived = csv.GetField<string>("Referral To Treatment Length (Derived)").GetTrimmedValueOrNull(),
                AEAssessmentWaitTime = csv.GetField<string>("AE Assessment Wait Time").GetTrimmedValueOrNull(),
                AEConclusionWaitTime = csv.GetField<string>("AE Conclusion Wait Time").GetTrimmedValueOrNull(),
                AEDuration = csv.GetField<string>("AE Duration").GetTrimmedValueOrNull(),
                AETreatmentWait = csv.GetField<string>("AE Treatment Wait").GetTrimmedValueOrNull(),
                AgerangepatientderivedfromDOB = csv.GetField<string>("Age range patient derived from DOB").GetTrimmedValueOrNull(),
                AreaCodeDerivedFromPostcode = csv.GetField<string>("Area code derived from postcode.").GetTrimmedValueOrNull(),
                CDSGroup = csv.GetField<string>("CDS Group").GetTrimmedValueOrNull(),
                FinishedIndicator = csv.GetField<string>("Finished Indicator").GetTrimmedValueOrNull(),
                PCTDerivedfromGP = csv.GetField<string>("PCT (Derived from GP)").GetTrimmedValueOrNull(),
                PCTTypeDerivedfromGP = csv.GetField<string>("PCT Type (Derived from GP)").GetTrimmedValueOrNull(),
                GPPracticeDerived = csv.GetField<string>("GP Practice (Derived)").GetTrimmedValueOrNull(),
                PCTDerivedfromderivedGPPractice = csv.GetField<string>("PCT (Derived from derived GP Practice)").GetTrimmedValueOrNull(),
                SHAfromGPPractice = csv.GetField<string>("SHA from GP Practice").GetTrimmedValueOrNull(),
                SHATypefromGPPractice = csv.GetField<string>("SHA Type from GP Practice").GetTrimmedValueOrNull(),
                MonthOfBirth = csv.GetField<string>("Month of Birth").GetTrimmedValueOrNull(),
                ElectoralWardFromPostcode = csv.GetField<string>("Electoral Ward from postcode").GetTrimmedValueOrNull(),
                PCTfrompostcode = csv.GetField<string>("PCT from postcode").GetTrimmedValueOrNull(),
                PCTTypefromPostcode = csv.GetField<string>("PCT Type from Postcode").GetTrimmedValueOrNull(),
                SHAfromPostcode = csv.GetField<string>("SHA from Postcode").GetTrimmedValueOrNull(),
                SHATypefromPostcode = csv.GetField<string>("SHA Type from Postcode").GetTrimmedValueOrNull(),
                AreaCodeFromProviderPostcode = csv.GetField<string>("Area code from Provider Postcode").GetTrimmedValueOrNull(),
                AgeAtEndOfEpisode = csv.GetField<string>("Age at End of Episode").GetTrimmedValueOrNull(),
                AgeAtStartOfEpisode = csv.GetField<string>("Age at Start of Episode").GetTrimmedValueOrNull(),
                YearOfBirth = csv.GetField<string>("Year of Birth").GetTrimmedValueOrNull(),
                CensusArea = csv.GetField<string>("2001 Census Area").GetTrimmedValueOrNull(),
                Country = csv.GetField<string>("Country").GetTrimmedValueOrNull(),
                CountyCode = csv.GetField<string>("County Code").GetTrimmedValueOrNull(),
                CensusED = csv.GetField<string>("1991 Census ED").GetTrimmedValueOrNull(),
                EDDistrictCode = csv.GetField<string>("ED District Code").GetTrimmedValueOrNull(),
                ElectoralWardCode = csv.GetField<string>("Electoral Ward Code").GetTrimmedValueOrNull(),
                GORCode = csv.GetField<string>("GOR Code").GetTrimmedValueOrNull(),
                LocalUnitaryAuthority = csv.GetField<string>("Local Unitary Authority").GetTrimmedValueOrNull(),
                OldSHACode = csv.GetField<string>("Old SHA Code").GetTrimmedValueOrNull(),
                ElectoralArea = csv.GetField<string>("1998 Electoral Area").GetTrimmedValueOrNull(),
                PrimeRecipient = csv.GetField<string>("Prime Recipient").GetTrimmedValueOrNull(),
                CopyRecipients = csv.GetField<string>("Copy Recipients").GetTrimmedValueOrNull(),
            };

            int index = 73;

            for (int i = 0; i < 24; i++)
            {
                var diagnosis = new SusAEDiagnosis
                {
                    MessageId = messageId,
                    AccidentAndEmergencyDiagnosis = csv[++index].GetTrimmedValueOrNull()
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
                    AccidentAndEmergencyInvestigation = csv[++index].GetTrimmedValueOrNull()
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
                    AccidentAndEmergencyTreatment = csv[++index].GetTrimmedValueOrNull()
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