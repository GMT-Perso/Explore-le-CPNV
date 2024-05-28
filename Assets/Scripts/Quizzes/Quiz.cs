using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quiz
{
    public Question[] Questions { get; set; }
    public int Id { get; set; }
    public bool IsDone { get; set; }
}
