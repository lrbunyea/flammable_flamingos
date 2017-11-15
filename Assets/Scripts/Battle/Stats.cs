using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int Health;
    public int MaxHealth;
    public int BaseAttack;
    public int Speed;
    public int Evasion;
    public int Defense;
    public int AP;
    public int MaxAP;
    public AttackPlug Type;
    public AttackPlug PrimedWith;
    public List<StatusEffect> StatusEffects;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(int damage)
    {

    }
}
