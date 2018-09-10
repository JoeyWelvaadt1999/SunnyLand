using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    private float _smoothTimeX = 0.2f;
    private float _smoothTimeY = 0.2f;

    private Vector2 _velocity = Vector2.zero;

    private GameObject _target;

	// Use this for initialization
	void Start () {
        _target = GameObject.FindGameObjectWithTag(Constants.PLAYERTAG);
	}
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
    }

    void MoveCamera()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, _target.transform.position.x, ref _velocity.x, _smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, _target.transform.position.y, ref _velocity.y, _smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
