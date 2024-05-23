using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    //Set different variables that will affect the interaction.
    [SerializeField] private Transform _interactionPoint; //Position of the interaction zone.
    [SerializeField] private float _interactionPointRadius = 0.5f; //Size of the interaction point.
    [SerializeField] private LayerMask _interactableMask;   //A mask set to know if an object is interactable.
    [SerializeField] private InteractionPromptUI _interactionPromptUI;  //The prompt that will be showed when a interactable object is in the zone.

    private readonly Collider[] _collider = new Collider[3];
    [SerializeField] private int _nubFound;

    private IInteractable _interactable;

    // Update is called once per frame
    void Update()
    {
        //Check the number of object that we can interact with in the interact zone.
        _nubFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _collider, _interactableMask);

        //Check if the player can interact with an object.
        if (_nubFound > 0)
        {
            //If the player can interact it prompt the UI and check if the player press the E key.
            _interactable = _collider[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                //If the E key is pressed it interact with the object.
                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }
        } 
        else
        {
            //If the player cannot interact with anything it set interaction to null and Close the Interaction UI prompt.
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }

    //It draws a sphere so we can see the Interaction zone in the editor.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);

    }
}
