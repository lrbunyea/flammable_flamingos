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
    
}
