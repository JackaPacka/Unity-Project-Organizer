using UnityEngine;

namespace JackedUp.Core {
    /// <summary>
    /// Tool for instantiating and destroying scene folders.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public static class SceneTool {
        #region Variables

        

        #endregion

        /// <summary>
        /// Instantiates a scene folder.
        /// </summary>
        /// <param name="folderName">The name of the scene folder.</param>
        public static GameObject InstantiateFolder(string folderName) {
#if UNITY_EDITOR
            var sceneFolder = GameObject.Find(folderName);
            
            if (sceneFolder != null && !sceneFolder.transform.IsChildOf(sceneFolder.transform.root)) 
                Debug.LogWarning($"A scene folder named <b>{folderName}</b> already exists in the scene.");
#endif

            return new GameObject(folderName);
        }

        /// <summary>
        /// Destroys a scene folder.
        /// </summary>
        /// <param name="folderName">The name of the scene folder to delete.</param>
        /// <param name="destroyStoredObjects">If all of the objects inside the scene folder should be destroyed.</param>
        public static void DestroyFolder(string folderName, bool destroyStoredObjects) {
            var sceneFolder = GameObject.Find(folderName);
            
            if (sceneFolder == null || sceneFolder.transform.IsChildOf(sceneFolder.transform.root)) {
#if UNITY_EDITOR
                Debug.LogError($"Failed to destroy a scene folder named <b>{folderName}</b> because it doesn't exist inside the scene.");
#endif
                return;
            }

            if (!destroyStoredObjects)
                sceneFolder.transform.DetachChildren();

            Object.Destroy(sceneFolder);
        }

        /// <summary>
        /// Adds the game object to the scene folder specified.
        /// </summary>
        /// <param name="gameObjectToAdd">The game object to add to the scene folder.</param>
        /// <param name="folderName">The folder to put the game object into. If a folder by this name doesn't exist, a folder will be created.</param>
        public static void AddToFolder(GameObject gameObjectToAdd, string folderName) {
            var sceneFolder = GameObject.Find(folderName);

            if (sceneFolder == null || sceneFolder.transform.childCount != 0) 
                 sceneFolder = InstantiateFolder(folderName);
            
            gameObjectToAdd.transform.SetParent(sceneFolder.transform);
        }
    }
}
