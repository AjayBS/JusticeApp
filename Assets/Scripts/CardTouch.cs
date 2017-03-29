using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardTouch : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject DraggedInstance;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    public Vector3 initialPosition;
    public GameObject targetRight;
    public GameObject targetLeft;
    float _zDistanceToCamera;
    Vector3 transformOfObject;
    public bool moveCardToRight = false;
    public bool moveCardToLeft = false;
    public GameObject eventSystem;
    GameObject canvas;

    // Use this for initialization
    void Start () {
        transformOfObject = transform.position;
        initialPosition = transform.position;
        eventSystem = GameObject.FindGameObjectWithTag("DragSystem");
        canvas = GameObject.FindGameObjectWithTag("CanvasInformation");
        //targetLeft.transform.position = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z);
        //targetRight.transform.position = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);//transform.position.x - 400;
    }
	
	// Update is called once per frame
	void Update () {
        if(moveCardToRight)
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetRight.transform.position, 10 * Time.deltaTime);
            eventSystem.SetActive(false);
            StartCoroutine(DoFade());
            
            // Debug.Log(GameObject.FindGameObjectWithTag("DragSystem").activeSelf);
        }
  
        if (moveCardToLeft)
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetLeft.transform.position, 10 * Time.deltaTime);
            eventSystem.SetActive(false);
           
            StartCoroutine(DoFade());
        }
       
    }

    IEnumerator DoFade()
    {
        while(canvas.GetComponent<CanvasGroup>().alpha > 0)
        {
            canvas.GetComponent<CanvasGroup>().alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvas.GetComponent<CanvasGroup>().interactable = false;
        yield return null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedInstance = gameObject;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);
        if (Input.touchCount > 1)
        {
            _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
          new Vector3(Input.GetTouch(0).position.x, transformOfObject.y, _zDistanceToCamera)
      );
        }
        else
        {
            _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
           new Vector3(Input.mousePosition.x, transformOfObject.y, _zDistanceToCamera)
       );
        }
           

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount > 1)
        {
            transform.position = Camera.main.ScreenToWorldPoint(
           new Vector3(Input.GetTouch(0).position.x, transformOfObject.y, _zDistanceToCamera)
           ) + _offsetToMouse;
          //  Debug.Log(transform.position.x);
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(
           new Vector3(Input.mousePosition.x, transformOfObject.y, _zDistanceToCamera)
           ) + _offsetToMouse;
           // Debug.Log(transform.position.x);
        }


        CheckCardPosition();
    }

    void CheckCardPosition()
    {
        if (Input.touchCount > 1)
        {
            Debug.Log(transform.position);
            if (transform.position.x > targetRight.transform.position.x - 19 && moveCardToRight == false)
            {
                //Debug.Log("Moved right");
                GameObject.Find("StoreValues").GetComponent<StoreValue>().fullSentenceScore++;
                GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.Add(1);
                moveCardToRight = true;
            }
            else if (transform.position.x < targetLeft.transform.position.x + 19 && moveCardToLeft == false)
            {
                //Debug.Log("Moved left");
                GameObject.Find("StoreValues").GetComponent<StoreValue>().halfSentenceScore++;
                GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.Add(0);
                moveCardToLeft = true;
            }
        }
        else
        {
           // Debug.Log(Input.mousePosition.x);
            if (transform.position.x > targetRight.transform.position.x - 19 && moveCardToRight == false)
            {
               // Debug.Log("Moved right");
                GameObject.Find("StoreValues").GetComponent<StoreValue>().fullSentenceScore++;
                GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.Add(1);
                moveCardToRight = true;
            }
            else if (transform.position.x < targetLeft.transform.position.x + 19 && moveCardToLeft == false)
            {
                //Debug.Log("Moved left");
                GameObject.Find("StoreValues").GetComponent<StoreValue>().halfSentenceScore++;
                GameObject.Find("StoreValues").GetComponent<StoreValue>().arrayList.Add(0);
                moveCardToLeft = true;
            }
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedInstance = null;
        _offsetToMouse = Vector3.zero;
    }
}
