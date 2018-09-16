﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {

    private Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}

    /*private void Update()
    {
        Debug.Log(_anim.GetInteger("AnimState"));
    }*/

    public int AnimState
    {
        set
        {
            _anim.SetInteger("AnimState", value);
        }
    }
}