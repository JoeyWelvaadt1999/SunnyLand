using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectible.
/// This class will check if an collectible is hit, if so the collectible will be destroyed after playing an animation and a sound.
/// </summary>
public class Collectible : MonoBehaviour {


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
			PlayerInventory pi = collision.GetComponent<PlayerInventory> ();
			pi.Inventory.AddToInventory (this);
            _audioSource.Play();
            _anim.Play(Constants.ITEMFEEDBACKANIMATION);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
