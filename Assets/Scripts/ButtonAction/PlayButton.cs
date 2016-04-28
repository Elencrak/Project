using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButton : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { this.OnClickPlay(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlay()
    {
        Debug.Log("ButtonPlay Clicked");
        Application.LoadLevel(2);
    }
}
