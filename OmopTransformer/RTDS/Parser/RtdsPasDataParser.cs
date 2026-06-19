using System.Globalization;
using CsvHelper;

namespace OmopTransformer.RTDS.Parser;

internal class RtdsPasDataParser(string text)
{
    private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

    public IEnumerable<RtdsPasData> Parse()
    {
        using var reader = new StringReader(_text);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Read();
        csv.ReadHeader();

        while (csv.Read())
        {
            yield return new RtdsPasData
            {
                Expr1 = csv.GetFieldOrNullWhenEmpty("Expr1"),
                Expr2 = csv.GetFieldOrNullWhenEmpty("Expr2"),
                Expr3 = csv.GetFieldOrNullWhenEmpty("Expr3"),
                Expr4 = csv.GetFieldOrNullWhenEmpty("Expr4"),
                Expr5 = csv.GetFieldOrNullWhenEmpty("Expr5"),
                Expr6 = csv.GetFieldOrNullWhenEmpty("Expr6"),
                PatientID2 = csv.GetFieldOrNullWhenEmpty("PatientID2"),
                FirstOfNHSNUMBER = csv.GetFieldOrNullWhenEmpty("FirstOfNHSNUMBER"),
                NHSNUMBERTRACESTATUS = csv.GetFieldOrNullWhenEmpty("NHSNUMBERTRACESTATUS"),
                Expr7 = csv.GetFieldOrNullWhenEmpty("Expr7"),
                Expr8 = csv.GetFieldOrNullWhenEmpty("Expr8"),
                FirstOfPOSTCODE = csv.GetFieldOrNullWhenEmpty("FirstOfPOSTCODE"),
                Expr9 = csv.GetFieldOrNullWhenEmpty("Expr9"),
                BIRTHDATE = csv.GetFieldOrNullWhenEmpty("BIRTHDATE"),
                GENDER = csv.GetFieldOrNullWhenEmpty("GENDER"),
                Expr10 = csv.GetFieldOrNullWhenEmpty("Expr10"),
                Expr11 = csv.GetFieldOrNullWhenEmpty("Expr11"),
                Expr12 = csv.GetFieldOrNullWhenEmpty("Expr12"),
                Expr13 = csv.GetFieldOrNullWhenEmpty("Expr13"),
                Expr14 = csv.GetFieldOrNullWhenEmpty("Expr14"),
                FirstOfGPNATIONALCODE = csv.GetFieldOrNullWhenEmpty("FirstOfGPNATIONALCODE"),
                FirstOfPRACTICECODE = csv.GetFieldOrNullWhenEmpty("FirstOfPRACTICECODE")
            };
        }
    }
}