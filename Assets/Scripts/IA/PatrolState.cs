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
            Debug.Log("Patrouille");
            var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
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
                transform.GetChild(0).GetComponent<Animator>().SetBool("shoot", true);
                GetComponent<EnemyScript>().currentState = GetComponent<ShootingState>();
            }
        }
        else
            Init();
    }
}
