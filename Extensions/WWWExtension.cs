using UnityEngine;

public static class WWWExtension
{
    public static bool WasSuccessful(this WWW stream)
    {
        return stream.error.IsNullOrEmpty();
    }
}

