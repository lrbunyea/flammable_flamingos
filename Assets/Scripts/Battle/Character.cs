using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : Object
{
    public string Name;
    public Stats stats;
    public abstract Turn NextTurn(Character player, List<Character> enemies);

	public Character(){
		stats = new Stats ();
	}
}
