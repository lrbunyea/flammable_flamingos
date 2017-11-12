using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {
       
    }

    public override void PostTurn(Stats stats, Turn turn)
    {
        turns++;
        stats.Health -= 3;

        if(turns == 3)
        {
            Complete = true;
        }
    }
}
