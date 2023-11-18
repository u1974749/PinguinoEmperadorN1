using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
   
    

    private bool gameStart = false;
    private bool gamePause = false;
    

    private int score;
    private float timeSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamePause && gameStart)
        {
            timeSpace += Time.deltaTime*2;
            score = (int)timeSpace;
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
        return score;
    }

}
