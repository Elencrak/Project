using UnityEngine;
using System.Collections;

public class ShootIA : MonoBehaviour {
    public Vector2 offset;
    float range = 500;
    public float precision=2;
    public float sprayRecul;
    public float maxRecul = 0.5f;
    public GameObject bullet;
    GameObject player;
    public float shootSpeed=0.5f;
    int bulletShoot=0;
    float lastShoot;
    Vector3 direction;
    int sprayReset = 10;

    // Use this for initialization
    void Start () {
        lastShoot = -1;
        player = GameObject.FindGameObjectWithTag("Player");
        bulletShoot = 0;
    }
	
	// Update is called once per frame
	void Update () {

            if (lastShoot + shootSpeed < Time.time)
            {
                lastShoot = Time.time;
                aim();
            }
    }

    void aim()
    {
        //if (sprayReset < bulletShoot)
        //    bulletShoot = 0;
        transform.LookAt(player.transform.position);
        direction = transform.forward * precision;
        //direction = player.transform.position - transform.position;
        trigger();
    }

    void trigger()
    {
        

        RaycastHit ray;
        
        direction.x +=  Random.Range(-offset.x, offset.x);
        float recul = Mathf.Max(0, Mathf.Min((float)bulletShoot / 20, sprayRecul));
        direction.y += Mathf.Min(maxRecul, (sprayRecul*bulletShoot)) + Random.Range(-offset.y, offset.y);

        Debug.DrawRay(transform.position, direction);
        if (Physics.Raycast(transform.position, direction, out ray, range))
        {
            //Debug.Log("Name:"+ray.collider.name +" Distance:" + ray.distance);
            Instantiate(bullet, ray.point, bullet.transform.rotation);
        }


        bulletShoot++;
    }
}
