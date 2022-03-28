using JackedUp.Core;
using UnityEditor;
using UnityEngine;

namespace JackedUp.Editor {
    /// <summary>
    /// Editor window responsible for setting asset folders.
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
        private bool _generateEnvironmentSubFolder;
        private bool _generatePlayerModelSubFolder;

        private bool _generatePrefabsFolder;
        private bool _generateModelsSubFolder;
        private bool _generateTilesSubFolder;
        private bool _generateParticlesSubFolder;

        private bool _generateResourcesFolder;
        private bool _generateDependenciesSubFolder;
        private bool _generatePlayerSubFolder;
        private bool _generateOtherSubFolder;
        
        private bool _generateScenesFolder;
        private bool _generateLevelsSubFolder;
        private bool _generateCinematicsSubFolder;
        private bool _generateOtherSceneSubFolder;
        private bool _generateTestingSubFolder;
        
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
        private bool _generateSpritesSubFolder;
        private bool _generateImagesSubFolder;
        private bool _generateTextureParticlesSubFolder;

        private bool _generateShadersFolder;
        
        private bool _generateFontsFolder;
        
        private bool _generatePhysicsFolder;

        private bool _generateEditorFolder;
        
        private bool _generateSettingsFolder;
        
        private bool _generatePluginsFolder;
        
        private bool _generateExtensionsFolder;
        
        private bool _generatePresetsFolder;

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
                SelectAll();

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
            if (_generateModelsFolder) {
                DrawSubEntry("Environment", _generateEnvironmentSubFolder, out _generateEnvironmentSubFolder);
                DrawSubEntry("Player", _generatePlayerModelSubFolder, out _generatePlayerModelSubFolder);
            }
            
            // Prefabs
            DrawEntry("Prefabs Folder", _generatePrefabsFolder, out _generatePrefabsFolder);
            if (_generatePrefabsFolder) {
                DrawSubEntry("Models", _generateModelsSubFolder, out _generateModelsSubFolder);
                DrawSubEntry("Tiles", _generateTilesSubFolder, out _generateTilesSubFolder);
                DrawSubEntry("Particles", _generateParticlesSubFolder, out _generateParticlesSubFolder);
            }
            
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
                DrawSubEntry("Levels", _generateLevelsSubFolder, out _generateLevelsSubFolder);
                DrawSubEntry("Cinematics", _generateCinematicsSubFolder, out _generateCinematicsSubFolder);
                DrawSubEntry("Other", _generateOtherSceneSubFolder, out _generateOtherSceneSubFolder);
                DrawSubEntry("Testing", _generateTestingSubFolder, out _generateTestingSubFolder);
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
            if (_generateTexturesFolder) {
                DrawSubEntry("Sprites", _generateSpritesSubFolder, out _generateSpritesSubFolder);
                DrawSubEntry("Images", _generateImagesSubFolder, out _generateImagesSubFolder);
                DrawSubEntry("Particles", _generateTextureParticlesSubFolder, out _generateTextureParticlesSubFolder);
            }
            
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

        [MenuItem("Window/Project Organizer/Setup Folder Structure")]
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

        private void SelectAll() {
            _generateAnimationsFolder = true;
            _generateAudioFolder = true;
            _generateSfxSubFolder = true;
            _generateMusicSubFolder = true;
            _generateMaterialsFolder = true;
            _generateModelsFolder = true;
            _generateEnvironmentSubFolder = true;
            _generatePlayerModelSubFolder = true;
            _generatePrefabsFolder = true;
            _generateModelsSubFolder = true;
            _generateTilesSubFolder = true;
            _generateParticlesSubFolder = true;
            _generateResourcesFolder = true;
            _generateDependenciesSubFolder = true;
            _generatePlayerSubFolder = true;
            _generateOtherSubFolder = true;
            _generateScenesFolder = true;
            _generateLevelsSubFolder = true;
            _generateCinematicsSubFolder = true;
            _generateOtherSceneSubFolder = true;
            _generateTestingSubFolder = true;
            _generateScriptsFolder = true;
            _generateEditorSubFolder = true;
            _generateCoreSubFolder = true;
            _generateControllersSubFolder = true;
            _generateManagersSubFolder = true;
            _generateMechanicsSubFolder = true;
            _generateUiSubFolder = true;
            _generateNetworkingSubFolder = true;
            _generateMiscellaneousSubFolder = true;
            _generateTexturesFolder = true;
            _generateSpritesSubFolder = true;
            _generateImagesSubFolder = true;
            _generateTextureParticlesSubFolder = true;
            _generateShadersFolder = true;
            _generateFontsFolder = true;
            _generatePhysicsFolder  = true;
            _generateEditorFolder = true;
            _generateSettingsFolder = true;
            _generatePluginsFolder = true;
            _generateExtensionsFolder = true;
            _generatePresetsFolder = true;
            
            Repaint();
        }
        
