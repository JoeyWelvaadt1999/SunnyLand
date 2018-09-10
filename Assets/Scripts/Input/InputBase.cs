using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCallback {
	public delegate void KeyCallback();

	public KeyCallback KeyDown { get; set;}
	public KeyCallback KeyUp {get; set;}
	public KeyCallback KeyPressed {get; set;}
}
