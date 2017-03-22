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
    static int i = 0;
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
        GameObject.Find("Main Camera").GetComponent<ReadJson>().LoadData();
    }

    private void ResetPositionOfMugShot(Collider2D other)
    {
        other.transform.position = other.GetComponent<CardTouch>().initialPosition;
        other.GetComponent<CardTouch>().moveCardToRight = false;
        other.GetComponent<CardTouch>().moveCardToLeft = false;
        other.GetComponent<CardTouch>().eventSystem.SetActive(true);
    }
}
