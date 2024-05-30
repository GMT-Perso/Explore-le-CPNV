using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// This class manage the prompt and the input of the quizzes prompt.
/// </summary>
public class QuizPromptUI : PromptUI
{

    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _progression;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI[] _answers;
    [SerializeField] private Quiz _quiz;
    private int _questionIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Make the UI panel with the text disapear so it's not blocking the view.
        _uiPanel.SetActive(false);
    }

    /// <summary>
    /// Setup the quiz prompt.
    /// </summary>
    /// <param name="quiz"> The quiz that have to be prompt. </param>
    public void Setup(Quiz quiz)
    {
        // Stop the time so the player can't move behind the prompt and activate the cursor.
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        Open();
        _quiz = quiz;

        FillQuizTexts();
    }

    /// <summary>
    /// It fills all the UI text and buttons so it matches with the quiz.
    /// </summary>
    void FillQuizTexts()
    {
        var question = _quiz.Questions[_questionIndex];
        _title.text = question.Text;

        // Fill the buttons text with the 4 answers 
        for (int i = 0; i < _answers.Length; i++)
        {
            _answers[i].text = question.Answers[i].Text;
        }

        // Get and fill the actual score and progression.
        _score.text = "Score : " + ScoreManager.Instance.MyScore.Points;
        _progression.text = "Question " + (_questionIndex + 1) + " / " + _quiz.Questions.Length;
    }

    /// <summary>
    /// Checks the answer input of the user and check if it's right.
    /// </summary>
    /// <param name="buttonId"> The identification number of the answer button pressed. </param>
   public void Answer(int buttonId)
    {
        // Check if the answer is right and add points to the score if it is.
        if (_quiz.Questions[_questionIndex].Answers[buttonId].IsRight)
        {
            ScoreManager.Instance.MyScore.Add(150);
        }

        // Check if it's the las question of the quiz. If it is it mark the quiz as done.
        if (_questionIndex == _quiz.Questions.Length - 1)
        {
            _quiz.IsDone = true;
            _questionIndex = 0;

            // If all quizzes are done it loads the score saving scene.
            if (QuizManager.Instance.AreAllQuizzesDone())
            {
                SceneManager.LoadScene("ScoreSaving");

            }

            // Close the prompt and set the time back to normal.
            Close();
            Time.timeScale = 1;
        }
        else
        {
            // if the question isn't the last of the quiz it loads the next question.
            _questionIndex++;
            FillQuizTexts();
        }
    }
}
