using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class QuizPromptUI : PromptUI
{

    private TextMeshPro _title;
    private TextMeshPro _progression;
    private TextMeshPro _score;
    private TextMeshPro[] _answers;
    private Quiz _quiz;
    private int _questionIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Make the UI panel with the text disapear so it's not blocking the view.
        _uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        Open();
    }

   public void Answer(int buttonId)
    {
        if (_quiz.Questions[_questionIndex].Answers[buttonId].IsRight)
        {
            Debug.Log("Correct answer");
        }
        else
        {
            Debug.Log("Wrong answer");
        }
    }
}
