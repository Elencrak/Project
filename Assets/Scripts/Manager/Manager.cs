using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

    //
    float waitToload = 5f;

    static Manager instance;

    // Getter
    public static Manager Instance
    {
        get
        {
            return instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        if (Application.loadedLevel == 0)
            Application.LoadLevelAsync(1);
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
