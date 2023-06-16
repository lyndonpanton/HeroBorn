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

    // Start is called before the first frame update
    void Start()
    {
        int CharacterLevel = 32;
        int NextSkillLevel = GenerateCharacter("Spike", CharacterLevel);

        Debug.Log(NextSkillLevel);
        Debug.Log(GenerateCharacter("Faye", CharacterLevel));
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
        //Debug.Log($"Character: {name} (lv. {level})");

        return level += 5;
    }
}
