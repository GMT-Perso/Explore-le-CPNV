using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    public void Setup(Quiz quiz)
    {
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        Open();
        _quiz = quiz;

        FillQuizTexts();
    }

    void FillQuizTexts()
    {
        var question = _quiz.Questions[_questionIndex];
        _title.text = question.Text;

        for (int i = 0; i < _answers.Length; i++)
        {
            _answers[i].text = question.Answers[i].Text;
        }

        _score.text = "Score : " + ScoreManager.Instance.MyScore.Points;
        _progression.text = "Question " + (_questionIndex + 1) + " / " + _quiz.Questions.Length;
    }

   public void Answer(int buttonId)
    {
        if (_quiz.Questions[_questionIndex].Answers[buttonId].IsRight)
        {
            ScoreManager.Instance.MyScore.Add(150);
        }

        if (_questionIndex == _quiz.Questions.Length - 1)
        {
            _quiz.IsDone = true;
            _questionIndex = 0;
            if (QuizManager.Instance.AreAllQuizzesDone())
            {
                SceneManager.LoadScene("ScoreSaving");

            }
            Close();
            Time.timeScale = 1;
        }
        else
        {
            _questionIndex++;
            FillQuizTexts();
        }
    }
}
