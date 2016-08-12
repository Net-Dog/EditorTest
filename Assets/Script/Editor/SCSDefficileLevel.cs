using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
public class UnitDefficileOnLevel {
    public float hp;
    public float speed;
    public float damege;
    public float cooldown;
}

public class SCSDefficileLevel : ScriptableObject { 
    public int CountLevel = 2;
    public List<UnitDefficileOnLevel> Car = new List<UnitDefficileOnLevel>();
    public List<UnitDefficileOnLevel> MotorCycle = new List<UnitDefficileOnLevel>();
    public List<UnitDefficileOnLevel> Btr = new List<UnitDefficileOnLevel>();
    public List<UnitDefficileOnLevel> Tank = new List<UnitDefficileOnLevel>();
}
