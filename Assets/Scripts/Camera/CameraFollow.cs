using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Vector3 offsetPosition;

    Quaternion cameraRotation;

	// Use this for initialization
	void Start () {
        follow = GameObject.FindWithTag("AnchorCamera").transform;
        offsetPosition = transform.position - follow.position;
        cameraRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = cameraRotation;
	}

    // Effectuer dans le late update pour mettre à jour la cam après tous les autre effets
    void LateUpdate()
    {
        // Déplace la camera
        transform.position = Vector3.Lerp(transform.position, follow.position + offsetPosition,0.02f);

        // Applique la rotation
        //transform.LookAt(follow);
    }

}