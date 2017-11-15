using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    None,
    WaitForTurn,
    ApplyingTurn,
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
    
    
    public int CharOrder(Character a, Character b)
    {
        return a.stats.Speed - b.stats.Speed;
    }

    public void SetupBattle(Character player, List<Character> enemies, List<Event> events)
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
        Stats target = a.target;

        // calculate hit chance

        // foreach target
        if (target.PrimedWith == AttackPlug.None) // Prime
        {
            // Calculate Priming chance
            target.PrimedWith = a.plug;
        }
        else // Detonate
        {
            DetonationEffect de = DetonationMap.GetEffect(target.PrimedWith, a.plug);
            // TODO apply de
            target.PrimedWith = AttackPlug.None;
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

        // TODO remove all PrimedWith
    }

    Turn turn;
    Queue<Attack> Attacks;
    bool AnimDone;

    void Update()
    {
        Character currentChar = turnOrder.Peek();

        switch(State)
        {
            case BattleState.WaitForTurn:
                // get turn if exists
                turn = currentChar.NextTurn(player, enemies);
                if (turn != null)
                    SetupTurn();
                break;
            case BattleState.ApplyingTurn:

                //break;
            case BattleState.None:
                return;
        }
    }
}
