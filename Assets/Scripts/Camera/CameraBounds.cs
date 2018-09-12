using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {
    [SerializeField] private Transform _maxLeft;
    [SerializeField] private Transform _maxRight;

    private float _width;
    private float _height;

    private void Start()
    {
        _height = Camera.main.orthographicSize * 2;
        _width = Camera.main.aspect * _height;
    }

    // Update is called once per frame
    void Update () {
        Vector3 tPos = transform.position;
        
        tPos.x = Mathf.Clamp(tPos.x, _maxLeft.position.x - _width / 2, _maxRight.position.x + _width / 2);
        transform.position = tPos;
	}

    public bool IsInBounds(Vector3 tPos) {

        if (tPos.x - _width / 2 > _maxLeft.position.x && tPos.x + _width / 2 < _maxRight.position.x) {
            return true;
        }
        Debug.Log(false);

        return false;
    }
}
