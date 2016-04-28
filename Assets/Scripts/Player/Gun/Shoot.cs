using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    //Linked game objects
    GameObject currentGun;

    // Gun values
    public int currentGunAmmo;
    public int currentGunMaxClip = 6;
    public int ammoStored;

    // timers
    public float reloadTime = 0.1f;
    public float shootDelay = 0.01f;

    // Use this for initialization
    void Start ()
    {
        if (currentGun == null)
        {
            currentGun = GameObject.FindGameObjectWithTag("Arm");
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Reload()
    {
        if (currentGunAmmo < currentGunMaxClip)
        {
            ammoStored -= currentGunMaxClip - currentGunAmmo;
            currentGunAmmo = currentGunMaxClip;
        }
    }
}
