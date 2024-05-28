using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int Points { get; private set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }

    public void Add(int amount)
    {
        Points += amount;
    }
}
