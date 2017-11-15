using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {
        List<Attack> tempAttackList = turn.Attacks;

        foreach(Attack attack in tempAttackList)
        {
            stats.Health -= 5;
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
            Complete = true;
        }
    }
}
