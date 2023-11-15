using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObstacules : MonoBehaviour
{

    [SerializeField] private GameObject [] preObstaculos; 
    [SerializeField] private GameObject [] obstaculePoints;


    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacules();
    }

    private void SpawnObstacules()
    {
        for(int i = 0; i < obstaculePoints.Length; i++)
        {
            if(RandomSpawn())
            {
                GameObject obstacule = preObstaculos[Random.Range(0, preObstaculos.Length)];
                GameObject.Instantiate(obstacule, obstaculePoints[i].transform);
            }
            
        }
    }

    private bool RandomSpawn()
    {
        return 1 == Random.Range(0, 3);
    }
}
