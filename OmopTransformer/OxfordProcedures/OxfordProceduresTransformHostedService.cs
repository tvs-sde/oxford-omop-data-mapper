using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.OxfordProcedures;

internal class OxfordProceduresTransformHostedService : FinalHostedService
{
    private readonly OxfordProceduresTransformer _transformer;

    public OxfordProceduresTransformHostedService(
        IHostApplicationLifetime appLifetime,
        ILogger<FinalHostedService> logger,
        OxfordProceduresTransformer transformer) : base(appLifetime, logger)
    {
        _transformer = transformer;
    }

    protected override async Task RunTask(CancellationToken cancellationToken)
    {
        await _transformer.Transform(cancellationToken);
    }
}
