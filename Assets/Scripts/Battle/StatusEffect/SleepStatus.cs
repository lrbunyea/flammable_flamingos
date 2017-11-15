using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {
        int random = Random.Range(0, 1);
        if(random == 0)
        {
            //TODO: use function to end turn

        }
    }

    public override void PostTurn(Stats stats, Turn turn)
    {
        if (turns != 3)
        {
            turns++;
        }
        else
        {
            Complete = true;
        }
    }
}
