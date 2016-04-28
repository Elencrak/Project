using UnityEngine;
using System.Collections;

public class TestSound : MonoBehaviour {

    // Var for testing sound
    public AudioClip myTestAudioClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Test son");
            SoundManager.Instance.playeSound(myTestAudioClip, 1);
        }
	}
}
