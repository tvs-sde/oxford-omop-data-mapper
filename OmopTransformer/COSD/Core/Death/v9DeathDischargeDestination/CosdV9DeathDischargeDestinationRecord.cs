using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Core.Death.v9DeathDischargeDestination;

[DataOrigin("COSD")]
[Description("COSD v9 DeathDischargeDestination")]
[SourceQuery("CosdV9DeathDischargeDestination.xml")]
internal class CosdV9DeathDischargeDestinationRecord
{
    public string? NhsNumber { get; set; }
    public string? DeathDate { get; set; }
}