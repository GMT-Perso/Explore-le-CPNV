using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public Answer[] Answers { get; set; }
    public string Text { get; set; }
}
