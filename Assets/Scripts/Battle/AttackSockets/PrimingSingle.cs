using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimingSingle : AttackSocket
{
    public PrimingSingle()
    {
        Damage = 10;
        Accuracy = 80;
        PrimeChance = 75;
        Type = TargetType.Single;
    }
}
