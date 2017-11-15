using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSingle : AttackSocket
{
    public DamageSingle()
    {
        Damage = 20;
        Accuracy = 80;
        PrimeChance = 25;
        Type = TargetType.Single;
    }
}
