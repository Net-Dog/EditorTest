using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(UnitController))]
public class UnitEditor : Editor {
    
    SerializedProperty Hp;
    SerializedProperty Speed;
    SerializedProperty Weapon;

    void OnEnable()
    {
        Hp = serializedObject.FindProperty("Hp");
        Speed = serializedObject.FindProperty("Speed");
        Weapon = serializedObject.FindProperty("wep");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Hp.floatValue = EditorGUILayout.FloatField("Head Point", Hp.floatValue/*, GUILayout.Width(200)*/);
       
        Speed.floatValue = EditorGUILayout.FloatField("Speed", (target as UnitController).Speed/*, GUILayout.Width(200)*/);
        Weapon.enumValueIndex = (int)(Weapon)EditorGUILayout.EnumPopup("Weapon", (Weapon)Weapon.enumValueIndex/*, GUILayout.Width(200)*/);
        serializedObject.ApplyModifiedProperties();
    }
}
