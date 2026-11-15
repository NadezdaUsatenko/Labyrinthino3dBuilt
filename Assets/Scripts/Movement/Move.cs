using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    [SerializeField] private Jostick _moveStick;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _maxSpeed = 1.7f;
    [SerializeField] private float _accelerationTime = 0.5f;// время разгона

    private CharacterController _controller;
    private Jump _jump;

    private float _currentSpeed = 0f;//текущая скорость
   

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _jump = GetComponent<Jump>();
    }

private void Update()
    {
        // Получаем направление от джойстика
        float h = _moveStick.Horizontal;
        float v = _moveStick.Vertical;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 inputDir = forward * v + right * h;

        float inputMag = Mathf.Clamp01(inputDir.magnitude);
        float targetSpeed = inputMag * _maxSpeed;

        // Плавное изменение скорости
        _currentSpeed = Mathf.MoveTowards(
            _currentSpeed,
            targetSpeed,
            (_maxSpeed * _accelerationTime) * Time.deltaTime
        );

        if (inputMag < 0.01f)
            _currentSpeed = 0f;

        

        // Общее движение
        Vector3 move = inputDir.normalized * _currentSpeed;

        move.y = _jump.VerticalVelocity;

        _controller.Move(move * Time.deltaTime);
        _jump.ApplyGravity();
    }
}


