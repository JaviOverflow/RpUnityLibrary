using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public static class RpHTTP
{
    public static WWW NewStream(String requestMethod, String url, String body = null)
    {
        body = body ?? "{}";
        byte[] binaryBody = body.ToBinaryUTF8();

        var headers = new Dictionary<string, string>
        {
            {"X-HTTP-Method-Override", requestMethod},
            {"Content-Type", "application/json"}
        };

        WWW stream = new WWW(url, binaryBody, headers);
        return stream;
    }
}

