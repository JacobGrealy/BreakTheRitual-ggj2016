using UnityEngine;
using System.Collections;

public class ComboActions : MonoBehaviour {



	public GameObject myPower;
	public GameObject mySecret;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void enableMyPower(){
		myPower.SetActive (true);
		mySecret.SetActive (false);
		if (triggerCondition == "") {
			//dumped
		}else{
			GameObject conditionKeeper;
			conditionKeeper = GameObject.Find ("ConditionsKeeper");
			conditionKeeper.GetComponent<GameConditions>().updateStatus(triggerCondition);
			conditionKeeper.GetComponent<GameConditions> ().toNextLevel ();
		}

	}
	public string triggerCondition = "";
	public GameObject mySelf, myUse;

	public void selfCheck(GameObject a, GameObject b){
		Debug.Log (a+" "+b);
		if (a == mySelf && b == myUse) {
			enableMyPower ();
		} else if (b == mySelf && a == myUse) {
			enableMyPower ();
		} 

	}

//	}
}
