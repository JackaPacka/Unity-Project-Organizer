using JackedUp.Core;
using UnityEditor;
using UnityEngine;

namespace JackedUp.Editor {
    /// <summary>
    /// Editor window responsible generating asset folders.
    /// </summary>
    /// <para>Author: Jack Randolph</para>
    public class GenerateFoldersEditor : EditorWindow {
        #region Variables

        private Vector2 _scrollPosition;
        private bool _generateAnimationsFolder;
        
        private bool _generateAudioFolder;
        private bool _generateSfxSubFolder;
        private bool _generateMusicSubFolder;
        
        private bool _generateMaterialsFolder;
        
        private bool _generateModelsFolder;

        private bool _generatePrefabsFolder;
        
        private bool _generateResourcesFolder;
        private bool _generateDependenciesSubFolder;
        private bool _generatePlayerSubFolder;
        private bool _generateOtherSubFolder;
        
        private bool _generateScenesFolder;
        private bool _generateLevelsFolder;
        private bool _generateCinematicsFolder;
        private bool _generateOtherFolder;
        private bool _generateTestingFolder;
        
        private bool _generateScriptsFolder;
        private bool _generateEditorSubFolder;
        private bool _generateCoreSubFolder;
        private bool _generateControllersSubFolder;
        private bool _generateManagersSubFolder;
        private bool _generateMechanicsSubFolder;
        private bool _generateUiSubFolder;
        private bool _generateNetworkingSubFolder;
        private bool _generateMiscellaneousSubFolder;
        
        private bool _generateTexturesFolder;

        private bool _generateShadersFolder;
        
        private bool _generateFontsFolder;
        
        private bool _generatePhysicsFolder;

        private bool _generateEditorFolder;
        
        private bool _generateSettingsFolder;
        
        private bool _generatePluginsFolder;
        
        private bool _generateExtensionsFolder;
        
        private bool _generatePresetsFolder;

        // Models Sub Folders: Environment, Player, 
        // Resources Sub Folders: Dependencies, Player
        // Texture Sub Folders: Sprites, Images, 

        private bool _drawEntryBackground = true;
        
        #endregion

        private void OnEnable() {
            _generateAnimationsFolder = !FolderTool.ParentFolderExists(ParentFolders.Animations);
            _generateAudioFolder = !FolderTool.ParentFolderExists(ParentFolders.Audio);
            _generateMaterialsFolder = !FolderTool.ParentFolderExists(ParentFolders.Materials);
            _generateModelsFolder = !FolderTool.ParentFolderExists(ParentFolders.Models);
            _generatePrefabsFolder = !FolderTool.ParentFolderExists(ParentFolders.Prefabs);
            _generateResourcesFolder = !FolderTool.ParentFolderExists(ParentFolders.Resources);
            _generateScenesFolder = !FolderTool.ParentFolderExists(ParentFolders.Scenes);
            _generateScriptsFolder = !FolderTool.ParentFolderExists(ParentFolders.Scripts);
            _generateTexturesFolder = !FolderTool.ParentFolderExists(ParentFolders.Textures);
        }

        private void OnGUI() {
            _drawEntryBackground = true;
            
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            GUILayout.BeginVertical();
            
            var content = new GUIContent {
                text = "Select all the parent and sub folders you would like to setup in your project."
            };
            GUILayout.Box(content);

            if (GUILayout.Button("Select all", GUILayout.Width(100)))
            {
                // Select all.
            }

            GUILayout.Space(5);
            GUILayout.Label("Selection");
            
            // Animation
            DrawEntry("Animations Folder", _generateAnimationsFolder, out _generateAnimationsFolder);
            
            // Audio
            DrawEntry("Audio Folder", _generateAudioFolder, out _generateAudioFolder);
            if (_generateAudioFolder) {
                DrawSubEntry("Music", _generateMusicSubFolder, out _generateMusicSubFolder);
                DrawSubEntry("SFX", _generateSfxSubFolder, out _generateSfxSubFolder);
            }

            // Materials
            DrawEntry("Materials Folder", _generateMaterialsFolder, out _generateMaterialsFolder);

            // Models
            DrawEntry("Models Folder", _generateModelsFolder, out _generateModelsFolder);

            // Prefabs
            DrawEntry("Prefabs Folder", _generatePrefabsFolder, out _generatePrefabsFolder);

            // Resources
            DrawEntry("Resources Folder", _generateResourcesFolder, out _generateResourcesFolder);
            if (_generateResourcesFolder) {
                DrawSubEntry("Dependencies", _generateDependenciesSubFolder, out _generateDependenciesSubFolder);
                DrawSubEntry("Player", _generatePlayerSubFolder, out _generatePlayerSubFolder);
                DrawSubEntry("Other", _generateOtherSubFolder, out _generateOtherSubFolder);
            }
            
            // Scenes
            DrawEntry("Scenes Folder", _generateScenesFolder, out _generateScenesFolder);
            if (_generateScenesFolder) {
                DrawSubEntry("Levels", _generateLevelsFolder, out _generateLevelsFolder);
                DrawSubEntry("Cinematics", _generateCinematicsFolder, out _generateCinematicsFolder);
                DrawSubEntry("Other", _generateOtherFolder, out _generateOtherFolder);
                DrawSubEntry("Testing", _generateTestingFolder, out _generateTestingFolder);
            }
            
            // Scripts
            DrawEntry("Scripts Folder", _generateScriptsFolder, out _generateScriptsFolder);
            if (_generateScriptsFolder) {
                DrawSubEntry("Editor", _generateEditorSubFolder, out _generateEditorSubFolder);
                DrawSubEntry("Core", _generateCoreSubFolder, out _generateCoreSubFolder);
                DrawSubEntry("Controllers", _generateControllersSubFolder, out _generateControllersSubFolder);
                DrawSubEntry("Managers", _generateManagersSubFolder, out _generateManagersSubFolder);
                DrawSubEntry("Mechanics", _generateMechanicsSubFolder, out _generateMechanicsSubFolder);
                DrawSubEntry("UI", _generateUiSubFolder, out _generateUiSubFolder);
                DrawSubEntry("Networking", _generateNetworkingSubFolder, out _generateNetworkingSubFolder);
                DrawSubEntry("Miscellaneous", _generateMiscellaneousSubFolder, out _generateMiscellaneousSubFolder);
            }

            // Textures
            DrawEntry("Textures Folder", _generateTexturesFolder, out _generateTexturesFolder);

            GUILayout.Space(15);
            GUILayout.Label("Extra");

            _drawEntryBackground = true;
            
            // Shaders
            DrawEntry("Shaders Folder", _generateShadersFolder, out _generateShadersFolder);
            
            // Fonts
            DrawEntry("Fonts Folder", _generateFontsFolder, out _generateFontsFolder);
            
            // Physics
            DrawEntry("Physics Folder", _generatePhysicsFolder, out _generatePhysicsFolder);
            
            // Editor
            DrawEntry("Editor Folder", _generateEditorFolder, out _generateEditorFolder);
            
            // Settings
            DrawEntry("Settings Folder", _generateSettingsFolder, out _generateSettingsFolder);
            
            // Plugins 
            DrawEntry("Plugins Folder", _generatePluginsFolder, out _generatePluginsFolder);
            
            // Extensions
            DrawEntry("Extensions Folder", _generateExtensionsFolder, out _generateExtensionsFolder);
            
            // Presets
            DrawEntry("Presets Folder", _generatePresetsFolder, out _generatePresetsFolder);

            GUILayout.EndVertical();
            GUILayout.EndScrollView();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Setup Folders"))
                GenerateFolders();
        }

