using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizLuncher : MonoBehaviour
{
    [SerializeField] private QuizPromptUI _quizPromptUI;
    [SerializeField] private int _quizId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch()
    {
        _quizPromptUI.Setup();
    }
}
