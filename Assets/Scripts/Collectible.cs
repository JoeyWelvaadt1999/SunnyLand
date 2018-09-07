using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    public delegate void OnHitDelegate();
    public static event OnHitDelegate OnHitEvent;

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYERTAG)
        {
            //OnHitEvent();
            _anim.Play(Constants.ITEMFEEDBACKANIMATION);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
