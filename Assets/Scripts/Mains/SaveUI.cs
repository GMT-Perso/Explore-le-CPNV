using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class manage the Saving user interface.
/// </summary>
public class SaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _firstName;
    [SerializeField] private TextMeshProUGUI _lastName;
    [SerializeField] private TextMeshProUGUI _email;
    [SerializeField] private UnityEvent _onFinishedSave;

    // Start is called before the first frame update
    void Start()
    {
        // Show the score on the user interface.
        _score.text = "Votre Score :" + Environment.NewLine + ScoreManager.Instance.MyScore.Points;

        // We set all the quizzes to done as it's the end of the game so a new game can be lunched after.
        QuizManager.Instance.SetAllQuizzesToNotDone();

        // We make the cursor visible and unlock.
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    /// <summary>
    /// This method get the input of the user and save all the data in the scores file.
    /// </summary>
    public void Save()
    {
        // Get the user's input.
        ScoreManager.Instance.MyScore.FirstName = _firstName.text;
        ScoreManager.Instance.MyScore.LastName = _lastName.text;
        ScoreManager.Instance.MyScore.Email = _email.text;

        // Save the score.
        ScoreManager.Instance.Save();

        // Reset the score and load the next scene.
        ScoreManager.Instance.MyScore = new Score();
        _onFinishedSave.Invoke();
    }

    /// <summary>
    /// This method happens when the user doesn't want to save his score.
    /// </summary>
    public void CancelSave()
    {

        // Reset the score and load the next scene.
        ScoreManager.Instance.MyScore = new Score();
        _onFinishedSave.Invoke();
    }
}
