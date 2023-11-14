using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector3 spawnPosition;
    private GameObject lastSpawn = null;
    private Vector3 rightLimit;
    
    // Update is called once per frame
    void Update()
    {

        if(lastSpawn == null)
        {
            lastSpawn = SpawnTile();
            rightLimit = lastSpawn.transform.Find("right_limit").transform.position;
        }
        else if(lastSpawn.transform.Find("left_limit").transform.position.z <= rightLimit.z)
        {
            GameObject currentTile = SpawnTile();
            rightLimit = currentTile.transform.Find("right_limit").transform.position;

            float difDistance = currentTile.transform.Find("right_limit").transform.position.z - lastSpawn.transform.Find("left_limit").transform.position.z;

            float speed = currentTile.GetComponent<FloorMovement>().GetSpeed();
            currentTile.transform.position = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, currentTile.transform.position.z - difDistance - speed * Time.deltaTime);

            difDistance = currentTile.transform.Find("right_limit").transform.position.z - lastSpawn.transform.Find("left_limit").transform.position.z;

         

            lastSpawn = currentTile;
        }

    }

    private GameObject SpawnTile()
    {
        return GameObject.Instantiate(tilePrefab, spawnPosition,Quaternion.identity);
    }
}
