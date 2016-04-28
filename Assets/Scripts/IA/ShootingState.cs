using UnityEngine;
using System.Collections;
using System;

public class ShootingState : MonoBehaviour, State {

    bool init = false;

    GameObject player;

    public void Init()
    {
        init = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StateUpdate()
    {
        if (init)
        {
            transform.LookAt(player.transform.position);
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, (player.transform.position - transform.position), out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    // In Range and i can see you!
                    Debug.Log("RATTATATATATATATTAT");
                }
                else
                {
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
}
