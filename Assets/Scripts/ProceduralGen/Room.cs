using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Room : MonoBehaviour {

    public List<Prop> props;
    public List<Door> doors;
    public List<Corridor> corridors;

    // Use this for initialization
    void Start() {
        Door[] tempDoor;
        tempDoor = GetComponentsInChildren<Door>();
        foreach (Door d in tempDoor)
        {
            doors.Add(d);
        }

        Prop[] tempProps;
        tempProps = GetComponentsInChildren<Prop>();
        foreach (Prop d in tempProps)
        {
            props.Add(d);
        }

        GameObject[] tempCorridor = GameObject.FindGameObjectsWithTag("Corridor");
        foreach (GameObject c in tempCorridor)
        {
            corridors.Add(c.GetComponent<Corridor>());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
            foreach (GameObject room in rooms)
            {
                if (room.GetInstanceID() != gameObject.GetInstanceID())
                {
                    Destroy(room);
                }
            }

            GameObject[] corridors = GameObject.FindGameObjectsWithTag("Corridor");
            foreach (GameObject corridor in corridors)
            {
                    Destroy(corridor);
            }


            GameObject corridor1 = Instantiate(Resources.Load("CorridorCross"), new Vector3(transform.position.x + 30, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
            GameObject corridor2 = Instantiate(Resources.Load("CorridorCross"), new Vector3(transform.position.x - 30, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0)) as GameObject;
            GameObject corridor3 = Instantiate(Resources.Load("CorridorCross"), new Vector3(transform.position.x, transform.position.y, transform.position.z + 30), Quaternion.Euler(90, 0, 0)) as GameObject;
            GameObject corridor4 = Instantiate(Resources.Load("CorridorCross"), new Vector3(transform.position.x, transform.position.y, transform.position.z - 30), Quaternion.Euler(90, 0, 0)) as GameObject;
        }
    }
}
