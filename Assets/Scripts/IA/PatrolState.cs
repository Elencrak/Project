using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PatrolState : MonoBehaviour,State
{
    public List<GameObject> patrolRoad;
    public float patrolSpeed;
    public float visionAngle;

    int index;
    GameObject target;
    GameObject player;

    bool init = false;

    public void Init()
    {
        // TODO : améliorer pour prendre le plus proche
        index = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        target = patrolRoad[index];
        init = true;
    }

    public void StateUpdate()
    {
        if (init)
        {
            Debug.Log("Patrouille");
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position,patrolSpeed*Time.deltaTime);
            if(Vector3.Distance(transform.position,target.transform.position) < 1.0f)
            {
                index++;
                target = patrolRoad[index % patrolRoad.Count];
            }

            // Player Detection

            if (Vector3.Angle(transform.forward, (player.transform.position - transform.position)) < visionAngle)
            {
                //Player Detected
                GetComponent<EnemyScript>().currentState = GetComponent<ShootingState>();
            }


            // FireShot Detection

        }
        else
            Init();
    }
}
