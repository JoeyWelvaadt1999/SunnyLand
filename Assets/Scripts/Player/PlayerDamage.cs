using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player damage.
/// </summary>
public class PlayerDamage : MonoBehaviour {

    private PlayerAnimationHandler _playerAnim;

    public delegate void PlayerDamageDelegate();
    public static event PlayerDamageDelegate OnDamageEvent;

    public delegate void EnemyHitDelegate();
    public static event EnemyHitDelegate OnEnemyHitEvent;

    public delegate void EnemyDeathEvent(string tag);
    public static event EnemyDeathEvent OnEnemyDeathEvent;

    private Collider2D _collider;

    private PlayerHealth _playerhealth;

    private float _waitForDamage;


    private void Start()
    {
        _playerAnim = GetComponent<PlayerAnimationHandler>();
        _collider = GetComponent<Collider2D>();
        _playerhealth = GetComponent<PlayerHealth>();
        IsDamaged = false;
        
    }

    //checks for triggering collision
    private void OnTriggerEnter2D(Collider2D collision)
	{
		//check wether you are colliding with one of the enemies
		if (collision.gameObject.tag == Constants.POSSUMTAG || collision.gameObject.tag == Constants.FROGTAG || collision.gameObject.tag == Constants.EAGLETAG || collision.gameObject.tag == Constants.TRAPTAG)
		{
			//checks to see if the enemy collider bounds center point are lower than the player collider bounds center point
			if (collision.bounds.center.y < _collider.bounds.center.y &&  collision.gameObject.tag != Constants.TRAPTAG)
			{
				OnEnemyHitEvent();
				OnEnemyDeathEvent(collision.gameObject.tag);
			}
			else //if the player is lower he will get damage and appropriate animation will be set
			{
				if (_playerhealth.GetHealthPoints > 1f)
				{
					IsDamaged = true;
				}
				_playerAnim.AnimState = Constants.PLAYERDAMAGE;
				OnDamageEvent();
			}
		}
	}

    private void OnTriggerStay2D(Collider2D collision) {
        if(!IsDamaged) {
            _waitForDamage += Time.deltaTime;
            if (_waitForDamage > 1f)
            {
                if (collision.gameObject.tag == Constants.TRAPTAG)
                {

                    if (_playerhealth.GetHealthPoints > 1f)
                    {
                        IsDamaged = true;
                    }
                    _playerAnim.AnimState = Constants.PLAYERDAMAGE;
                    OnDamageEvent();
                    _waitForDamage = 0f;
                    Debug.Log("Getting damaged" + _playerAnim.AnimState);
                }
            }
        }
    }

    //function that is called after the 'damaged' animation is over
    void SetDamaged()
    { 
		IsDamaged = false;
	}

	//getter setter to get value if its being damaged so that the appropriate animations will be played
	public bool IsDamaged { get; private set; }
}
