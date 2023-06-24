using System;
using UnityEngine;

[Serializable]
public struct Weapon
{
    public string name;
    public int damage;

    public Weapon(string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.Log($"Weapon: {name} - {damage} attack");
    }
}
