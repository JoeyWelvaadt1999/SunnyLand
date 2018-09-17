using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public delegate void OnDeathDelegate();
    public static event OnDeathDelegate OnDeathEvent;

    private PlayerAnimationHandler _playerAnim;

    private float _healthPoints;
    private float _finalHealthPoint;
    public Text _livesText;

    // Use this for initialization
    void Start()
    {
        _playerAnim = GetComponent<PlayerAnimationHandler>();
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
            _playerAnim.AnimState = Constants.PLAYERDEATH;
        }
    }

    void Die()
    {
        OnDeathEvent();
        PlayerDamage.OnDamageEvent -= DecreaseHealthPoints;
        Destroy(gameObject);
    }

    void UpdateUIHealthPoints()
    {
        _livesText.text = "Lives: " + _healthPoints.ToString();
    }

    public float GetHealthPoints
    {
        get { return _healthPoints; }
    }
}
