using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player jump.
/// The player jumps gets its functionallity from the jump base.
/// </summary>
//[RequireComponent(typeof(PlayerAnimationHandler))]
public class PlayerJump : JumpBase
{
	
    private PlayerAnimationHandler _animHandler;

    private PlayerDamage _playerDamage;

    private float _lastY;

    protected override void Start()
    {
        base.Start();
		float height = Camera.main.orthographicSize * 2f;


        _animHandler = GetComponent<PlayerAnimationHandler>();
        _playerDamage = GetComponent<PlayerDamage>();
        
        
    }

    void FixedUpdate()
    {


		
        InputCallback ic = new InputCallback();
        ic.KeyDown = Jump;

        KeyboardInput.AddToDict(KeyCode.Space, ic);

        //jump animation handling
        if (!_isGrounded && !_playerDamage.IsDamaged)
        {
            float currentY = transform.position.y;
            if (currentY - _lastY > 0)
            {
                _animHandler.AnimState = Constants.PLAYERRISE;
               
            }
            else if (currentY - _lastY < 0)
            {
                _animHandler.AnimState = Constants.PLAYERFALL;
                
            }
            _lastY = currentY;
        }
    }
}
