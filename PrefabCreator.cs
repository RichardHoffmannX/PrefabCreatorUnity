using UnityEngine;
using UnityEditor;

public class PrefabCreator
{
    [MenuItem("Tools/Create Prefab From Selected")]
    static void CreatePrefab()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected == null)
        {
            Debug.LogWarning("No GameObject selected!");
            return;
        }

        // Where to save the prefab
        string localPath = "Assets/Prefabs/" + selected.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        // Ensure folder exists
        System.IO.Directory.CreateDirectory("Assets/Prefabs");

        // Create prefab asset
        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(selected, localPath);

        // Focus Project window
        EditorUtility.FocusProjectWindow();

        // Select the prefab
        Selection.activeObject = prefab;

        Debug.Log("Prefab created at: " + localPath);
    }
}
