using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public Character player;
    public Character[] enemies;
    public Event[] events;

    private Queue<Character> turnOrder;
    
    public int CharOrder(Character a, Character b)
    {
        return a.stats.Speed - b.stats.Speed;
    }

    public void SetupBattle(Character player, Character[] enemies, Event[] events)
    {
        this.player = player;
        this.enemies = enemies;
        this.events = events;

        // sort characters by speed to get turn order
        List<Character> order = new List<Character>();
        order.Sort(CharOrder);
        foreach (Character c in order)
            turnOrder.Enqueue(c);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
