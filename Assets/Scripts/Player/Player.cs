using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    //Linked game objects and scripts
    Shoot gun;
    Interact hand;

    //Player values
    float life;

    public void Hit(float damage)
    {
        if(life > Values.EPSYLON)
        {
            life -= damage;
        }
        else
        {
            Death();
        }
    }

    void Death()
    {
        //GameManager.Instance.GameOver();
    }

    public int GetLife()
    {
        return Mathf.RoundToInt(life);
    }
}
