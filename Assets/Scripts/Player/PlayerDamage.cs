using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void Start()
    {
        _playerAnim = GetComponent<PlayerAnimationHandler>();
        _collider = GetComponent<Collider2D>();
        _playerhealth = GetComponent<PlayerHealth>();
        IsDamaged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check wether you are colliding with one of the enemies
        if (collision.gameObject.tag == Constants.POSSUMTAG || collision.gameObject.tag == Constants.FROGTAG || collision.gameObject.tag == Constants.EAGLETAG)
        {
            if (collision.bounds.center.y < _collider.bounds.center.y)
            {
                OnEnemyHitEvent();
                OnEnemyDeathEvent(collision.gameObject.tag);
            }
            else
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

    void SetDamaged()
    {
        IsDamaged = false;
    }


    public bool IsDamaged { get; private set; }
}
