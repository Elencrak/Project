using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Props : MonoBehaviour {

    public List<Prop> listOfProps;
    public GameObject[] props;

	// Use this for initialization
	void Start () {
        Prop[] tempProp;

        tempProp = GetComponentsInChildren<Prop>();
        foreach (Prop p in tempProp)
        {
            listOfProps.Add(p);
        }
    }
	
}
