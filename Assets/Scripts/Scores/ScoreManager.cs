using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private UnityTextFile _file = new UnityTextFile();
    private AES256Cypher _cypher = new AES256Cypher();
    public static ScoreManager Instance { get; private set; }
    public List<Score> Scores { get; private set; }
    public Score MyScore { get; set; }

    void Awake()
    {
        DetermineInstanceSingleton();
        GetScoresFromJSON();
        MyScore = new Score();
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

    public void Save()
    {
        Scores.Add(MyScore);

        string encryptedJsonScores = new string("");
        encryptedJsonScores = _cypher.Encrypt(JsonConvert.SerializeObject(Scores));

        _file.Write("Scores.txt", encryptedJsonScores);
    }

    private void GetScoresFromJSON()
    {
        string decodedExternalFileText = new string("");
        string readedFile = _file.Read("Scores.txt");
        if (readedFile != "")
        {
            decodedExternalFileText = _cypher.Decrypt(readedFile);
            Scores = JsonConvert.DeserializeObject<List<Score>>(decodedExternalFileText);
        }
        else
        {
            Scores = new List<Score>();
        }
    }
}
