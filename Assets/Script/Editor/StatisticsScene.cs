using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;

public class StatisticsScene : EditorWindow {
    public static StatisticsScene Instance;
    public static Scene StartScene;
    public static Scene LoadScene;
    private GameObject _scene;
    private GameObject _oldScene;
    static List<GameObject> _gameObjectFromScene = new List<GameObject>();
    string[] _nameOfDirectory;
    [MenuItem("Editor/Statistic Level")]
    public static void Init() {
        Instance = (StatisticsScene)EditorWindow.GetWindow(typeof(StatisticsScene), false, "Statistic scene");
        Instance.minSize = new Vector2(420, 245);
        Instance.maxSize = new Vector2(420, 720);
        StartScene = EditorSceneManager.GetActiveScene();
        LoadScene = EditorSceneManager.OpenScene("Assets/01_01.unity");
        GameObject[] _loarObject = GameObject.FindGameObjectsWithTag("enemy");
        Debug.Log("initialization");
        Debug.Log("_load enemy = " + _loarObject.Length);
        foreach(GameObject g in _loarObject) {
            _gameObjectFromScene.Add(g);
        }
        EditorSceneManager.CloseScene(LoadScene, true);
        EditorSceneManager.SetActiveScene(StartScene);
        //EditorSceneManager.SetActiveScene(StartScene);
    }
    UnitController unit = new UnitController();
    void OnGUI() {
        GUILayout.Label("size list = " + _gameObjectFromScene.Count);
        for(int i = 0; i < _gameObjectFromScene.Count; i++) {
            unit = _gameObjectFromScene[i].GetComponent<UnitController>();
            GUILayout.BeginHorizontal();
            GUILayout.Label(_gameObjectFromScene[i].name);
            GUILayout.Label(unit.Hp.ToString());
            GUILayout.Label(unit.Speed.ToString());
            GUILayout.Label(unit.wep.ToString());
            GUILayout.EndHorizontal();
        }
    }
    
}
#endif
