using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate OnDeathEvent;

    private float _healthPoints;
    private float _finalHealthPoint;
    public Text _livesText;

    // Use this for initialization
    void Start()
    {
        _healthPoints = Constants.STARTINGHEALTHPOINTS;
        _finalHealthPoint = Constants.ONEHEALTHPOINT;
        PlayerDamage.OnDamageEvent += DecreaseHealthPoints;
        UpdateUIHealthPoints();
    }

    void DecreaseHealthPoints()
    {
        if (_healthPoints > _finalHealthPoint)
        {
            _healthPoints--;
            UpdateUIHealthPoints();
        }
        else
        {
            _healthPoints--;
            UpdateUIHealthPoints();
            OnDeathEvent();
            PlayerDamage.OnDamageEvent -= DecreaseHealthPoints;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void UpdateUIHealthPoints()
    {
        _livesText.text = "Lives: " + _healthPoints.ToString();
    }
}
