using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreValue : MonoBehaviour {

    public int fullSentenceScore = 0;
    public int halfSentenceScore = 0;
    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        // Do not destroy this game object:
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
