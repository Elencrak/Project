using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour {

    Material material;

    // Use this for initialization
    void Start() {
        material = GetComponent<Material>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RandomProp()
    {
        int random = Random.Range(0, GetComponentInParent<Props>().props.Length);
        GameObject prop = Instantiate(GetComponentInParent<Props>().props[random], transform.position, Quaternion.identity) as GameObject;
        prop.transform.parent = this.transform;
    }
}
