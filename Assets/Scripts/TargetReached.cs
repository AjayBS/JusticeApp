using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TargetReached : MonoBehaviour {

    public Text nameText;
    public Text heightText;
    public Text weightText;
    public Text chargeText;
    public Text descriptionText;
    public Text historyText;
    public Text currentStateText;
    GameObject canvas;
    int i = 0;
    // Use this for initialization
    void Start () {
        // name = GetComponent<Text>();
        canvas = GameObject.FindGameObjectWithTag("CanvasInformation");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "MugShot")
        {
            Debug.Log("Collided");
            ResetPositionOfMugShot(other);
            GetSetOfNewDetails();
            StartCoroutine(DoFade());
           // GameObject.FindGameObjectWithTag("CanvasInformation").GetComponent<Renderer>().enabled = true;
        }
       // Debug.Log("Collided");
    }

    IEnumerator DoFade()
    {
        while (canvas.GetComponent<CanvasGroup>().alpha < 1)
        {
            canvas.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 2;
            yield return null;
        }
        canvas.GetComponent<CanvasGroup>().interactable = false;
        yield return null;
    }

    private void GetSetOfNewDetails()
    {
        if (i == 0)
        {
            nameText.text = "Christian Worthy";
            heightText.text = "5’’ 9’";
            weightText.text = "140";
            historyText.text = "Domestic Violence Arrest, no charges";
            chargeText.text = "Manslaughter";
            descriptionText.text = "Suspect appears to have accidentally killed brother in a fight.";
            currentStateText.text = "Jail";
        }
        else if(i == 1)
        {
            nameText.text = "Joe Rowlen";
            heightText.text = "6’’ 0’";
            weightText.text = "190";
            historyText.text = "2 other convictions of possession";
            chargeText.text = "Possession";
            descriptionText.text = "N/ A";
            currentStateText.text = "Treatment and Parole";
        }
        else if (i == 2)
        {
            nameText.text = "Dave Wellen";
            heightText.text = "6’’ 5’";
            weightText.text = "260";
            historyText.text = "Served 1.5 years in prison for stalking. Got out early on good behavior.";
            chargeText.text = "Sexual Assault";
            descriptionText.text = "N/ A";
            currentStateText.text = "Jail";
        }
        else if (i == 3)
        {
            nameText.text = "Bob Rhogan";
            heightText.text = "6’’ 1’";
            weightText.text = "190";
            historyText.text = "Served 3 years in prison for possession";
            chargeText.text = "Robbery and possession";
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

    private void ResetPositionOfMugShot(Collider2D other)
    {
        other.transform.position = other.GetComponent<CardTouch>().initialPosition;
        other.GetComponent<CardTouch>().moveCardToRight = false;
        other.GetComponent<CardTouch>().moveCardToLeft = false;
        other.GetComponent<CardTouch>().eventSystem.SetActive(true);
    }
}
