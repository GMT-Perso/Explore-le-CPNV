using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is how data are stored for the quizzes.
/// </summary>
[System.Serializable]
public class Quiz
{
    public Question[] Questions { get; set; }
    public int Id { get; set; }
    public bool IsDone { get; set; }
}
