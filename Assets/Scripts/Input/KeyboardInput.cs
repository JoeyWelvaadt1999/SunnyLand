using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour {
	private static Dictionary<KeyCode, InputCallback> _inputs = new Dictionary<KeyCode, InputCallback>();

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

	public static void AddToDict(KeyCode key, InputCallback value) {
		if (!_inputs.ContainsKey(key)) {
			_inputs.Add (key, value);
		}
	}
}
