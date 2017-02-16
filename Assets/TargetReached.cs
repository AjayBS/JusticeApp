using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetReached : MonoBehaviour {

    public Text nameText;
	// Use this for initialization
	void Start () {
       // name = GetComponent<Text>();
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
          
        }
       // Debug.Log("Collided");
    }

    private void GetSetOfNewDetails()
    {
        nameText.text = "Ajay Sathish";
    }

    private void ResetPositionOfMugShot(Collider2D other)
    {
        other.transform.position = other.GetComponent<CardTouch>().initialPosition;
        other.GetComponent<CardTouch>().moveCardToRight = false;
        other.GetComponent<CardTouch>().moveCardToLeft = false;
        other.GetComponent<CardTouch>().eventSystem.SetActive(true);
    }
}
