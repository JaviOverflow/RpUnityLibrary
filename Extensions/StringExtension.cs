using System;
using System.Text;

public static class StringExtension
{
    public static byte[] ToBinaryUTF8(this String text)
    {
        return Encoding.UTF8.GetBytes(text);
    }

    public static bool IsNullOrEmpty(this String text)
    {
        return String.IsNullOrEmpty(text);
    }

    public static string Format(this String text, params object[] items)
    {
        return String.Format(text, items);
    }
}

