﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public int att = 1;
    public int def = 1;
    public int ap = 2;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
