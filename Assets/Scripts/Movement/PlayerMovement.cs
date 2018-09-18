using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player movement.
/// This class wil be taking care of the walking movement of the player.
/// It will also take care of the walking animation and idle animation.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 5f; //This variable will indicate the speed of the player, this is not the final speed because it will be altered in a sum.

    private PlayerJump _playerJump; // This is an instance to the player jump script.
	private PlayerDamage _playerDamage; // This is an instance to the player damage script.

	private PlayerAnimationHandler _animHandler; // This is an instance to the player animation handler script.
	private SpriteFlipper _flipper; // This is an instance to the sprite flipper script.

    private BoxCollider2D _box2D;
    
	//In the start function all the variable will be initialized.

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

	//The move function checks if a key is pressed, lets say the left key is pressed, then the following this happen.
	//The player moves to the left, flips to the left and plays a run animation if the player is standing on the ground and is currently not 
	//being damaged, same goes for the right.
	//If the down arrow is pressed then the player will dash towards the direction he is facing.
	//In the case that none of these buttons are pressed, meaning the player is standing still. The idle animation will play.
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
