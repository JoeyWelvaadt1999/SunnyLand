using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy movement.
/// The enemy movement contains 3 important variable, _path, _speed, _index.
/// The path variable is an array of transforms, these transforms will be used as points.
/// The speed variable is the speed of the enemy.
/// The index variable indicates on which point in the array the enemy is currently at.
/// </summary>
public class EnemyMovement : MonoBehaviour {
	[SerializeField]private Transform[] _path;
	[SerializeField][Range(0f, 1f)]private float _speed;
	private int _index = 0;

	private bool _forward = true;

    private SpriteFlipper _flipper;

    private void Start()
    {
        _flipper = GetComponent<SpriteFlipper>();
    }


	//In the update function the enemy moves to the next point in the array. If the enemy is at the limit of the array it will reverse its path.
    private void Update() {
		transform.position = Vector3.MoveTowards (transform.position, _path [_index].position, _speed);

		if (transform.position == _path [_index].position) {
			if (_forward) {
                
				_index++;
			} else {
                
				_index--;
			}
		}

        if (transform.position.x < _path[_index].position.x)
        {
            _flipper.Flip(Constants.FACINGLEFT);
        }
        else {
            _flipper.Flip(Constants.FACINGRIGHT);
        }

		if (_index == _path.Length - 1) {
			_forward = false;
		} else if (_index == 0) {
			_forward = true;
		}
	}
}
