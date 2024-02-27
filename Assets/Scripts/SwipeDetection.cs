using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = 0.2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField,Range(0f,1f)]private float directionThreshold = 0.9f;
    private InputManager inputManager;
    private Vector3 startPosition;
    private float startTime;
    private Vector3 endPosition;
    private float endTime;
    
    // public delegate void LeftSwipe();
    // public event LeftSwipe OnSwipeLeft;
    // public delegate void RightSwipe();
    // public event RightSwipe OnSwipeRight;
    // public delegate void UpSwipe ();
    // public event UpSwipe OnSwipeUp;
    // public delegate void DownSwipe();
    // public event DownSwipe OnSwipeDown;

    [SerializeField] private Rigidbody rb;
    [SerializeField] float force = 1f; // to control throw force in X and Y directions
    //[SerializeField] float throwForceInZ = 50f;
    private Vector3 direction3D;
    private float timeInterval;// to control throw force in Z direction
    
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
        
        /*OnSwipeLeft += SwipeLeft;
        OnSwipeRight += SwipeRight;
        OnSwipeUp += SwipeUp;
        OnSwipeDown += SwipeDown;*/
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timeInterval = endTime - startTime;
        transform.Translate(direction3D * force * Time.deltaTime);
        //rb.AddForce (direction2D.x * force,0, 0);
        //rb.AddForce (Mathf.Abs(direction2D.x)*force,0, 0);
    }

    /*private void SwipeDown()
    {
        Debug.Log("Direction : " + direction3D);
    }

    private void SwipeUp()
    {
        Debug.Log("Direction : " + direction3D);
    }

    private void SwipeRight()
    {
        Debug.Log("Direction : " + direction3D);
    }

    private void SwipeLeft()
    {
        Debug.Log("Direction : " + direction3D);
    }*/

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
        
        /*OnSwipeLeft -= SwipeLeft;
        OnSwipeRight -= SwipeRight;
        OnSwipeUp -= SwipeUp;
        OnSwipeDown -= SwipeDown;*/
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition,endPosition,Color.blue,5f);
           
            Vector3 direction = endPosition - startPosition;
            direction3D = new Vector3(direction.x, 0f,direction.y).normalized;
            //SwipeDirection(direction3D);
        }
            
    }

    /*private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            if (OnSwipeUp != null) OnSwipeUp();
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            if (OnSwipeDown != null) OnSwipeDown();
        }
        else if (Vector2.Dot (Vector2.left, direction) > directionThreshold)
        {
            if (OnSwipeLeft != null) OnSwipeLeft();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            if (OnSwipeRight != null) OnSwipeRight();
        }
    }*/
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(startPosition,endPosition);
    }
}
