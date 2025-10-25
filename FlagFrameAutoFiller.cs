#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

[CustomEditor(typeof(MonoBehaviour), true)]
public class FlagFrameAutoFiller : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        // Only show button for objects that have a StreamingFlagAnimator-like field
        SerializedObject so = serializedObject;

        // Try to find a property named "frames" or "flagFrames"
        SerializedProperty framesProp = so.FindProperty("frames");
        if (framesProp == null) framesProp = so.FindProperty("flagFrames");

        if (framesProp == null)
        {
            // nothing to auto-fill for this component
            return;
        }

        if (GUILayout.Button("Auto-Fill Frames from Selected Folder"))
        {
            string folderPath = EditorUtility.OpenFolderPanel("Select Flag Frame Folder", "Assets", "");
            if (string.IsNullOrEmpty(folderPath)) return;

            // Convert absolute path to relative path under Assets
            if (folderPath.StartsWith(Application.dataPath))
            {
                folderPath = "Assets" + folderPath.Substring(Application.dataPath.Length);
            }

            // Find all Texture2D assets in the folder
            string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { folderPath });

            List<string> assetPaths = new List<string>(guids.Length);
            for (int i = 0; i < guids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                if (!string.IsNullOrEmpty(path))
                    assetPaths.Add(path);
            }

            if (assetPaths.Count == 0)
            {
                EditorUtility.DisplayDialog("No textures found", "No Texture2D assets found in: " + folderPath, "OK");
                return;
            }

            // Sort by filename so frame_0001 ... frame_0105 order is preserved
            assetPaths.Sort((a, b) => string.Compare(Path.GetFileName(a), Path.GetFileName(b)));

            // Load assets
            Texture2D[] textures = new Texture2D[assetPaths.Count];
            for (int i = 0; i < assetPaths.Count; i++)
            {
                textures[i] = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPaths[i]);
            }

            // Write into the serialized property array
            so.Update();

            framesProp.arraySize = textures.Length;
            for (int i = 0; i < textures.Length; i++)
            {
                SerializedProperty elem = framesProp.GetArrayElementAtIndex(i);
                elem.objectReferenceValue = textures[i];
            }

            so.ApplyModifiedProperties();

            // Mark target dirty for saving
            EditorUtility.SetDirty(target);
            Undo.RecordObject(target, "Auto Fill Frames");

            Debug.Log("Loaded " + textures.Length + " frames into " + target.name);
        }
    }
}
#endif
