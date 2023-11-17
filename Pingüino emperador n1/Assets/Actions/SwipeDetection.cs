using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimumDistance = .2f;
    [SerializeField] private float maximunTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = .9f;
    [SerializeField] private GameObject trail;
    [SerializeField] private GameObject player;

    private InputManager inputManager;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private Coroutine coroutine;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        trail.SetActive(true);
        trail.transform.position = position;
        coroutine = StartCoroutine(Trail());
        DetectSwipe();
    }

    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        trail.SetActive(false);
        StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        MovePlayer();
        if(Vector3.Distance(startPosition, endPosition) >= minimumDistance &&
            (endTime - startTime) <= maximunTime)
        {
            Debug.Log("Swipe detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up,direction) > directionThreshold)
        {
            Debug.Log("Swiper no robes up");
        }
        else if(Vector2.Dot(Vector2.down,direction) > directionThreshold)
        {
            Debug.Log("Swiper no robes down");
        }        
        else if(Vector2.Dot(Vector2.left,direction) > directionThreshold)
        {
            Debug.Log("Swiper no robes left");
        }        
        else if(Vector2.Dot(Vector2.right,direction) > directionThreshold)
        {
            Debug.Log("Swiper no robes right");
        }
    }

    private void MovePlayer()
    {
        if (startPosition.x < endPosition.x && (endTime - startTime) <= maximunTime)
        {

            if(player.transform.position.x < 0.24f)
                player.transform.position = new Vector3(player.transform.position.x+0.24f, player.transform.position.y,player.transform.position.z);
        }
        else if (startPosition.x > endPosition.x && (endTime - startTime) <= maximunTime)
        {

            if(player.transform.position.x > -0.24f)
                player.transform.position = new Vector3(player.transform.position.x-0.24f, player.transform.position.y,player.transform.position.z);
        }
        //else if()
    }
}
