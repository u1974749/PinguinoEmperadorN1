using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject inGameMenu;

    public void ResumeGame()
    {
        gameManager.ResumeGame();
        inGameMenu.SetActive(false);
    }

    public void PauseGame()
    {
        gameManager.PauseGame();
        inGameMenu.SetActive(true);
    }

    public void MainMenu()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
    }

}
