using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectible.
/// This class will check if an collectible is hit, if so the collectible will be destroyed after playing an animation and a sound.
/// </summary>
public class Collectible : MonoBehaviour {

    public delegate void OnHitDelegate();
    public static event OnHitDelegate OnHitEvent;

    private AudioSource _audioSource;

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYERTAG)
        {
            OnHitEvent();
            _audioSource.Play();
            _anim.Play(Constants.ITEMFEEDBACKANIMATION);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
