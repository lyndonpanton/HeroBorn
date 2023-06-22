using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

using System.IO;
using UnityEngine.UIElements;

public class DataManager : MonoBehaviour, IManager
{
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

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _state = "Data Manager initialised";
        Debug.Log(_state);

        FilesystemInfo();
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
}