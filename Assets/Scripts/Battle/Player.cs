using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	//TODO: remove attack list and index... sorry Corey
	public List<Attack> A;
	public int index;

    public override Turn NextTurn(Character player, List<Character> enemies)
    {
		if (((Player) player).index >= player.stats.AP) {
			Turn next = new Turn ();
			next.Attacks = ((Player) player).A;

			Debug.Log ("Turn Returned!");

			return next;

		} else {
			Debug.Log ("Current Attacks: " + index);
			return null;
		}
    }
		
	public Player() : base(){
		Name = "W01T3R";
		A = new List<Attack> ();
		for (int i = 0; i < stats.MaxAP; i++) {
			A.Add (new Attack ());
		}
		stats.Speed = 10;
	}

	public void ResetAttacks(Character enemy){
		for (int i = 0; i < stats.MaxAP; i++) {
			A.Add (new Attack ());
			A [i].target = BattleManager.instance.enemies [0].stats;
		}
		index = 0;
	}
}
