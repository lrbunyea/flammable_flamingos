﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasionDebuffStatus : StatusEffect {

    public int turns;

    // runs before the turn is applied
    public override void PreTurn(Stats stats, Turn turn)
    {
        if (turns == 0)
            stats.Evasion -= 5;
    }

    // runs after the turn is applied
    public override void PostTurn(Stats stats, Turn turn)
    {
        turns++;
        if (turns == 3)
        {
            Complete = true;
            stats.Evasion += 5;
        }
    }
}
