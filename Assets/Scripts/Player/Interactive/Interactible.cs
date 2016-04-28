using UnityEngine;
using System.Collections;

public class Interactible : MonoBehaviour {

    BoxCollider interactiveTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Use()
    {
        Debug.Log("Use : " + name);
    }
}
