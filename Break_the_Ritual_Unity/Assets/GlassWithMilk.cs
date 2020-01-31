using UnityEngine;
using System.Collections;

public class GlassWithMilk : MonoBehaviour
{
    public GameObject glassWithoutMilk;
	// Use this for initialization
	void Start ()
    {
        glassWithoutMilk.SetActive(false);
		GameObject.Find ("ConditionsKeeper").GetComponent<GameConditions> ().spoiledMilk=true;
		GameObject.Find("ConditionsKeeper").GetComponent<GameConditions> ().toNextLevel();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
