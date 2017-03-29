using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeInput : MonoBehaviour
{
    [SerializeField]
    private float minimumSwipeDistanceY;
    [SerializeField]
    private float minimumSwipeDistanceX;

    public Canvas mainCanvas;
    public Canvas subCanvas;

    private Touch t = default(Touch);
    private Vector3 startPosition = Vector3.zero;

    private void Update()
    {
        if (Input.touches.Length > 0)
        {

            t = Input.touches[0];

            switch (t.phase)
            {
                case TouchPhase.Began:
                    startPosition = t.position;
                    return;
                case TouchPhase.Ended:
                    Vector3 positionDelta = (Vector3)t.position - startPosition;
                    if (Mathf.Abs(positionDelta.y) > minimumSwipeDistanceY)
                    {
                        if (positionDelta.y > 0)
                        {
                            Debug.Log("UP SWIPE!!!");
                            GameObject.Find("MugShot").GetComponent<MeshRenderer>().enabled = false; //= new Vector3(1, 1, 1);
                            GameObject.Find("Info").GetComponent<MeshRenderer>().enabled = true;
                            GameObject.Find("Info").GetComponent<HorizontalLayoutGroup>().enabled = true;
                            //else
                            //{
                            //    mainCanvas.GetComponent<CanvasGroup>().alpha = 1;
                            //    subCanvas.GetComponent<CanvasGroup>().alpha = 0;
                            //}
                        }
                        else
                        {
                            Debug.Log("DOWN SWIPE!!!");
                            GameObject.Find("MugShot").GetComponent<MeshRenderer>().enabled = true; //= new Vector3(1, 1, 1);
                            GameObject.Find("Info").GetComponent<MeshRenderer>().enabled = false;
                            GameObject.Find("Info").GetComponent<HorizontalLayoutGroup>().enabled = false;
                        }
                    }
                    if (Mathf.Abs(positionDelta.x) > minimumSwipeDistanceX)
                    {
                        if (positionDelta.x > 0)
                        {
                            Debug.Log("SWIPE RIGHT");
                        }
                        else
                        {
                            Debug.Log("SWIPE LEFT");
                        }
                    }
                    return;
                default:
                    return;
            }
        }
    }
}