using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event
{
    public abstract void Check(Character player, Character[] enemies);
}
