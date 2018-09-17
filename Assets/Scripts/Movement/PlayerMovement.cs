using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 5f;

    private PlayerJump _playerJump;
    private PlayerDamage _playerDamage;

    private PlayerAnimationHandler _animHandler;
    private SpriteFlipper _flipper;

    private float _facingDir;
    private string _facing;

    void Start()
    {
        _animHandler = GetComponent<PlayerAnimationHandler>();
        _playerJump = GetComponent<PlayerJump>();
        _playerDamage = GetComponent<PlayerDamage>();
        _flipper = GetComponent<SpriteFlipper>();
        _facingDir = Constants.FACINGVALUE;
        _facing = Constants.FACINGRIGHT;
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
            //Flip(Constants.FACINGLEFT);
            _flipper.Flip(Constants.FACINGLEFT);
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
            {
                _animHandler.AnimState = Constants.PLAYERRUN;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right.normalized * Time.deltaTime * _moveSpeed);
            //Flip(Constants.FACINGRIGHT);
            _flipper.Flip(Constants.FACINGRIGHT);
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
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
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
            {
                _animHandler.AnimState = Constants.PLAYERIDLE;
            }
        }
    }

    void Flip(string currentface)
    {
        if (currentface != _facing)
        {
            _facing = currentface;

            Vector3 localScale = transform.localScale;

            localScale.x *= _facingDir;

            transform.localScale = localScale;
        }
    }
}
