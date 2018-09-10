using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate OnDeathEvent;

    private int _healthPoints;

	// Use this for initialization
	void Start () {
        _healthPoints = 5;
        PlayerDamage.OnDamageEvent += DecreaseHealthPoints;

	}

    void DecreaseHealthPoints()
    {
        if (_healthPoints >= 1)
        {
            _healthPoints--;
            Debug.Log("You have " + _healthPoints + " left");
        }
        else
        {
            OnDeathEvent();
            PlayerDamage.OnDamageEvent -= DecreaseHealthPoints;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
