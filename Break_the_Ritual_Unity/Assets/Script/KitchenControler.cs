using UnityEngine;
using System.Collections;

public class KitchenControler : MonoBehaviour {


	GameObject gameMaster;
	GameConditions conditions = new GameConditions();

	public GameObject goodSink, freshBread, glassDoor, drinkingGlass, coffeePot, brokenGlass;
	// Use this for initialization
	void Start () {
		gameMaster = GameObject.Find("ConditionsKeeper");
		conditions = gameMaster.GetComponent<GameConditions> ();

		goodSink.SetActive(!conditions.waterFountain);
		freshBread.SetActive (!conditions.quickToast);
		glassDoor.SetActive (!conditions.dogTime);
		drinkingGlass.SetActive (!conditions.spoiledMilk);
		coffeePot.SetActive (!conditions.freshCoffee);
		brokenGlass.SetActive (conditions.dogTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
