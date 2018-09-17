using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpBase : MonoBehaviour {
	[SerializeField]protected Vector2 _jumpForce;
	protected Rigidbody2D _rb2d;
	protected bool _isGrounded;
    protected int _maxJumps;
    protected int _currentJumps;
    
	protected virtual void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Jump() {
        if (_currentJumps < _maxJumps)
        {
            _currentJumps++;
            Debug.Log(_isGrounded);
            _isGrounded = false;
            Debug.Log(_isGrounded);
            _rb2d.AddForce(_jumpForce, ForceMode2D.Impulse);
        }
	}

	private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == Constants.PLATFORMLAYER)
        {
            _isGrounded = true;
            _currentJumps = 0;
        }
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constants.PLATFORMLAYER)
        {
            _isGrounded = false;
        }
    }
    

    public bool GetGrounded
    {
        get { return _isGrounded; }
    }
}
