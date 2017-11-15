using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDetonation : DetonationEffect {

    List<Character> enemylist = GameObject.FindObjectOfType<BattleManager>().enemies;

    public override void Detonate(Stats Target)
    {
        Target.ApplyDamage(10, AttackPlug.None, 1);

        foreach(Character enemy in enemylist)
        {
            enemy.stats.ApplyDamage(5, AttackPlug.None, 1);
        }
    }
}
