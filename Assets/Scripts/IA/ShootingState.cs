﻿using UnityEngine;
using System.Collections;

public class ShootingState : MonoBehaviour, State {

    bool init = false;
    public Vector2 offset;
    float range = 50;
    public float precision = 2;
    public float sprayRecul;
    public float maxRecul = 0.5f;
    public GameObject bullet;
    GameObject player;
    public float shootSpeed = 0.5f;
    int bulletShoot = 0;
    float lastShoot;
    Vector3 direction;
    int sprayReset = 10;
    float rotationSpeed;

    public void Init()
    {
        lastShoot = -1;
        player = GameObject.FindGameObjectWithTag("Player");
        bulletShoot = 0;
        rotationSpeed = GetComponent<EnemyScript>().rotationSpeed;
        init = true;
    }

    public void StateUpdate()
    {
        if (init)
        {
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
       
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    if (lastShoot + shootSpeed < Time.time)
                    {
                        lastShoot = Time.time;
                        aim();
                    }
                }
                else
                {
                    Debug.Log(hit.transform.tag);
                    Debug.Log("Lol pd");
                    GetComponent<EnemyScript>().currentState = GetComponent<PatrolState>();
                }
            }
            else
            {
                GetComponent<EnemyScript>().currentState = GetComponent<PatrolState>();
            }
        }
        else
        {
            Init();
        }
    }

    void aim()
    {
        //if (sprayReset < bulletShoot)
        //    bulletShoot = 0;
        
        var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
       
        transform.LookAt(player.transform.position);
        direction = transform.forward * precision;
        //direction = player.transform.position - transform.position;
        trigger();
    }

    void trigger()
    {


        RaycastHit ray;
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 targetPosition = Vector3.zero;

        targetPosition += Random.Range(-offset.x, offset.x) * transform.right;
        targetPosition += Random.Range(-offset.y, offset.y) * transform.up;
        if(targetPosition.magnitude > 1.0f)
            targetPosition.Normalize();
        targetPosition += player.transform.position;

        Debug.DrawLine(transform.position, targetPosition, Color.red);
        if (Physics.Raycast(transform.position, targetPosition-transform.position, out ray, range))
        {
            //Debug.Log("Name:"+ray.collider.name +" Distance:" + ray.distance);
            //Instantiate(bullet, ray.point, bullet.transform.rotation);
        }

        bulletShoot++;
    }
}