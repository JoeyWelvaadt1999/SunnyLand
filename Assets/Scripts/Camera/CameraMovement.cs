using UnityEngine;

[RequireComponent(typeof(CameraBounds))]
public class CameraMovement : MonoBehaviour {
    
    private float _smoothTimeX = 0.2f;
    private float _smoothTimeY = 0.2f;

    private Vector2 _velocity = Vector2.zero;

    [SerializeField]private GameObject _target;

    private CameraBounds _cameraBounds;
    private void Start()
    {
        _cameraBounds = GetComponent<CameraBounds>();
    }

    void Update () {
        if (_target != null)
        {
            Vector3 tPos = transform.position;
            Vector3 newCameraPos = MoveCamera();
            if (_cameraBounds.IsInBounds(newCameraPos))
            {
                tPos.x = newCameraPos.x;
            }
            tPos.y = newCameraPos.y;
            transform.position = tPos;
        }
    }

    Vector3 MoveCamera()
    {
        
        float posX = Mathf.SmoothDamp(transform.position.x, _target.transform.position.x, ref _velocity.x, _smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, _target.transform.position.y, ref _velocity.y, _smoothTimeY);
        Vector3 newPos = new Vector3(posX, posY, transform.position.z);
        
        return newPos;
    }
}
