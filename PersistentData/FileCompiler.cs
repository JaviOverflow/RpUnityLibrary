using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public static class FileCompiler {

    public static void CompileCSV<T>(string editor_filepath_txt, string editor_filepath_bin, string resources_filepath_txt) where T : class {	
        var txt_info = new FileInfo( editor_filepath_txt );
        var bin_info = new FileInfo( editor_filepath_bin );

        Debug.Log( string.Format("txt: {0} \nbin: {1}", txt_info.LastWriteTime, bin_info.LastWriteTime) );

        if (txt_info.LastAccessTimeUtc > bin_info.LastWriteTimeUtc) {
            var itemsDict = MyCSV.LoadFromCSV<T>( resources_filepath_txt );
            BinaryIO.Save<Dictionary<int, T>>( editor_filepath_bin, itemsDict );
            AssetDatabase.Refresh();
            Debug.Log(string.Format( "{0}.bin recompiled", resources_filepath_txt ));
        } else {
            Debug.Log(string.Format( "{0}.bin is up to date", resources_filepath_txt ));
        }
	}
}
