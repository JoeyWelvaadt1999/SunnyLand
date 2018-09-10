using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpBase : MonoBehaviour {
	[SerializeField]protected Vector2 _jumpForce;
	protected Rigidbody2D _rb2d;
	protected bool _isGrounded;

	private void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Jump() {
		if (_isGrounded) {
			_isGrounded = false;
			_rb2d.AddForce (_jumpForce, ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(){
		_isGrounded = true;	
	}
}
