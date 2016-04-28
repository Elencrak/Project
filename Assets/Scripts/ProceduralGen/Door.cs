using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    float openPos;
    float closePos;
	// Use this for initialization
	void Start ()
    {
        closePos = transform.localPosition.z;
        openPos = closePos - 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine("openDoor");
            
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            StartCoroutine("closeDoor");
        }
    }


    IEnumerator openDoor()
    {
        StopCoroutine("closeDoor");
        while (transform.localPosition.z > openPos ) { 
            transform.Translate(0, 0, -0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator closeDoor()
    {
        StopCoroutine("openDoor");
        while (transform.localPosition.z < closePos)
        {
            transform.Translate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
