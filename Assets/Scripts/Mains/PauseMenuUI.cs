using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// This class manage the game pause and the prompt of the UI.
/// </summary>
public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    public static bool GameIsPaused = false;
    private bool _timeWasPaused = false;
    private bool _cursorIsVisible = false;

    // Start is called before the first frame update.
    void Start()
    {
        // We hide the UI by setting it to inactive.
        _pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame.
    void Update()
    {
        
        // We check if the user press escape. If he does it pause or unpause the game depending on the current state.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// This method pause the game by setting the time to 0, it show the UI and if needed activate the mouse cursor.
    /// </summary>
    public void Pause()
    {
        // Check if the game time was already to zero and save the information in a variable to know what to do when the game is unpaused.
        if (Time.timeScale == 0) _timeWasPaused = true;

        // Game is put to pause by setting the time to 0.
        Time.timeScale = 0;
        GameIsPaused = true;

        // Check if the cursor is already active and store the data in a variable to know what to do when we unpause the game.
        if (UnityEngine.Cursor.lockState == CursorLockMode.None)
        {
            _cursorIsVisible = true;

        }
        else
        {
            _cursorIsVisible = false;
        }

        // Set the mouse cursor to active.
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        // Show the UI
        _pauseMenuUI.SetActive(true);
    }

    /// <summary>
    /// This method resume the game when called by setting the game time to normal.
    /// </summary>
    public void Resume()
    {
        // Check if before the game was in pause if the cursor was visible. if not then we disactivate the cursor.
        if (!_cursorIsVisible)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }
        
        // Hide the UI panel.
        _pauseMenuUI.SetActive(false);

        // Unpause the game by setting the time to normal.
        if (!_timeWasPaused) Time.timeScale = 1;
        GameIsPaused = false;
    }
}
