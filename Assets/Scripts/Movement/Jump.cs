using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Jump : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField] private float _jumpHeight = 2f;//высота прыжка
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _verticalSpeed = 0f;//вертикальная скорость
    private bool _jumpRequested = false;

    public float VerticalVelocity => _verticalSpeed;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
      {
        if(_jumpRequested && _controller.isGrounded )
        {
            _verticalSpeed = Mathf.Sqrt(2f * _gravity * _jumpHeight);
        }
        _jumpRequested = false;
    
    }
    public void ApplyGravity()
    { 
        _verticalSpeed -= _gravity * Time.deltaTime;
    }

    public void OnJumpButtonClick()
    {
       _jumpRequested = true;
    }
}
