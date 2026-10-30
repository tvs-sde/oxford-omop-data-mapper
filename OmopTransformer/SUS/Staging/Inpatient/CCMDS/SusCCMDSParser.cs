namespace OmopTransformer.SUS.Staging.Inpatient.CCMDS;

internal class SusCCMDSParser : ISusCCMDSParser
{
    public IEnumerable<CCMDSRecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = CsvReaderExtensions.CreateReader(reader);

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var activityCodes = new List<CCMDSCriticalCareActivityCode>();
            var highCostDrugs = new List<CCMDSCriticalCareHighCostDrugs>();

            Guid messageId = Guid.NewGuid();

            var record = new CCMDSRow
            {
                MessageId = messageId,
                GeneratedRecordID = csv.GetString("Generated Record ID").GetTrimmedValueOrNull(),
                LoadStagingDate = csv.GetString("Load Staging Date").GetTrimmedValueOrNull(),
                CriticalCarePeriodSequenceNumber = csv.GetString("Critical Care Period Sequence Number").GetTrimmedValueOrNull(),
                CDSVersionontheepisodes = csv.GetString("CDS Version on the episodes").GetTrimmedValueOrNull(),
                HESEPITYPEoftheepisode = csv.GetString("HES EPITYPE of the episode").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetString("CDS Interchange ID").GetTrimmedValueOrNull(),
                HESEPISTAToftheepisode = csv.GetString("HES EPISTAT of the episode").GetTrimmedValueOrNull(),
                EventDate = csv.GetString("Event Date").GetTrimmedValueOrNull(),
                ActivityDateCriticalCare = csv.GetString("Activity Date (Critical Care)").GetTrimmedValueOrNull(),
                CriticalCarePeriodType = csv.GetString("Critical Care Period Type").GetTrimmedValueOrNull(),
                CriticalCareEpisodeRelationship = csv.GetString("Critical Care Episode Relationship").GetTrimmedValueOrNull(),
                CriticalCareUnitFunction = csv.GetString("Critical Care Unit Function").GetTrimmedValueOrNull(),
                CriticalCareStartDate = csv.GetString("Critical Care Start Date").GetTrimmedValueOrNull(),
                CriticalCareStartTime = csv.GetString("Critical Care Start Time").GetTrimmedValueOrNull(),
                CriticalCarePeriodDischargeDate = csv.GetString("Critical Care Period Discharge Date").GetTrimmedValueOrNull(),
                CriticalCarePeriodDischargeTime = csv.GetString("Critical Care Period Discharge Time").GetTrimmedValueOrNull(),
                CriticalCarePeriodLocalIdentifier = csv.GetString("Critical Care Period Local Identifier").GetTrimmedValueOrNull(),
                GestationLengthAtDelivery = csv.GetString("Gestation Length At Delivery").GetTrimmedValueOrNull(),
                CriticalCareSequenceNumberDerived = csv.GetString("Critical Care Sequence Number (Derived)").GetTrimmedValueOrNull(),
                TotalnumberofCriticalCareActivitiesDerived = csv.GetString("Total number of Critical Care Activities (Derived)").GetTrimmedValueOrNull(),
                LastRecordforthisCriticalCarePeriodIndicatorDerived = csv.GetString("Last Record for this Critical Care Period Indicator (Derived)").GetTrimmedValueOrNull(),
                CriticalCareActivitytoEpisodeRelationshipDerived = csv.GetString("Critical Care Activity to Episode Relationship (Derived)").GetTrimmedValueOrNull(),
                PersonWeight = csv.GetString("Person Weight").GetTrimmedValueOrNull()
            };

            int index = 22;

            for (int i = 0; i < 20; i++)
            {
                var activityCode = new CCMDSCriticalCareActivityCode
                {
                    MessageId = messageId,
                    CriticalCareActivityCode = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (activityCode.IsEmpty)
                    break;

                activityCodes.Add(activityCode);
            }

            index = 42;

            for (int i = 0; i < 20; i++)
            {
                var highCostDrug = new CCMDSCriticalCareHighCostDrugs
                {
                    MessageId = messageId,
                    CriticalCareHighCostDrugs = csv.GetString(++index).GetTrimmedValueOrNull()
                };

                if (highCostDrug.IsEmpty)
                    break;

                highCostDrugs.Add(highCostDrug);
            }

            yield return
                new CCMDSRecord(
                    record,
                    activityCodes,
                    highCostDrugs);
        }
    }
}