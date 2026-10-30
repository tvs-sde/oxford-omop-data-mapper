using CsvHelper;
using OmopTransformer;

namespace OmopTransformerTests;

[TestClass]
public class CsvReaderTests
{
    [TestMethod]
    public void Read_PreservesFirstRowAndQuotedFields()
    {
        using var text = new StringReader("Id,Text,Empty,Spaces\r\n1,\"a,\"\"b\"\"\r\nc\",,   \r\n2,last,, \r\n");
        using var csv = CsvReaderExtensions.CreateReader(text);

        Assert.IsTrue(csv.Read());
        Assert.AreEqual("1", csv.GetString("Id"));
        Assert.AreEqual("a,\"b\"\r\nc", csv.GetFieldOrNullWhenEmpty("Text"));
        Assert.IsNull(csv.GetFieldOrNullWhenEmpty("Empty"));
        Assert.IsNull(csv.GetFieldOrNullWhenEmpty("Spaces"));
        Assert.IsTrue(csv.Read());
        Assert.AreEqual("2", csv.GetString(0));
        Assert.IsFalse(csv.Read());
    }

    [TestMethod]
    public async Task ReadAsync_PreservesFirstRow()
    {
        using var text = new StringReader("Id,Text\n1,first\n2,second\n");
        using var csv = CsvReaderExtensions.CreateReader(text);

        Assert.IsTrue(await csv.ReadAsync());
        Assert.AreEqual("1", csv.GetString("Id"));
        Assert.IsTrue(await csv.ReadAsync());
        Assert.AreEqual("2", csv.GetString("Id"));
        Assert.IsFalse(await csv.ReadAsync());
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("Id,Text\n")]
    public void Read_WithoutData_ReturnsFalse(string input)
    {
        using var text = new StringReader(input);
        using var csv = CsvReaderExtensions.CreateReader(text);

        Assert.IsFalse(csv.Read());
    }

    [TestMethod]
    public void GetFieldOrNullWhenEmptyIfExists_HandlesMissingAndEmptyFields()
    {
        using var text = new StringReader("Value,Empty,Short\n padded ,\n");
        using var csv = CsvReaderExtensions.CreateReader(text);
        Assert.IsTrue(csv.Read());

        Assert.AreEqual(" padded ", csv.GetFieldOrNullWhenEmptyIfExists("Value"));
        Assert.IsNull(csv.GetFieldOrNullWhenEmptyIfExists("Empty"));
        Assert.IsNull(csv.GetFieldOrNullWhenEmptyIfExists("Absent"));
        Assert.IsNull(csv.GetFieldOrNullWhenEmptyIfExists("Short"));
        Assert.ThrowsExactly<IndexOutOfRangeException>(() => csv.GetString("Short"));
    }

    [TestMethod]
    public void Read_UsesCommaSeparatorRatherThanDetection()
    {
        using var text = new StringReader("Value\none;two|three\tfour\n");
        using var csv = CsvReaderExtensions.CreateReader(text);

        Assert.IsTrue(csv.Read());
        Assert.AreEqual(1, csv.FieldCount);
        Assert.AreEqual("one;two|three\tfour", csv.GetString("Value"));
    }

    [TestMethod]
    public void Read_WithMalformedQuotes_Throws()
    {
        using var text = new StringReader("Id,Text\n1,un\"quoted\n");
        using var csv = CsvReaderExtensions.CreateReader(text);

        Assert.ThrowsExactly<CsvFormatException>(() => csv.Read());
    }
}
