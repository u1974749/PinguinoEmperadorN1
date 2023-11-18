using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private TextMeshProUGUI finalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            gameManager.StopGame();
            endMenu.SetActive(true);
            finalScore.text = "Final Score: " + gameManager.GetScore();
        }
    }

}
