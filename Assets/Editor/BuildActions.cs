using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Game
{
    
    public class BuildActions : MonoBehaviour
    {
        static string GAME_NAME = "my_game";
        static string VERSION = Application.version;
        static string APP_FOLDER = Directory.GetCurrentDirectory ();
        static string ANDROID_DEVELOPMENT_FILE = string.Format ("{0}/Builds/Android/{1}.{2}.development.apk", APP_FOLDER, GAME_NAME, VERSION);
        static string IOS_FOLDER = string.Format("{0}/Builds/iOS/", APP_FOLDER);
        static string IOS_DEVELOPMENT_FOLDER = string.Format("{0}/Builds/iOS/build/development", APP_FOLDER);
        

        
        static string[] GetScenes () {
            List<string> scenes = new List<string> ();
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++) {
                if (EditorBuildSettings.scenes[i].enabled) {
                    scenes.Add (EditorBuildSettings.scenes[i].path);
                }
            }
            return scenes.ToArray ();
        }

        static void iOSDevelopment()
        {
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, null);
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
            BuildReport report = BuildPipeline.BuildPlayer(GetScenes(), IOS_DEVELOPMENT_FOLDER, BuildTarget.iOS,
                BuildOptions.None);
            int code = report.summary.result == BuildResult.Succeeded ? 0 : 1;
            EditorApplication.Exit(code);
        }
        
        static void AndroidDevelopment () {
            PlayerSettings.SetScriptingBackend (BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, "DEV");
            EditorUserBuildSettings.SwitchActiveBuildTarget (BuildTargetGroup.Android, BuildTarget.Android);
            EditorUserBuildSettings.development = true;
            EditorUserBuildSettings.androidETC2Fallback = AndroidETC2Fallback.Quality32Bit;
            BuildReport report = BuildPipeline.BuildPlayer (GetScenes(), ANDROID_DEVELOPMENT_FILE, BuildTarget.Android, BuildOptions.None);
            int code = (report.summary.result == BuildResult.Succeeded) ? 0 : 1;
            EditorApplication.Exit (code);    
        }
    }
}