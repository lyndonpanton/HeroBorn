using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    public GameBehaviour GameManager;

    void Start()
    {
        GameManager = GameObject.Find("Game_Manager")
            .GetComponent<GameBehaviour>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected");

            GameManager.Items++;
        }
    }
}