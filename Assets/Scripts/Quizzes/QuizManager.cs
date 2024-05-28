using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using Unity.VisualScripting;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance { get; private set; }

    private List<Quiz> _quizzes;

    void Awake()
    {
        DetermineInstanceSingleton();
        GetQuizzesFromJSON();
    }

    void DetermineInstanceSingleton()
    {
        //https://gamedevbeginner.com/singletons-in-unity-the-right-way/
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void GetQuizzesFromJSON()
    {
        var asset = Resources.Load<TextAsset>("Quizzes");
        if (asset == null)
        {
            Debug.LogWarning("You don't have a Quiz json file under Resources/Quizzes.json");
            _quizzes = new List<Quiz>();
        }
        else
        {
            _quizzes = JsonConvert.DeserializeObject<List<Quiz>>(asset.text);
        }
    }
    
    public Quiz GetById(int id)
    {
        return _quizzes.First(quiz => quiz.Id == id);
    }

    public bool AreAllQuizzesDone()
    {
        return _quizzes.All(quiz => quiz.IsDone);
    }

    public void SetAllQuizzesToNotDone()
    {
        foreach (var quiz in _quizzes)
        {
            quiz.IsDone = false;
        }
    }
}