        private void GenerateFolders() {
            // Animation
            if (_generateAnimationsFolder && !FolderTool.ParentFolderExists(ParentFolders.Animations))
                FolderTool.CreateParentFolder(ParentFolders.Animations);
            
            // Audio
            if (_generateAudioFolder && !FolderTool.ParentFolderExists(ParentFolders.Audio))
                FolderTool.CreateParentFolder(ParentFolders.Audio);
            
            if (_generateMusicSubFolder && !FolderTool.SubFolderExists(ParentFolders.Audio, "Music"))
                FolderTool.CreateSubFolder(ParentFolders.Audio, "Music");
            
            if (_generateSfxSubFolder && !FolderTool.SubFolderExists(ParentFolders.Audio, "SFX"))
                FolderTool.CreateSubFolder(ParentFolders.Audio, "SFX");
            
            // Materials
            if (_generateMaterialsFolder && !FolderTool.ParentFolderExists(ParentFolders.Materials))
                FolderTool.CreateParentFolder(ParentFolders.Materials);
            
            // Models
            if (_generateModelsFolder && !FolderTool.ParentFolderExists(ParentFolders.Models))
                FolderTool.CreateParentFolder(ParentFolders.Models);

            if (_generateEnvironmentSubFolder && !FolderTool.SubFolderExists(ParentFolders.Models, "Environment"))
                FolderTool.CreateSubFolder(ParentFolders.Models, "Environment");
            
            if (_generatePlayerModelSubFolder && !FolderTool.SubFolderExists(ParentFolders.Models, "Player"))
                FolderTool.CreateSubFolder(ParentFolders.Models, "Player");

            // Prefabs
            if (_generatePrefabsFolder && !FolderTool.ParentFolderExists(ParentFolders.Prefabs))
                FolderTool.CreateParentFolder(ParentFolders.Prefabs);
            
            if (_generateModelsSubFolder && !FolderTool.SubFolderExists(ParentFolders.Prefabs, "Models"))
                FolderTool.CreateSubFolder(ParentFolders.Prefabs, "Models");

            if (_generateTilesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Prefabs, "Tiles"))
                FolderTool.CreateSubFolder(ParentFolders.Prefabs, "Tiles");
            
