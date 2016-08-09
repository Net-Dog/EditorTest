using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

    [System.Serializable]
    public class HeadPoint
    {
        public float HP = 300f;
    }
    [System.Serializable]
    public class Speed
    {
        public float speed = 5f;
    }
    public HeadPoint Hp;
    public Speed speed;
	
	// Update is called once per frame
	void Update () {
	
	}
}
