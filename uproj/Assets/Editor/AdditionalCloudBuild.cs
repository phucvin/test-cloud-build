using System.IO;
using UnityEditor;
using UnityEngine;

public static class AdditionalCloudBuild
{
    [MenuItem("ACB/PreExport")]
    public static void PreExport()
    {
        Debug.Log("ACB.PreExport");

        File.WriteAllText(Application.dataPath + "/../../dlc/ab", "AB");

        Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/dlc/");
        File.Copy(Application.dataPath + "/../../dlc/ab",
            Application.dataPath + "/StreamingAssets/dlc/ab");
        File.Copy(Application.dataPath + "/../../dlc/data.txt",
            Application.dataPath + "/StreamingAssets/dlc/data.txt");
    }

    [MenuItem("ACB/PostExport")]
    public static void PostExport()
    {
        Debug.Log("ACB.PreExport");

        File.Delete(Application.dataPath + "/../../dlc/ab");
    }
}