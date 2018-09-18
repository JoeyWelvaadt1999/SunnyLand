using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy death.
/// </summary>
public class EnemyDeath : MonoBehaviour {

    private Transform _childTransform;

    private Animator _anim;

    private AudioSource[] _audioSource;
    private AudioSource _deathAudio;

	// Use this for initialization
	void Start () {
        PlayerDamage.OnEnemyDeathEvent += CompareGameObjectTags;
        _anim = GetComponent<Animator>();
        _audioSource = GetComponents<AudioSource>();
        _deathAudio = _audioSource[1];
        _childTransform = transform.GetChild(0);
	}

	//method subscribed to the Playerdamage event that checks with enemy has to respond
	void CompareGameObjectTags(string tag)
	{
		if (tag == _childTransform.tag)
		{
			StartDeathProcess();
		}
	}

	//playing the death animation and the death sound
	void StartDeathProcess()
	{
		_anim.Play(Constants.ENEMYDEATHANIMATION);
		_deathAudio.Play();
	}

	//method that is called when the death animation reaches its end
	void Die()
	{
		PlayerDamage.OnEnemyDeathEvent -= CompareGameObjectTags;
		Destroy(gameObject);
	}
}
