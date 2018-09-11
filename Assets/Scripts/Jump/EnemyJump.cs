using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : JumpBase {
	[SerializeField]private float _jumpDelay;
	private float _currentTime;

	private void Update() {
		_currentTime += Time.deltaTime;

		if (_currentTime >= _jumpDelay) {
			if (_isGrounded) {
				Jump ();
				_jumpForce = new Vector2 (-_jumpForce.x, _jumpForce.y);
				_currentTime = 0;
			}
		}
	}
}
