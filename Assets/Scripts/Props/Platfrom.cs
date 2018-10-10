using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfrom : MonoBehaviour {
    [SerializeField] private Transform[] _path;
    [SerializeField] [Range(0f, 1f)] private float _speed;
    private int _index = 0;

    private bool _forward = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, _path[_index].position, _speed);

        if (transform.position == _path[_index].position)
        {
            if (_forward)
            {

                _index++;
            }
            else
            {

                _index--;
            }
        }

        if (_index == _path.Length - 1)
        {
            _forward = false;
        }
        else if (_index == 0)
        {
            _forward = true;
        }
    }
}
