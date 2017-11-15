using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzeStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {
        if(turns == 0)
        {
            stats.AP -= 1;
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
            stats.AP++;
            Complete = true;
        }
    }
}
