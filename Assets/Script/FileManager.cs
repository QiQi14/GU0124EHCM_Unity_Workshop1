using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static string path = "";
    private string fileName = "";

    public FileManager(string fileName)
    {
        this.fileName = fileName;

        Directory.CreateDirectory("save");
        path = $"{Environment.CurrentDirectory}/save/";

    }

    public void WriteToFile(string json)
    {
        using (StreamWriter output = new(Path.Combine(path, fileName)))
        {
            output.WriteLine(json);
        }
    }

    public List<BaseCharacterStats> ReadCharacterFromFile()
    {
        using (StreamReader reader = new StreamReader(Path.Combine(path, fileName)))
        {
            List<BaseCharacterStats> character = new List<BaseCharacterStats> ();
            string readString = reader.ReadToEnd();

            try
            {
                character = JsonConvert.DeserializeObject<List<BaseCharacterStats>>(readString);
            } catch (Exception e)
            {
                Debug.Log($"read failed with error: {e.Message}");
            }

            return character;
        }
    }
}

public class FileName {
    public static string FILE_SAVE = "fileSave.txt";
}
