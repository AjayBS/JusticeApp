using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    public Text fullScoreText;
    public Text minScoreText;
    public Button quitButton;

    // Use this for initialization
    void Start () {
        fullScoreText.text = GameObject.Find("StoreValues").GetComponent<StoreValue>().fullSentenceScore.ToString();
        minScoreText.text = GameObject.Find("StoreValues").GetComponent<StoreValue>().halfSentenceScore.ToString();
        List<int> list = GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList;
        for (int i=0; i< list.Count;i++)
        {
            Debug.Log(list[i]);
        }
        Button btn = quitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
        
    }
}
