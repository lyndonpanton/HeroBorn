using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

public class DataManager : MonoBehaviour, IManager
{
    private string _dataPath;
    private string _textFile;
    private string _streamingTextFile;
    private string _xmlLevelProgress;
    private string _xmlWeapons;
    private List<Weapon> weaponInventory = new List<Weapon>()
    {
        new Weapon("Sword of Doom", 100),
        new Weapon("Butterfly knives", 25),
        new Weapon("Brass knuckles", 15)
    };

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
        _xmlLevelProgress = Path.Combine(_dataPath, "Progress_Data.xml");
        _xmlWeapons = Path.Combine(_dataPath, "WeaponInventory.xml");

        Debug.Log(_dataPath);
    }

    void Start()
    {
        Initialize();
    }

    public void DeleteDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            return;
        }

        Directory.Delete(_dataPath, true);
    }

    public void DeleteFile(string filename)
    {
        if (!File.Exists(filename))
        {
            return;
        }

        File.Delete(filename);
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

    public void Initialize()
    {
        _state = "Data Manager initialised";
        //Debug.Log(_state);

        FilesystemInfo();

        NewDirectory();
        //DeleteDirectory();

        //NewTextFile();
        //UpdateTextFile();
        //ReadFromFile(_textFile);
        //DeleteFile(_textFile);

        //WriteToStream(_streamingTextFile);

        //WriteToXML(_xmlLevelProgress);
        // XML files can be read from using the same methods as either text
        // files or Streams
        //ReadFromFile(_xmlLevelProgress);
        //ReadFromStream(_xmlLevelProgress);
        SerializeXML();
    }

    public void NewDirectory()
    {
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);

            return;
        }
    }

    public void NewTextFile()
    {
        if (!File.Exists(_textFile))
        {
            File.WriteAllText(_textFile, "<SAVE DATA>\n\n");

            return;
        }
    }

    public void ReadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            return;
        }

        Debug.Log(File.ReadAllText(filename));
    }

    public void ReadFromStream(string filename)
    {
        // Check if file does not exist
        if (!File.Exists(filename))
        {
            return;
        }

        using (StreamReader streamReader = new StreamReader(filename))
        {
            // Create a new StreamReader instance with the name of the file to
            // access
            // StreamReader streamReader = new StreamReader(filename);

            // Output the contents of the file (from beginning) to the end
            Debug.Log(streamReader.ReadToEnd());

            //streamReader.Close();
        }
    }

    public void SerializeXML()
    {
        // A xmlSerializer instance that can translate the given data type in
        // Xml format
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Weapon>));

        // Create a new FileStream instance with the name of the file to access
        using (FileStream stream = File.Create(_xmlWeapons))
        {
            // Use the serializer and the file stream to serialize the second
            // argument into xml format and place the serialized data into the
            // supplied stream
            xmlSerializer.Serialize(stream, weaponInventory);
        }
    }

    public void UpdateTextFile()
    {
        if (!File.Exists( _textFile))
        {
            return;
        }

        File.AppendAllText(
            _textFile,
            $"Game started: {DateTime.Now}\n"
        );
    }

    public void WriteToStream(string filename)
    {
        // Check if file does not exist
        if (!File.Exists(filename))
        {
            using (StreamWriter newStream = File.CreateText(filename))
            {
                // create the new StreamWriter instance and create and open a
                // new file
                // StreamWriter newStream = File.CreateText(filename);

                // Make first line (HEADER) of stream if not already
                newStream.WriteLine("<Save Data> for HERO BORN\n\n");

                // Close the stream
                //newStream.Close();
            }
        }

        using (StreamWriter streamWriter = File.AppendText(filename))
        {
            // Create a new StreamWriter instance and open a new file to append to
            // Use this method so existing data is not overwritten
            // StreamWriter streamWriter = File.AppendText(filename);

            // Write a new line to the game data
            streamWriter.WriteLine("Game ended: " + DateTime.Now);

            // Close the stream
            //streamWriter.Close();
        }
    }

    public void WriteToXML(string filename)
    {
        // Check if the file does not exist
        if (!File.Exists(filename))
        {
            // using FileStream xmlStream = File.Create(filename);
            // Above method removes need for nesting

            // Automatically closes a stream at end of block by calling
            // Dispose from the IDisposable interface that Streams inherit
            // from
            using (FileStream xmlStream = File.Create(filename))
            {
                // Create a new FileStream (use default format bytes?, not text)
                //FileStream xmlStream = File.Create(filename);

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                // Indent based on element nesting
                xmlWriterSettings.Indent = true;
                // Remove first line declaration above root element (using default)
                xmlWriterSettings.OmitXmlDeclaration = false;
                // Put attributes on a new line(using default)
                xmlWriterSettings.NewLineOnAttributes = false;

                // Convert the FileStream to an xml format writer
                XmlWriter xmlWriter = XmlWriter.Create(xmlStream, xmlWriterSettings);

                // Specify the xml version is 1.0
                // Has an optional boolean argument which determines whether or
                // not it (the xml version?) is standalone
                xmlWriter.WriteStartDocument();

                // Create the root element
                xmlWriter.WriteStartElement("level_progress");

                // Add some attributes
                xmlWriter.WriteAttributeString("fire", "hot");
                xmlWriter.WriteAttributeString("water", "wet");
                xmlWriter.WriteAttributeString("grass", "green");

                for (int i = 1; i < 5; i++)
                {
                    // Add a new element to the current start element (index 0)
                    // which contains the following text
                    xmlWriter.WriteElementString("level", $"Level-{i}");
                }

                // End the root element
                xmlWriter.WriteEndElement();

                // Close the xmlWriter to release the resources being used up
                xmlWriter.Close();
                // Close the FileStream to release the resources being used up
                //xmlStream.Close();

                // Use the default encoding
                // <?xml version="1.0" encoding="utf-8"?>
                // <level_progress fire="hot" water="wet" grass="green">
                // <level>Level-1</level>
                // <level>Level-2</level>
                // <level>Level-3</level>
                // <level>Level-4</level>
                // </level_progress>

                // xmlWriter.WriteAttributeString(key, value) to an add attribute
                // to the current start element
            }
        }
    }
}