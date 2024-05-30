using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This set how the answers data are stored.
/// </summary>
[System.Serializable]
public class Answer
{
    public string Text { get; set; }
    public bool IsRight { get; set; }
}
