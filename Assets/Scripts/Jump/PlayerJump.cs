using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : JumpBase {
	

	void Update () {
		InputCallback ic = new InputCallback();
		ic.KeyDown = Jump;

		KeyboardInput.AddToDict (KeyCode.Space, ic);
	}

	protected override void Jump ()
	{
		base.Jump ();
	}
}
