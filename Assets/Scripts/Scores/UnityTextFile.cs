using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// This class allow to Write and read from a text file located locally.
/// Source : https://support.unity.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file
/// </summary>
public class UnityTextFile
{
    /// <summary>
    /// This method replace the file text with the text entered as a parameter in the file.
    /// </summary>
    /// <param name="fileName"> The name of the file located under "Assets/Resources/". </param>
    /// <param name="text"> The text that has to be written in the file. </param>
    public void Write(string fileName, string text)
    {
        // Save the file path as a variable
        string path = "Assets/Resources/" + fileName;

        //Write the text to the file
        File.WriteAllText(path, text);
    }

    /// <summary>
    /// This method read and return the text file content.
    /// </summary>
    /// <param name="fileName"> The name of the file located under "Assets/Resources/". </param>
    /// <returns> Returns the content of the text file. </returns>
    public string Read(string fileName)
    {
        // Save the file path as a variable
        string path = "Assets/Resources/" + fileName;

        //Read the text from directly from the fileName file
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();

        return text;
    }
}
