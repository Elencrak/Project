using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Interact : MonoBehaviour {

    public List<Interactible> interactibles;

	// Use this for initialization
	void Start () {
        interactibles = new List<Interactible>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Interact"))
        {
            for (int i = 0; i < interactibles.Count; i++)
            {
                interactibles[i].Use();
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.CompareTag("Interactible") && !interactibles.Contains(coll.GetComponent<Interactible>()))
        {
            interactibles.Add(coll.GetComponent<Interactible>());
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if(coll.gameObject.CompareTag("Interactible") && interactibles.Contains(coll.GetComponent<Interactible>()))
        {
            interactibles.Remove(coll.GetComponent<Interactible>());
        }
    }
}
