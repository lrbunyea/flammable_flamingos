using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionDetonation : DetonationEffect{

    public override void Detonate(Stats Target)
    {
        Target.StatusEffects.Add(new ConfusionStatus());
    }
}
