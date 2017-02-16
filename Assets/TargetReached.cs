using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReached : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
          
        }
       // Debug.Log("Collided");
    }

    private void ResetPositionOfMugShot(Collider2D other)
    {
        other.transform.position = other.GetComponent<CardTouch>().initialPosition;
        other.GetComponent<CardTouch>().moveCardToRight = false;
        other.GetComponent<CardTouch>().moveCardToLeft = false;
        other.GetComponent<CardTouch>().eventSystem.SetActive(true);
    }
}
