using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;

    public Character()
    {
        name = "n/a";
    }

    public Character(string name)
    {
        this.name = name;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.Log($"Hero: {this.name} ({this.exp}xp)");
    }

    private void Reset()
    {
        this.name = "n/a";
        this.exp = 0;
    }
}
