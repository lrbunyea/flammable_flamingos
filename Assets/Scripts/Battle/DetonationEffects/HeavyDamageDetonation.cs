using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyDamageDetonation : DetonationEffect {

    public override void Detonate(Stats Target)
    {
        Target.Health -= 25;
    }
}
