using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehaviour : MonoBehaviour, IManager
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 1;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI ProgressText;

    public TextMeshProUGUI WinButton;
    public TextMeshProUGUI LoseButton;

    public Stack<string> LootStack = new Stack<string>();

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

        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;

        _state = "Game Manager initialized...";

        // _state is a string and extending the string class is relevant
        // to it
        _state.FancyDebug();

        //Debug.Log(_state);

        //LootStack.Push("Sword of Doom");
        //LootStack.Push("HP Boost");
        //LootStack.Push("Golden Key");
        //LootStack.Push("Pair of Winged Boots");
        //LootStack.Push("Mythril Bracer");

        Shop<Collectable> itemShop = new();

        itemShop.AddItem(new Potion());
        itemShop.AddItem(new Antidote());

        Debug.Log($"There are {itemShop.GetStockCount<Potion>()} item(s) for sale.");
        Debug.Log($"There are {itemShop.GetStockCount<Antidote>()} item(s) for sale.");
    }

    public int Items
    {
        get
        {
            return _itemsCollected;
        }

        set
        {
            _itemsCollected = value;

            ItemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                WinButton.gameObject.transform.parent
                    .gameObject.SetActive(true);

                UpdateScene(ProgressText.text = "You've found all the items!");
                
            }
            else
            {
                ProgressText.text = "Item found, only "
                    + (MaxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get { 
            return _playerHP;
        }

        set
        {
            _playerHP = value;

            HealthText.text = "Player Health: " + HP;
            Debug.Log($"Lives: {_playerHP}");

            if (_playerHP <= 0)
            {
                LoseButton.gameObject.transform.parent
                    .gameObject.SetActive(true);

                UpdateScene("You want another life with that?");
            }
            else
            {
                ProgressText.text = "Ouch... that's gotta hurt";
            }
        }
    }

    public void PrintLootReport()
    {
        var currentItem = LootStack.Pop();

        var nextItem = LootStack.Peek();

        Debug.Log($"You retrieved and removed {currentItem}. You have a good"
            + $" chance of finding {nextItem} next.");

        Debug.Log($"There are {LootStack.Count} random loot items waiting"
                    + $" for you.");
    }

    public void RestartScene()
    {
        //Utilities.RestartLevel();
        Utilities.RestartLevel(0);
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0;
    }
}