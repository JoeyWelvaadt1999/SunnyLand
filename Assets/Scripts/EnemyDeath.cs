using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

    private Transform _childTransform;

    private Animator _anim;

	// Use this for initialization
	void Start () {
        PlayerDamage.OnEnemyDeathEvent += CompareGameObjectTags;
        _anim = GetComponent<Animator>();
        _childTransform = gameObject.transform.GetChild(0);
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
    }

    void Die()
    {
        PlayerDamage.OnEnemyDeathEvent -= CompareGameObjectTags;
        Destroy(gameObject);
    }
}