            if (_generateParticlesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Prefabs, "Particles"))
                FolderTool.CreateSubFolder(ParentFolders.Prefabs, "Particles");
            
            // Resources
            if (_generateResourcesFolder && !FolderTool.ParentFolderExists(ParentFolders.Resources))
                FolderTool.CreateParentFolder(ParentFolders.Resources);
            
            if (_generateDependenciesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Resources, "Dependencies"))
                FolderTool.CreateSubFolder(ParentFolders.Resources, "Dependencies");
            
            if (_generatePlayerSubFolder && !FolderTool.SubFolderExists(ParentFolders.Resources, "Player"))
                FolderTool.CreateSubFolder(ParentFolders.Resources, "Player");
            
            if (_generateOtherSubFolder && !FolderTool.SubFolderExists(ParentFolders.Resources, "Other"))
                FolderTool.CreateSubFolder(ParentFolders.Resources, "Other");
            
            // Scenes
            if (_generateScenesFolder && !FolderTool.ParentFolderExists(ParentFolders.Scenes))
                FolderTool.CreateParentFolder(ParentFolders.Scenes);
            
            if (_generateLevelsSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scenes, "Levels"))
                FolderTool.CreateSubFolder(ParentFolders.Scenes, "Levels");
            
            if (_generateCinematicsSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scenes, "Cinematics"))
                FolderTool.CreateSubFolder(ParentFolders.Scenes, "Cinematics");
            
            if (_generateOtherSceneSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scenes, "Other"))
                FolderTool.CreateSubFolder(ParentFolders.Scenes, "Other");
            
            if (_generateTestingSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scenes, "Testing"))
                FolderTool.CreateSubFolder(ParentFolders.Scenes, "Testing");
            
            // Scripts
            if (_generateScriptsFolder && !FolderTool.ParentFolderExists(ParentFolders.Scripts))
                FolderTool.CreateParentFolder(ParentFolders.Scripts);
            
            if (_generateEditorSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Editor"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Editor");
            
            if (_generateCoreSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Core"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Core");
            
            if (_generateControllersSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Controllers"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Controllers");
            
            if (_generateManagersSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Managers"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Managers");
            
            if (_generateMechanicsSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Mechanics"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Mechanics");
            
            if (_generateUiSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "UI"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "UI");
            
            if (_generateNetworkingSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Networking"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Networking");
            
            if (_generateMiscellaneousSubFolder && !FolderTool.SubFolderExists(ParentFolders.Scripts, "Miscellaneous"))
                FolderTool.CreateSubFolder(ParentFolders.Scripts, "Miscellaneous");
            
            // Textures
            if (_generateTexturesFolder && !FolderTool.ParentFolderExists(ParentFolders.Textures))
                FolderTool.CreateParentFolder(ParentFolders.Textures);
            
            if (_generateSpritesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Textures, "Sprites"))
                FolderTool.CreateSubFolder(ParentFolders.Textures, "Sprites");
            
            if (_generateImagesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Textures, "Images"))
                FolderTool.CreateSubFolder(ParentFolders.Textures, "Images");
            
            if (_generateTextureParticlesSubFolder && !FolderTool.SubFolderExists(ParentFolders.Textures, "Particles"))
                FolderTool.CreateSubFolder(ParentFolders.Textures, "Particles");
            
            // Shaders
            if (_generateShadersFolder && !FolderTool.ParentFolderExists(ParentFolders.Shaders))
                FolderTool.CreateParentFolder(ParentFolders.Shaders);
            
            // Fonts
            if (_generateFontsFolder && !FolderTool.ParentFolderExists(ParentFolders.Fonts))
                FolderTool.CreateParentFolder(ParentFolders.Fonts);
            
            // Physics
            if (_generatePhysicsFolder && !FolderTool.ParentFolderExists(ParentFolders.Physics))
                FolderTool.CreateParentFolder(ParentFolders.Physics);
            
            // Editor
            if (_generateEditorFolder && !FolderTool.ParentFolderExists(ParentFolders.Editor))
                FolderTool.CreateParentFolder(ParentFolders.Editor);
            
            // Settings
            if (_generateSettingsFolder && !FolderTool.ParentFolderExists(ParentFolders.Settings))
                FolderTool.CreateParentFolder(ParentFolders.Settings);
            
            // Plugins
            if (_generatePluginsFolder && !FolderTool.ParentFolderExists(ParentFolders.Plugins))
                FolderTool.CreateParentFolder(ParentFolders.Plugins);
            
            // Extensions
            if (_generateExtensionsFolder && !FolderTool.ParentFolderExists(ParentFolders.Extensions))
                FolderTool.CreateParentFolder(ParentFolders.Extensions);
            
            // Presets
            if (_generatePresetsFolder && !FolderTool.ParentFolderExists(ParentFolders.Plugins))
                FolderTool.CreateParentFolder(ParentFolders.Plugins);

            Debug.Log("<color=green><b>Setup selected folders successfully.</b></color>");
            Close();

            AssetDatabase.Refresh();
        }
    }
}