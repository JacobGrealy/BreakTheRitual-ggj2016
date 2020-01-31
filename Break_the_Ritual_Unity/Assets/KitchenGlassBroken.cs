using UnityEngine;
using System.Collections;

public class KitchenGlassBroken : MonoBehaviour
{
    public GameObject idleDog;
    public GameObject runningDog;
    // Use this for initialization
    void Start ()
    {
        Invoke("ActivateDog", 1.5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void ActivateDog()
    {
        idleDog.SetActive(false);
        runningDog.SetActive(true);
    }
}
