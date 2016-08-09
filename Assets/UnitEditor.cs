using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(UnitController))]
public class UnitEditor : Editor {

    SerializedProperty Hp;
    SerializedProperty Speed;
    SerializedProperty Weapon;

    SerializedProperty fff;

    void OnEnable()
    {
        Hp = serializedObject.FindProperty("Hp");
        Speed = serializedObject.FindProperty("Speed");

        Weapon = serializedObject.FindProperty("wep");
        //fff = serializedObject.FindProperty("wep");
        //Debug.Log("fasfasfas");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Hp.floatValue = EditorGUILayout.FloatField("Head Point", Hp.floatValue, GUILayout.Width(200));
        Speed.floatValue = EditorGUILayout.FloatField("Speed", (target as UnitController).Speed, GUILayout.Width(200));
        UnitController.Weapon index = (UnitController.Weapon)EditorGUILayout.EnumPopup("Weapon", (UnitController.Weapon)Weapon.enumValueIndex, GUILayout.Width(200));
        Weapon.enumValueIndex = (int)index;
        serializedObject.ApplyModifiedProperties();
    }
}
