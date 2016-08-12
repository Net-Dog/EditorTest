using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
public class GameSettingConfig : ScriptableObject  {
    [MenuItem("Editor/Complexity Enemy Level")]
    public static void CreateLevelCastum()
    {
        CustomAssetUtility.CreateAsset<SCSDefficileLevel>();
    }
    [MenuItem("Editor/Generate Config Level")]
    public static void CreateLevelConfig() {
        CustomAssetUtility.CreateAsset<ConfigLevelController>();
    }
}
#endif