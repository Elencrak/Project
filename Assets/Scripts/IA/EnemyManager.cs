using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {
    static public EnemyManager instance;
    List<GameObject> enemyList;

    void Awake()
    {
        instance = this;
        enemyList = new List<GameObject>();
    }

    public void addEnemy(GameObject en)
    {
        enemyList.Add(en);
    }

    public void removeEnemy(GameObject en)
    {
        enemyList.Remove(en);
    }

    public void removeAllEnemy()
    {
        enemyList.RemoveRange(0, enemyList.Count);
    }

    public void alert()
    {
        foreach (GameObject go in enemyList)
        {
            //go.getComponent<IA>.changeState()  .... 
        }
    }


    void Start () {
	
	}
	

	void Update () {
	
	}
}
