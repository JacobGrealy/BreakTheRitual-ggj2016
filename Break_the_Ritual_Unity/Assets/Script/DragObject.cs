using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DragObject : MonoBehaviour {

//	public AlarmRoom MasterObject = new AlarmRoom(); avoid calling each room
//	public GameConditions checkCondition = new GameConditions();
	public Vector3 OriginalPoint;
	int success = 0;
	bool dragging = false;

	GameObject heldObject;


	// Use this for initialization
	void Start () {
		// get the master script
//		GameObject tempSpace;
//		tempSpace = GameObject.Find ("ConditionsKeeper");
//		checkCondition = tempSpace.GetComponent<GameConditions> ();
	//	MasterObject = tempSpace.GetComponent<AlarmRoom>();
		Debug.Log(SceneManager.GetActiveScene ());


		//set my position
		OriginalPoint = new Vector3(transform.position.x,transform.position.y,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (success==1) {
		//	SceneManager.LoadScene (1);
		}
	}


	public void OnMouseEnter()
	{
		if (!dragging) {
			heldObject = this.gameObject;
			Debug.Log (heldObject);
		}
	}
		

	public void OnEndDrag()
	{
		// check GameConditions to see if drop point is a solution
		PointerEventData target = new PointerEventData(EventSystem.current);
		target.position = Input.mousePosition;

		List<RaycastResult> raycastTargets = new List<RaycastResult> ();
		EventSystem.current.RaycastAll (target, raycastTargets);
		Debug.Log (raycastTargets[0].gameObject.name);
		Debug.Log (raycastTargets[1].gameObject.name);
		if (raycastTargets.Count > 1) {
		//	success = 
		//	success = checkCondition.checkBedRoom(raycastTargets[0].gameObject.name,raycastTargets[1].gameObject.name);
			heldObject.GetComponent<ComboActions>().selfCheck(raycastTargets[0].gameObject,raycastTargets[1].gameObject);


			/*
			if ((raycastTargets [0].gameObject.name == "Key") && raycastTargets [1].gameObject.name == "LockedDrawer") {
				raycastTargets [1].gameObject.GetComponent<ComboActions> ().enableMyPower();
			}else if ((raycastTargets [1].gameObject.name == "Key") && raycastTargets [0].gameObject.name == "LockedDrawer" ) {
				raycastTargets [0].gameObject.GetComponent<ComboActions> ().enableMyPower();
			}else if ((raycastTargets [0].gameObject.name == "Hammer") && raycastTargets [1].gameObject.name == "Clock") {
				raycastTargets [1].gameObject.GetComponent<ComboActions> ().enableMyPower();
			}else if ((raycastTargets [1].gameObject.name == "Hammer") && raycastTargets [0].gameObject.name == "Clock" ) {
				raycastTargets [0].gameObject.GetComponent<ComboActions> ().enableMyPower();
			}
		*/
		
		}

		if (success==0) {
			GetComponent<RectTransform> ().position= OriginalPoint;
		}
	}

	public void UseDrag()
	{
		dragging = true;
		heldObject = this.gameObject;
		Debug.Log (heldObject);
		
		//GetComponent<RectTransform> ().position = Input.mousePosition;
	
		Vector2 pos;

		RectTransformUtility.ScreenPointToLocalPointInRectangle (GameObject.FindObjectOfType<Canvas> ().transform as RectTransform, Input.mousePosition, GameObject.FindObjectOfType<Camera> (), out pos);
		transform.position = GameObject.FindObjectOfType<Canvas> ().transform.InverseTransformPoint (pos);

	}
}
