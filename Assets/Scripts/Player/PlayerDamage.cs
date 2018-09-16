using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public delegate void PlayerDamageDelegate();
    public static event PlayerDamageDelegate OnDamageEvent;

    public delegate void EnemyHitDelegate();
    public static event EnemyHitDelegate OnEnemyHitEvent;

    public delegate void EnemyDeathEvent(string tag);
    public static event EnemyDeathEvent OnEnemyDeathEvent;

    private float _offset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _offset = transform.position.y * Constants.HALFPLAYERSIZE;

        if (collision.gameObject.tag == Constants.POSSUMTAG)
        {
            if (collision.gameObject.transform.position.y > transform.position.y + _offset)
            {
                OnEnemyHitEvent();
                OnEnemyDeathEvent(collision.gameObject.tag);
            }
            else
            {
                OnDamageEvent();
            }
        }
    }


}
