using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    None,
    WaitForTurn,
    ApplyingTurn
}

public class BattleManager : MonoBehaviour {

    public static BattleManager instance = null;
    
    public static BattleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BattleManager();
                DontDestroyOnLoad(instance);
            }
            return instance;
        }
    }

    public BattleState State;
    public Character player;
    public List<Character> enemies;
    public List<Event> events;

    private Queue<Character> turnOrder;
    
	Turn turn;
	Queue<Attack> Attacks;
	bool AnimDone;
	bool endNow;
    
    public int CharOrder(Character a, Character b)
    {
        return b.stats.Speed - a.stats.Speed;
    }

	public void SetupBattle(Character new_player, List<Character> new_enemies, List<Event> new_events)
    {
		Debug.Log ("Beep");

        this.player = new_player;
        this.enemies = new_enemies;
        this.events = new_events;

        // sort characters by speed to get turn order
        List<Character> order = new List<Character>();
		order.Add (this.player);
		foreach (Character c in this.enemies)
			order.Add (c);

        order.Sort(CharOrder);
        foreach (Character c in order)
            turnOrder.Enqueue(c);

		foreach (Character c in turnOrder) {
			Debug.Log (c.Name);
		}

		((Player)player).ResetAttacks (enemies[0]);
		State = BattleState.WaitForTurn;
    }

    public void EndBattle()
    {

    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("ERROR: THERE CAN ONLY BE ONE (BattleManager Singleton), removing newly spawned BattleManager");
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
		List<Character> en = new List<Character> ();
		en.Add (new TestMonster ());
		turnOrder = new Queue<Character> ();

		SetupBattle (new Player (), en, new List<Event> ());

		turn = new Turn();
		Attacks = new Queue<Attack>();
    }

    void SetupTurn()
    {

        Character currentChar = turnOrder.Peek();
        // run pre turn
        foreach (StatusEffect se in currentChar.stats.StatusEffects)
            se.PreTurn(currentChar.stats, turn);
        // add attacks to list
        foreach (Attack a in turn.Attacks)
            Attacks.Enqueue(a);
        // begin applying turn
        State = BattleState.ApplyingTurn;
    }

    void ApplyAttack()
    {
        Attack a = Attacks.Dequeue();
        List<Stats> targets = new List<Stats>();
        int attack = turnOrder.Peek().stats.BaseAttack;
        Queue<Character> tempOrder = new Queue<Character>();

        if (a.socket.Type == TargetType.Single)
        {
            if (a.target.Dead)
            {
                a.target = enemies[Random.Range(0, enemies.Count - 1)].stats;
            }
            targets.Add(a.target);
        }
        else if (a.socket.Type == TargetType.Area)
        {
            Character currentChar = turnOrder.Peek();
            if (currentChar != player)
                targets.Add(player.stats);
            else
                foreach (Character c in enemies)
                    targets.Add(c.stats);
        }
        else
        {
            // TODO self care
            // TODO make status map
            return;
        }

        // foreach target
        foreach (Stats s in targets)
        {
            // calculate hit chance
            int hitChance = s.Evasion - a.socket.Accuracy;
            int chance = Random.Range(1, 100);

            if(chance < hitChance)
            {
                if (s.PrimedWith == AttackPlug.None) // Prime
                {
                    // Calculate Priming chance
                    chance = Random.Range(1, 100);
                    if(chance < a.socket.PrimeChance)
                        s.PrimedWith = a.plug;
                    s.ApplyDamage(a.socket.Damage, a.plug, attack);
                }
                else // Detonate
                {
                    DetonationEffect de = DetonationMap.GetEffect(s.PrimedWith, a.plug);
                    de.Detonate(s);
                    s.ApplyDamage(a.socket.Damage, a.plug, attack);
                    s.PrimedWith = AttackPlug.None;
                }
            }
            
            if(s.Health <= 0)
            {
                int index = 0;   
                foreach(Character c in enemies)
                {
                    if(c.stats == s)
                    {
                        enemies.Remove(c);
                        
                    }
                }

                while(index < turnOrder.Count)
                {
                    if (turnOrder.Peek().stats != s) {
                        tempOrder.Enqueue(turnOrder.Dequeue());
                     }
                    index++;
                }
                turnOrder = tempOrder;

                index = 0;

                targets.Remove(s);
                
                s.Kill();
            }
            

        }
    }

    void EndTurn()
    {
        Character currentChar = turnOrder.Peek();
        // run post turn
        foreach (StatusEffect se in currentChar.stats.StatusEffects)
            se.PostTurn(currentChar.stats, turn);
        // move to next char and wait for turn
        turnOrder.Enqueue(turnOrder.Dequeue());
        State = BattleState.WaitForTurn;

		((Player)player).ResetAttacks (enemies[0]);

        // Remove Primed effect from all characters
        player.stats.PrimedWith = AttackPlug.None;
        foreach (Character c in enemies)
            c.stats.PrimedWith = AttackPlug.None;

        endNow = false;
    }

    public void EndTurnImmediately()
    {
        endNow = true;
    }

    void Update()
    {
        Character currentChar = turnOrder.Peek();

        switch(State)
        {
            case BattleState.WaitForTurn:
				Debug.Log("It is " + currentChar.Name + "'s turn!");
                // get turn if exists
                turn = currentChar.NextTurn(player, enemies);
                if (turn != null)
                    SetupTurn();
                break;
			case BattleState.ApplyingTurn:
                while (!endNow && Attacks.Count > 0)
                    ApplyAttack();
                EndTurn();
                break;
            case BattleState.None:
                return;
        }
    }
}
