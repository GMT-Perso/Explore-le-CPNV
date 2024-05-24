using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{

    private Quiz[] _quizzes;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quiz GetById(int id)
    {
        return _quizzes[id];
    }

    public bool AreAllQuizzesDone()
    {
        return false;
    }
}
