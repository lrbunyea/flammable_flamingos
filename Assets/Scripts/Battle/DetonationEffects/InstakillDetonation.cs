
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstakillDetonation : DetonationEffect {

    
    public override void Detonate(Stats Target)
    {

        int randNum = Random.Range(1, 100);

        if(randNum <= 5)
        {
            Target.Health = 0;
        }
        else
        {
            Target.ApplyDamage(10, AttackPlug.None, 1);
        }

    }
}
