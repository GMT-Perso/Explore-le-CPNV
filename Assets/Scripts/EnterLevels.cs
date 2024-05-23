using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevels : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    //This is gonna open the Level1 scene when a interaction is made with the object.
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Level!");
        SceneManager.LoadScene(1);
        return true;
    }
}
