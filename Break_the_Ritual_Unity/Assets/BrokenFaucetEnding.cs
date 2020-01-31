using UnityEngine;
using System.Collections;

public class BrokenFaucetEnding : MonoBehaviour
{
    public GameObject faucet;
    public GameObject SinkWater;
    public GameObject RisingWater;

    // Use this for initialization
    void Start () {
        faucet.SetActive(false);
        SinkWater.SetActive(true);
        RisingWater.SetActive(true);
		GameObject.Find ("ConditionsKeeper").GetComponent<GameConditions> ().waterFountain=true;
		GameObject.Find("ConditionsKeeper").GetComponent<GameConditions> ().toNextLevel();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
