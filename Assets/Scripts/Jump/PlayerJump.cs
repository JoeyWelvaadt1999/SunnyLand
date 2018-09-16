using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerAnimationHandler))]
public class PlayerJump : JumpBase
{
    private PlayerAnimationHandler _animHandler;

    private float _lastY;

    protected override void Start()
    {
        base.Start();
        _animHandler = GetComponent<PlayerAnimationHandler>();
    }

    void Update()
    {
        InputCallback ic = new InputCallback();
        ic.KeyDown = Jump;

        KeyboardInput.AddToDict(KeyCode.Space, ic);


        //jump animation handling
        if (!_isGrounded)
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
