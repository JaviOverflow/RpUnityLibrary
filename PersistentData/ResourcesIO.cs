using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesIO {

    public static TextAsset Load_TextAsset(string path) {
        return Resources.Load(path) as TextAsset;
    }

    public static string Read_TextAsset(string path) {
        try {
            var file = Load_TextAsset(path);
            return file.text;

        } catch (NullReferenceException) {
            Debug.LogError( string.Format("File {0} could not be loaded", path) );
            return "";
        }
    }

    public static Stream Read_BinaryFile(string path) {
        var text = Load_TextAsset(path);
        Stream stream = new MemoryStream(text.bytes);
        return stream;
    }

    public static Dictionary<int, AudioClip> LoadAudioClips(string path) {
        var audioClipsDict = new Dictionary<int, AudioClip>();
        var audioClips = Resources.LoadAll<AudioClip>(path);

        foreach (var audioClip in audioClips)
            audioClipsDict[int.Parse(audioClip.name)] = audioClip;

        return audioClipsDict;
    }
}
