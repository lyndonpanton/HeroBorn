using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Character
{
    public Weapon weapon;

    public Paladin() : base()
    {

    }

    public Paladin(string name) : base(name)
    {

    }

    public Paladin(string name, Weapon weapon) : base(name)
    {
        this.weapon = weapon;
    }
}
