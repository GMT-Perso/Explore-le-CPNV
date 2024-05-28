using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//https://support.unity.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file
public class UnityTextFile
{
    public void Write(string fileName, string text)
    {
        string path = "Assets/Resources/" + fileName;

        //Write some text to the test.txt file
        File.WriteAllText(path, text);
        //StreamWriter writer = new StreamWriter(path, true);
        ////writer.Close();

        StreamReader reader = new StreamReader(path);

        //Print the text from the file
        reader.Close();
    }

    public string Read(string fileName)
    {
        string path = "Assets/Resources/" + fileName;

        //Read the text from directly from the fileName file
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();

        return text;
    }
}
