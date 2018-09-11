using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public delegate void PlayerDamageDelegate();
    public static event PlayerDamageDelegate OnDamageEvent;

    public delegate void EnemyHitDelegate();
    public static event EnemyHitDelegate OnEnemyHitEvent;

    public delegate void EnemyDeathDelegate(string goTag);
    public static event EnemyDeathDelegate OnEnemyDeathEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.FROGTAG || collision.gameObject.tag == Constants.POSSUMTAG)
        {
            if (collision.gameObject.transform.position.y < transform.position.y + transform.position.y *.5f)//TEST DISTANCE WITH JUMP
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
