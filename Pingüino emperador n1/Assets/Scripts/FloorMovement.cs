using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{

    [SerializeField] private float speed = 4f;

    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(0,0,-speed);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=(move * Time.deltaTime);        

        if(transform.position.z < -4)
        {
            Destroy(gameObject);
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

}
