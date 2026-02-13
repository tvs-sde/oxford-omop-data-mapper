using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer;

[Description("Resolve ICD-O-3 morphology codes to OMOP concepts. This selector handles morphology-only codes (not requiring separate topography).")]
internal class Icdo3MorphologySelector(string? morphologyCode, Icdo3Resolver icdo3Resolver) : ISelector
{
    public object? GetValue() => icdo3Resolver.GetConceptCode(morphologyCode);
}
