using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manage the score by saving it and getting the saved scores.
/// </summary>
public class ScoreManager : MonoBehaviour
{

    [SerializeField] private UnityTextFile _file = new UnityTextFile();
    private AES256Cypher _cypher = new AES256Cypher();
    public static ScoreManager Instance { get; private set; }
    public List<Score> Scores { get; private set; }
    public Score MyScore { get; set; }

    /// <summary>
    /// This method is called before the Start method and the scene loading.
    /// </summary>
    void Awake()
    {
        DetermineInstanceSingleton();
        GetScoresFromJSON();
        MyScore = new Score();
    }

    /// <summary>
    /// Create a singleton so we don't lose the score when we change scene and to have access to the data in all the classes.
    /// Source : https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    /// </summary>
    void DetermineInstanceSingleton()
    {
        // If there is already an instance, and it's not this when, it delete itself.
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
    /// Save the actual score and user data on the scores saving file after encryption.
    /// </summary>
    public void Save()
    {
        Scores.Add(MyScore);

        string encryptedJsonScores = new string("");
        encryptedJsonScores = _cypher.Encrypt(JsonConvert.SerializeObject(Scores));

        _file.Write("Scores.txt", encryptedJsonScores);
    }

    /// <summary>
    /// Is going to read the JSON data once they decrypted from the text file.
    /// </summary>
    private void GetScoresFromJSON()
    {

        string readedFile = _file.Read("Scores.txt");

        //If the file isn't empty it store the data in the instance. Otherwise, it creates an empty Score list.
        if (readedFile != "")
        {
            string decodedExternalFileText = _cypher.Decrypt(readedFile);
            Scores = JsonConvert.DeserializeObject<List<Score>>(decodedExternalFileText);
        }
        else
        {
            Scores = new List<Score>();
        }
    }
}
