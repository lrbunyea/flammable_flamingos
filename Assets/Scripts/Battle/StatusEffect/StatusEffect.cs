using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public abstract void PreTurn(Stats stats, Turn turn);
    public abstract void PostTurn(Stats stats, Turn turn);

    public bool Complete;
}
