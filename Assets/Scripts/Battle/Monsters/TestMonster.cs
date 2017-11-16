using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonster : Character
{
    public override Turn NextTurn(Character player, List<Character> enemies)
    {
        Turn turn = new Turn();
        Attack attack = new Attack();
        

        attack.plug = AttackPlug.None;
        attack.socket = new DamageSingle();
        attack.target = enemies[0].stats;

        turn.Attacks.Add(attack);

        return turn;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
