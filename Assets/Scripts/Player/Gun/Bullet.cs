using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            Destroy(GetComponent<Rigidbody>());
            GetComponent<Collider>().enabled = false;
        }

        //
        /*
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<>().Hit();
        }
        */
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<Player>().Hit(damage);
        }
    }
}
