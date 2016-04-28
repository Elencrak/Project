using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interact : MonoBehaviour {

    public List<Interactible> interactibles;
    public GameObject holsterOnArm;
    public GameObject collected;

    public float throwForce = 5.0f;

	// Use this for initialization
	void Start () {
        interactibles = new List<Interactible>();
        holsterOnArm = transform.Find("Holster").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Interact"))
        {
            bool isGrabbed = false;
            for (int i = 0; i < interactibles.Count; i++)
            {
                GameObject go = interactibles[i].Use(holsterOnArm);
                if(go && collected == null)
                {
                    isGrabbed = true;
                    collected = go;
                }
            }
            if(!isGrabbed && collected)
            {
                collected.GetComponent<Interactible>().Throw(transform.forward, throwForce);
                collected = null;
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Interactible") && !interactibles.Contains(coll.GetComponent<Interactible>()))
        {
            Debug.Log("Add : " + coll.name);
            interactibles.Add(coll.GetComponent<Interactible>());
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.CompareTag("Interactible") && interactibles.Contains(coll.GetComponent<Interactible>()))
        {
            Debug.Log("Remove : " + coll.name);
            interactibles.Remove(coll.GetComponent<Interactible>());
        }
    }
}
