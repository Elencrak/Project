using UnityEngine;
using System.Collections;

public class Interactible : MonoBehaviour {

    Collider interactiveCollider;
    Rigidbody interactiveRigidBody;

    public bool isGrabable;
    public GameObject _holster;

	// Use this for initialization
	void Start () {
        interactiveRigidBody = GetComponent<Rigidbody>();
        interactiveCollider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(_holster)
        {
            transform.position = _holster.transform.position;
        }
	}

    public GameObject Use(GameObject holster = null)
    {
        Debug.Log("Use : " + name);
        interactiveCollider.enabled = false;
        if(isGrabable && holster)
        {
            _holster = holster;
            return gameObject;
        }
        return null;
    }

    public void Throw(Vector3 direction, float force)
    {
        Debug.Log("Throw : " + name);
        _holster = null;
        interactiveCollider.enabled = true;
        interactiveRigidBody.isKinematic = false;
        interactiveRigidBody.AddForce(direction * force);
        Debug.Log("Throw : " + _holster);
    }

    void OnCollisionEnter(Collision coll)
    {
        if(!interactiveRigidBody.isKinematic && coll.gameObject.CompareTag("Wall"))
        {
            interactiveRigidBody.isKinematic = true;
        }
    } 
}
