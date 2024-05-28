using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class SaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _firstName;
    [SerializeField] private TextMeshProUGUI _lastName;
    [SerializeField] private TextMeshProUGUI _email;
    [SerializeField] private UnityEvent _onFinishedSave;
    void Start()
    {
        _score.text = "Votre Score :" + Environment.NewLine + ScoreManager.Instance.MyScore.Points;
        QuizManager.Instance.SetAllQuizzesToNotDone();
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    public void Save()
    {
        ScoreManager.Instance.MyScore.FirstName = _firstName.text;
        ScoreManager.Instance.MyScore.LastName = _lastName.text;
        ScoreManager.Instance.MyScore.Email = _email.text;
        ScoreManager.Instance.Save();
        ScoreManager.Instance.MyScore = new Score();
        _onFinishedSave.Invoke();
    }

    public void CancelSave()
    {

        ScoreManager.Instance.MyScore = new Score();
        _onFinishedSave.Invoke();
    }
}
