using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float Jump = 10;

    private Camera _camera;
    private CharacterController _characterController;
    private float _yVelocity = 0;

    private void Start()
    {
        _camera = Camera.main;
        _characterController = GetComponent<CharacterController>();
    }

    private Vector3 CalculateMovementDirection()
    {
        var cameraTransform = _camera.transform;
        var forward = cameraTransform.forward.normalized;
        var right = cameraTransform.right.normalized;
        
        var movementDir = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));
        movementDir *= Speed;
        movementDir.y = _yVelocity;
        return movementDir;
    }

    private void Update()
    {
        switch (_characterController.isGrounded)
        {
            case false:
                _yVelocity += Physics.gravity.y * Time.deltaTime;
                break;
            case true when Input.GetKeyDown(KeyCode.Space):
                _yVelocity = Jump;
                break;
        }

        var movementDir = transform.TransformDirection(CalculateMovementDirection());
        if (movementDir != Vector3.zero)
        {
            _characterController.Move(movementDir * Time.deltaTime);
        }
    }
}
