using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

    public enum StateEnum
    {
        PATROL,
        SHOOTING,
        DEAD
    }

    public State currentState;
    
    

    // Use this for initialization
    void Start () {
        currentState = GetComponent<PatrolState>();
	}
	
	// Update is called once per frame
	void Update () {
        currentState.StateUpdate();
	}
}
