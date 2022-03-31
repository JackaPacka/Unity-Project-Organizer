using UnityEditor;
using UnityEngine;

namespace JackedUp.Core {
    /// <summary>
    /// Tool for creating and deleting folders.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public static class FolderTool {
        #region Variables

        public const string ROOT_FOLDER = "Assets";

        /// <summary>
        /// Checks if a valid folder exists at the path specified.
        /// </summary>
        /// <param name="path">The path of the folder to check.</param>
        /// <returns>If the folder exists or not at the path.</returns>
        public static bool FolderExists(string path) 
            => AssetDatabase.IsValidFolder(path);
        
        #endregion

        /// <summary>
        /// Creates a folder at the specified path.
        /// </summary>
        /// <param name="parentFolder">The root parent folder.</param>
        /// <param name="subfolderName">Optional name of subfolder to create. LEAVE THIS BLANK IF YOU'D LIKE TO CREATE THE PARENT FOLDER ONLY.</param>
        public static void CreateFolder(ParentFolders parentFolder, string subfolderName = null) {
            if (Application.isPlaying) {
#if UNITY_EDITOR
                Debug.LogError("You cannot create folders while in play mode.");
#endif
                return;
            }
            
            if (!FolderExists($"{ROOT_FOLDER}/{parentFolder}")) {
                var parentFolderGUID = AssetDatabase.CreateFolder(ROOT_FOLDER, parentFolder.ToString());
            
                if (string.IsNullOrEmpty(parentFolderGUID)) {
#if UNITY_EDITOR
                    Debug.LogError($"Failed to create parent folder because the GUID was empty/null. <b>({ROOT_FOLDER}/{parentFolder})</b>");
#endif
                    return;
                }
            
                AssetDatabase.GUIDToAssetPath(parentFolderGUID);
            }
            
            if (string.IsNullOrEmpty(subfolderName) || FolderExists($"{ROOT_FOLDER}/{parentFolder}/{subfolderName}"))
                return;

            var subfolderGUID = AssetDatabase.CreateFolder($"{ROOT_FOLDER}/{parentFolder}", subfolderName);
            
            if (string.IsNullOrEmpty(subfolderGUID)) {
#if UNITY_EDITOR
                Debug.LogError($"Failed to create subfolder because the GUID was empty/null. <b>({ROOT_FOLDER}/{parentFolder}/{subfolderName})</b>");
#endif
                return;
            }

            AssetDatabase.GUIDToAssetPath(subfolderGUID);
        }

        /// <summary>
        /// Deletes the folder at the path specified.
        /// </summary>
        /// <param name="parentFolder">The root parent folder.</param>
        /// <param name="subfolderName">Optional name of the subfolder to delete. LEAVE THIS BLANK IF YOU'D LIKE TO DELETE THE PARENT FOLDER ONLY.</param>
        public static void DeleteFolder(ParentFolders parentFolder, string subfolderName = null) {
            if (Application.isPlaying) {
#if UNITY_EDITOR
                Debug.LogError("You cannot delete folders while in play mode.");
#endif
                return;
            }
            
            var path = $"{ROOT_FOLDER}/{parentFolder}" + (!string.IsNullOrEmpty(subfolderName)
                ? $"/{subfolderName}"
                : string.Empty); 
            
            AssetDatabase.DeleteAsset(path);
        }
    }

    /// <summary>
    /// A list of all of the main parent folders. Most all assets should fit into one of the folders.
    /// </summary>
    public enum ParentFolders {
        Animations,
        Audio,
        Materials,
        Models,
        Prefabs,
        Resources,
        Scenes,
        Scripts,
        Textures,
        Shaders,
        Fonts,
        Physics,
        Editor,
        Settings,
        Plugins,
        Extensions,
        Presets
    }
}
