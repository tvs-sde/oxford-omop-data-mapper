namespace OmopTransformer;

public static class StringExtensions
{
    public static string? SubstringOrNullOffByOne(this string text, int index, int length)
    {
        // The indexes of the infoflex documentation are off by one. (e.g their array index begins at one rather than zero.)

        return text.SubstringOrNull(index - 1, length);
    }

    public static string? SubstringOrNull(this string text, int index, int length)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text));

        var value = text.Substring(index, length);

        value = value.TrimEnd(' ');

        if (string.IsNullOrEmpty(value))
            return null;

        return value;
    }

    public static bool IsEmpty(this string text)
    {
        return text.TrimEnd(' ').Length == 0;
    }

    public static string? TrimWhitespace(this string? text) => text?.TrimStart(' ').TrimEnd(' ');

    public static string? GetTrimmedValueOrNull(this string? text)
    {
        text = text.TrimWhitespace();

        text = text?.TrimEnd('\r', '\n') ?? null;

        if (string.IsNullOrEmpty(text))
            return null;

        return text;
    }
}