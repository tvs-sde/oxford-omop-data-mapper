using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("DISCHARGE DESTINATION CODE (HOSPITAL PROVIDER SPELL)")]
internal class DischargeDestinationCodeHospitalProviderSpellLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "19", new ValueWithNote(null, "Usual place of residence unless listed below (includes private dwelling, wardened accommodation, and patients with no fixed abode; excludes residential accommodation where health care is provided)") },
            { "29", new ValueWithNote(null, "Temporary place of residence when usually resident elsewhere (includes hotel, residential educational establishment)") },
            { "30", new ValueWithNote(null, "Repatriation from high security psychiatric accommodation in an NHS hospital provider (NHS trust or NHS foundation trust)") },
            { "37", new ValueWithNote(null, "Court") },
            { "38", new ValueWithNote(null, "Penal establishment or police station") },
            { "48", new ValueWithNote(null, "High security psychiatric hospital, Scotland") },
            { "49", new ValueWithNote(null, "NHS other hospital provider - high security psychiatric accommodation") },
            { "50", new ValueWithNote(null, "NHS other hospital provider - medium secure unit") },
            { "51", new ValueWithNote(null, "NHS other hospital provider - ward for general patients or the younger physically disabled") },
            { "52", new ValueWithNote(null, "NHS other hospital provider - ward for maternity patients or neonates") },
            { "53", new ValueWithNote(null, "NHS other hospital provider - ward for patients who are mentally ill or have learning disabilities") },
            { "54", new ValueWithNote(null, "NHS run care home") },
            { "65", new ValueWithNote(null, "Local authority residential accommodation where care is provided") },
            { "66", new ValueWithNote(null, "Local authority foster care") },
            { "79", new ValueWithNote(null, "Not applicable - patient died or stillbirth") },
            { "84", new ValueWithNote(null, "Non-NHS run hospital - medium secure unit") },
            { "85", new ValueWithNote(null, "Non-NHS (other than local authority) run care home") },
            { "87", new ValueWithNote(null, "Non-NHS run hospital") },
            { "88", new ValueWithNote(null, "Non-NHS (other than local authority) run hospice") },
            { "98", new ValueWithNote(null, "Not applicable - hospital provider spell not finished at episode end (not discharged) or current episode unfinished") },
            { "99", new ValueWithNote(null, "Not known") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
