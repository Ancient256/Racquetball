using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTrigger : MonoBehaviour
{
    public string nextSceneName;  // Name of the next scene
    public Transform originalPosition;
    public GameObject player;
    public int lifePenalty = 1;

    private bool gameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AssignedItem")) // Check if the colliding object has the tag "AssignedItem"
        {
            if (!gameOver)
            {
                DeductLife();
                if (gameOver)
                {
                    SwitchToNextScene();  // Change this line to switch to the next scene
                }
            }
        }
    }

    private void SwitchToNextScene()
    {
        // Check if the next scene name is not empty
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set for the ResetTrigger script.");
        }
    }

    private void DeductLife()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(lifePenalty);
                if (playerHealth.IsGameOver())
                {
                    gameOver = true;
                }
            }
        }
    }
}
