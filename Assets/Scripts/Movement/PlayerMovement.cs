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

    private BoxCollider2D _box2D;

    void Start()
    {
        _animHandler = GetComponent<PlayerAnimationHandler>();
        _playerJump = GetComponent<PlayerJump>();
        _playerDamage = GetComponent<PlayerDamage>();
        _flipper = GetComponent<SpriteFlipper>();
        _box2D = GetComponent<BoxCollider2D>();
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
            _flipper.Flip(Constants.FACINGLEFT);
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
            {
                _animHandler.AnimState = Constants.PLAYERRUN;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right.normalized * Time.deltaTime * _moveSpeed);
            _flipper.Flip(Constants.FACINGRIGHT);
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
            {
                _animHandler.AnimState = Constants.PLAYERRUN;
            }
        }
        else
        {
            if (_playerJump.GetGrounded && !_playerDamage.IsDamaged)
            {
                _animHandler.AnimState = Constants.PLAYERIDLE;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow) && _playerJump.GetGrounded && !_playerDamage.IsDamaged)
        {
            _box2D.isTrigger = true;
            _animHandler.AnimState = Constants.PLAYERDASH;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _box2D.isTrigger = false;
    }
}
