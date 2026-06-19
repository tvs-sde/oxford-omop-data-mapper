using Microsoft.Extensions.Logging;

namespace OmopTransformer.Transformation;

internal class RecordTransformLookupLogger
{
    private readonly Dictionary<string, LookupMissCount> _missCountByLookup = new();
    private readonly object _lock = new();

    public void Reset()
    {
        lock (_lock)
        {
            _missCountByLookup.Clear();
        }
    }

    public void Hit(ILookup lookup)
    {
        lock (_lock)
        {
            var counter = GetOrCreateMissCount(lookup.GetType().Name);

            counter.Hit();
        }
    }

    public void Miss(ILookup lookup, string value)
    {
        if (string.IsNullOrEmpty(value))
            return;

        lock (_lock)
        {
            var counter = GetOrCreateMissCount(lookup.GetType().Name);

            counter.Miss(value);
        }
    }

    private LookupMissCount GetOrCreateMissCount(string lookupName)
    {
        if (_missCountByLookup.TryGetValue(lookupName, out var counter))
        {
            return counter;
        }

        var lookupCounter = new LookupMissCount();

        _missCountByLookup.Add(lookupName, lookupCounter);

        return lookupCounter;
    }

    public void PrintLog(ILoggerFactory loggerFactory)
    {
        lock (_lock)
        {
            if (ShouldPrintLog(_missCountByLookup) == false)
                return;

            string logText = "Missed lookups" + Environment.NewLine;

            var missedLookupCounters =
                _missCountByLookup
                    .Where(counter => counter.Value.MissCount > 0)
                    .OrderByDescending(count => count.Value.MissCount);

            foreach (var countByLookup in missedLookupCounters)
            {
                logText += $"Lookup name: {countByLookup.Key} {Environment.NewLine}";

                var missRatePercentage = (countByLookup.Value.MissCount * 100d) / (countByLookup.Value.MissCount + countByLookup.Value.HitCount);

                logText += $"  Total miss rate {Math.Round(missRatePercentage, 2)}% ({countByLookup.Value.HitCount} hits, {countByLookup.Value.MissCount} misses){Environment.NewLine}";

                logText += "  Misses" + Environment.NewLine;

                foreach (var missCount in countByLookup.Value.MissCountByValue.OrderByDescending(count => count.Value))
                {
                    if (missCount.Value == 0)
                        continue;

                    logText += $"  - \"{missCount.Key}\" misses: {missCount.Value}{Environment.NewLine}";
                }

                logText += Environment.NewLine;
            }

            var logger = loggerFactory.CreateLogger("LookupTransformer");

            logger.LogWarning(logText);
        }
    }

    private static bool ShouldPrintLog(Dictionary<string, LookupMissCount> lookupCounts) =>
        lookupCounts
            .Any(count => count.Value.MissCount > 0);

    private class LookupMissCount
    {
        public int HitCount { get; private set; }
        public int MissCount { get; private set; }

        public readonly Dictionary<string, int> MissCountByValue = new();

        public void Hit()
        {
            HitCount++;
        }

        public void Miss(string value)
        {
            MissCount++;

            if (MissCountByValue.TryGetValue(value, out int count))
            {
                MissCountByValue[value] = ++count;
            }
            else
            {
                MissCountByValue.Add(value, value: 1);
            }
        }
    }
}