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
    public Text probabilityScoreValue;
    public Text weightValue;

    public Text birthValue;
    public Text offenseValue;

    public Text zipCodeValue;
    public Text citizenshipValue;

    public Text maritalValue;
    public Text educationValue;
    public Text employmentValue;

    public Text priorFeloniesValue;
    public Text priorViolentFeloniesValue;

    public Text priorDrugOffenseValue;
    public Text priorSexOffenseValue;

    public Text raceValue;
    static int index = 0;

    // Use this for initialization
    void Start () {
        StartCoroutine(GetTextFromWWW());
    }

    public void LoadData()
    {      
            Debug.Log(jsonString);
            if(index < itemData["profiles"].Count)
            {
            priorFeloniesValue.text = "N/A";
            raceValue.text = "N/A";
            priorSexOffenseValue.text = "N/A";
            citizenshipValue.text = "N/A";
            birthValue.text = "N/A";
            zipCodeValue.text = "N/A";
            zipCodeValue.text = "N/A";
            zipCodeValue.text = "N/A";
            //race.text = itemData["profiles"][index]["Race"].ToString();
            offenseValue.text = "N/A";
            priorDrugOffenseValue.text = "N/A";
            educationValue.text = "N/A";
            educationValue.text = "N/A";            
            employmentValue.text = "N/A";
            priorViolentFeloniesValue.text = "N/A";
            priorViolentFeloniesValue.text = "N/A";
            priorFeloniesValue.text = "N/A";
            priorSexOffenseValue.text = "N/A";

            //  IDictionary tdictionary = jsonString as IDictionary;
            if (jsonString.Contains("Race"))
            {
                raceValue.text = itemData["profiles"][index]["Race"].ToString();
            }
            if (jsonString.Contains("Prior felonies"))
            {
                priorFeloniesValue.text = itemData["profiles"][index]["Prior felonies"].ToString();
            }
            if (jsonString.Contains("Prior sex offenses"))
            {
                priorSexOffenseValue.text = itemData["profiles"][index]["Prior sex offenses"].ToString();
            }
           if(jsonString.Contains("Citizenship"))
            {
                citizenshipValue.text = itemData["profiles"][index]["Citizenship"].ToString();
            }
            if(jsonString.Contains("Date of Birth"))
            {
                birthValue.text = itemData["profiles"][index]["Date of Birth"].ToString();
            }
            if (jsonString.Contains("Zipcode"))
            {
                zipCodeValue.text = itemData["profiles"][index]["Zipcode"].ToString();
            }
            if (jsonString.Contains("Zipcode"))
            {
                zipCodeValue.text = itemData["profiles"][index]["Zipcode"].ToString();
            }
            if(jsonString.Contains("Marital Status"))
            {
                zipCodeValue.text = itemData["profiles"][index]["Marital Status"].ToString(); 
            }
            if(jsonString.Contains("Race"))
            {
                //race.text = itemData["profiles"][index]["Race"].ToString();
            }
            if (jsonString.Contains("Offense"))
            {
                offenseValue.text = itemData["profiles"][index]["Offense"].ToString();
            }
            if(jsonString.Contains("Prior drug offense"))
            {
                priorDrugOffenseValue.text = itemData["profiles"][index]["Prior drug offense"].ToString();
            }
            if (jsonString.Contains("Education"))
            {
                educationValue.text = itemData["profiles"][index]["Education"].ToString();
            }
            if (jsonString.Contains("Education"))
            {
                educationValue.text = itemData["profiles"][index]["Education"].ToString();
            }
            if (jsonString.Contains("Employment"))
            {
                employmentValue.text = itemData["profiles"][index]["Employment"].ToString();
            }
            if (jsonString.Contains("Prior violent felonies"))
            {
                priorViolentFeloniesValue.text = itemData["profiles"][index]["Prior violent felonies"].ToString();
            }
            if (jsonString.Contains("Prior violent felonies"))
            {
                priorViolentFeloniesValue.text = itemData["profiles"][index]["Prior violent felonies"].ToString();
            }
            if (jsonString.Contains("Prior felonies"))
            {
                priorFeloniesValue.text = itemData["profiles"][index]["Prior felonies"].ToString();
            }
            if (jsonString.Contains("Prior sex offenses"))
            {
                priorSexOffenseValue.text = itemData["profiles"][index]["Prior sex offenses"].ToString();
            }


            index++;
            }
            else
            {
           
           // Debug.Log(url);
            // StartCoroutine(GetTextFromWWW());
            SceneManager.LoadScene("FinalScene");
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

        Debug.Log(GameObject.Find("StoreValues").GetComponent<StoreValue>().url+" is the url");
       // GameObject.Find("StoreValues").GetComponent<StoreValue>().url = ;
        WWW www = new WWW(GameObject.Find("StoreValues").GetComponent<StoreValue>().url);

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

        if(GameObject.Find("StoreValues").GetComponent<StoreValue>().currentRound == 1)
        {
            GameObject.Find("StoreValues").GetComponent<StoreValue>().id = itemData["id"]["$oid"].ToString();
        }

        LoadData();

        
    }
   
}
