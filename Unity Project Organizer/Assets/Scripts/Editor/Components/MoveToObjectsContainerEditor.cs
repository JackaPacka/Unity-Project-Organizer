using JackedUp.Tools;
using UnityEditor;
using UnityEngine;

namespace JackedUp.Editor.Components {
    /// <summary>
    /// Editor for the 'MoveToContainerFolder' component.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    [CustomEditor(typeof(MoveToObjectContainer))]
    public class MoveToObjectsContainerEditor : UnityEditor.Editor {
        #region Variables

        private SerializedProperty _gameObjectsToMoveProperty;
        private GameObject _lastGameObjectChecked;
        private bool _detectedMultipleReferencesOfGameObject;
        
        #endregion

        private void OnEnable() => _gameObjectsToMoveProperty = serializedObject.FindProperty("gameObjectsToMove");

        public override void OnInspectorGUI() {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_gameObjectsToMoveProperty);
            serializedObject.ApplyModifiedProperties();
            
            // Check for game objects referenced multiple times
            var instance = (MoveToObjectContainer)target;
            foreach (var gameObject in instance.gameObjectsToMove) {
                _detectedMultipleReferencesOfGameObject = gameObject.gameObjectToCache == _lastGameObjectChecked && _lastGameObjectChecked != null;

                if (_detectedMultipleReferencesOfGameObject) {
                    EditorGUILayout.HelpBox("Detected multiple references of the same game object(s).", MessageType.Error);
                    _lastGameObjectChecked = null;
                    break;
                }
                
                _lastGameObjectChecked = gameObject.gameObjectToCache;
            }

            EditorGUILayout.HelpBox("The game objects will not persist between scene changes. When a scene is unloaded, the game objects will be destroyed.", MessageType.Warning);
        }
    }
}