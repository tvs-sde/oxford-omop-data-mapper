using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer;

[Description("Resolve ICD-o-3 codes to OMOP concepts.")]
internal class Icdo3Selector(string? histology, string? topography,  Icdo3Resolver icdo3Resolver) : ISelector
{
    public object? GetValue() => icdo3Resolver.GetConceptCode(Icdo3Resolver.CovertHistologyTopographyToICDO3(histology, topography));
}