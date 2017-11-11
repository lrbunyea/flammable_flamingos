using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusAttackDetonation : DetonationEffect
{
    public override void Detonate(Stats Target)
    {
        Target.StatusEffects.Add(new MinusAttackStatus());
    }
}
