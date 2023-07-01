using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop<T>
{
    //public List<T> inventory = new List<T>();
    public List<T> inventory = new();

    public void AddItem(T newItem)
    {
        inventory.Add(newItem);
    }
}
