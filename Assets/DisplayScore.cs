using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    public Text fullScoreText;
    public Text minScoreText;

    // Use this for initialization
    void Start () {
        fullScoreText.text = GameObject.Find("StoreValues").GetComponent<StoreValue>().fullSentenceScore.ToString();
        minScoreText.text = GameObject.Find("StoreValues").GetComponent<StoreValue>().halfSentenceScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        
    }
}
