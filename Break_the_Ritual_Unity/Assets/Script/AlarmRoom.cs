using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Timers;

public class AlarmRoom : MonoBehaviour {


	// Script for controlling conditions and controls of the alarm stage
	GameObject gameMaster;
	public GameConditions conditions = new GameConditions();
	public GameObject conditionsKeeper;
	public Image activeObject = null;
	public bool dragging = false;
	//public Vector3 TempVector = new Vector3(0,0,0);

	public Image Clock, Outlet;
	public Image Drawer, Hammer;
	public Image Dog, lockedDrawer,Key,DogTreat;
	public Image Plant, Water;
	public Image Window, baseballBat;

	//images that will change through interaction
	public GameObject TopDrawer;



	public int success = 0;

	public Sprite openedDrawer;
	public Sprite HIDDEN;

	public GameObject alarm;
	public GameObject theHammer, dogTreats, powerOutlet, baseball, waterCup;

	// Use this for initialization
	void Start () {
		gameMaster = GameObject.Find("ConditionsKeeper");
		conditions = gameMaster.GetComponent<GameConditions> ();

		theHammer.SetActive(!conditions.hammerAlarm);
		dogTreats.SetActive (!conditions.dogTrick);
		powerOutlet.SetActive (!conditions.powerUnplug);
		baseball.SetActive (!conditions.homeRun);
		waterCup.SetActive (!conditions.plantFood);

		Debug.Log (SceneManager.GetActiveScene ().buildIndex);
	}
	
	// Update is called once per frame
	void Update () {



	}
	//*********__Hammer Time__*********\\
	public void openDrawer(){
		if (TopDrawer.activeSelf == true) {
			TopDrawer.SetActive (false);
		}else{
			TopDrawer.SetActive (true);
		}
	}
		
	public void pullPlug(){
		if (conditions.powerUnplug == false) {
			powerOutlet.SetActive (false);
			alarm.GetComponent<Animator> ().enabled = false;
			alarm.transform.FindChild ("AlarmVibrationLeft").gameObject.SetActive (false);
			alarm.transform.FindChild ("AlarmVibrationRght").gameObject.SetActive (false);
			conditions.powerUnplug = true;
			//next scene

			nextRoom();
		}
	}

	void nextRoom(){
		StartCoroutine (waiting ());

	}
	IEnumerator waiting(){
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene (2);
	}
		

}