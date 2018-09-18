using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera bounds.
/// In this class we will check if the camera is in certain bounds.
/// The 2 transform variable are used to define the bounds.
/// Max left indicates how far the camera can move left and Max right indicates how far the camera can move right.
/// </summary>
public class CameraBounds : MonoBehaviour {
    [SerializeField] private Transform _maxLeft;
    [SerializeField] private Transform _maxRight;

    private float _width; // This variable contains the width of the camera and is later used to clamp the camera between bounds.
    private float _height; // This variable contains the height of the camera and is used to calculate the width of the camera.

	//This function defines the variable
    private void Start()
    {
        _height = Camera.main.orthographicSize * 2;
        _width = Camera.main.aspect * _height;
    }

	//Every frame we need to check if the current position is inside the bounds, but we also need to subtract or add (depends on the side)
	//the width from the camera. This is because we are checking the middle point of the camera and we need to check the far right and far left point
	//of the camera.
    void Update () {
        Vector3 tPos = transform.position;
        
        tPos.x = Mathf.Clamp(tPos.x, _maxLeft.position.x - _width / 2, _maxRight.position.x + _width / 2);
        transform.position = tPos;
	}

	/// <summary>
	/// Checks if the param tPos is inside the bounds.
	/// </summary>
	/// <returns><c>true</c> if tPos is inside the bounds; otherwise, <c>false</c>.</returns>
	/// <param name="tPos">Transform position.</param>
    public bool IsInBounds(Vector3 tPos) {

        if (tPos.x - _width / 2 > _maxLeft.position.x && tPos.x + _width / 2 < _maxRight.position.x) {
            return true;
        }
        return false;
    }
}
