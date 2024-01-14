using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChangeButton : MonoBehaviour
{
    public string targetSceneName;

    // Reference to the TextMeshPro component on the button
    private TextMeshProUGUI buttonText;

    void Start()
    {
        // Get the TextMeshPro component
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        // Make sure a target scene is set
        if (string.IsNullOrEmpty(targetSceneName))
        {
            Debug.LogError("Target scene name is not set for the SceneChangeButton script.");
        }

        // Add a click listener to the button
        if (buttonText != null)
        {
            var button = buttonText.gameObject.GetComponentInParent<UnityEngine.UI.Button>();
            if (button != null)
            {
                button.onClick.AddListener(ChangeScene);
            }
        }
    }

    void ChangeScene()
    {
        // Check if the target scene name is not empty
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("Target scene name is not set for the SceneChangeButton script.");
        }
    }
}
