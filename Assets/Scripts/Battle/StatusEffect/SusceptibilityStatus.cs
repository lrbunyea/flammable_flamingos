using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusceptibilityStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {
        if (turns == 0)
        {
            stats.WeaknessMultiplier *= 2;
        }
    }

    public override void PostTurn(Stats stats, Turn turn)
    {
        if(turns != 3)
        {
            turns++;
        }
        else
        {
            stats.WeaknessMultiplier /= 2;
            Complete = true;
        }
        
    }
}
