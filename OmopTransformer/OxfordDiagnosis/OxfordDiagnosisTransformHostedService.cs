using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.OxfordDiagnosis;

internal class OxfordDiagnosisTransformHostedService : FinalHostedService
{
    private readonly OxfordDiagnosisTransformer _transformer;

    public OxfordDiagnosisTransformHostedService(
        IHostApplicationLifetime appLifetime,
        ILogger<FinalHostedService> logger,
        OxfordDiagnosisTransformer transformer) : base(appLifetime, logger)
    {
        _transformer = transformer;
    }

    protected override async Task RunTask(CancellationToken cancellationToken)
    {
        await _transformer.Transform(cancellationToken);
    }
}
