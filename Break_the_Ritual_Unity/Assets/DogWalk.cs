using UnityEngine;
using System.Collections;

public class DogWalk : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		GameObject.Find ("ConditionsKeeper").GetComponent<GameConditions> ().dogTime=true;
		GameObject.Find("ConditionsKeeper").GetComponent<GameConditions> ().toNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime,0,0);

	}
}
