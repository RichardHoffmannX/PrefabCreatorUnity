# PrefabCreatorUnity
Create Prefab From Selected Object in Hierarchy in Unity

´´´
public class ReplayCamera : MonoBehaviour
{
        private string prefabDir = "Prefabs/";

        [Button]
        [Tooltip("Select the GameObject first to become a Prefab")]
        void CreatePrefab()
        {
#if UNITY_EDITOR
            GameObject selected = Selection.activeGameObject;
            if (selected == null)
            {
                Debug.LogWarning("No GameObject selected!");
                return;
            }

            string localPath = $"Assets/{prefabDir}{selected.name}.prefab";
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

            // Create prefab
            GameObject prefab = PrefabUtility.SaveAsPrefabAsset(selected, localPath);

            // Focus Project window
            EditorUtility.FocusProjectWindow();

            // Select the prefab
            Selection.activeObject = prefab;

            Debug.Log("Prefab created at: " + localPath);
#endif
        }
}
´´´
