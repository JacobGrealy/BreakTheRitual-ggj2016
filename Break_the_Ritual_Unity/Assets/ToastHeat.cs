using UnityEngine;
using System.Collections;

public class ToastHeat : MonoBehaviour
{
    public GameObject toast;
    public float targetTime = 2f;

    private float passedTime;

    // Use this for initialization
    void Start ()
    {
        passedTime = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //check for time
        if (passedTime > targetTime)
        {
            toast.SetActive(true);
            this.gameObject.SetActive(false);

			GameObject.Find ("ConditionsKeeper").GetComponent<GameConditions> ().quickToast=true;
			GameObject.Find("ConditionsKeeper").GetComponent<GameConditions> ().toNextLevel();
        }
        passedTime += Time.deltaTime;
	}
}
