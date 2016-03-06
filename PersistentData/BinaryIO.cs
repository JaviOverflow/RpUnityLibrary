using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class BinaryIO {

    public static void Save<T>(string path, T obj) {
        // Create/Open the file and write the obj
		using (FileStream file = File.Open(path, FileMode.Create)) {
            var bf = new BinaryFormatter();
            bf.Serialize(file, obj);
        }
    }

    public static T Load<T>(string path, bool isResource = false) {
        if (!isResource && !File.Exists(path)) 
            throw new FileLoadException();

        T data;

        using (Stream stream = (isResource) ? 
            ResourcesIO.Read_BinaryFile(path) : File.Open(path, FileMode.Open)) {

            var bf = new BinaryFormatter();
            data = (T) bf.Deserialize(stream);
        }

        return data;
    }

    public static void SaveHashSet<T>(string path, HashSet<T> obj) where T: struct{
        // Hashset to array
        var arr = new T[obj.Count]; obj.CopyTo(arr);

        // Save array
        BinaryIO.Save<T[]>(path, arr);
    }

    public static HashSet<T> LoadHashSet<T>(string path) where T: struct {
        HashSet<T> hset = null;

        // Load array from file
        var arr = BinaryIO.Load<T[]>(path);

        // Array to hashset
        if (arr != null) { 
            hset = new HashSet<T>(); 
            foreach (T x in arr) { hset.Add(x); } 
        }

        return hset;
    }
}
