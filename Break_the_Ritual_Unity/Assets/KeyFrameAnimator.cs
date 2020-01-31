using UnityEngine;
using System.Collections;

[System.Serializable]

public class KeyFrameAnimator : MonoBehaviour
{
    public MonoBehaviour objectToAnimate;
    public KeyFrameBehavior[] keyFrames;

    private int currentKeyFrame = 0;
    public int GetCurrentKeyFrame()
    {
        return currentKeyFrame;
    }

    bool isPlaying = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startAnimation()
    {
        isPlaying = true;
        currentKeyFrame = 0;
        playNextKeyFrame();
    }

    private void playNextKeyFrame()
    {
        if (currentKeyFrame >= keyFrames.Length)
        {
            isPlaying = false;
            Debug.Log("Is playing: " + isPlaying);
            return; //No more key frames to animate
        }

        //Start Next Animation if applicable
        string currentAnimationName = keyFrames[currentKeyFrame].animationName;
        if (currentAnimationName != null && currentAnimationName.Length >= 1)
        {
            objectToAnimate.GetComponent<Animator>().Play(keyFrames[currentKeyFrame].animationName);
        }

        //play sound if applicable
        AudioClip currentSound = keyFrames[currentKeyFrame].sound;
        if (currentSound != null)
        {
            objectToAnimate.GetComponent<AudioSource>().PlayOneShot(currentSound);
        }

        //Check if there is another key frame to translate to
        int nextKeyFrame = currentKeyFrame + 1;
        if (nextKeyFrame >= keyFrames.Length)
        {
            isPlaying = false;
            Debug.Log("Is playing: " + isPlaying);
            return; //No more key frames to animate

        }
        //Start Next Translate
        StartCoroutine(Translate(keyFrames[currentKeyFrame].transform, keyFrames[nextKeyFrame].transform, keyFrames[nextKeyFrame].speed));
        currentKeyFrame += 1;
        Debug.Log("Is playing: " + isPlaying);
    }

    IEnumerator Translate(Transform startMarker, Transform endMarker, float speed)
    {
        if(speed!=0)speed = 1f / speed;
        for (float f = 0f; f < 1f; f += speed * Time.deltaTime)
        {
            //Debug.Log("\n f: " + f);
            //sanity check, we dont want to lerp past it
            if (f > 1f) f = 1f;
            objectToAnimate.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, f);
            objectToAnimate.transform.rotation = Quaternion.Lerp(startMarker.rotation, endMarker.rotation, f);
            objectToAnimate.transform.localScale = Vector3.Lerp(startMarker.localScale, endMarker.localScale, f);
            yield return null;
        }
        Debug.Log("play next key frame");
        playNextKeyFrame();
    }
}