using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractionPromptUI : PromptUI
{

    //Initialization of Variables and Objets.
    private Camera _mainCam;
    [SerializeField] private TextMeshProUGUI _promptText;

    // Start is called before the first frame update
    private void Start()
    {
        //Get the main camera to assign it to _mainCam variable.
        _mainCam = Camera.main;

        //Make the UI panel with the text disapear so it's not blocking the view.
        _uiPanel.SetActive(false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Create a variable with the orientation of the camera.
        var rotation = _mainCam.transform.rotation;

        //Move the UI text panel so it is oriented in front of the camera.
        transform.LookAt(transform.position + rotation  * Vector3.forward, rotation * Vector3.up);
    }

    /// <summary>
    /// This function set up the text that will be prompt and display it by activating the UI panel.
    /// </summary>
    /// <param name="promptText"> The text that have to be prompted. </param>
    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        Open();
    }
}
