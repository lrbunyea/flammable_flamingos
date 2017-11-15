using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimingArea : AttackSocket
{
    public PrimingArea()
    {
        Damage = 5;
        Accuracy = 75;
        PrimeChance = 75;
        Type = TargetType.Area;
    }
}
