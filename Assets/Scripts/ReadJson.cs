using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class ReadJson : MonoBehaviour {
    private string textFromWWW;
    private string jsonString;
    private string url = "http://logandanielcox.me/round1/test";
    private JsonData itemData;



    //public Text nameText;
    //public Text heightText;
    //public Text weightText;
    //public Text chargeText;
    //public Text descriptionText;
    //public Text historyText;
    //public Text currentStateText;

    public Text offenceValue;
    public Text DOBValue;
    public Text genderValue;
    public Text raceValue;
    static int index = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(GetTextFromWWW());
        //ReadDataFromSource();
       // LoadData();
        
    }

    public void LoadData()
    {
      
            Debug.Log(itemData["profiles"].Count);
            if(index < itemData["profiles"].Count)
            {
            DOBValue.text = itemData["profiles"][index]["Date of Birth"].ToString();
            genderValue.text = itemData["profiles"][index]["Gender"].ToString();
            raceValue.text = itemData["profiles"][index]["Race"].ToString();
            offenceValue.text = itemData["profiles"][index]["Offense"].ToString();
            index++;
            }
            else
            {
            int[] list = GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.ToArray();
            string arrayString = "[" + string.Join(",", list.Select(x => x.ToString()).ToArray()) + "]";
          
            
            url = "http://logandanielcox.me/round2/" + itemData["id"]["$oid"].ToString() + "," + arrayString;
            Debug.Log(url);
            StartCoroutine(GetTextFromWWW());
            }
          
            //if (i == 0)
            //{
            //    DOBValue.text = itemData["profiles"][i]["Date of Birth"].ToString();
            //    genderValue.text = itemData["profiles"][i]["Gender"].ToString();
            //    raceValue.text = itemData["profiles"][i]["Race"].ToString();
            //    offenceValue.text = itemData["profiles"][0]["Offense"].ToString();
            //    //chargeText.text = itemData["profiles"][i]["Offense"].ToString();
            //    //descriptionText.text = "Suspect appears to have accidentally killed brother in a fight.";
            //    //currentStateText.text = "Jail";
            //}
            //else if (i == 1)
            //{
            //    //nameText.text = "Joe Rowlen";
            //    //heightText.text = "6’’ 0’";
            //    //weightText.text = "190";
            //    //historyText.text = "2 other convictions of possession";
            //    //chargeText.text = itemData["profiles"][i]["Offense"].ToString();
            //    //descriptionText.text = "N/ A";
            //    //currentStateText.text = "Treatment and Parole";
            //}
            //else if (i == 2)
            //{
            //    //nameText.text = "Dave Wellen";
            //    //heightText.text = "6’’ 5’";
            //    //weightText.text = "260";
            //    //historyText.text = "Served 1.5 years in prison for stalking. Got out early on good behavior.";
            //    //chargeText.text = itemData["profiles"][i]["Offense"].ToString();
            //    //descriptionText.text = "N/ A";
            //    //currentStateText.text = "Jail";
            //}
            //else if (i == 3)
            //{
            //    //nameText.text = "Bob Rhogan";
            //    //heightText.text = "6’’ 1’";
            //    //weightText.text = "190";
            //    //historyText.text = "Served 3 years in prison for possession";
            //    //chargeText.text = itemData["profiles"][i]["Offense"].ToString();
            //    //descriptionText.text = "Suspect was high and attempted to rob a drug store.";
            //    //currentStateText.text = "Jail and Treatment";
            //}
            //else
            //{
            //    SceneManager.LoadScene("FinalScene");
            //}
           
       
           
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
            jsonString = www.text;
        }
        jsonString = jsonString.Replace(@"\", string.Empty);
        jsonString = jsonString.Trim('"');
        
        itemData = JsonMapper.ToObject(jsonString);
        index = 0;
        LoadData();

        
    }
   
}
