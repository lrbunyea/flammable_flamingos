using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public AttackPlug plug;
    public AttackSocket socket;
    public Stats target;

	public 	Attack(){
		plug = AttackPlug.None;
		socket = null;
		target = null;
	}
}
