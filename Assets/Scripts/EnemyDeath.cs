using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void CompareGameObjectTags(string tag)
    {
        if (tag == _childTransform.tag)
        {
            StartDeathProcess();
        }
    }

    void StartDeathProcess()
    {
        _anim.Play(Constants.ENEMYDEATHANIMATION);
        _deathAudio.Play();
    }

    void Die()
    {
        PlayerDamage.OnEnemyDeathEvent -= CompareGameObjectTags;
        Destroy(gameObject);
    }
}
