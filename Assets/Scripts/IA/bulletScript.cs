using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
    
    public Vector3 direction = Vector3.zero;
    public float speed;
    LineRenderer line;
	
	// Update is called once per frame
	void Update () {
        if(direction != Vector3.zero)
            transform.position += direction * speed * Time.deltaTime;
	}
    

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag != "Enemy")
            Destroy(gameObject);
    }
    
}
