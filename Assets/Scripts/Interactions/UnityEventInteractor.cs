using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent _onInteract;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    
    public void Interact(Interactor interactor)
    {
        if (_prompt.Contains("quiz"))
        {
            _prompt = "Vous avez termine ce quiz !";
        }
        _onInteract.Invoke();
    }
}
