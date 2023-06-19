using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 1;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ItemText;
    public TextMeshProUGUI ProgressText;

    public TextMeshProUGUI WinButton;
    public TextMeshProUGUI LoseButton;

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

    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");

        Time.timeScale = 1;
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0;
    }
}