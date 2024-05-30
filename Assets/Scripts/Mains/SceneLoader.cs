using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is made to load a scene.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    //This is going to open a scene.
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
