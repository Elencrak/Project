using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float delayToDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, delayToDestroy);
	}
}
