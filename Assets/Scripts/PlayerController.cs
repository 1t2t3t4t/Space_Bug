using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float Jump = 10;
    public float TurnSpeed = 3;

    public Animator PlayerAnimator;
    public Transform ModelTransform;

    private Camera _camera;
    private CharacterController _characterController;
    private float _yVelocity = 0;
    
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

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

        var movement = CalculateMovementDirection();
        var movementDir = transform.TransformDirection(movement);
        if (movementDir != Vector3.zero)
        {
            _characterController.Move(movementDir * Time.deltaTime);
        }
        TurnPlayer();
        UpdateAnimationState(movement);
    }

    private void TurnPlayer()
    {
        var forwardDir = _camera.transform.forward;
        var targetRotation = Quaternion.FromToRotation(Vector3.forward, forwardDir);
        targetRotation.x = 0;
        ModelTransform.rotation = Quaternion.Slerp(ModelTransform.rotation, targetRotation, Time.deltaTime * TurnSpeed);
    }

    private void UpdateAnimationState(Vector3 movement)
    {
        var isMoving = movement.x != 0 || movement.z != 0;
        PlayerAnimator.SetBool(IsMoving, isMoving);
    }
}
