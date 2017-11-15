using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyDamageDetonation : DetonationEffect {
    public int damage = 25;

    public override void Detonate(Stats Target)
    {
        Target.ApplyDamage(damage, AttackPlug.None, 1);
    }
}
