using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.ConceptResolution;

internal class StandardConceptResolver
{
    private readonly ILogger<StandardConceptResolver> _logger;
    private readonly IStandardConceptResolverDataProvider _dataProvider;

    private Dictionary<int, IGrouping<int, ConceptCodeMapRow>>? _mappings;
    private Dictionary<int, IReadOnlyCollection<int>>? _devicesByConceptId;

    private readonly object _loadingLock = new();
    private DomainMapResults? _domainMappingResults;

    public StandardConceptResolver(ILogger<StandardConceptResolver> logger, IStandardConceptResolverDataProvider dataProvider)
    {
        _logger = logger;
        _dataProvider = dataProvider;
    }

    
    private void EnsureMapping()
    {
        if (_mappings != null) 
            return;

        lock (_loadingLock)
        {
            _mappings ??= _dataProvider.GetMappings();

            if (_mappings.Count == 0)
            {
                throw new InvalidOperationException("concept_code_map table is empty. Call stored procedure omop_staging.generate_concept_code_map first.");
            }
        }
    }

    private void EnsureDeviceMapping()
    {
        lock (_loadingLock)
        {
            _devicesByConceptId ??= _dataProvider.GetDevices();
        }
    }
    
    private static int? ResolveConcept(ConceptCodeMapRow conceptCodeMapRow, string domain)
    {
        const int unknownConceptId = 0;

        // Standard or non standard with relationship with standard concept in concept correct domain
        if (conceptCodeMapRow.target_domain_id == domain && conceptCodeMapRow.target_concept_id.HasValue)
        {
            return conceptCodeMapRow.target_concept_id;
        }


        //Non standard or Standard concept in wrong domain

        if (conceptCodeMapRow.target_domain_id != domain && conceptCodeMapRow.target_concept_id.HasValue)
        {
            return null;
        }

        //Non standard concept in wrong domain with no relationship to standard 

        if (conceptCodeMapRow.mapped_from_standard == 0 && conceptCodeMapRow.source_domain_id != domain && conceptCodeMapRow.target_concept_id.HasValue == false)
        {
            return null;
        }

        // Non standard concept in correct domain with no relationship to standard
        if (conceptCodeMapRow.mapped_from_standard == 0 && conceptCodeMapRow.source_domain_id == domain && conceptCodeMapRow.target_concept_id.HasValue == false)
        {
            return unknownConceptId;
        }

        return null;
    }

    public int[] GetConcepts(int conceptId, string? domain)
    {
        EnsureMapping();

        const int unknownConceptId = 0;

        var unknownConcept = new[] { unknownConceptId };

        //| Domain Constraint | Input | Source Concept Id | Concept Id |
        //| -------------------| -------| ------------------| ------------|
        //| No | Unknown concept | 0 | 0 |
        //| No | Standard concept | 456 | 456 |
        //| No | Non standard concept with no relationship to standard | 123 | 0 |
        //| No | Non standard concept with relationship to standard | 123 | 456 |
        //| Yes | Unknown concept | 0 | 0 |
        //| Yes | Standard concept correct domain | 456 | 456 |
        //| Yes | Non standard concept with relationship to standard in correct domain | 123 | 456 |
        //| Yes | Non standard concept in correct domain with no relationship to standard | 123 | 0 |
        //| Yes | Standard concept wrong domain | null | null |
        //| Yes | Non standard concept in wrong domain with no relationship to standard | null | null |
        //| Yes | Non standard concept with relationship to standard in wrong domain | null | null


        if (domain == null)
        {
            if (_mappings!.TryGetValue(conceptId, out var value))
            {
                if (value.Any(row => row.target_concept_id.HasValue == false))
                {
                    // Non standard concept with no relationship to standard

                    return unknownConcept;
                }

                // Standard concept or Non standard concept with relationship to standard
                return
                    value
                        .Select(row => row.target_concept_id!.Value)
                        .ToArray();
            }

            // Unknown concept
            return unknownConcept;
        }
        else
        {
            if (_mappings!.TryGetValue(conceptId, out var value))
            {

                var resolvedConcepts =
                    value
                        .Select(row => ResolveConcept(row, domain))
                        .Where(result => result.HasValue)
                        .Select(result => result!.Value)
                        .ToArray();

                if (resolvedConcepts.Length > 0)
                {
                    return resolvedConcepts;
                }


                _domainMappingResults ??= new DomainMapResults(domain);

                // Log domain of standard version of input concept, if exists
                foreach (var row in value)
                {
                    if (row.target_domain_id != null)
                        _domainMappingResults.Record(row.target_domain_id!);
                }

                return resolvedConcepts;
            }

            return unknownConcept;
        }
    }

    public IReadOnlyCollection<int> GetConceptDevices(int conceptId)
    {
        EnsureDeviceMapping();

        if (_devicesByConceptId!.TryGetValue(conceptId, out var devices))
        {
            return devices.ToArray();
        }

        return new int[] { };
    }

    public void PrintLogsAndResetLogger()
    {
        _domainMappingResults?.PrintResults(_logger);
        _domainMappingResults = null;
    }

    private class DomainMapResults
    {
        public DomainMapResults(string intendedDomain)
        {
            _intendedDomain = intendedDomain;
        }

        private readonly ConcurrentDictionary<string, int> _domainCounts = new();
        private readonly string _intendedDomain;

        public void Record(string domain)
        {
            _domainCounts.AddOrUpdate(domain, 1, (_, count) => count + 1);
        }

        public void PrintResults(ILogger<StandardConceptResolver> logger)
        {
            if (_domainCounts.Count == 0)
                return;

            if (_domainCounts.Count == 1 && _domainCounts.ContainsKey(_intendedDomain))
                return;

            long total = _domainCounts.Sum(count => count.Value);

            string logText = $"Source concepts intended for domain {_intendedDomain} were mapped to the following domains:" + Environment.NewLine;

            foreach (var domainCount in _domainCounts.OrderByDescending(count => count.Value))
            {
                var percentage = domainCount.Value * 100d / total;
                logText += $"   - Domain: {domainCount.Key}. Count: {domainCount.Value}. Percentage: {Math.Round(percentage, 2)}%." + Environment.NewLine;
            }

            logger.LogInformation(logText);
        }
    }
}