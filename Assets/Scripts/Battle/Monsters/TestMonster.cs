﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Character
{
    public override Turn NextTurn(Character player, List<Character> enemies)
    {
        this.stats.AP = this.stats.MaxAP;
        Turn turn = new Turn();
        int i = 0;

        while (this.stats.AP > 0) { 
            Attack attack = new Attack();


            attack.plug = AttackPlug.None;
            attack.socket = new DamageSingle();
            attack.target = player.stats;

            turn.Attacks.Add(attack);
            this.stats.AP--;
        }
        return turn;
    }

	public TestMonster() : base(){
		Name = "Test";
	}
}
