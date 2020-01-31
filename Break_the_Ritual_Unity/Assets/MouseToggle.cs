using UnityEngine;
using System.Collections;

public class MouseToggle : MonoBehaviour
{
    public GameObject toggleTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        toggleTarget.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
