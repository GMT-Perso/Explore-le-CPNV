using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLuncher : MonoBehaviour
{
    [SerializeField] private QuizPromptUI _quizPromptUI;
    [SerializeField] private int _quizId;

    public void Launch()
    {
        var quiz = QuizManager.Instance.GetById(_quizId);
        if (!quiz.IsDone) _quizPromptUI.Setup(quiz);
    }
}
