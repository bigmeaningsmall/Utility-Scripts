using UnityEngine;

/*
 * The `RotateTowardsMouse2D` class is a MonoBehaviour that makes a GameObject rotate towards the mouse cursor in a 2D space.
 *
 * The class has several public properties that can be adjusted in the Unity editor:
 * - `rotationAxis`: The axis around which the GameObject rotates.
 * - `useClamp`: Whether to clamp the rotation angle.
 * - `minAngle` and `maxAngle`: The minimum and maximum angles when clamping is enabled.
 * - `useScale`: Whether to scale the rotation angle.
 * - `scale`: The scale factor for the rotation angle.
 * - `useNormalization`: Whether to normalize the rotation angle to the range 0-360.
 * - `useSmoothRotation`: Whether to smoothly interpolate the rotation.
 * - `smoothSpeed`: The speed of the smooth rotation.
 *
 * In the `Start` method, it stores the initial position of the main camera.
 *
 * In the `Update` method, it:
 * - Calculates the camera's movement offset.
 * - Retrieves the mouse position in world coordinates.
 * - Calculates the direction from the GameObject to the mouse cursor.
 * - Calculates the angle of this direction in degrees.
 * - Optionally scales, normalizes, and clamps the angle.
 * - Adjusts the angle based on the GameObject's default orientation.
 * - Optionally smoothly interpolates the GameObject's rotation towards the calculated angle.
 * - Applies the final rotation to the GameObject.
 */

public class RotateTowardsMouse2D : MonoBehaviour
{
    // Enum to select the rotation axis
    public enum RotationAxis { X, Y, Z}

    // Public variables to choose features
    public RotationAxis rotationAxis = RotationAxis.Z;
    public bool useClamp = false;
    public float minAngle = -90f, maxAngle = 90f;
    public bool useScale = true;
    public float scale = 8f;
    public bool useNormalization = false;
    public bool useSmoothRotation = true;
    public float smoothSpeed = 20f;

    private Vector3 cameraInitialPosition;
    
    void Start()
    {
        // Store the initial position of the camera
        cameraInitialPosition = Camera.main.transform.position;
    }
    
    void Update()
    {
        
        // Calculate the camera's movement offset
        Vector3 cameraMovementOffset = Camera.main.transform.position - cameraInitialPosition;
        
        Vector2 mousePosition;
        
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //Debug.Log(mousePosition);

        // Get direction from the sprite to the mouse
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        // Calculate the angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //convert an angle from radians to degrees manually - not needed as we use atan2 and apply a scale
        //angle=(180/Mathf.PI)*angle;

        // Apply scaling
        if (useScale)
        {
            angle *= scale;
        }

        // Normalize the angle to 0-360 range
        if (useNormalization)
        {
            angle = (angle + 360) % 360;
        }

        // Clamp the angle if required
        if (useClamp)
        {
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
        }

        // Determine final angle based on selected rotation axis
        float finalAngle = angle - 90; // Adjust based on sprite's default orientation

        // Smooth Rotation
        if (useSmoothRotation)
        {
            float currentAngle = 0f;
            switch (rotationAxis)
            {
                case RotationAxis.X: currentAngle = transform.eulerAngles.x; break;
                case RotationAxis.Y: currentAngle = transform.eulerAngles.y; break;
                case RotationAxis.Z: currentAngle = transform.eulerAngles.z; break;
            }
            finalAngle = Mathf.LerpAngle(currentAngle, finalAngle, smoothSpeed * Time.deltaTime);
        }

        // Apply the rotation based on the selected axis
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.rotation = Quaternion.Euler(finalAngle, 0f, 0f);
                break;
            case RotationAxis.Y:
                transform.rotation = Quaternion.Euler(0f, finalAngle, 0f);
                break;
            case RotationAxis.Z:
                transform.rotation = Quaternion.Euler(0f, 0f, finalAngle);
                break;
        }
        
        //apply a constant movement in the x direction (for testing
        // transform.position += new Vector3(0.001f, 0, 0);
    }

}
