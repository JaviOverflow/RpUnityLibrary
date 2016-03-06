using System;
using System.Reflection;
using System.Collections.Generic;

public static class MyCSV {

    /*
     * Item class must implement the following interface:
     *  - public int _id
     *      Unique object identifier
     *  - public static T FromFields(string[] fields)
     *      Returns T object if fields are valid. Otherwise, returns null.
     */
    public static Dictionary<int, T> LoadFromCSV<T>(string path, bool isResource = true) where T: class {
        if (! isResource)
            throw new NotSupportedException("Operation not implemented");

        var itemsDict = new Dictionary<int, T>();
        List<string[]> lines = MyCSV.UnwrapFile(path);

        foreach (string[] line in lines) {
            var item = (T) typeof(T).GetMethod( "FromFields" ).Invoke(null, new Object[]{line});

            if (item != null)
                itemsDict[(int) typeof(T).GetField("_id").GetValue(item)] = item;
        }

        return itemsDict;
    }

    public static List<string[]> UnwrapFile(string path, bool isResource = true) {
        if (! isResource)
            throw new NotSupportedException("Operation not implemented");

        string[] lines = ReadLines(path);
        var unwrapped = new List<string[]>();

        foreach (string line in lines) {
            string[] fields = line.Split(';');
            unwrapped.Add(fields);
        }

        return unwrapped;
    }

    public static string[] ReadLines(string path, bool isResource = true) {
        if (! isResource)
            throw new NotSupportedException("Operation not implemented");
        
        string raw = ResourcesIO.Read_TextAsset(path);
        string[] lines = raw.Split('\n');
        
        return lines;
    }
}
