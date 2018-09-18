using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : JumpBase {
	[SerializeField]private float _jumpDelay;
	private float _currentTime;
    private Animator _anim;
    private SpriteFlipper _flipper;
    private float _lastY;
    private bool lastUpdated = false;

    protected override void Start()
    {
        base.Start();
        _currentJumps = 0;
        _maxJumps = Constants.ENEMYJUMPAMOUNT;
        _anim = GetComponent<Animator>();
        _flipper = GetComponent<SpriteFlipper>();
    }

    private void Update() {
		_currentTime += Time.deltaTime;

		if (_currentTime >= _jumpDelay) {
			Jump ();
            _flipper.BasicFlip();
			_jumpForce = new Vector2 (-_jumpForce.x, _jumpForce.y);
			_currentTime = 0;
		}
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        if (_isGrounded)
        {
            _anim.SetInteger("State", Constants.FROGIDLE);
        }
        else
        {
            
            float currY = transform.position.y;
            if (currY - _lastY > 0)
            {
                _anim.SetInteger("State", Constants.FROGRISE);
            }
            else if (currY - _lastY < 0)
            {
                _anim.SetInteger("State", Constants.FROGFALL);
            }
            _lastY = currY;
        }
    }
}
