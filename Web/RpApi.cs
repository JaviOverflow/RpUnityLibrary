using System;
using System.Collections;
using UnityEngine;

public class RpApi : MonoBehaviourUndestroyableSingleton<RpApi>
{
    public void Call<T>(
        String          requestMethod, 
        String          url, 
        Action<T>       onSuccess, 
        Action<string>  onError, 
        Func<string, T> bodyProcessor   = null, 
        String          body            = null)
    {
        StartCoroutine(Call0<T>(requestMethod, url, onSuccess, onError, bodyProcessor, body));
    }
       
    private IEnumerator Call0<T>(
        String          requestMethod, 
        String          url, 
        Action<T>       onSuccess, 
        Action<string>  onError, 
        Func<string, T> bodyProcessor, 
        String          body)
    {
        WWW stream = RpHTTP.NewStream(requestMethod, url, body);
        yield return stream;

        if (stream.WasSuccessful())
        {
            try
            {
                onSuccess.Emit((bodyProcessor != null) ? 
                    bodyProcessor(stream.text) : (T)(object)stream.text);
            }
            catch (Exception exp)
            {
                onError.Emit(
                    string.Format("ParseError -> Verb: {0}, URL: {1}, Message: {2}", requestMethod, url, exp.Message));
            }
        }
        else
        {
            onError.Emit(
                string.Format("FetchError -> Verb: {0}, URL: {1}, Message: {2}", requestMethod, url, stream.error));
        }
    }
}
