using System;
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

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;

    //public delegate void EventDelegate(int param1, int param2);
    //public event EventDelegate eventInstance;

    public PlayerBehaviour playerBehaviour;

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    void Start()
    {
        Initialize();
    }

    // OnDisable executes when the object is inactive
    void OnDisable()
    {
        // Clean up event subscription in order to release allocated resources
        // By default subscriptions are not removed after the subscribing
        // object is destroyed
        playerBehaviour.playerJump -= HandlePlayerJump;
        debug("Jump event unsubscribed");
    }

    // OnEnable executes when the object is active, not just in the process of
    // of loading (that is how Awake works)
    void OnEnable()
    {
        // Get the player game object
        GameObject player = GameObject.Find("Player");

        // Get the player behaviour script
        playerBehaviour = player.GetComponent<PlayerBehaviour>();

        //playerBehaviour = GameObject.Find("Player")
        //    .GetComponent<PlayerBehaviour>();

        // Subscribe to the playerJump event (declared in PlayerBehaviour)
        // with the denoted method
        playerBehaviour.playerJump += HandlePlayerJump;

        debug("Jump event subscribed");
    }

    public void HandlePlayerJump()
    {
        debug("Player has jumped...");
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
        debug(_state);

        LogWithDelegate(debug);

        //LootStack.Push("Sword of Doom");
        //LootStack.Push("HP Boost");
        //LootStack.Push("Golden Key");
        //LootStack.Push("Pair of Winged Boots");
        //LootStack.Push("Mythril Bracer");

        //Shop<Collectable> itemShop = new();

        //itemShop.AddItem(new Potion());
        //itemShop.AddItem(new Antidote());

        //Debug.Log($"There are {itemShop.GetStockCount<Potion>()} item(s) for sale.");
        //Debug.Log($"There are {itemShop.GetStockCount<Antidote>()} item(s) for sale.");
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

    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegating the debug task...");
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
        try
        {
            //Utilities.RestartLevel();
            //Utilities.RestartLevel(0);
            Utilities.RestartLevel(-1);
            debug("Level successfully restarted...");
        }
        catch (ArgumentException exception)
        {
            Utilities.RestartLevel(0);
            // exception.ToString() is automatically called when an exception
            // is placed in a string
            debug($"Reverting to scene 0: {exception}");
        }
        finally
        {
            debug("Level restarted successfully...");
        }

    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0;
    }
}