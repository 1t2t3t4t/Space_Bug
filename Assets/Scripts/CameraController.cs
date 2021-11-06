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
        var adjustedMovement = currentTransform.rotation.eulerAngles + (movement * Time.deltaTime * MouseSpeed);
        if (adjustedMovement.x >= 70 && adjustedMovement.x < 90)
            adjustedMovement.x = 70;
        else if (adjustedMovement.x >= 90 && adjustedMovement.x <= 290)
            adjustedMovement.x = 290;
        currentTransform.rotation = Quaternion.Euler(adjustedMovement);
        currentTransform.position = target - currentTransform.forward * 5;
    }
}
