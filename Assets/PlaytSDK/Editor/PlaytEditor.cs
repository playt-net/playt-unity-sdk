using PlaytSDK.Scripts;
using PlaytSDK.Scripts.Unity;
using UnityEditor;
using UnityEngine;

namespace PlaytSDK.Editor
{
    public class PlaytEditor : EditorWindow
    {
        [SerializeField] private PlaytSettings _settings;

        [MenuItem("PLAYT/Configuration")]
        public static void ShowWindow()
        {
            GetWindow(typeof(PlaytEditor));
        }

        void OnGUI()
        {
            GUILayout.Label("PLAYT SDK Settings", EditorStyles.boldLabel);

            if (_settings == null)
            {
                _settings = CreateInstance<PlaytSettings>();
                AssetDatabase.CreateAsset(_settings, "Assets/PlaytSettings.asset");
                AssetDatabase.SaveAssets();
            }

            _settings =
                EditorGUILayout.ObjectField("SDK Settings", _settings, typeof(PlaytSettings), false) as PlaytSettings;
        }
    }
}