using UnityEngine;

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

    void Update()
    {
        // Convert mouse position into world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

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
    }
}
