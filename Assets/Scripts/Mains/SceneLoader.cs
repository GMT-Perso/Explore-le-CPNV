using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //This is gonna open a scene.
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
