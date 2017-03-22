using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ReadJson : MonoBehaviour {
    private string textFromWWW;
    private string jsonString;
    private string url = "http://mysafeinfo.com/api/data?list=englishmonarchs&format=json";
    private JsonData itemData;



    public Text nameText;
    public Text heightText;
    public Text weightText;
    public Text chargeText;
    public Text descriptionText;
    public Text historyText;
    public Text currentStateText;
    static int i = 0;

    // Use this for initialization
    void Start () {
        //StartCoroutine(GetTextFromWWW());
        ReadDataFromSource();
        LoadData();
        
    }

    public void LoadData()
    {
        if (i == 0)
        {
            nameText.text = "Christian Worthy";
            heightText.text = "5’’ 9’";
            weightText.text = "140";
            historyText.text = "Domestic Violence Arrest, no charges";
            chargeText.text = itemData[i]["Offense"].ToString();
            descriptionText.text = "Suspect appears to have accidentally killed brother in a fight.";
            currentStateText.text = "Jail";
        }
        else if (i == 1)
        {
            nameText.text = "Joe Rowlen";
            heightText.text = "6’’ 0’";
            weightText.text = "190";
            historyText.text = "2 other convictions of possession";
            chargeText.text = itemData[i]["Offense"].ToString();
            descriptionText.text = "N/ A";
            currentStateText.text = "Treatment and Parole";
        }
        else if (i == 2)
        {
            nameText.text = "Dave Wellen";
            heightText.text = "6’’ 5’";
            weightText.text = "260";
            historyText.text = "Served 1.5 years in prison for stalking. Got out early on good behavior.";
            chargeText.text = itemData[i]["Offense"].ToString();
            descriptionText.text = "N/ A";
            currentStateText.text = "Jail";
        }
        else if (i == 3)
        {
            nameText.text = "Bob Rhogan";
            heightText.text = "6’’ 1’";
            weightText.text = "190";
            historyText.text = "Served 3 years in prison for possession";
            chargeText.text = itemData[i]["Offense"].ToString();
            descriptionText.text = "Suspect was high and attempted to rob a drug store.";
            currentStateText.text = "Jail and Treatment";
        }
        else
        {
            SceneManager.LoadScene("FinalScene");
        }
        i++;
        //nameText.text = "Ajay Sathish";
      
    }

    // Update is called once per frame
    void Update () {
       // Debug.Log(textFromWWW);
	}

    void ReadDataFromSource()
    {
        jsonString = File.ReadAllText(Application.dataPath + "/Resources/Items.json");
        itemData = JsonMapper.ToObject(jsonString);
        Debug.Log(itemData[0]["Education"]);
    }

    IEnumerator GetTextFromWWW()
    {
        WWW www = new WWW(url);

        yield return www;

        if (www.error != null)
        {
            Debug.Log("Ooops, something went wrong...");
        }
        else
        {
            textFromWWW = www.text;
        }
        itemData = JsonMapper.ToObject(textFromWWW);
        Debug.Log(itemData[1]["nm"]);
    }
   
}
