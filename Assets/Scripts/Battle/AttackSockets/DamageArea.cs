using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : AttackSocket
{
    public DamageArea()
    {
        Damage = 15;
        Accuracy = 75;
        PrimeChance = 25;
        Type = TargetType.Area;
    }

}
