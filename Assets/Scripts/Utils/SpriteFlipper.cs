using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Sprite flipper.
/// This class flips a sprite from left to right.
/// </summary>
public class SpriteFlipper : MonoBehaviour {

    private float _facingDir;
    private string _facing;

	// Use this for initialization
	void Start () {
        _facingDir = Constants.FACINGVALUE;
        _facing = Constants.FACINGRIGHT;
	}

    public void BasicFlip()
    {
        Vector3 basicScale = transform.localScale;

        basicScale.x *= _facingDir;

        transform.localScale = basicScale;
    }

    public void Flip(string dir)
    {
        if (dir != _facing)
        {
            _facing = dir;

            Vector3 thisScale = transform.localScale;

            thisScale.x *= _facingDir;

            transform.localScale = thisScale;
        }
    }
}
