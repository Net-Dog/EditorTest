using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task {
    public bool _isOff = false;
    public string _meta;
    public int _time = 0;
}

[System.Serializable]
public class Level {
    public int _countTask;
    public List<Task> _listTaskInLevel = new List<Task>();
} 


[System.Serializable]
public class Location {
    public string _nameLocation;
    public int _countLevel;
    public List<Level> _level = new List<Level>();
    
}
[System.Serializable]
public class ConfigLevelController : ScriptableObject {
    public int _countLocation = 5;
    public List<Location> _listLocation = new List<Location>();
}
