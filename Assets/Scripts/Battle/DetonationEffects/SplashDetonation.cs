using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDetonation : DetonationEffect {

    Character[] enemylist = GameObject.FindObjectOfType<BattleManager>().enemies;

    public override void Detonate(Stats Target)
    {
        Target.Health -= 10;

        foreach(Character enemy in enemylist)
        {
            enemy.stats.Health -= 5;
        }
    }
}
