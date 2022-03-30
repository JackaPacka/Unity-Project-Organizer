using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JackedUp.Tools {
    /// <summary>
    /// A system for storing game objects in scene folders. Game objects will persist IF the object is set to persistent.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public static class ObjectContainer {
        #region Variables 

        /// <summary>
        /// The root container folder that contains all of the 'ContainerFolders'.
        /// </summary>
        public static Transform RootContainerFolder { get; private set; }
        
        /// <summary>
        /// A list of all of the container folders created.
        /// Each container folder has a name and a transform (folder).
        /// </summary>
        public static List<ContainerFolder> ContainerFolders { get; private set; } = new List<ContainerFolder>();

        /// <summary>
        /// Fetches the container folder by name. Returns null if the container folder does not exist.
        /// </summary>
        /// <param name="name">The name of the container folder to return.</param>
        /// <returns>The container folder.</returns>
        public static ContainerFolder GetContainerFolderByName(string name) {
            foreach (var containerFolder in ContainerFolders.Where(containerFolder => containerFolder.name == name))
                return containerFolder;

            return new ContainerFolder();
        }
        
        private static List<GameObject> _deleteOnSceneUnloaded = new List<GameObject>();

        #endregion

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadCallback() {
            SceneManager.sceneUnloaded += SceneUnloadedCallback;
            
            RootContainerFolder = new GameObject("Object Container").transform;
            UnityEngine.Object.DontDestroyOnLoad(RootContainerFolder);
        }

        /// <summary>
        /// Moves the game object in to the scene container folder.
        /// If the container folder doesn't exist, the container folder will be created.
        /// </summary>
        /// <param name="gameObject">The game object to move into the scenes container.</param>
        /// <param name="destroyOnSceneUnloaded">If the game object should be destroyed when a scene unloads.</param>
        /// <param name="containerFolderName">The name of the folder to create/put the game object into.</param>
        public static void MoveGameObjectToContainerFolder(GameObject gameObject, bool destroyOnSceneUnloaded, string containerFolderName) {
            if (gameObject == null) {
#if UNITY_EDITOR
                Debug.LogError("The game object was null and could not be added to a container folder.");
#endif
                return;
            }

            if (!ContainerFolders.Contains(GetContainerFolderByName(containerFolderName))) {
                var newContainerFolderGameObject = new GameObject(containerFolderName);
                UnityEngine.Object.DontDestroyOnLoad(newContainerFolderGameObject);
                newContainerFolderGameObject.transform.SetParent(RootContainerFolder);

                var newContainerFolder = new ContainerFolder {
                    name = containerFolderName,
                    folder = newContainerFolderGameObject.transform
                };
                
                ContainerFolders ??= new List<ContainerFolder>();
                ContainerFolders.Add(newContainerFolder);
            }

            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            gameObject.transform.SetParent(GetContainerFolderByName(containerFolderName).folder);
            
            if (!destroyOnSceneUnloaded)
                return;

            _deleteOnSceneUnloaded ??= new List<GameObject>();
            _deleteOnSceneUnloaded.Add(gameObject);
        }
        
        private static void SceneUnloadedCallback(Scene scene) {
            if (RootContainerFolder == null) {
#if UNITY_EDITOR
                Debug.LogWarning("The root container folder seems to have been destroyed. Repairing...");
#endif
                
                RootContainerFolder = new GameObject("Object Container (Repair)").transform;
                UnityEngine.Object.DontDestroyOnLoad(RootContainerFolder);
            }
            
            foreach (var gameObject in _deleteOnSceneUnloaded.Where(gameObject => gameObject != null)) 
                UnityEngine.Object.Destroy(gameObject);

            if (ContainerFolders != null) {
                foreach (var containerFolder in ContainerFolders.Where(containerFolder => containerFolder.folder.childCount == 0)) {
                    UnityEngine.Object.Destroy(containerFolder.folder);
                    ContainerFolders.Remove(containerFolder);
                }
            }
        }
    }
    
    [Serializable]
    public struct ContainerFolder {
        public string name;
        public Transform folder;
    }
}
