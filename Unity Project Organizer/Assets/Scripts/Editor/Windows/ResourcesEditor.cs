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
            
            GUILayout.Label("If you'd like to support us, here's a link to our Patreon :)");
                
            if (GUILayout.Button("Patreon", GUILayout.Width(75)))
                Debug.Log("Ayyooo");

            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();
            
            GUILayout.Label("Copyright 2022 Jacked Up Studios LLC");
        }
        
        [MenuItem("Window/Project Organizer/Resources")]
        private static void ShowWindow() => GetWindow(typeof(ResourcesEditor), false, "Resources");
    }
}