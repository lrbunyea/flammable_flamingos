using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {

    public int Health;
    public int MaxHealth;
    public int BaseAttack;
    public int Speed;
    public int Evasion;
    public int Defense;
    public int AP;
    public int MaxAP;
    public int WeaknessMultiplier;
    public bool Dead = false;
    public AttackPlug Type;
    public AttackPlug PrimedWith;
    public List<StatusEffect> StatusEffects;

	public Stats(){
		MaxHealth = 100;
		Health = MaxHealth;
		BaseAttack = 5;
		Speed = 5;
		Evasion = 5;
		Defense = 5;
		MaxAP = 2;
		AP = MaxAP;
		WeaknessMultiplier = 2;
		Type = AttackPlug.None;
		PrimedWith = AttackPlug.None;
		StatusEffects = new List<StatusEffect>();
	}

    public void ApplyDamage(int damage, AttackPlug damageType, int attackStat)
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
        damage *= attackStat;

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

    public void Kill()
    {
        Dead = true;
        
    }
}
