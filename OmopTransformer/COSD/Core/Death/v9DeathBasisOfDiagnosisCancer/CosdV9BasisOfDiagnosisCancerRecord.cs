using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.Death.v9DeathBasisOfDiagnosisCancer;

[DataOrigin("COSD")]
[Description("COSD v9 BasisOfDiagnosisCancer")]
[SourceQuery("CosdV9BasisOfDiagnosisCancer.xml")]
internal class CosdV9BasisOfDiagnosisCancerRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? DeathDate { get; set; }
}