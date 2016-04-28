using UnityEngine;
using System.Collections;
using System;

public class Shoot : MonoBehaviour {

    //Linked game objects
    GameObject currentGun;
    public Transform endGun;
    public Transform douilleEjecteur;

    // Gun values
    public int currentGunAmmo;
    public int currentGunMaxClip = 6;
    public int ammoStored;
    public int maxAmmoStored = 36;
    public float shootPower;
    public float ejectionPower;

    // timers
    public float reloadTime = 0.1f;
    public float shootDelay = 0.01f;

    //Coroutines
    Coroutine shoot;
    Coroutine reload;

    //Instantiations
    public GameObject bullet;
    public GameObject douille;

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
        if (Input.GetButton("Reload") && hasToReload())
        {
            Reload();
        }
        else if(Input.GetButton("Fire") && shoot == null && reload == null)
        {
            shoot = StartCoroutine(CorShoot());
        }
    }

    private bool hasToReload()
    {
        return currentGunAmmo < currentGunMaxClip;
    }

    public void AddAmmo(int amount)
    {
        ammoStored = Mathf.Min(amount + ammoStored, maxAmmoStored);
    }

    public void Reload()
    {
        if(reload == null)
        {
            reload = StartCoroutine(CorReload());
        }
    }

    IEnumerator CorReload()
    {
        yield return new WaitForSeconds(reloadTime);

        if (ammoStored != 0)
        {
            if (hasToReload())
            {
                if (ammoStored > 0)
                {
                    ammoStored -= currentGunMaxClip - currentGunAmmo;
                }
                currentGunAmmo = currentGunMaxClip;
            }
        }

        reload = null;
    }

    IEnumerator CorShoot()
    {
        if(currentGunAmmo > 0)
        {
            // Instantiate Bullet
            if (bullet)
            {
                GameObject go = Instantiate(bullet, endGun.position, transform.parent.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddExplosionForce(shootPower, endGun.position - transform.parent.forward, 1.5f);
            }

            // Instantiate Douille
            if (douille)
            {
                GameObject go = Instantiate(douille, douilleEjecteur.position, transform.parent.rotation) as GameObject;
                go.GetComponent<Rigidbody>().AddForce(ejectionPower * (transform.parent.right + transform.parent.up).normalized);
            }

            currentGunAmmo--;

            yield return new WaitForSeconds(shootDelay);
        }
        else
        {
            Reload();
        }

        shoot = null;
    }
}
