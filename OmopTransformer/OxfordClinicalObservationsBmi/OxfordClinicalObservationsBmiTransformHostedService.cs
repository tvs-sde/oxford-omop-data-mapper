using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.OxfordClinicalObservationsBmi;

internal class OxfordClinicalObservationsBmiTransformHostedService : FinalHostedService
{
    private readonly OxfordClinicalObservationsBmiTransformer _transformer;

    public OxfordClinicalObservationsBmiTransformHostedService(
        IHostApplicationLifetime appLifetime,
        ILogger<FinalHostedService> logger,
        OxfordClinicalObservationsBmiTransformer transformer) : base(appLifetime, logger)
    {
        _transformer = transformer;
    }

    protected override async Task RunTask(CancellationToken cancellationToken)
    {
        await _transformer.Transform(cancellationToken);
    }
}
