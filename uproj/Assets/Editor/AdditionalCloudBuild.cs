using Monday.Editor;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class AdditionalCloudBuild
{
    [MenuItem("ACB/PreExport")]
    public static void PreExport()
    {
        Debug.Log("ACB.PreExport");

        MAssetBundleMenu.BuildAssetBundles(Application.dataPath + "/../../z_built_abs", BuildTarget.Android);
        string absFolder = Path.Combine(Application.streamingAssetsPath, "dlc/abs/");
        new DirectoryInfo(absFolder).Create();
        foreach (string child in Directory.GetFiles(Application.dataPath + "/../../z_built_abs"))
        {
            string fileName = Path.GetFileName(child);
            if (child.EndsWith(".manifest") || fileName == "z_built_abs") continue;
            File.Copy(child, Path.Combine(absFolder, fileName));
        }

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
        Directory.Delete(Application.dataPath + "/../../z_built_abs", recursive: true);
        Directory.Delete(Application.streamingAssetsPath, recursive: true);
        File.Delete(Application.streamingAssetsPath + ".meta");
    }
}