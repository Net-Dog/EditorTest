using UnityEngine;
using System.Collections;
public enum Weapon { firemet, bazuka, pulemet, pistolet, rainbow, koktelmolotova, granate, bigdog, pinkponі };
[System.Serializable]
public class UnitController : MonoBehaviour
{
    public float Hp = 300f;
    public float Speed = 10f;
    public Weapon wep = Weapon.rainbow;
}
