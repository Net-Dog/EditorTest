using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Xml.Serialization;

[CustomEditor(typeof(SCSDefficileLevel))]
public class EnemyEditorDifficile : Editor {
    SerializedProperty _car;
    SerializedProperty _motorCycle;
    SerializedProperty _btr;
    SerializedProperty _tank;
    SerializedProperty _countLevel;
    SerializedProperty _testCar;
    static bool Lock = false;

    void OnEnable() {
        _car = serializedObject.FindProperty("Car");
        _motorCycle = serializedObject.FindProperty("MotorCycle");
        _btr = serializedObject.FindProperty("Btr");
        _tank = serializedObject.FindProperty("Tank");
        _countLevel = serializedObject.FindProperty("CountLevel");
        //Debug.Log("enable ok");
        //SetLengthArrValue();
    }
    public string[] ArrName = { "hp", "speed", "damege", "cooldown" };
    public override void OnInspectorGUI() {
        serializedObject.Update();
        SetLengthArrValue();
        bool carStatus = true;
        bool motorcycleStat = true;
        bool btrStat = true;
        bool tankStat = true;
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enter Count Level");
        _countLevel.intValue = EditorGUILayout.IntField(_countLevel.intValue);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Level", GUILayout.Width(80));
        for (int i = 0; i < _countLevel.intValue; i++) {
            EditorGUILayout.LabelField((i + 2).ToString(), GUILayout.Width(80));
        }
        GUILayout.EndHorizontal();
        carStatus = EditorGUILayout.Foldout(carStatus, "Car");
        if (carStatus) {
            for (int i = 0; i < ArrName.Length; i++) {
                GUILayout.BeginHorizontal();
                GUILayout.Label(ArrName[i], GUILayout.Width(80));
                //Debug.Log("size car = " + _car.arraySize);
                for (int j = 0; j < _car.arraySize; j++)
                    _car.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue = EditorGUILayout.FloatField(_car.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue, GUILayout.Width(80));
                GUILayout.EndHorizontal();
            }

        }
        motorcycleStat = EditorGUILayout.Foldout(motorcycleStat, "MotorCycle");
        if (motorcycleStat) {
            for (int i = 0; i < ArrName.Length; i++) {
                GUILayout.BeginHorizontal();
                GUILayout.Label(ArrName[i], GUILayout.Width(80));
                for (int j = 0; j < _motorCycle.arraySize; j++)
                    _motorCycle.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue = EditorGUILayout.FloatField(_motorCycle.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue, GUILayout.Width(80));
                GUILayout.EndHorizontal();
            }
        }
        btrStat = EditorGUILayout.Foldout(btrStat, "Btr");
        if (btrStat) {
            for (int i = 0; i < ArrName.Length; i++) {
                GUILayout.BeginHorizontal();
                GUILayout.Label(ArrName[i], GUILayout.Width(80));
                for (int j = 0; j < _btr.arraySize; j++)
                    _btr.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue = EditorGUILayout.FloatField(_btr.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue, GUILayout.Width(80));
                GUILayout.EndHorizontal();
            }
        }
        tankStat = EditorGUILayout.Foldout(btrStat, "Tank");
        if (tankStat) {
            for (int i = 0; i < ArrName.Length; i++) {
                GUILayout.BeginHorizontal();
                GUILayout.Label(ArrName[i], GUILayout.Width(80));
                for (int j = 0; j < _btr.arraySize; j++)
                    _tank.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue = EditorGUILayout.FloatField(_tank.GetArrayElementAtIndex(j).FindPropertyRelative(ArrName[i]).floatValue, GUILayout.Width(80));
                GUILayout.EndHorizontal();
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    void SetLengthArrValue() {
        if (_countLevel != null) {
            if (_car.arraySize != _countLevel.intValue) {
                while (_car.arraySize < _countLevel.intValue) _car.InsertArrayElementAtIndex(_car.arraySize);
                while (_car.arraySize > _countLevel.intValue) _car.DeleteArrayElementAtIndex(_car.arraySize - 1);
                //Debug.Log("initialization size = " + _car.arraySize);
            }
            if (_motorCycle.arraySize != _countLevel.intValue) {
                while (_motorCycle.arraySize < _countLevel.intValue) _motorCycle.InsertArrayElementAtIndex(_motorCycle.arraySize);
                while (_motorCycle.arraySize > _countLevel.intValue) _motorCycle.DeleteArrayElementAtIndex(_motorCycle.arraySize - 1);
            }
            if (_btr.arraySize != _countLevel.intValue) {
                while (_btr.arraySize < _countLevel.intValue) _btr.InsertArrayElementAtIndex(_btr.arraySize);
                while (_btr.arraySize > _countLevel.intValue) _btr.DeleteArrayElementAtIndex(_btr.arraySize - 1);
            }
            if (_tank.arraySize != _countLevel.intValue) {
                while (_tank.arraySize < _countLevel.intValue) _tank.InsertArrayElementAtIndex(_tank.arraySize);
                while (_tank.arraySize > _countLevel.intValue) _tank.DeleteArrayElementAtIndex(_tank.arraySize - 1);
            }
        }
    }
}


