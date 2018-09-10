using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]private float _movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");

		Vector2 tPos = transform.position;
		tPos.x += (x * _movementSpeed) * Time.deltaTime;
		tPos.y = tPos.y;
		transform.position = tPos;
	}
}
