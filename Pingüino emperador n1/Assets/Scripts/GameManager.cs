using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
   
    

    private bool gameStart = false;
    private bool gamePause = false;
    

    private float score = 0;
    private float timeSpace;
    [SerializeField] private float gameSpeed = 2f;
    [SerializeField] private float difficulty = 0.5f;
    [SerializeField] private float maxSpeed = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamePause && gameStart)
        {      
            score += (Time.deltaTime);

            if(gameSpeed < maxSpeed)
                gameSpeed += Time.deltaTime * difficulty;
        }
                   
    }

    public void StartGame()
    {
        gameStart = true;
    }

    public void StopGame()
    {
        gameStart = false;
    }

    public bool GetGameStart()
    {
        return gameStart;
    }


    public void PauseGame()
    {
        gamePause = true;
    }

    public void ResumeGame()
    {
        gamePause = false;
    }

    public bool GetGamePause()
    {
        return gamePause;
    }

    public int GetScore()
    {
        return (int)score;
    }

    public void AddScore(float value)
    {
        score += value;
    }

    public float GetSpeed()
    {
        return gameSpeed;
    }

}
