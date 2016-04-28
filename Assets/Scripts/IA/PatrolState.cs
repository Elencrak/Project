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
    float rotationSpeed;

    public void Init()
    {
        // TODO : améliorer pour prendre le plus proche
        float maxDist = Mathf.Infinity;
        float tmp;
        for (int i = 0;i<patrolRoad.Count;++i)
        {
            tmp = Vector3.Distance(transform.position, patrolRoad[i].transform.position);
            if (tmp<maxDist)
            {
                maxDist = tmp;
                index = i;
            }
        }
        
        player = GameObject.FindGameObjectWithTag("Player");
        target = patrolRoad[index];
        init = true;
        rotationSpeed = GetComponent<EnemyScript>().rotationSpeed;
    }

    public void StateUpdate()
    {
        if (init)
        {
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            Debug.Log("Patrouille");
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
