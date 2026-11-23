using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns;

internal class OxfordClinicalObservationsVitalSignsTransformHostedService : FinalHostedService
{
    private readonly OxfordClinicalObservationsVitalSignsTransformer _transformer;

    public OxfordClinicalObservationsVitalSignsTransformHostedService(
        IHostApplicationLifetime appLifetime,
        ILogger<FinalHostedService> logger,
        OxfordClinicalObservationsVitalSignsTransformer transformer) : base(appLifetime, logger)
    {
        _transformer = transformer;
    }

    protected override Task RunTask(CancellationToken cancellationToken) => _transformer.Transform(cancellationToken);
}
