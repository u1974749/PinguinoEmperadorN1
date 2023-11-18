using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActualizaUIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + gameManager.GetScore();
    }
}
