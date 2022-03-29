using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JackedUp.Tools {
    /// <summary>
    /// Moves the referenced game objects into the container folders requested.
    /// This component runs at start and destroys itself when it is finished.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    [DisallowMultipleComponent]
    public class MoveToContainerFolder : MonoBehaviour {
        #region Variables
        
        /// <summary>
        /// The game objects to move into the container folders.
        /// The game objects are moved on start.
        /// </summary>
        public List<GameObjectContainerParameters> gameObjectsToCache = new List<GameObjectContainerParameters>();

        [Serializable]
        public struct GameObjectContainerParameters {
            public string containerFolderName;
            public GameObject gameObjectToCache;
        }
        
        #endregion

        private void Start() {
            if (gameObjectsToCache == null) {
                Destroy(gameObject);
                return;
            }

            foreach (var gameObjectToContain in gameObjectsToCache.Where(gameObjectToContain => gameObjectToContain.gameObjectToCache != null)) 
                ScenesContainer.MoveGameObjectToContainerFolder(gameObjectToContain.gameObjectToCache, true, gameObjectToContain.containerFolderName);

            Destroy(gameObject);
        }
    }
}