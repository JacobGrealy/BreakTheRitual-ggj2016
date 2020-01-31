using UnityEngine;
using System.Collections;

public class DogAnimationontroller : MonoBehaviour
{
    public KeyFrameAnimator keyFrameAnimator;

	// Use this for initialization
	void Start ()
    {
        startEndAnimation();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void startEndAnimation()
    {
        GetComponent<Animator>().Play("DogEndAnimation");
    }
}
