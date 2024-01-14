using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitButton : MonoBehaviour
{
    // Reference to the TextMeshPro component on the button
    private TextMeshProUGUI buttonText;

    void Start()
    {
        // Get the TextMeshPro component
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        // Add a click listener to the button
        if (buttonText != null)
        {
            var button = buttonText.gameObject.GetComponentInParent<UnityEngine.UI.Button>();
            if (button != null)
            {
                button.onClick.AddListener(ExitGame);
            }
        }
    }

    void ExitGame()
    {
        // Close the application
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
