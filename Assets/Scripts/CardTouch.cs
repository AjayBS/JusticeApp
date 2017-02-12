using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTouch : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    public GameObject targetRight;
    public GameObject targetLeft;
    float _zDistanceToCamera;
    Vector3 transformOfObject;
    bool moveCardToRight = false;
    bool moveCardToLeft = false;
    GameObject eventSystem;
    // Use this for initialization
    void Start () {
        transformOfObject = transform.position;
        eventSystem = GameObject.FindGameObjectWithTag("DragSystem");
    }
	
	// Update is called once per frame
	void Update () {
        if(moveCardToRight)
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetRight.transform.position, 10 * Time.deltaTime);
            eventSystem.SetActive(false);
           // Debug.Log(GameObject.FindGameObjectWithTag("DragSystem").activeSelf);
        }
        if (moveCardToLeft)
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetLeft.transform.position, 10 * Time.deltaTime);
            eventSystem.SetActive(false);
        }
    }

    void OnMouseEnter()
    {
     
    }

    void OnMouseExit()
    {
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedInstance = gameObject;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, transformOfObject.y, _zDistanceToCamera)
        );

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, transformOfObject.y, _zDistanceToCamera)
            ) + _offsetToMouse;

        

        CheckCardPosition();
    }

    void CheckCardPosition()
    {
        if(Input.mousePosition.x > 700 && moveCardToRight == false)
        {
            Debug.Log("Moved right");
            moveCardToRight = true;
        }
        else if(Input.mousePosition.x < 300 && moveCardToLeft == false)
        {
            Debug.Log("Moved left");
            moveCardToLeft = true;
        } 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance = null;
        _offsetToMouse = Vector3.zero;
    }
}
