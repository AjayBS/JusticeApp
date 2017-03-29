using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    public Text fullScoreText;
    public Text minScoreText;
    public Button quitButton;
   
    public Button continueButton;

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

        if(GameObject.Find("StoreValues").GetComponent<StoreValue>().currentRound == 5)
        {
            GameObject.Find("ContinueButton").SetActive(false);
        }
        else
        {
            GameObject.Find("ContinueButton").SetActive(true);
            Button btn1 = continueButton.GetComponent<Button>();
            btn1.onClick.AddListener(ContinueLevel);
        }
        
    }

    void TaskOnClick()
    {
        Application.Quit();
    }

    void ContinueLevel()
    {
        int roundNo = ++GameObject.Find("StoreValues").GetComponent<StoreValue>().currentRound;
        int[] list = GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.ToArray();
        string arrayString = "[" + string.Join(",", list.Select(x => x.ToString()).ToArray()) + "]";


        GameObject.Find("StoreValues").GetComponent<StoreValue>().url = "http://logandanielcox.me/round"+ roundNo + "/" + GameObject.Find("StoreValues").GetComponent<StoreValue>().id + "," + arrayString;
        GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.Clear();
        //GameObject.Find("StoreValues").GetComponent<StoreValue>().url = 
        SceneManager.LoadScene("Justice");
    }
        // Update is called once per frame
        void Update () {
        
    }
}
