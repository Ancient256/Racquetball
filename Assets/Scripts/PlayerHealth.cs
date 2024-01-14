using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;

    public TextMeshProUGUI livesText; 

    private void Start()
    {
        currentLives = maxLives;

        UpdateLivesText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentLives -= damageAmount;

        UpdateLivesText();

        if (currentLives <= 0)
        {
         
            GameOver();
        }
    }

    public bool IsGameOver()
    {
        return currentLives <= 0;
    }

    void UpdateLivesText()
    {
      
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    void GameOver()
    {
   
        Debug.Log("Game Over");
    }
}
