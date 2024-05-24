using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PromptUI : MonoBehaviour
{
    [SerializeField]protected GameObject _uiPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDisplayed { get; set; } = false;

    //This function close the UI panel by setting it to diseable.
    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }

    protected void Open()
    {
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }
}
