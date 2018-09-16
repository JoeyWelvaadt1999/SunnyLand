using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour {

    private float _moveSpeed = 10f;

    //using FixedUpdate and normalizing the vector so that the collision doesn't jitter
    void FixedUpdate()
    {
        Move();
    }
    
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left.normalized * Time.deltaTime * _moveSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right.normalized * Time.deltaTime * _moveSpeed);
        }
    }
}
