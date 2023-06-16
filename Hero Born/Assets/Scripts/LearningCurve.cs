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
    public int CurrentGold = 48;
    public string weaponType = "Arcane Staff";

    // Start is called before the first frame update
    void Start()
    {
        if (hasDungeonKey)
        {
            Debug.Log("You possess the sacred key - enter");
        }

        if (weaponType != "Longsword")
        {
            Debug.Log("You don\'t appear to have the right type of weapon...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComputeAge()
    {
        Debug.Log(CurrentAge + AddedAge);
    }

    public int GenerateCharacter(string name, int level)
    {
        return level += 5;
    }

    public void Thievery()
    {
        if (CurrentGold > 50)
        {
            Debug.Log("You\'re rolling in it!");
        }
        else if (CurrentGold < 15)
        {
            Debug.Log("Not much there to steal...");
        }
        else
        {
            Debug.Log("Looks like your purse is in the sweet spot.");
        }
    }
}
