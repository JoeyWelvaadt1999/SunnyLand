using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour {

    private float _moveSpeed = 10f;
    private float _jumpForce = 10f;
    private bool _isGrounded;

    private Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //test jump here
        }
	}
}
