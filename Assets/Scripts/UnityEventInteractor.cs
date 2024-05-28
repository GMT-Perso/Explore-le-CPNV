using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventInteractor : MonoBehaviour, IInteractable
{
    //[SerializeField] private QuizLuncher _quizLuncher;
    //[SerializeField]private UnityEvent _onInteract;
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Interactor interactor)
    {
        QuizLuncher _quizLuncher = interactor.GetComponent<QuizLuncher>();
        //_onInteract.Invoke();
        _quizLuncher.Launch();
    }
}
