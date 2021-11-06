using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    public Transform Target;

    public float MouseSpeed = 100;

    private static Vector3 MouseMovement =>
        new Vector3
        {
            x = Input.GetAxis("Mouse Y"),
            y = Input.GetAxis("Mouse X"),
            z = 0
        };

    private void LateUpdate()
    {
        RotateAround(Target.position, MouseMovement);
    }

    private void RotateAround(Vector3 target, Vector3 movement)
    {
        var currentTransform = transform;
        
        movement.x *= -1;
        movement.z = 0;
        movement.y = Mathf.Clamp(movement.y, -90, 90);
        var adjustedMovement = movement * Time.deltaTime * MouseSpeed;
        currentTransform.rotation = Quaternion.Euler(currentTransform.rotation.eulerAngles + adjustedMovement);
        currentTransform.position = target - currentTransform.forward * 5;
    }
}
