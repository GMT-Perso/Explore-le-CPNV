using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is made to lunch an unity event after an interaction.
/// </summary>
public class UnityEventInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent _onInteract;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    
    /// <summary>
    /// This method start the event and if needed change the prompt of the interactor for this game.
    /// </summary>
    /// <param name="interactor"> The Object that did the interaction. </param>
    public void Interact(Interactor interactor)
    {
        // Check if the object that was interated with was for a quiz. If yes then we change the prompt as we can't do 2 time the same quiz.
        if (_prompt.Contains("quiz"))
        {
            _prompt = "Vous avez termine ce quiz !";
        }
        _onInteract.Invoke();
    }
}
