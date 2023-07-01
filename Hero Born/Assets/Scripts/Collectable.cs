using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectable
{
    public string name;
}

public class Potion : Collectable
{
    public Potion()
    {
        this.name = "Potion";
    }
}

public class Antidote : Collectable
{
    public Antidote()
    {
        this.name = "Antidote";
    }
}
