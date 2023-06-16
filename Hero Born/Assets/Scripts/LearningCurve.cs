using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    public int CurrentAge = 18;
    public int AddedAge = 1;

    public const float PI = 3.14f;
    public string FirstName = "Harrison";
    public bool isAuthor = true;

    public bool hasDungeonKey = true;

    // Start is called before the first frame update
    void Start()
    {
        if (hasDungeonKey)
        {
            Debug.Log("You possess the sacred key - enter");
        }
        else
        {
            Debug.Log("You have not proved yourself yet.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }

    int GenerateCharacter(string name, int level)
    {
        return level += 5;
    }
}
