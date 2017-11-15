using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionStatus : StatusEffect {

    public int turns;

    public override void PreTurn(Stats stats, Turn turn)
    {

        int i = 0;
        Character[] newTargetList = GameObject.FindObjectsOfType<Character>();
        Stats[] newStatList = new Stats[newTargetList.Length];
        int randomTarget = Random.Range(0, newTargetList.Length - 1);

        foreach(Character target in newTargetList)
        {
            newStatList[i] = target.stats;
            i++;
        }

        List<Attack> tempAttackList = turn.Attacks;

        foreach(Attack attack in tempAttackList)
        {
            attack.target = newStatList[randomTarget];
            randomTarget = Random.Range(0, newTargetList.Length - 1);
        }

    }

    public override void PostTurn(Stats stats, Turn turn)
    {
        if(turns != 3)
        {
            turns++;
        }
        else
        {
            Complete = true;
        }
    }

   
}