        [MenuItem("Window/Project Structure System/Setup Folder Structure")]
        public static void OpenWindow() => GetWindow(typeof(GenerateFoldersEditor), false, "Setup Folder Structure");

        private void DrawEntry(string name, bool value, out bool outValue) {
            GUILayout.BeginVertical(new GUIStyle {normal = new GUIStyleState {background = _drawEntryBackground ? Texture2D.grayTexture : null}});
            
                outValue = EditorGUILayout.Toggle(name, value);
            
            GUILayout.EndVertical();

            _drawEntryBackground = !_drawEntryBackground;
        }
        
        private void DrawSubEntry(string name, bool value, out bool outValue) {
            GUILayout.BeginVertical(new GUIStyle {normal = new GUIStyleState {background = !_drawEntryBackground ? Texture2D.grayTexture : null}});
            
                outValue = EditorGUILayout.Toggle($"| {name}", value);
            
            GUILayout.EndVertical();
        }
        
        private void GenerateFolders() {
            if (_generateAnimationsFolder && !FolderTool.ParentFolderExists(ParentFolders.Animations))
                FolderTool.CreateParentFolder(ParentFolders.Animations);
            
            if (_generateAudioFolder && !FolderTool.ParentFolderExists(ParentFolders.Audio))
                FolderTool.CreateParentFolder(ParentFolders.Audio);
            
            if (_generateMusicSubFolder && !FolderTool.SubFolderExists(ParentFolders.Audio, "Music"))
                FolderTool.CreateSubFolder(ParentFolders.Audio, "Music");
            
            if (_generateSfxSubFolder && !FolderTool.SubFolderExists(ParentFolders.Audio, "SFX"))
                FolderTool.CreateSubFolder(ParentFolders.Audio, "SFX");
            
            if (_generateMaterialsFolder && !FolderTool.ParentFolderExists(ParentFolders.Materials))
                FolderTool.CreateParentFolder(ParentFolders.Materials);
            
            if (_generateModelsFolder && !FolderTool.ParentFolderExists(ParentFolders.Models))
                FolderTool.CreateParentFolder(ParentFolders.Models);

            if (_generatePrefabsFolder && !FolderTool.ParentFolderExists(ParentFolders.Prefabs))
                FolderTool.CreateParentFolder(ParentFolders.Prefabs);
            
            if (_generateResourcesFolder && !FolderTool.ParentFolderExists(ParentFolders.Resources))
                FolderTool.CreateParentFolder(ParentFolders.Resources);
            
            if (_generateScenesFolder && !FolderTool.ParentFolderExists(ParentFolders.Scenes))
                FolderTool.CreateParentFolder(ParentFolders.Scenes);
            
            if (_generateScriptsFolder && !FolderTool.ParentFolderExists(ParentFolders.Scripts))
                FolderTool.CreateParentFolder(ParentFolders.Scripts);
            
            if (_generateEditorSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Editor"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Editor");
            
            if (_generateTexturesFolder && !FolderTool.ParentFolderExists(ParentFolders.Textures))
                FolderTool.CreateParentFolder(ParentFolders.Textures);
            
            Debug.Log("<color=green><b>Setup selected folders successfully.</b></color>");
            Close();
        }
    }
}