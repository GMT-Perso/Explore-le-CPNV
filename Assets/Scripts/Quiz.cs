using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    [SerializeField] private Question[] _questions;
    [SerializeField] private int _id;
    [SerializeField] private bool _isDone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Question[] Questions { get; set; }
    public int Id { get; set; }
    public bool IsDone { get; set; }
}
