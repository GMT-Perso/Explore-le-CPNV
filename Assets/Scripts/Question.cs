using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

    [SerializeField] private Answer[] _answers;
    [SerializeField] private string _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Answer[] Answers { get; set; }
    public string Text { get; set; }
}
