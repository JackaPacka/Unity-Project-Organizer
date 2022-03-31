using UnityEditor;
using UnityEngine;

namespace JackedUp.Editor.Windows {
    /// <summary>
    /// 
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public class ResourcesEditor : EditorWindow {
        #region Variables

        private Vector2 _scrollPosition;

        #endregion
        
        private void OnGUI() {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            GUILayout.BeginVertical();
            
            var contentA = new GUIContent {
                text = "Thanks for using the Unity Project Organizer! Here are all of the links to our sites."
            };
            GUILayout.Box(contentA);
            
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            
                var contentB = new GUIContent {
                    text = "If you'd like to support Jacked Up, here's a link to our Patreon. :)"
                };
                GUILayout.Box(contentB);
                
                if (GUILayout.Button("Patreon", GUILayout.Width(75)))
                    Debug.Log("Ayyooo");
            
            GUILayout.EndHorizontal();
            
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            
            GUILayout.Label("Copyright 2022 Jacked Up Studios LLC");
        }
        
        [MenuItem("Window/Project Organizer/Resources")]
        private static void ShowWindow() => GetWindow(typeof(ResourcesEditor), false, "Resources");
    }
}