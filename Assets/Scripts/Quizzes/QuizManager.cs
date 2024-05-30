using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using Unity.VisualScripting;

/// <summary>
/// This class manage the quizzes by getting them from the config file and get all the quizzes informations.
/// </summary>
public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance { get; private set; }

    private List<Quiz> _quizzes;

    // This method is called before Start when the scene is loaded.
    void Awake()
    {
        DetermineInstanceSingleton();
        GetQuizzesFromJSON();
    }

    /// <summary>
    /// It creates a singleton instance to store the quizzes list data and not lose them when we change the scene.
    /// Source : https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    /// </summary>
    void DetermineInstanceSingleton()
    {
        // If there is an instance, and it's not this one, it deletes itself.
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

    /// <summary>
    /// It gets all the quizzes from the config file and store them in the instance.
    /// </summary>
    private void GetQuizzesFromJSON()
    {
        var asset = Resources.Load<TextAsset>("Quizzes");

        // Check if the file has been found or not.
        if (asset == null)
        {
            // If not found it send an error and create an empty list.
            Debug.LogWarning("You don't have a Quiz json file under Resources/Quizzes.json");
            _quizzes = new List<Quiz>();
        }
        else
        {
            // If it's found it set the instance quiz list to the Data found in the JSON file.
            _quizzes = JsonConvert.DeserializeObject<List<Quiz>>(asset.text);
        }
    }
    
    /// <summary>
    /// Get the quiz by its id.
    /// </summary>
    /// <param name="id"> The indentification number of the quiz that have to be found. </param>
    /// <returns> Returns the quiz that correspond to the id entered. </returns>
    public Quiz GetById(int id)
    {
        return _quizzes.First(quiz => quiz.Id == id);
    }

    /// <summary>
    /// Check if all quizzes are done or not.
    /// </summary>
    /// <returns> True if the quizzes are all done, false if they are not. </returns>
    public bool AreAllQuizzesDone()
    {
        return _quizzes.All(quiz => quiz.IsDone);
    }
    
    // Set all the quizzes to not done so a new game can be lunch.
    public void SetAllQuizzesToNotDone()
    {
        foreach (var quiz in _quizzes)
        {
            quiz.IsDone = false;
        }
    }
}
