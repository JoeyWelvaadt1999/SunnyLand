using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 5f;

    private PlayerJump _playerJump;

    private PlayerAnimationHandler _animHandler;

    void Start()
    {
        _animHandler = GetComponent<PlayerAnimationHandler>();
        _playerJump = GetComponent<PlayerJump>();
    }

    //using FixedUpdate and normalizing the vector so that the collision doesn't jitter with transform.Translate
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left.normalized * Time.deltaTime * _moveSpeed);
            if (_playerJump.GetGrounded)
            {
                _animHandler.AnimState = Constants.PLAYERRUN;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right.normalized * Time.deltaTime * _moveSpeed);
            if (_playerJump.GetGrounded)
            {
                _animHandler.AnimState = Constants.PLAYERRUN;
            }
        }
        else if (Input.GetKeyDown(KeyCode.X) && _playerJump.GetGrounded)
        {
            //dash
            Debug.Log("Dash");
            _animHandler.AnimState = Constants.PLAYERDASH;
        }
        else
        {
            if (_playerJump.GetGrounded)
            {
                _animHandler.AnimState = Constants.PLAYERIDLE;
            }
        }
    }
}
