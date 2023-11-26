using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Swipe : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isJumping = false; 
    private bool comingDown = false; 

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            Vector2 inputVector = endTouchPosition - startTouchPosition;
            if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
            {
                if (inputVector.x > 0)
                {
                    RightSwipe();
                }
                else
                {
                    LeftSwipe();
                }
            }
            else
            {
                if (inputVector.y > 0)
                {
                    UpSwipe();
                }
                else if(inputVector.y < -4)
                {
                    DownSwipe();
                }
            }
        }

    }

    private void UpSwipe()
    {
        print("up");

        if(isJumping == false)
        {
            isJumping = true;
            player.GetComponent<Animator>().SetTrigger("isJumping");
            if(isJumping == true)
            {
                if(comingDown == false)
                {
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (5* Time.deltaTime), player.transform.position.z);
                    //player.GetComponent<Animator>().Play("Jump");
                }
            }
            StartCoroutine(JumpSequence());
        }
    }
    private void DownSwipe()
    {
        print("down");
        player.GetComponent<Animator>().SetTrigger("isSliding");
        player.GetComponent<Animator>().Play("Slide");
    }
    private void LeftSwipe()
    {
        print("left");
        if (player.transform.position.x > -0.24f)
            player.transform.position = new Vector3(player.transform.position.x - 0.24f, player.transform.position.y, player.transform.position.z);
    }
    private void RightSwipe()
    {
        print("right");
        if (player.transform.position.x < 0.24f)
            player.transform.position = new Vector3(player.transform.position.x + 0.24f, player.transform.position.y, player.transform.position.z);
    }

    IEnumerator JumpSequence()
    {
        //rb.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        if (comingDown == true)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y*-2*Time.deltaTime, player.transform.position.z);
            //transform.Translate(Vector3.up * Time.deltaTime * -10, Space.World);
        }
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y * 0, player.transform.position.z);
        //transform.Translate(Vector3.up * 0, Space.World);
        player.GetComponent<Animator>().Play("Run");
    }

}