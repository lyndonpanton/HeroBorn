using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 4;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI ProgressText;

    void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
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
                ProgressText.text = "You've found all the items!";
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
        }
    }
}