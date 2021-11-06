using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 10;

    private Camera _camera;
    private CharacterController _characterController;

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
        forward.y = 0;
        right.y = 0;
        var movementDir = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));
        movementDir *= Speed;
        movementDir += Physics.gravity;
        return movementDir;
    }

    private void Update()
    {
        var movementDir = transform.TransformDirection(CalculateMovementDirection());
        if (movementDir != Vector3.zero)
        {
            _characterController.Move(movementDir * Time.deltaTime);
        }
    }
}
