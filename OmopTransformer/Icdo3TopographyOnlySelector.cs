using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer;

/// <summary>
/// Resolves ICD-O-3 topography codes to OMOP concepts.
/// Created to handle cases where only topography is available (no histology/morphology).
/// Uses the ICDO3 vocabulary to map standalone topography codes.
/// </summary>
[Description("Resolve ICD-O-3 topography codes to OMOP concepts.")]
internal class Icdo3TopographyOnlySelector(string? topography, Icdo3Resolver icdo3Resolver) : ISelector
{
    public object? GetValue() => icdo3Resolver.GetConceptCode(topography);
}
