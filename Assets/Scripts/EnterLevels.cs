using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevels : MonoBehaviour
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
}
