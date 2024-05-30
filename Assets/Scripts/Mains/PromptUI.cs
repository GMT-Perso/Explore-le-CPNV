using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This class is the parent for the basics of the user interfaces.
/// </summary>
public class PromptUI : MonoBehaviour
{
    [SerializeField]protected GameObject _uiPanel;

    public bool IsDisplayed { get; set; } = false;

    
    /// <summary>
    /// This function close the UI panel by setting it to inactive.
    /// </summary>
    public void Close()
    {
        // Hide the UI panel
        _uiPanel.SetActive(false);
        IsDisplayed = false;

        // Lock the mouse cursor and make it invisible.
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    /// <summary>
    /// This method open the ui panel by setting it to active.
    /// </summary>
    protected void Open()
    {
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }
}
