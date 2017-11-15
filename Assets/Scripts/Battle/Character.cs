﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string Name;
    public Stats stats;
    public abstract Turn NextTurn(Character player, List<Character> enemies);
}
