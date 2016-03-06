using UnityEngine;
using System;
using System.Collections.Generic;

public static class RpJson
{
    [Serializable]
    private class ListWrapper<T>
    {
        public List<T> list;
    }

    public static List<T> FromJsonList<T>(String jsonList)
    {
        String jsonListWrapped = "{ \"list\": " + jsonList + " }";
        List<T> list = JsonUtility.FromJson<ListWrapper<T>>(jsonListWrapped).list;
        return list;
    }

    public static String ToJsonList<T>(List<T> list)
    {
        ListWrapper<T> listWrapper = new ListWrapper<T>
        {
            list = list
        };

        String jsonListWrapped = JsonUtility.ToJson(listWrapper);

        int fromIndex = jsonListWrapped.IndexOf('[');
        int toIndex = jsonListWrapped.LastIndexOf(']');

        String jsonList = jsonListWrapped
            .Remove(toIndex + 1, jsonListWrapped.Length - (toIndex + 1))
            .Remove(0, fromIndex);

        return jsonList;
    }

    public static T FromJsonObject<T>(String jsonObject)
    {
        T obj = JsonUtility.FromJson<T>(jsonObject);
        return obj;
    }

    public static String ToJsonObject<T>(T obj)
    {
        String jsonObject = JsonUtility.ToJson(obj);
        return jsonObject;
    }
}

