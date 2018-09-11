﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounce : MonoBehaviour {

    private Rigidbody2D _rd2b;
    private Vector2 _bounceForce;

	// Use this for initialization
	void Start () {
        _rd2b = GetComponent<Rigidbody2D>();
        PlayerDamage.OnEnemyHitEvent += Bounce;
        PlayerHealth.OnDeathEvent += Unsubscribe;
        _bounceForce = new Vector2(0, 5);
	}

    void Bounce()
    {
        _rd2b.AddForce(_bounceForce, ForceMode2D.Impulse);
    }

    void Unsubscribe()
    {
        PlayerDamage.OnEnemyHitEvent -= Bounce;
        PlayerHealth.OnDeathEvent -= Unsubscribe;
    }
}