using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    public GameObject target;
    public GameObject toggle;

    private Vector3 initialPos;
    bool followingMouse = false;
    bool clickable = true;

    // Use this for initialization
    void Start ()
    {
        initialPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*//If this was dropped on it's target last frame
        if (consumed == true)
        {
            toggle
            this.gameObject.SetActive(false);
        }*/

        if (followingMouse == true)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
            this.transform.position = targetPosition;
        }
	}

    void OnMouseDown()
    {
        if(clickable)
            followingMouse = true;
    }

    void OnMouseUp()
    {
        //Debug.Log("MouseUp");
        followingMouse = false;
        clickable = false;

        //Check if over target
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        bool targetFound = false;
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider.gameObject.GetInstanceID() == target.GetInstanceID())
            {
                targetFound = true;
            }
        }
        if (targetFound == true)
        {
            if (toggle != null)
            {
                toggle.SetActive(!toggle.activeSelf);
            }
            this.gameObject.SetActive(false);
        }


        //else return to start postition
        else
        {
            StartCoroutine(Translate(this.transform.position, initialPos, 3f));
        }
    }

    IEnumerator Translate(Vector3 startMarker, Vector3 endMarker, float speed)
    {
        for (float f = 0f; f < 1f; f += speed * Time.deltaTime)
        {
            //sanity check, we dont want to lerp past it
            if (f > 1f) f = 1f;
            this.transform.position = Vector3.Lerp(startMarker, endMarker, f);
            yield return null;
        }
        this.transform.position = endMarker; //correct close but not quite 1
        clickable = true;
    }

}
