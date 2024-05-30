using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manage the lunch of the quizzes with and id and a prompt.
/// </summary>
public class QuizLuncher : MonoBehaviour
{
    [SerializeField] private QuizPromptUI _quizPromptUI;
    [SerializeField] private int _quizId;

    /// <summary>
    /// It launchs the the corect quiz corresponding with the id to the correct prompt.
    /// </summary>
    public void Launch()
    {
        var quiz = QuizManager.Instance.GetById(_quizId);
        if (!quiz.IsDone) _quizPromptUI.Setup(quiz);
    }
}
