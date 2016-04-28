using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public Vector3 destination;
    LineRenderer line;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 0.5f);
        line = this.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        draw();
	}

    void draw()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, destination);
        
    }
}
