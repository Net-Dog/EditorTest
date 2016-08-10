using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
public class EnemySettingConfig : ScriptableObject  {
    [MenuItem("Editor/Complexity Enemy Level")]
    public static void CreateLevelCastum()
    {
        CustomAssetUtility.CreateAsset<SCSDefficileLevel>();
    }

}
#endif