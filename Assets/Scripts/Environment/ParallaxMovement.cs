using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parallax movement.
/// This class will give a certain effect to the level layout. When the player moves right the background moves left, which makes it look more like the player is actually walking.
/// </summary>
public class ParallaxMovement : MonoBehaviour {
    [SerializeField] private float _speed;
    private Vector3 _startPos;
	// Use this for initialization
	void Start () {
        _startPos = transform.position;
	}
	
	// Every frame this function checks which way the player is walking and will move this object the opposite way.
	void Update () {
        float x = Input.GetAxis("Horizontal");

        Vector3 tPos = transform.position;
        tPos.x -= x * Time.deltaTime * _speed;
        tPos.y = Camera.main.transform.position.y + _startPos.y;
        transform.position = tPos;

	}
}
