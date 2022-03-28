using UnityEditor;
using UnityEngine;

namespace JackedUp.Core {
    /// <summary>
    /// Tool for creating and deleting parent folders and sub folders.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public static class FolderTool {
        #region Variables

        private const string ROOT_FOLDER = "Assets";

        public static bool SubFolderExists(ParentFolders parentFolder, string subFolderPath)
            => AssetDatabase.IsValidFolder($"{ROOT_FOLDER}/{parentFolder}/{subFolderPath}");

        public static bool ParentFolderExists(ParentFolders parentFolder)
            => AssetDatabase.IsValidFolder($"{ROOT_FOLDER}/{parentFolder}");
        
        #endregion

        #region Parent Folders

        public static void CreateParentFolder(ParentFolders parentFolder) {
            if (ParentFolderExists(parentFolder)) {
                Debug.LogWarning($"Did not create parent folder because it already exists. <b>({ROOT_FOLDER}/{parentFolder})</b>");
                return;
            }
            
            var folderGUID = AssetDatabase.CreateFolder(ROOT_FOLDER, parentFolder.ToString());
            
            if (string.IsNullOrEmpty(folderGUID)) {
                Debug.LogError($"Failed to create parent folder because the GUID was empty/null. <b>({ROOT_FOLDER}/{parentFolder})</b>");
                return;
            }
            
            AssetDatabase.GUIDToAssetPath(folderGUID);
        }

        public static void DeleteParentFolder(ParentFolders parentFolder) {
            if (!ParentFolderExists(parentFolder)) {
                Debug.LogError($"Failed to delete parent folder because it does not exist. <b>({ROOT_FOLDER}/{parentFolder})</b>");
                return;
            }
            
            AssetDatabase.DeleteAsset($"{ROOT_FOLDER}/{parentFolder}");
        }
        
        #endregion

        #region Sub Folders

        public static void CreateSubFolder(ParentFolders parentFolder, string subFolderPath) {
            if (SubFolderExists(parentFolder, subFolderPath)) {
                Debug.LogWarning($"Did not create sub folder because it already exists. <b>({ROOT_FOLDER}/{parentFolder}/{subFolderPath})</b>");
                return;
            }
            
            if (!ParentFolderExists(parentFolder)) 
                CreateParentFolder(parentFolder);

            var folderGUID = AssetDatabase.CreateFolder($"{ROOT_FOLDER}/{parentFolder}", subFolderPath);
            
            if (string.IsNullOrEmpty(folderGUID)) {
                Debug.LogError($"Failed to create sub folder because the GUID was empty/null. <b>({ROOT_FOLDER}/{parentFolder}/{subFolderPath})</b>");
                return;
            }

            AssetDatabase.GUIDToAssetPath(folderGUID);
        }

        public static void DeleteSubFolder(ParentFolders parentFolder, string folderPath) { 
            if (!SubFolderExists(parentFolder, folderPath)) {
                Debug.LogError($"Failed to delete sub folder because it does not exist. <b>({ROOT_FOLDER}/{parentFolder}/{folderPath})</b>");
                return;
            }
            
            AssetDatabase.DeleteAsset($"{ROOT_FOLDER}/{parentFolder}/{folderPath}");
        }

        #endregion
    }

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
