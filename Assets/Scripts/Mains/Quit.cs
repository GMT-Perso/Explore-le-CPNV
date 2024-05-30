using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is there so the player can Exit the game.
/// </summary>
public class Quit : MonoBehaviour
{

    /// <summary>
    /// It close the programme.
    /// </summary>
    public void CloseProgram()
    {
        Application.Quit();
    }
}
