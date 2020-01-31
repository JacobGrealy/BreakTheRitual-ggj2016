using UnityEngine;
using System.Collections;

public class MoveWaterUp : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = this.transform.position + new Vector3(0, speed * Time.deltaTime, 0);
    }
}
