using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This set how the data are stored for the question.
/// </summary>
[System.Serializable]
public class Question
{
    public Answer[] Answers { get; set; }
    public string Text { get; set; }
}
