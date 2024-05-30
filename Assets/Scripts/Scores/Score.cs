using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the score type of what data are needed to save a score with the users information.
/// </summary>
public class Score
{
    public int Points { get; private set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }

    /// <summary>
    /// Add the amount of points entered to the score.
    /// </summary>
    /// <param name="amount"> Number of points that have to be added to the score. </param>
    public void Add(int amount)
    {
        Points += amount;
    }
}
