using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Jump base.
/// The jump base defines al functions that are needed for the enemy jump and player jump. It also has a required component rigidbody 2d 
/// this is used to add force to the player or enemy so it can jump.
/// It also checks whether the player or enemy is standing on the ground and is able to jump.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class JumpBase : MonoBehaviour {
	[SerializeField]protected Vector2 _jumpForce;
	protected Rigidbody2D _rb2d;
    protected AudioSource[] _audioSource;
    protected AudioSource _jumpAudio;
    
	protected bool _isGrounded;
    protected int _maxJumps;
    protected int _currentJumps;


    
	protected virtual void Start() {
		_rb2d = GetComponent<Rigidbody2D> ();
        _audioSource = GetComponents<AudioSource>();
        _jumpAudio = _audioSource[0];
	}

	protected virtual void Jump() {
        if (_currentJumps < _maxJumps)
        {
            _jumpAudio.Play();
            _currentJumps++;
            _isGrounded = false;
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
