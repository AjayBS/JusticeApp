using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreValue : MonoBehaviour {

    public int fullSentenceScore = 0;
    public int halfSentenceScore = 0;

    public string url = "http://logandanielcox.me/round1/test";

    public List<int> arrayList;

    public int currentRound = 1;

    public string id;
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
