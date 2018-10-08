using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player health.
/// This class contains the player health. 
/// </summary>
public class PlayerHealth : MonoBehaviour {

    public delegate void OnDeathDelegate(); //This delegate will activate when the player dies.
    public static event OnDeathDelegate OnDeathEvent;
    
    private PlayerAnimationHandler _playerAnim; //An instance of the player animation handler.

    private float _healthPoints; //This is the amount of health the player has.
	private float _startHealth;
    private float _finalHealthPoint;

	[SerializeField] private GameObject[] _lives;


    // Use this for initialization
    void Start()
    {
        _playerAnim = GetComponent<PlayerAnimationHandler>();
        _healthPoints = Constants.STARTINGHEALTHPOINTS;
        _finalHealthPoint = Constants.ONEHEALTHPOINT;
        PlayerDamage.OnDamageEvent += DecreaseHealthPoints;
        WinningHandler.WonTheGameEvent += SetWinAnimation;

		_startHealth = _healthPoints;
    }

	//In this function the health is decreased by one everytime this function is called.

	public void DecreaseHealthPoints()
    {
        if (_healthPoints > 1)
        {
            _healthPoints--;
            UpdateUIHealthPoints();

        }
        else
        {
			_healthPoints--;
            UpdateUIHealthPoints();
            _playerAnim.AnimState = Constants.PLAYERDEATH;
//			Die ();
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
		Destroy (_lives [(int)_healthPoints].gameObject);	
    }

    void SetWinAnimation()
    {
        _playerAnim.AnimState = Constants.PLAYERWIN;
        WinningHandler.WonTheGameEvent -= SetWinAnimation;
    }


	//This 'getter' returns the health point variable and is visible to other classes.
    public float GetHealthPoints
    {
        get { return _healthPoints; }
    }
}
