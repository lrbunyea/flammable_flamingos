using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    public Stats stats;

    public abstract void NextTurn(Stats[] enemies);
}
