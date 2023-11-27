using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{

    [SerializeField] private float speed = 4f;
    private GameManager gameManager;

    private Vector3 move;

    void Start()
    {
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
    }
   
    void Update()
    {
        move = new Vector3(0, 0, -gameManager.GetSpeed());
        if (gameManager.GetGameStart() && !gameManager.GetGamePause())
        {
            transform.position += (move * Time.deltaTime);

            if (transform.position.z < -4)
            {
                Destroy(gameObject);
            }
        }       
    }

    public float GetSpeed()
    {
        return speed;
    }

}
