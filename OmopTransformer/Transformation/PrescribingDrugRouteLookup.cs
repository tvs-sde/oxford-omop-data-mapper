using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Prescribing Drug Routes to OMOP Condition Concept IDs")]
internal class PrescribingDrugRouteLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "affected eye(s)", new ValueWithNote("40549429", "ocular") },
            { "anal", new ValueWithNote("4290759", "rectal") },
            { "bath", new ValueWithNote("4263689", "topical") },
            { "both ears", new ValueWithNote("4023156", "otic") },
            { "both eyes", new ValueWithNote("40549429", "ocular") },
            { "buccal", new ValueWithNote("4181897", "buccal") },
            { "caudal", new ValueWithNote("4220455", "caudal") },
            { "chewed", new ValueWithNote("4132161", "oral") },
            { "dental", new ValueWithNote("4163765", "dental") },
            { "endotracheal", new ValueWithNote("40491832", "transtracheal") },
            { "enteral feed", new ValueWithNote("4167540", "enteral") },
            { "epidural", new ValueWithNote("4225555", "epidural") },
            { "flush", new ValueWithNote("0", "flush") },
            { "gastrojejunostomy", new ValueWithNote("4133177", "jejunostomy") },
            { "gastrostomy", new ValueWithNote("4132254", "gastrostomy") },
            { "gingival", new ValueWithNote("4156704", "gingival") },
            { "handihaler", new ValueWithNote("40486069", "respiratory tract") },
            { "inhalation", new ValueWithNote("40486069", "respiratory tract") },
            { "intraarterial", new ValueWithNote("4240824", "intra-arterial") },
            { "intraarticular", new ValueWithNote("4006860", "intra-articular") },
            { "intrabiliary", new ValueWithNote("4223965", "intrabiliary") },
            { "intracameral", new ValueWithNote("4303409", "intracameral") },
            { "intracardiac", new ValueWithNote("4156705", "intracardiac") },
            { "intracavernosal", new ValueWithNote("37174549", "intracorporus cavernosum") },
            { "intradermal", new ValueWithNote("4156706", "intradermal") },
            { "intradiscal", new ValueWithNote("4163769", "intradiscal") },
            { "intralesional", new ValueWithNote("4157758", "intralesional") },
            { "intralymphatic", new ValueWithNote("4157759", "intralymphatic") },
            { "intramuscular", new ValueWithNote("4302612", "intramuscular") },
            { "intramyometrial", new ValueWithNote("4168038", "intramyometrial") },
            { "intraocular", new ValueWithNote("4157760", "intraocular") },
            { "intraosseous", new ValueWithNote("4213522", "intraosseous") },
            { "intraperitoneal", new ValueWithNote("4243022", "intraperitoneal") },
            { "intrapleural", new ValueWithNote("4156707", "intrapleural") },
            { "intrathecal", new ValueWithNote("4217202", "intrathecal") },
            { "intratracheal", new ValueWithNote("4229543", "intratracheal") },
            { "intraurethral", new ValueWithNote("4305382", "transurethral") },
            { "intrauterine", new ValueWithNote("4269621", "intrauterine") },
            { "intra", new ValueWithNote("4171047", "intra") },
            { "intravenous", new ValueWithNote("4171047", "intravenous") },
            { "intravenous (central)", new ValueWithNote("4170113", "intravenous central") },
            { "intraventricular", new ValueWithNote("4222259", "intraventricular route - cardiac") },
            { "intravesical", new ValueWithNote("4186838", "intravesical") },
            { "intraviteal", new ValueWithNote("4302785", "intravitreal") },
            { "intravitreal", new ValueWithNote("4302785", "intravitreal") },
            { "irrigation", new ValueWithNote("0", "irrigation") },
            { "jejunostomy", new ValueWithNote("4133177", "jejunostomy") },
            { "left ear", new ValueWithNote("4023156", "otic") },
            { "left eye", new ValueWithNote("40549429", "ocular") },
            { "line lock", new ValueWithNote("0", "line lock") },
            { "local infiltration", new ValueWithNote("37397638", "infiltrationr") },
            { "nasal", new ValueWithNote("4262914", "nasal") },
            { "nasogastric", new ValueWithNote("4132711", "nasogastric") },
            { "nasojejunal", new ValueWithNote("4305834", "nasojejunal") },
            { "nebulised inhalation", new ValueWithNote("40486069", "respiratory tract") },
            { "oral", new ValueWithNote("4132161", "oral") },
            { "orogastric", new ValueWithNote("4303795", "orogastric") },
            { "orojejunal", new ValueWithNote("4133177", "jejunostomy") },
            { "oromucosal", new ValueWithNote("4186839", "oromucosal") },
            { "paravertebral", new ValueWithNote("4170267", "paravertebral") },
            { "patient-controlled epidural analgesia", new ValueWithNote("4225555", "epidural") },
            { "patient-controlled intravenous analgesia", new ValueWithNote("4171047", "intravenous") },
            { "per rectum", new ValueWithNote("4290759", "rectal") },
            { "regional analgesia", new ValueWithNote("0", "regional analgesia") },
            { "right ear", new ValueWithNote("4023156", "otic") },
            { "right eye", new ValueWithNote("40549429", "ocular") },
            { "rinse", new ValueWithNote("4263689", "topical") },
            { "soak", new ValueWithNote("4263689", "topical") },
            { "soap", new ValueWithNote("4263689", "topical") },
            { "subconjunctival", new ValueWithNote("4163770", "subconjunctival") },
            { "subcutaneous", new ValueWithNote("4142048", "subcutaneous") },
            { "subdermal", new ValueWithNote("4142048", "subcutaneous") },
            { "sublingual", new ValueWithNote("4292110", "sublingual") },
            { "topical", new ValueWithNote("4263689", "topical") },
            { "transdermal", new ValueWithNote("4262099", "transdermal") },
            { "transurethral", new ValueWithNote("4305382", "transurethral") },
            { "vaginal", new ValueWithNote("4057765", "vaginal") },
            { "via cvvhd", new ValueWithNote("0", "via cvvhd") },
            { "transmucosal", new ValueWithNote("0", "transmucosal") },
            { "shampoo", new ValueWithNote("0", "shampoo") }
        };


    public string[] ColumnNotes =>
    [
        "[OMOP Routes](https://athena.ohdsi.org/search-terms/terms?domain=Route&standardConcept=Standard&page=1&pageSize=500&query=&boosts"
    ];
}
