using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour {
    [SerializeField] private float _speed;
    private Vector3 _startPos;
	// Use this for initialization
	void Start () {
        _startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");

        Vector3 tPos = transform.position;
        tPos.x -= x * Time.deltaTime * _speed;
        tPos.y = Camera.main.transform.position.y + _startPos.y;
        transform.position = tPos;

	}
}
