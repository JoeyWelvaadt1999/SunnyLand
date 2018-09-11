using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate OnDeathEvent;

    private int _healthPoints;
    public Text _livesText;

	// Use this for initialization
	void Start () {
        _healthPoints = 5;
        PlayerDamage.OnDamageEvent += DecreaseHealthPoints;
        _livesText.text = "Lives: " + _healthPoints.ToString();
	}

    void DecreaseHealthPoints()
    {
        if (_healthPoints >= 2)
        {
            _healthPoints--;
            Debug.Log("You have " + _healthPoints + " left");
            _livesText.text = "Lives " + _healthPoints.ToString();
        }
        else
        {
            _healthPoints--;
            _livesText.text = "Lives " + _healthPoints.ToString();
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
