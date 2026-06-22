    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    namespace OmopTransformer.OxfordGP.Staging.Clearing;

internal class OxfordGPStagingSchema : StagingSchema, IOxfordGPStagingSchema
{
    public OxfordGPStagingSchema(IOptions<Configuration> configuration, ILogger<OxfordGPStagingSchema> logger) : base(configuration, logger)
    {
    }

    protected override string[] ClearStagingSql =>
    [
        "truncate table omop_staging.oxford_gp_medication;",
        "truncate table omop_staging.oxford_gp_event;",
        "truncate table omop_staging.oxford_gp_demographic;",
        "truncate table omop_staging.oxford_gp_appointment;",
    ];
}