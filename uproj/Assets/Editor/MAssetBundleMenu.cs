using System.IO;
using UnityEditor;
using UnityEngine;

namespace Monday.Editor
{
    public static class MCacheMenu
    {
        private const string MenuFolder = "Monday/Cache/";

        [MenuItem(MenuFolder + "Check Cache")]
        private static void CheckCache()
        {
            MLog.Debug("Cache now have: ", System.Math.Round(Caching.spaceOccupied * 1.0 / (1024 * 1024), 2), "mb");
        }

        [MenuItem(MenuFolder + "Clear Cache")]
        private static void ClearCache()
        {
            Caching.CleanCache();
        }
    }

    public static class MAssetBundleMenu
    {
        private const string MenuFolder = "Monday/Asset Bundle/";

        //
        private const string SaveBundle = "Monday_Save_Bundle";

        private const string Android = "Monday_Build_AB_Android";
        private const string iOS = "Monday_Build_AB_iOS";
        private const string Pc = "Monday_Build_AB_PC";
        private const string Mac = "Monday_Build_AB_Mac";
        private const string WebGl = "Monday_Build_AB_WebGL";

        [MenuItem(MenuFolder + "Build Asset Bundles")]
        public static void BuildAssetBundles()
        {
            // Bring up save panel
            string outputPath = EditorUtility.SaveFolderPanel("Save Bundle", EditorPrefs.GetString(SaveBundle, ""), "");
            if (string.IsNullOrEmpty(outputPath)) return;

            EditorPrefs.SetString(SaveBundle, outputPath);
            BuildAssetBundles(outputPath);
        }

        public static void BuildAssetBundles(string outputPath)
        {
            if (EditorPrefs.GetBool(Android, false))
            {
                BuildAssetBundles(outputPath + "/Android", BuildTarget.Android);
            }

            if (EditorPrefs.GetBool(iOS, false))
            {
                BuildAssetBundles(outputPath + "/iOS", BuildTarget.iOS);
            }

            if (EditorPrefs.GetBool(Pc, false))
            {
                BuildAssetBundles(outputPath + "/PC", BuildTarget.StandaloneWindows);
            }

            if (EditorPrefs.GetBool(Mac, false))
            {
                BuildAssetBundles(outputPath + "/OSX", BuildTarget.StandaloneOSXUniversal);
            }

            if (EditorPrefs.GetBool(WebGl, false))
            {
                BuildAssetBundles(outputPath + "/WebGL", BuildTarget.WebGL);
            }
        }

        public static void BuildAssetBundles(string outputPath, BuildTarget target)
        {
            if (Directory.Exists(outputPath)) Directory.Delete(outputPath, recursive: true);
            Directory.CreateDirectory(outputPath);

            BuildPipeline.BuildAssetBundles(outputPath,
                BuildAssetBundleOptions.ChunkBasedCompression, // BuildAssetBundleOptions.ForceRebuildAssetBundle,
                target);
        }

        [MenuItem(MenuFolder + "For Android")]
        private static void ToggleAndroidBuild()
        {
            EditorPrefs.SetBool(Android, !EditorPrefs.GetBool(Android, false));
        }

        [MenuItem(MenuFolder + "For Android", true)]
        private static bool ToggleAndroidBuildValidate()
        {
            Menu.SetChecked(MenuFolder + "For Android", EditorPrefs.GetBool(Android, false));
            return true;
        }

        [MenuItem(MenuFolder + "For iOS")]
        private static void ToggleiOSBuild()
        {
            EditorPrefs.SetBool(iOS, !EditorPrefs.GetBool(iOS, false));
        }

        [MenuItem(MenuFolder + "For iOS", true)]
        private static bool ToggleiOSBuildValidate()
        {
            Menu.SetChecked(MenuFolder + "For iOS", EditorPrefs.GetBool(iOS, false));
            return true;
        }

        [MenuItem(MenuFolder + "For PC")]
        private static void TogglePCBuild()
        {
            EditorPrefs.SetBool(Pc, !EditorPrefs.GetBool(Pc, false));
        }

        [MenuItem(MenuFolder + "For PC", true)]
        private static bool TogglePCBuildValidate()
        {
            Menu.SetChecked(MenuFolder + "For PC", EditorPrefs.GetBool(Pc, false));
            return true;
        }

        [MenuItem(MenuFolder + "For OSX")]
        private static void ToggleOSXBuild()
        {
            EditorPrefs.SetBool(Mac, !EditorPrefs.GetBool(Mac, false));
        }

        [MenuItem(MenuFolder + "For OSX", true)]
        private static bool ToggleOSXBuildValidate()
        {
            Menu.SetChecked(MenuFolder + "For OSX", EditorPrefs.GetBool(Mac, false));
            return true;
        }

        [MenuItem(MenuFolder + "For WebGL")]
        private static void ToggleWebGlBuild()
        {
            EditorPrefs.SetBool(WebGl, !EditorPrefs.GetBool(WebGl, false));
        }

        [MenuItem(MenuFolder + "For WebGL", true)]
        private static bool ToggleWebGlBuildValidate()
        {
            Menu.SetChecked(MenuFolder + "For WebGL", EditorPrefs.GetBool(WebGl, false));
            return true;
        }
    }
}