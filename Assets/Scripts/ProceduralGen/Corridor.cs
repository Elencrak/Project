using UnityEngine;
using System.Collections;

public class Corridor : MonoBehaviour
{
    GameObject[] roomManager;

    // Use this for initialization
    void Start ()
    {
        roomManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<RoomManager>().rooms;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
            foreach(GameObject room in rooms)
            {
                Destroy(room);
            }

            GameObject[] corridors = GameObject.FindGameObjectsWithTag("Corridor");
            foreach (GameObject c in corridors)
            {
                if (c.GetInstanceID() != gameObject.GetInstanceID())
                {
                    Destroy(c);
                }
            }

            int random = Random.Range(0, roomManager.Length);

            GameObject room1 = Instantiate(roomManager[random], new Vector3(transform.position.x + 30, transform.position.y, transform.position.z), Quaternion.Euler(90,0,0)) as GameObject;
            GameObject room2 = Instantiate(roomManager[random], new Vector3(transform.position.x - 30, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
            GameObject room3 = Instantiate(roomManager[random], new Vector3(transform.position.x, transform.position.y, transform.position.z + 30), Quaternion.Euler(90, 0, 0)) as GameObject;
            GameObject room4 = Instantiate(roomManager[random], new Vector3(transform.position.x, transform.position.y, transform.position.z - 30), Quaternion.Euler(90, 0, 0)) as GameObject;
        }
    }
}
