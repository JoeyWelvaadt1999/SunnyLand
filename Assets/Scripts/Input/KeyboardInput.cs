using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keyboard input.
/// This class is used for a generic keyboard input.
/// </summary>
public class KeyboardInput : MonoBehaviour {
	private static Dictionary<KeyCode, InputCallback> _inputs = new Dictionary<KeyCode, InputCallback>();//This variable saves all keycodes together with a inputcallback, the inputcallback is explained in another class.

	//Every frame we will check if the inputs dictionary has 1 or more indexes, if so we will loop through all possible keycodes to check
	//if the input dictionary contains this keycode. If this is the case check for all three sorts of key press if the input callback has a function.
	//Then call this method.
	private void FixedUpdate() {
		if (_inputs.Count == 0)
			return;

		foreach (KeyCode kc in System.Enum.GetValues(typeof(KeyCode))) {
			if (_inputs.ContainsKey (kc)) {
				InputCallback icb = _inputs [kc];
				if (Input.GetKeyDown (kc)) {
					if(icb.KeyDown != null) 
						icb.KeyDown ();
				}

				if (Input.GetKeyUp (kc)) {
					if(icb.KeyUp != null)
						icb.KeyUp ();
				}

				if (Input.GetKey (kc)) {
					if(icb.KeyPressed != null)
						icb.KeyPressed ();
				}
			}
		}
	}


	//In this function you will be able to add a key with a inputcallback to the dictionary.
	public static void AddToDict(KeyCode key, InputCallback value) {
		if (!_inputs.ContainsKey(key)) {
			_inputs.Add (key, value);
		}
	}
}
