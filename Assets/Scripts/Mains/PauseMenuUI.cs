using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    public static bool GameIsPaused = false;
    private bool _timeWasPaused = false;
    private bool _cursorIsVisible = false;

    void Start()
    {
        _pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        
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

    public void Pause()
    {
        if (Time.timeScale == 0) _timeWasPaused = true;
        if (UnityEngine.Cursor.lockState == CursorLockMode.None)
        {
            _cursorIsVisible = true;

        }
        else
        {
            _cursorIsVisible = false;
        }

        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        _pauseMenuUI.SetActive(true);

        
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        if (!_cursorIsVisible)
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }
        
        _pauseMenuUI.SetActive(false);

        if (!_timeWasPaused) Time.timeScale = 1;
        GameIsPaused = false;
    }
}
