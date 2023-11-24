using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{

    public GameObject[] prefabs;

    public float maxTime = 8f;
    public float minTime = 4f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Instantiate(prefabs[Random.Range(0, prefabs.Length)],transform.position,Quaternion.identity);
            timer = Random.Range(minTime, maxTime);
        }

        timer -= Time.deltaTime;


    }
}
