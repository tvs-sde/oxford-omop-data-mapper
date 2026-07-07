using System.Globalization;
using CsvHelper;

namespace OmopTransformer.SUS.Staging.Inpatient.CCMDS;

internal class SusCCMDSParser : ISusCCMDSParser
{
    public IEnumerable<CCMDSRecord> ReadFile(string path, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var activityCodes = new List<CCMDSCriticalCareActivityCode>();
            var highCostDrugs = new List<CCMDSCriticalCareHighCostDrugs>();

            Guid messageId = Guid.NewGuid();

            var record = new CCMDSRow
            {
                MessageId = messageId,
                GeneratedRecordID = csv.GetField<string>("Generated Record ID").GetTrimmedValueOrNull(),
                LoadStagingDate = csv.GetField<string>("Load Staging Date").GetTrimmedValueOrNull(),
                CriticalCarePeriodSequenceNumber = csv.GetField<string>("Critical Care Period Sequence Number").GetTrimmedValueOrNull(),
                CDSVersionontheepisodes = csv.GetField<string>("CDS Version on the episodes").GetTrimmedValueOrNull(),
                HESEPITYPEoftheepisode = csv.GetField<string>("HES EPITYPE of the episode").GetTrimmedValueOrNull(),
                CDSInterchangeID = csv.GetField<string>("CDS Interchange ID").GetTrimmedValueOrNull(),
                HESEPISTAToftheepisode = csv.GetField<string>("HES EPISTAT of the episode").GetTrimmedValueOrNull(),
                EventDate = csv.GetField<string>("Event Date").GetTrimmedValueOrNull(),
                ActivityDateCriticalCare = csv.GetField<string>("Activity Date (Critical Care)").GetTrimmedValueOrNull(),
                CriticalCarePeriodType = csv.GetField<string>("Critical Care Period Type").GetTrimmedValueOrNull(),
                CriticalCareEpisodeRelationship = csv.GetField<string>("Critical Care Episode Relationship").GetTrimmedValueOrNull(),
                CriticalCareUnitFunction = csv.GetField<string>("Critical Care Unit Function").GetTrimmedValueOrNull(),
                CriticalCareStartDate = csv.GetField<string>("Critical Care Start Date").GetTrimmedValueOrNull(),
                CriticalCareStartTime = csv.GetField<string>("Critical Care Start Time").GetTrimmedValueOrNull(),
                CriticalCarePeriodDischargeDate = csv.GetField<string>("Critical Care Period Discharge Date").GetTrimmedValueOrNull(),
                CriticalCarePeriodDischargeTime = csv.GetField<string>("Critical Care Period Discharge Time").GetTrimmedValueOrNull(),
                CriticalCarePeriodLocalIdentifier = csv.GetField<string>("Critical Care Period Local Identifier").GetTrimmedValueOrNull(),
                GestationLengthAtDelivery = csv.GetField<string>("Gestation Length At Delivery").GetTrimmedValueOrNull(),
                CriticalCareSequenceNumberDerived = csv.GetField<string>("Critical Care Sequence Number (Derived)").GetTrimmedValueOrNull(),
                TotalnumberofCriticalCareActivitiesDerived = csv.GetField<string>("Total number of Critical Care Activities (Derived)").GetTrimmedValueOrNull(),
                LastRecordforthisCriticalCarePeriodIndicatorDerived = csv.GetField<string>("Last Record for this Critical Care Period Indicator (Derived)").GetTrimmedValueOrNull(),
                CriticalCareActivitytoEpisodeRelationshipDerived = csv.GetField<string>("Critical Care Activity to Episode Relationship (Derived)").GetTrimmedValueOrNull(),
                PersonWeight = csv.GetField<string>("Person Weight").GetTrimmedValueOrNull()
            };

            int index = 22;

            for (int i = 0; i < 20; i++)
            {
                var activityCode = new CCMDSCriticalCareActivityCode
                {
                    MessageId = messageId,
                    CriticalCareActivityCode = csv[++index].GetTrimmedValueOrNull()
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
                    CriticalCareHighCostDrugs = csv[++index].GetTrimmedValueOrNull()
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