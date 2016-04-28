using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    static SoundManager instance;
    public GameObject speakerPrefab;

    private GameObject speaker;

    // getter
    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject playeSound(AudioClip myclip, float volume)
    {
        //Debug.Log(myclip);
        speaker = (GameObject)Instantiate(speakerPrefab, Vector3.zero, Quaternion.identity);
        AudioSource audioSource = speaker.GetComponent<AudioSource>();
        audioSource.clip = myclip;
        audioSource.Play();
        audioSource.volume = volume;
        speaker.AddComponent<DestroyByTime>().delayToDestroy = myclip.length;
        return speaker;
    }
}
