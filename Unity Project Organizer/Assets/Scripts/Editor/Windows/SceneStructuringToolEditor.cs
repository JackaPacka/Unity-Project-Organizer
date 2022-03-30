using UnityEditor;
using UnityEngine;

namespace JackedUp.Editor.Windows {
    /// <summary>
    /// Editor tool responsible for creating and setting up the scene structure.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public class SceneStructuringToolEditor : EditorWindow {
        #region Variables

        private Vector2 _scrollPosition;

        #endregion

        private void OnGUI() {
            if (Application.isPlaying) {
                EditorGUILayout.HelpBox("You cannot set up the scene structure while in playmode.", MessageType.Info);
                
                if (GUILayout.Button("Exit playmode"))
                    EditorApplication.ExitPlaymode();
                
                return;
            }

            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            GUILayout.BeginVertical();
            
            var content = new GUIContent {
                text = "Select all the scene folders you would like to have setup in your scene."
            };
            GUILayout.Box(content);
            
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();

            EditorGUILayout.HelpBox("The scene structuring tool is nondestructive.", MessageType.Info);
            
            if (GUILayout.Button("Setup structure"))
                Debug.Log("Cannot setup. Sorry");
        }
        
        [MenuItem("Window/Project Organizer/Setup Scene Structure")]
        public static void OpenWindow() => GetWindow(typeof(SceneStructuringToolEditor), false, "Scene Structuring Tool");
    }
}
