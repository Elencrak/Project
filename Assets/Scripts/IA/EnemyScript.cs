﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

    public enum StateEnum
    {
        PATROL,
        SHOOTING,
        DEAD
    }

    void Awake()
    {
        EnemyManager.instance.addEnemy(gameObject);
    }

    public State currentState;

    public float rotationSpeed;
    

    // Use this for initialization
    void Start () {
        currentState = GetComponent<PatrolState>();
	}
	
	// Update is called once per frame
	void Update () {
        currentState.StateUpdate();
	}

    void OnDestroy()
    {
        EnemyManager.instance.removeEnemy(gameObject);
    }
}