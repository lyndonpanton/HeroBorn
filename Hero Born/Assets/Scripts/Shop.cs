using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// T is defined at initialisation and all inner instances of a generic will
// match the outer most definition
public class Shop<T>
{
    //public List<T> inventory = new List<T>();
    public List<T> inventory = new();

    public void AddItem(T newItem)
    {
        inventory.Add(newItem);
    }

    // A new generic type. Since it is the outer most instance of the generic
    // called U, it is defined when this method is called
    public int GetStockCount<U>()
    {
        int stock = 0;

        foreach (T item in inventory)
        {
            if (item is U)
            {
                stock++;
            }
        }

        return stock;
    }
}
