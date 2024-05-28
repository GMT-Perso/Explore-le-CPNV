using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    //It get the prompt for the interactable object.
    public string InteractionPrompt { get; }

    //This set object so we can interact with it.
    public void Interact(Interactor interactor);
}
