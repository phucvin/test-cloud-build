using System.IO;
using UnityEditor;
using UnityEngine;

public static class AdditionalCloudBuild
{
    [MenuItem("ACB/PreExport")]
    public static void PreExport()
    {
        Debug.Log("ACB.PreExport");

        Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/dlc/");
        File.Copy(Application.dataPath + "/../../dlc/data.txt",
            Application.dataPath + "/StreamingAssets/dlc/data.txt", overwrite: true);
    }

    [MenuItem("ACB/PostExport")]
    public static void PostExport()
    {
        Debug.Log("ACB.PreExport");
    }
}