using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using System.IO;
using System;
//using System;

public class DataManager : MonoBehaviour, IManager
{
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;

    private string _state;
    public string State
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
        }
    }

    void Awake()
    {

        _dataPath = Path.Combine(Application.persistentDataPath, "Player_Data");
        _textFile = Path.Combine(_dataPath, "Save_Data.txt");
        _streamingTextFile = Path.Combine(_dataPath, "Streaming_Save_Data.txt");

        Debug.Log(_dataPath);
    }

    void Start()
    {
        Initialize();
    }

    public void FilesystemInfo()
    {
        // ":" (mac/linux) or ";" (windows/unix)
        Debug.Log($"Path separator character: {Path.PathSeparator}");

        // "/" (mac/linux) or "\" (windows/unix)
        Debug.Log($"Directory separator character: {Path.DirectorySeparatorChar}");

        // The full path where HeroBorn directory is stored
        Debug.Log($"Current directory: {Directory.GetCurrentDirectory()}");

        // The temporary path which is the location of the Filesystem's
        // temporary folder
        Debug.Log($"Temporary Path: {Path.GetTempPath()}");
    }

    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Debug.Log("Directory does not exist");
            return;
        }

        Directory.Delete(_dataPath, true);
        Debug.Log("Data path directory deleted");
    }

    public void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File does not exist");
            return;
        }

        File.Delete(filename);
        Debug.Log("Persistent data file deleted");
    }

    public void Initialize()
    {
        _state = "Data Manager initialised";
        //Debug.Log(_state);

        NewDirectory();
        //DeleteDirectory();
        //NewTextFile();
        //UpdateTextFile();
        //ReadFromFile(_textFile);
        //DeleteFile(_textFile);
        WriteToStream(_streamingTextFile);
    }
    
    public void NewDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
            Debug.Log("Data Path directory created");

            return;
        }

        Debug.Log("Data Path directory already exists...");
    }

    public void NewTextFile()
    {
        if (!File.Exists(_textFile))
        {
            File.WriteAllText(_textFile, "<SAVE DATA>\n\n");
            Debug.Log("Text file created");

            return;
        }

        Debug.Log("Text file already exists");
    }

    public void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Debug.Log("File does not exist");
            return;
        }

        Debug.Log(File.ReadAllText(filename));
    }

    public void UpdateTextFile()
    {
        if (!File.Exists( _textFile))
        {
            Debug.Log("File does not exist");
            return;
        }

        File.AppendAllText(
            _textFile,
            $"Game started: {DateTime.Now}\n"
        );

        Debug.Log("File updated successfully");
    }

    public void WriteToStream(string filename)
    {
        // Check if file does not exist
        if (!File.Exists(filename))
        {
            // create the new StreamWriter instance and create and open a
            // new file
            StreamWriter newStream = File.CreateText(filename);

            // Make first line (HEADER) of stream if not already
            newStream.WriteLine("<Save Data> for HERO BORN\n\n");

            // Close the stream
            newStream.Close();

            Debug.Log("New file created with StreamWriter");
        }

        // Create a new StreamWriter instance and open a new file to append to
        // Use this method so existing data is not overwritten
        StreamWriter streamWriter = File.AppendText(filename);

        // Write a new line to the game data
        streamWriter.WriteLine("Game ended: " + DateTime.Now);

        // Close the stream
        streamWriter.Close();

        Debug.Log("File contents updated with StreamWriter");
    }
}