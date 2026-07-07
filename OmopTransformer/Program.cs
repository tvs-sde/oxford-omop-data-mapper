using System.Runtime.CompilerServices;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OmopTransformer.ConceptResolution;
using OmopTransformer.COSD;
using OmopTransformer.COSD.Staging;
using OmopTransformer.Documentation;
using OmopTransformer.Init;
using OmopTransformer.Omop;
using OmopTransformer.Omop.CareSite;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Omop.Death;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.Omop.Location;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Omop.Person;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Omop.Provider;
using OmopTransformer.Omop.Prune;
using OmopTransformer.Omop.VisitDetail;
using OmopTransformer.Omop.VisitOccurrence;
using OmopTransformer.OxfordGP;
using OmopTransformer.OxfordGP.Staging;
using OmopTransformer.OxfordGP.Staging.Clearing;
using OmopTransformer.OxfordLab;
using OmopTransformer.OxfordPrescribing;
using OmopTransformer.OxfordSpineDeath;
using OmopTransformer.RTDS;
using OmopTransformer.RTDS.Parser;
using OmopTransformer.Rtds.Staging;
using OmopTransformer.RTDS.Staging;
using OmopTransformer.SACT;
using OmopTransformer.SACT.Staging;
using OmopTransformer.SUS.AE;
using OmopTransformer.SUS.APC;
using OmopTransformer.SUS.OP;
using OmopTransformer.SUS.Staging.AE;
using OmopTransformer.SUS.Staging.AE.Clearing;
using OmopTransformer.SUS.Staging.Inpatient;
using OmopTransformer.SUS.Staging.Inpatient.APC;
using OmopTransformer.SUS.Staging.Inpatient.CCMDS;
using OmopTransformer.SUS.Staging.Inpatient.Clearing;
using OmopTransformer.SUS.Staging.OP;
using OmopTransformer.SUS.Staging.OP.Clearing;
using OmopTransformer.Transformation;

