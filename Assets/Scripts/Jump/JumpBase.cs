using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpBase : MonoBehaviour {
	[SerializeField]protected Vector2 _jumpForce;
	protected Rigidbody2D _rb2d;
	protected bool _isGrounded;

	protected virtual void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Jump() {
		if (_isGrounded) {
			_isGrounded = false;
			_rb2d.AddForce (_jumpForce, ForceMode2D.Impulse);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		_isGrounded = true;	
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;
    }

    public bool GetGrounded
    {
        get { return _isGrounded; }
    }
}
