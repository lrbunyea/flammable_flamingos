using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfCare : AttackSocket
{
    public SelfCare()
    {
        Damage = -20;
        Accuracy = 100;
        PrimeChance = 0;
        Type = TargetType.Self;
    }

}
