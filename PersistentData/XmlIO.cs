using System.Xml.Linq;

public static class MyXML {

    public static XElement Parse(string resourcesPath) {
        return XElement.Parse( ResourcesIO.Read_TextAsset(resourcesPath) );
    }
}
