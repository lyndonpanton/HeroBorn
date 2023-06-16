using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool weaponEquipped = true;

    public bool PureOfHeart = true;
    public bool HasSecretIncantation = false;
    public string RareItem = "Relic Stone";

    public string CharacterAction = "Attack";
    int DiceRoll = 7;

    //int[] topPlayerScores = new int[3];
    //int[] topPlayerScores = new int[] { 713, 549, 984 };
    int[] topPlayerScores = { 713, 549, 984 };

    List<string> QuestPartyMembers = new List<string>()
        {
            "Grim the Barbarian",
            "Merlin the Wise",
            "Sterling the Knight"
    };


    //Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
    //{
    //        { "Potion", 5 },
    //        { "Antidote", 7 },
    //        { "Aspirin", 1 }
    //};


    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> ItemInventory = new Dictionary<string, int>()
        {
            { "Potion", 5 },
            { "Antidote", 7 },
            { "Aspirin", 1 }
        };

        Debug.Log($"Items: {ItemInventory.Count}");

        int numberOfPotions = ItemInventory["Potion"];
        ItemInventory["Potion"] = 10;

        ItemInventory.Add("Throwing Knife", 3);
        // Non-existent key is automatically added to the dictionary
        ItemInventory["Bandage"] = 5;

        if (ItemInventory.ContainsKey("Aspirin"))
        {
            ItemInventory["Aspirin"] = 3;
        }

        ItemInventory.Remove("Antidote");

        Debug.Log(ItemInventory.Count);
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

    public void OpenTreasureChamber()
    {
        if (PureOfHeart && RareItem == "Relic Stone")
        {
            if (!HasSecretIncantation)
            {
                Debug.Log("You have the spirit, but not the knowledge.");
            }
            else
            {
                Debug.Log("The treasure is yours, worthy hero!");
            }
        }
        else
        {
            Debug.Log("Come back when you have what it takes.");
        }
    }

    public void PrintCharacterAction()
    {
        switch(CharacterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To arms!");
                break;
            default:
                Debug.Log("Shields up.");
                break;
        }
    }

    public void RollDice()
    {
        switch(DiceRoll)
        {
            case 7:
            case 15:
                Debug.Log("Mediorce damage, not bad.");
                break;
            case 20:
                Debug.Log("Critical hit, the creature goes down!");
                break;
            default:
                Debug.Log("You completely missed and fell on your face.");
                break;
        }
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
