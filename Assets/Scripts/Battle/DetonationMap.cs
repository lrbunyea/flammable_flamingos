using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackPlug
{
    None,
    Bomb,
    Dot,
    CC,
    Debuff
}

public enum TargetType
{
    Self,
    Single,
    Area
}

public class DetonationMap
{
    private static Dictionary<int, DetonationEffect> Map;

    private static int getKey(AttackPlug Primer, AttackPlug Detonator)
    {
        return 1 >> (int)Primer | 1 >> (int)Detonator;
    }

    public static DetonationEffect GetEffect(AttackPlug Primer, AttackPlug Detonator)
    {
        return Map[getKey(Primer, Detonator)];
    }

    private static void initialize()
    {
        Map.Add(getKey(AttackPlug.Bomb, AttackPlug.Dot), new HeavyDamageDetonation());
        Map.Add(getKey(AttackPlug.Bomb, AttackPlug.CC), new SplashDetonation());
        Map.Add(getKey(AttackPlug.Bomb, AttackPlug.Debuff), new InstakillDetonation());
        Map.Add(getKey(AttackPlug.Dot, AttackPlug.Bomb), new PoisonDetonation());
        Map.Add(getKey(AttackPlug.Dot, AttackPlug.CC), new SpikesDetonation());
        Map.Add(getKey(AttackPlug.Dot, AttackPlug.Debuff), new SleepDetonation());
        Map.Add(getKey(AttackPlug.CC, AttackPlug.Bomb), new ConfusionDetonation());
        Map.Add(getKey(AttackPlug.CC, AttackPlug.Dot), new SleepDetonation());
        Map.Add(getKey(AttackPlug.CC, AttackPlug.Debuff), new ParalyzeDetonation());
        Map.Add(getKey(AttackPlug.Debuff, AttackPlug.Bomb), new DefenseDebuffDetonation());
        Map.Add(getKey(AttackPlug.Debuff, AttackPlug.Dot), new MinusAttackDetonation());
        Map.Add(getKey(AttackPlug.Debuff, AttackPlug.CC), new EvasionDebuffDetonation());

    }
    
}
