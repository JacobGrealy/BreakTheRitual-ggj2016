using UnityEngine;
using System.Collections;

public class CoffeeMug : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject waterBottleFlag;
    public GameObject filterFlag;
    public GameObject groundsFlag;
    
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(waterBottleFlag.activeSelf && filterFlag.activeSelf && groundsFlag.activeSelf)
        {
            objectToActivate.SetActive(true);
            this.gameObject.SetActive(false);
			GameObject.Find ("ConditionsKeeper").GetComponent<GameConditions> ().freshCoffee=true;
			GameObject.Find("ConditionsKeeper").GetComponent<GameConditions> ().toNextLevel();
        }
	}
}
