using OmopTransformer.Annotations;
using OmopTransformer.Transformation;

namespace OmopTransformer;

[Description("Resolve ICD-o-3 codes to OMOP concepts.")]
internal class Icdo3Selector : ISelector
{
    private readonly string? _icdo3Code;
    private readonly Icdo3Resolver _icdo3Resolver;

    // Constructor for combined histology + topography
    public Icdo3Selector(string? histology, string? topography, Icdo3Resolver icdo3Resolver)
    {
        _icdo3Code = Icdo3Resolver.CovertHistologyTopographyToICDO3(histology, topography);
        _icdo3Resolver = icdo3Resolver;
    }

    // Constructor for single ICD-O-3 code
    public Icdo3Selector(string? icdo3Code, Icdo3Resolver icdo3Resolver)
    {
        _icdo3Code = icdo3Code;
        _icdo3Resolver = icdo3Resolver;
    }

    public object? GetValue() => _icdo3Resolver.GetConceptCode(_icdo3Code);
}