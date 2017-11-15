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
    public int WeaknessMultiplier;
    public AttackPlug Type;
    public AttackPlug PrimedWith;
    public List<StatusEffect> StatusEffects;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(int damage, AttackPlug damageType)
    {
        bool applyWeakness = false;
        AttackPlug weakness = DetermineWeakness();
        if(damageType == weakness && damageType != AttackPlug.None)
        {
            applyWeakness = true;
        }
        if (applyWeakness)
        {
            damage *= WeaknessMultiplier;
        }

        damage /= Defense;

        Health -= damage;
    }

    public AttackPlug DetermineWeakness()
    {
        switch (Type)
        {
            case AttackPlug.Bomb:
                {
                    return AttackPlug.CC;
                }

            case AttackPlug.CC:
                {
                    return AttackPlug.Debuff;
                }

            case AttackPlug.Debuff:
                {
                    return AttackPlug.Dot;
                }

            case AttackPlug.Dot:
                {
                    return AttackPlug.Bomb;
                }

            default:
                {
                    return AttackPlug.None;
                }
        }
    }
}
