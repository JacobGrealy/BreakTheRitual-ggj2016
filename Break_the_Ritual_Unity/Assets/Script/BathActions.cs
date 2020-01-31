using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class BathActions : MonoBehaviour {


	//images to hide if completed

	public GameObject showerDog;
	public GameObject Beard;
	public GameObject clown;
	public GameObject radio;
	public GameObject hammer;


	//the ongoing conditions
	GameObject gameMaster;
	GameConditions conditions = new GameConditions();



	// Use this for initialization
	void Start () {
		gameMaster = GameObject.Find("ConditionsKeeper");
		conditions = gameMaster.GetComponent<GameConditions> ();
		//remove images of conditions already met
		showerDog.SetActive(!conditions.showerSurprise);
		Beard.SetActive (!conditions.shaveBeard);
		clown.SetActive (!conditions.evilClown);
		radio.SetActive (!conditions.happyDance);
		hammer.SetActive (!conditions.pimplePopper);


	}
	
	// Update is called once per frame
	void Update () {
	
	}



	// Showering dog
	IEnumerator DogShower(){
		yield return new WaitForSeconds (2);
		dogBefore.SetActive (false);
		dogAfter.SetActive (true);
		conditions.showerSurprise = true;
		yield return new WaitForSeconds (2);

		//end level
	}

	public GameObject showerCurtainClosed,showerCurtainOpened; // sprites are named backwards
	public GameObject dogBefore, dogAfter;
	public void PullShowerCurtain(){
		if (showerCurtainClosed.activeSelf == true) {
			showerCurtainClosed.SetActive (false);
			showerCurtainOpened.SetActive (true);

			if (showerDog.active == true) {
				StartCoroutine(DogShower());
				//end level
				conditions.toNextLevel ();
			}
		} else {
			showerCurtainClosed.SetActive (true);
			showerCurtainOpened.SetActive (false);
		}

	}
	// end showering dog


	public GameObject reflection;
	public GameObject beardReflection;
	public GameObject raido;
	public GameObject mirrorShelves;

	public void useMirror(){
		if (mirrorShelves.active == false) {
			reflection.SetActive (false);
			beardReflection.SetActive (false);
			raido.SetActive (false);
			mirrorShelves.SetActive (true);
		} else {
			reflection.SetActive (true);
			beardReflection.SetActive (true);
			raido.SetActive (true);
			mirrorShelves.SetActive (false);
		}

	}
	public GameObject goatDance;
	public void useRaido(){
		conditions.GetComponent<GameConditions> ().happyDance = true;
		goatDance.SetActive (true);
		conditions.toNextLevel ();

	}


}
