using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    private Vector2 firstPoint;
    private Vector2 secondPoint;
    [SerializeField] PlayerController player;
    private float deadZone = 40;

    private bool isSwiping;
    private bool isMobile;


    //Start is called before the first frame update
    //void Start()
    //{
    //    isMobile = Application.isMobilePlatform;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isMobile)
    //        return;

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        isSwiping = true;
    //        tapPosition = Input.mousePosition;

    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        ResetSwipe();
    //    }
    //    else
    //    {


    //        if (Input.touchCount > 0)
    //        {
    //            if (Input.GetTouch(0).phase == TouchPhase.Began)
    //            {
    //                isSwiping = true;
    //                tapPosition = Input.GetTouch(0).position;
    //            }
    //            else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
    //                Input.GetTouch(0).phase == TouchPhase.Ended)
    //            {
    //                ResetSwipe();
    //            }
    //        }

    //    }


    //    CheckSwipe();
    //}

    //private void CheckSwipe()
    //{
    //    swipeDelta = Vector2.zero;

    //    if (isSwiping)
    //    {
    //        if (!isMobile && Input.GetMouseButton(0))
    //        {
    //            swipeDelta = (Vector2)Input.mousePosition - tapPosition;

    //        }
    //        else if (Input.touchCount > 0)
    //        {
    //            swipeDelta = Input.GetTouch(0).position - tapPosition;
    //        }


    //    }

    //    if (swipeDelta.magnitude > deadZone)
    //    {
    //        if (SwipeEvent != null)
    //        {
    //            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
    //            {
    //                SwipeEvent(swipeDelta.x > 0 ? Vector2.right : Vector2.left);
    //            }
    //            else
    //            {
    //                SwipeEvent(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
    //            }

    //            ResetSwipe();
    //        }
    //    }
    //}

    //private void ResetSwipe()
    //{
    //    isSwiping = false;

    //    tapPosition = Vector2.zero;
    //    swipeDelta = Vector2.zero;
    //}
    //bool isTouch = false;

    private void ResetPoints()
    {
        isTouch = false;
        firstPoint = Vector2.zero;
        secondPoint = Vector2.zero;
    }
    bool isTouch = false;
    private void Update()
    {


        //if(isTouch)
        //{
        //    secondPoint = Input.mousePosition;
        //    if (firstPoint == secondPoint)
        //        return;

        //    var result = secondPoint - firstPoint;

        //    float x = 0;
        //    if (Mathf.Abs(result.x) > Mathf.Abs(result.y))
        //        x = Mathf.Abs(result.x) / result.x;

        //    float y = 0;
        //    if (x == 0)
        //        y = Mathf.Abs(result.y) / result.y;

        //    var swipeDir = new Vector2(x, y);

        //    player.Swipe(swipeDir);
        //    ResetPoints();


        //}

        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            firstPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
            secondPoint = Input.mousePosition;
            if (firstPoint == secondPoint)
                return; //touch

            var result = secondPoint - firstPoint;

            float x = 0;
            if (Mathf.Abs(result.x) > Mathf.Abs(result.y))
                x = Mathf.Abs(result.x) / result.x;

            float y = 0;
            if (x == 0)
                y = Mathf.Abs(result.y) / result.y;

            var dir = new Vector2(x, y);

            player.Swipe(dir);
        }

    }


}
