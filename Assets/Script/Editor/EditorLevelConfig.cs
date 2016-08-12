using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(ConfigLevelController))]
public class EditorLevelConfig : Editor {
    SerializedProperty countLocation;
    SerializedProperty listLocation;
    bool[] arrLocationStat;
    bool[] bossStat;
    bool[][] arrLevelStat;
    public void OnEnable() {
        countLocation = serializedObject.FindProperty("_countLocation");
        listLocation = serializedObject.FindProperty("_listLocation");
        arrLevelStat = new bool[countLocation.intValue+1][];
        bossStat = new bool[countLocation.intValue + 1];
        arrLocationStat = new bool[countLocation.intValue+1];
        for (int i = 0; i < countLocation.intValue; i++) {
            arrLevelStat[i] = new bool[listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue + 1];
            //arrLevelStat[i][0] = false;
        }
            
    }
    private void SetLengthList() {
        if (arrLevelStat.Length != countLocation.intValue + 1) {
            bossStat = new bool[countLocation.intValue + 1];
            arrLocationStat = new bool[countLocation.intValue + 1];
            arrLevelStat = new bool[countLocation.intValue + 1][];
            for (int i = 0; i < arrLevelStat.Length; i++) {
                arrLevelStat[i] = new bool[listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue + 1];
                //arrLevelStat[i][0] = false;
            }
        }
        if (countLocation.intValue != listLocation.arraySize) {
            while (countLocation.intValue < listLocation.arraySize) listLocation.DeleteArrayElementAtIndex(listLocation.arraySize - 1);
            while (countLocation.intValue > listLocation.arraySize) listLocation.InsertArrayElementAtIndex(listLocation.arraySize); 
        }
    }
    public override void OnInspectorGUI() {
        serializedObject.Update();
        SetLengthList();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Count Location");
        countLocation.intValue = EditorGUILayout.IntField(countLocation.intValue);
        GUILayout.EndHorizontal();
        for (int i = 0; i < listLocation.arraySize; i++) {
            GUILayout.BeginHorizontal();
            arrLocationStat[i] = EditorGUILayout.Foldout(arrLocationStat[i], "Name Location");
            listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_nameLocation").stringValue = EditorGUILayout.TextField(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_nameLocation").stringValue);
            GUILayout.EndHorizontal();
            //Debug.Log("i = " + i + " arr[i].length " + arrLevelStat[i].Length);
            if (arrLocationStat[i] == true) {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Enter count lavel");
                listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue = EditorGUILayout.IntField(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue);
                GUILayout.EndHorizontal();
                if(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue != listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").arraySize) {
                    /*змінюємо розмір кількості місій*/
                    SetLenghtLevel(i);
                }
                for (int j = 0; j < listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_countLevel").intValue; j++) {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(j.ToString(), GUILayout.Width(20));
                    arrLevelStat[i][j] = EditorGUILayout.Foldout(arrLevelStat[i][j], "Task");
                    GUILayout.EndHorizontal();
                    if(arrLevelStat[i][j] == true) {
                        /*тут список тасків ((*/
                        GUILayout.BeginHorizontal();
                        //GUILayout.Label("Mission", GUILayout.Width(80));
                        listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_mission").enumValueIndex = (int)(Mission)EditorGUILayout.EnumPopup("Mission", (Mission)listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_mission").enumValueIndex);
                        listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_isOff").boolValue = EditorGUILayout.Toggle(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_isOff").boolValue);
                        if(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_isOff").boolValue == true) {
                            /*тут відображаємо поле для вваду часу*/
                            listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_time").intValue = EditorGUILayout.IntField(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_level").GetArrayElementAtIndex(j).FindPropertyRelative("_time").intValue);
                        }
                        GUILayout.EndHorizontal();
                    }
                    //UnityEditorInternal.ReorderableList l = new UnityEditorInternal.ReorderableList()
                    //UnityEditorInternal.ReorderableList
                }
                bossStat[i] = EditorGUILayout.Foldout(bossStat[i], "BOSS");
                if(bossStat[i] == true) {
                    GUILayout.BeginHorizontal();
                    listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_mission").enumValueIndex = (int)(Mission)EditorGUILayout.EnumPopup("Mission", (Mission)listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_mission").enumValueIndex);
                    listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_isOff").boolValue = EditorGUILayout.Toggle(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_isOff").boolValue);
                    if (listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_isOff").boolValue == true)
                        listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_time").intValue = EditorGUILayout.IntField(listLocation.GetArrayElementAtIndex(i).FindPropertyRelative("_boss").FindPropertyRelative("_time").intValue);
                    GUILayout.EndHorizontal();
                }

            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    private void SetLenghtLevel(int index) {
        if (arrLevelStat[index].Length != listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_countLevel").intValue + 1) {
            arrLevelStat[index] = new bool[listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_countLevel").intValue + 1];
            for (int i = 0; i < arrLevelStat[index].Length; i++) {
                arrLevelStat[index][i] = false;
            }
        }
        while (listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_countLevel").intValue > listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").arraySize) listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").InsertArrayElementAtIndex(listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").arraySize);
        while (listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_countLevel").intValue < listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").arraySize) listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").DeleteArrayElementAtIndex(listLocation.GetArrayElementAtIndex(index).FindPropertyRelative("_level").arraySize-1);
    }
}
#endif