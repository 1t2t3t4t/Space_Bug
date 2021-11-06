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

    private void Update()
    {
        var forward = _camera.transform.forward;
        var right = _camera.transform.right;
        forward.y = 0;
        right.y = 0;
        var movementDir = (forward * Input.GetAxis("Vertical")) + (right * Input.GetAxis("Horizontal"));
        movementDir.Normalize();
        if (movementDir != Vector3.zero)
        {
            _characterController.Move(movementDir * Time.deltaTime * Speed);
        }
    }
}