[assembly: InternalsVisibleTo("OmopTransformerTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
namespace OmopTransformer;

internal class Program
{
    private static async Task ActionMustBeSpecifiedError() => await Console.Error.WriteLineAsync("Action flag must be specified.");
    private static async Task UnknownActionMustBeSpecifiedError(string actionName) => await Console.Error.WriteLineAsync($"Unknown action {actionName}.");

    private static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        var result = Parser.Default.ParseArguments<StagingOptions, DocumentationOptions, TransformOptions, FinaliseOptions, InitOptions>(args);

        if (result.Value == null)
        {
            return;
        }

        var queryLocator = await QueryLocator.Create();
        builder.Services.AddSingleton<IQueryLocator, QueryLocator>(_ => queryLocator);


        if (result.Value is InitOptions)
        {
            builder.Services.AddTransient<IInitiation, Initiation>();
            builder.Services.AddHostedService<InitHostedService>();
        }

        if (result.Value is DocumentationOptions generateDocumentation)
        {
            var dataDictionaryUrlResolver = await DataDictionaryUrlResolver.CreateAsync(queryLocator);
            builder.Services.AddSingleton<DataDictionaryUrlResolver>(_ => dataDictionaryUrlResolver);

            builder.Services.AddTransient(_ => generateDocumentation);
            builder.Services.AddHostedService<DocumentationGenerationHostedService>();
        }

        if (result.Value is StagingOptions stagingOptions)
        {
            builder.Services.AddSingleton<IDataOptOut, DataOptOut>();
            builder.Services.AddTransient(_ => stagingOptions);

            if (string.Equals(stagingOptions.Type, "cosd", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<ICosdStaging, CosdStaging>();
                        builder.Services.AddHostedService<CosdLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<CosdClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "sact", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<ISactInserter, SactInserter>();
                        builder.Services.AddTransient<ISactStaging, SactStaging>();
                        builder.Services.AddHostedService<SactLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<SactClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "rtds", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<IRtdsInserter, RtdsInserter>();
                        builder.Services.AddTransient<IRtdsInserter, RtdsInserter>();
                        builder.Services.AddTransient<IRtdsStaging, RtdsStaging>();
                        builder.Services.AddHostedService<RtdsLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<RtdsClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "sus-apc", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<ISusAPCInserter, SusApcInserter>();
                        builder.Services.AddTransient<ISusAPCParser, SusAPCParser>();
                        builder.Services.AddTransient<ISusCCMDSInserter, SusCCMDSInserter>();
                        builder.Services.AddTransient<ISusCCMDSParser, SusCCMDSParser>();

                        builder.Services.AddTransient<ISusInpatientStaging, SusInpatientStaging>();

                        builder.Services.AddHostedService<SusInpatientLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<SusInpatientClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "sus-op", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<ISusOPInserter, SusOPInserter>();
                        builder.Services.AddTransient<ISusOPParser, SusOPParser>();
                        builder.Services.AddTransient<ISusOPStaging, SusOPStaging>();
                        builder.Services.AddHostedService<SusOPLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<SusOPClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "sus-ae", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<ISusAEInserter, SusAEInserter>();
                        builder.Services.AddTransient<ISusAEParser, SusAEParser>();
                        builder.Services.AddTransient<ISusAEStaging, SusAEStaging>();
                        builder.Services.AddHostedService<SusAELoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<SusAEClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else if (string.Equals(stagingOptions.Type, "oxford-gp", StringComparison.OrdinalIgnoreCase))
            {
                if (stagingOptions.Action == null)
                {
                    await ActionMustBeSpecifiedError();
                    return;
                }

                switch (stagingOptions.Action.ToLower())
                {
                    case "load":
                        builder.Services.AddTransient<IOxfordGPRecordInserter, OxfordGPRecordInserter>();
                        builder.Services.AddTransient<IOxfordGPParser, OxfordGPParser>();
                        builder.Services.AddTransient<IOxfordGPStaging, OxfordGPStaging>();
                        builder.Services.AddHostedService<OxfordGPLoadStagingHostedService>();
                        break;
                    case "clear":
                        builder.Services.AddHostedService<OxfordGPClearStagingHostedService>();
                        break;
                    default:
                        await UnknownActionMustBeSpecifiedError(stagingOptions.Action);
                        return;
                }
            }
            else
            {
                await Console.Error.WriteLineAsync($"Unknown staging type {stagingOptions.Type}.");
                return;
            }
        }

        if (result.Value is TransformOptions transformOptions)
        {
            builder.Services.AddTransient(_ => transformOptions);
            builder.Services.AddTransient<IRunAnalysisRecorder, RunAnalysisRecorder>();
            builder.Services.AddTransient<ILocationRecorder, LocationRecorder>();
            builder.Services.AddTransient<IPersonRecorder, PersonRecorder>();
            builder.Services.AddTransient<IConditionOccurrenceRecorder, ConditionOccurrenceRecorder>();
            builder.Services.AddTransient<IVisitOccurrenceRecorder, VisitOccurrenceRecorder>();
            builder.Services.AddTransient<IVisitDetailRecorder, VisitDetailRecorder>();
            builder.Services.AddTransient<IDeathRecorder, DeathRecorder>();
            builder.Services.AddTransient<IProcedureOccurrenceRecorder, ProcedureOccurrenceRecorder>();
            builder.Services.AddTransient<IDrugExposureRecorder, DrugExposureRecorder>();
            builder.Services.AddTransient<IDeviceExposureRecorder, DeviceExposureRecorder>();
            builder.Services.AddTransient<IObservationRecorder, ObservationRecorder>();
            builder.Services.AddTransient<IMeasurementRecorder, MeasurementRecorder>();
            builder.Services.AddTransient<ICareSiteRecorder, CareSiteRecorder>();
            builder.Services.AddTransient<IProviderRecorder, ProviderRecorder>();

            if (string.Equals(transformOptions.Type, "cosd", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<CosdTransformer>();
                builder.Services.AddHostedService<CosdTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "sact", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<SactTransformer>();
                builder.Services.AddHostedService<SactTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "rtds", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<RtdsTransformer>();
                builder.Services.AddHostedService<RtdsTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "sus-apc", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<SusAPCTransformer>();
                builder.Services.AddHostedService<SusAPCTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "sus-op", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<SusOPTransformer>();
                builder.Services.AddHostedService<SusOPTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "sus-ae", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<SusAETransformer>();
                builder.Services.AddHostedService<SusAETransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "oxford-gp", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<OxfordGPTransformer>();
                builder.Services.AddHostedService<OxfordGPTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "oxford-prescribing", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<OxfordPrescribingTransformer>();
                builder.Services.AddHostedService<OxfordPrescribingTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "oxford-lab", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<OxfordLabTransformer>();
                builder.Services.AddHostedService<OxfordLabTransformHostedService>();
            }
            else if (string.Equals(transformOptions.Type, "oxford-death", StringComparison.OrdinalIgnoreCase))
            {
                builder.Services.AddTransient<OxfordSpineDeathTransformer>();
                builder.Services.AddHostedService<OxfordSpineDeathTransformHostedService>();
            }
            else
            {
                await Console.Error.WriteLineAsync($"Unknown transform type {transformOptions.Type}.");
            }
        }

        if (result.Value is FinaliseOptions)
        {
            builder.Services.AddTransient<OmopFinaliser>();
            builder.Services.AddHostedService<FinaliseTransformHostedService>();
        }

        builder.Services.AddTransient<IDocumentationWriter, DocumentationWriter>();
        builder.Services.AddTransient<IRecordTransformer, RecordTransformer>();
        builder.Services.AddTransient<IRecordProvider, RecordProvider>();
        builder.Services.AddTransient<ICosdStagingSchema, CosdStagingSchema>();
        builder.Services.AddTransient<ISactStagingSchema, SactStagingSchema>();
        builder.Services.AddTransient<IRtdsStagingSchema, RtdsStagingSchema>();
        builder.Services.AddTransient<ISusInpatientStagingSchema, SusInpatientStagingSchema>();
        builder.Services.AddTransient<ISusOPStagingSchema, SusOPStagingSchema>();
        builder.Services.AddTransient<ISusAEStagingSchema, SusAEStagingSchema>();
        builder.Services.AddSingleton<Icd10NonStandardResolver>();
        builder.Services.AddSingleton<Icd10StandardResolver>();
        builder.Services.AddSingleton<Opcs4Resolver>();
        builder.Services.AddSingleton<Icdo3Resolver>();
        builder.Services.AddSingleton<SnomedResolver>();
        builder.Services.AddTransient<IStandardConceptResolverDataProvider, StandardConceptResolverDataProvider>();
        builder.Services.AddSingleton<StandardConceptResolver>();
        builder.Services.AddSingleton<MeasurementMapsToValueResolver>();

        IHostEnvironment env = builder.Environment;

        builder.Configuration
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        builder.Services.Configure<Configuration>(builder.Configuration);

        using IHost host = builder.Build();

        await host.RunAsync();
    }
}

[Verb("stage", HelpText = "Handles staging operations.")]
public class StagingOptions
{
    [Value(0, MetaName = "action", Required = true, HelpText = "Action to be performed (e.g., load).")]
    public string? Action { get; set; }

    [Option('t', "type", Required = false, HelpText = "Type of the data source (e.g., cosd, sact).")]
    public string? Type { get; set; }

    [Value(1, MetaName = "filename", Required = false, HelpText = "Filename to be processed (e.g., file.zip).")]
    public string? FileName { get; set; }

    [Option("ccmds", Required = false, HelpText = "CCMDS filename for sus-apc transforms.")]
    public string? CCMDSFileName { get; set; }

    [Option("allowed_nhs_number_list_path", Required = false, HelpText = "File that contains a list of allowed patient NHSNumbers. If specified this argument prevents data for patients that are outside of this list from being staged and transformed.")]
    public string? AllowedListNhsNumber { get; set; }

    [Option("demographics", Required = false, HelpText = "Path to demographics CSV file (required when type is oxford-gp).")]
    public string? Demographics { get; set; }

    [Option("appointments", Required = false, HelpText = "Path to appointments CSV file (required when type is oxford-gp).")]
    public string? Appointments { get; set; }

    [Option("events", Required = false, HelpText = "Path to events CSV file (required when type is oxford-gp).")]
    public string? Events { get; set; }

    [Option("medications", Required = false, HelpText = "Path to medications CSV file (required when type is oxford-gp).")]
    public string? Medications { get; set; }

}

[Verb("transform", HelpText = "Handles transformation operations.")]
public class TransformOptions
{
    [Option('t', "type", Required = true, HelpText = "Type of the transformation (e.g., sus-op).")]
    public string? Type { get; set; }

    [Option('d', "duckdb-source", Required = false, HelpText = "DuckDB source, eg 'read_csv('\\data\\medication_results_short.csv', all_varchar=true)'.")]
    public string? DuckdbSource { get; set; }

    [Option("dry-run", Required = false, Default = false, HelpText = "Run the transformation in dry-run mode.")]
    public bool DryRun { get; set; }

    [Option("batch-size", Required = false, Default = 4000000, HelpText = "Number of records to process in each batch (default 10,000).")]
    public int BatchSize { get; set; }
}

[Verb("finalise", HelpText = "Prunes incomplete OMOP records. Builds era tables.")]
public class FinaliseOptions
{
}

[Verb("docs", HelpText = "Documentation generation.")]
public class DocumentationOptions
{
    [Value(0, MetaName = "filename", Required = true, HelpText = "Target path for the generated documentation.")]
    public string? DirectoryPath { get; set; }
}

[Verb("init", HelpText = "Create database and import vocabulary.")]
public class InitOptions
{
}