using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject inGameMenu;
    public void StartGame()
    {
        gameManager.StartGame();
        mainMenu.SetActive(false);
        inGameMenu.SetActive(true);
    }

}
