using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : StatusEffect {

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

    }

    public override void PostTurn(Stats stats, Turn turn)
    {
        throw new System.NotImplementedException();
    }

   
}
