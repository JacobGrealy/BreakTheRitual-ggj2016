using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Timers;

public class GameConditions : MonoBehaviour {

	public static GameConditions conditionKeeper;


	void Awake() {
		if (conditionKeeper)
			DestroyImmediate (gameObject);
		else{
			DontDestroyOnLoad(transform.gameObject);
			conditionKeeper = this;
			}

	}

	//bools for BedRoom
	public bool hammerAlarm, dogTrick, powerUnplug, homeRun, plantFood ;

	//bools for Bathroom
	public bool shaveBeard, happyDance, evilClown, showerSurprise, pimplePopper;

	//bools for Kitchen
	public bool freshCoffee, spoiledMilk, waterFountain, dogTime, quickToast;

	//bools for Office
//	public bool easyDay, hamsterHavoc, thirstyBirdy, missingYou, actualWork;

	//bools for Livingroom
//	public bool dartPratice, weeklyRun, dogwalk, recliningRover, secretControler;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	public void updateStatus(string action){
		switch (action) {
		case "hammerAlarm":
			hammerAlarm = true;
			break;
		case "homeRun":
			homeRun = true;
			break;
		case "dogTrick":
			dogTrick = true;
			break;
		case "plantFood":
			plantFood = true;
			break;
		case "shaveBeard":
			shaveBeard = true;
			break;
		case "evilClown":
			evilClown = true;
			break;
		case "pimplePopper":
			pimplePopper = true;
			break;
		case "spoiledMilk":
			spoiledMilk = true;
			break;
		case "quickToast":
			quickToast = true;
			break;
		case "dogTime":
			dogTime = true;
			break;

		default:
			break;
		}
	}




	IEnumerator waiting(){
		yield return new WaitForSeconds(5);
		SceneManager.GetActiveScene ();
		int level = SceneManager.GetActiveScene ().buildIndex;
		if (level == 1) {
			SceneManager.LoadScene (2);
		}else if (level == 2) {
			SceneManager.LoadScene (3);
		}else if (level == 3) {
			if((freshCoffee && spoiledMilk && waterFountain && dogTime && quickToast) == true)
			{
				SceneManager.LoadScene (4);
			} else {
				SceneManager.LoadScene(1);
			}
		}

	}
	public void toNextLevel(){
		StartCoroutine (waiting ());

	}



}