using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public delegate void PlayerDamageDelegate();
    public static event PlayerDamageDelegate OnDamageEvent;

    public delegate void EnemyHitDelegate();
    public static event EnemyHitDelegate OnEnemyHitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.ENEMYTAG)
        {
            if (collision.gameObject.transform.position.y < transform.position.y + transform.position.y *.5f)//TEST DISTANCE WITH JUMP
            {
                Debug.Log("hit the beast");
                //OnEnemyHitEvent();
                //Destroy(collision.gameObject);
            }
            else
            {
                OnDamageEvent();
            }
        }
    }
}
