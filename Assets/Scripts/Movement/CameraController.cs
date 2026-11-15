using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;


    [SerializeField] private float _sensitivity = 5f;//чувствительность
    [SerializeField] private float _minVerticalAngle = -80f;
    [SerializeField] private float _maxVerticalAngle = 80f;
    [SerializeField] private Jostick _lookStick;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Start()
    {
        if (_cameraTransform == null)
        {
            _cameraTransform = transform;

            Vector3 currentRotation = _cameraTransform.localRotation.eulerAngles;
            _rotationX = currentRotation.x;
            _rotationY = currentRotation.y;

            if (_rotationX > 180) _rotationX -= 360;

        }
    }

    private void Update()
    {
        float h = _lookStick.Horizontal;
        float v = _lookStick.Vertical;
        _rotationY += h * _sensitivity * Time.deltaTime;
        _rotationX -= v * _sensitivity * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, _minVerticalAngle, _maxVerticalAngle);
        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0f);

    }
}
