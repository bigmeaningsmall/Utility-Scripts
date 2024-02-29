using UnityEngine;

/*
 * The `LookAtMouse2D` class is a MonoBehaviour that makes a GameObject look at the mouse cursor in a 2D space.
 *
 * The class has a public property `zAxisValue` that can be adjusted in the Unity editor. This value represents the Z-axis value where the game action happens.
 *
 * In the `Update` method, it:
 * - Retrieves the direction from the GameObject to the mouse cursor using the `GetMouseDirection` method.
 * - Calculates the angle of this direction in degrees.
 * - Sets the rotation of the GameObject to this angle, offset by -90 degrees to align the GameObject's up direction with the mouse cursor.
 *
 * The `GetMouseDirection` method:
 * - Retrieves the mouse position in screen coordinates.
 * - Converts the screen coordinates to world coordinates using the `ScreenToWorldPoint` method of the main camera.
 * - Sets the z-coordinate of the world position to the `zAxisValue` to keep the GameObject on the specified Z-plane.
 * - Returns the direction from the GameObject to the mouse cursor.
 */

public class LookAtMouse2D : MonoBehaviour
{
    public float zAxisValue = 0; // Z-axis value where the game action happens

    void Update()
    {
        Vector2 direction = GetMouseDirection();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    Vector2 GetMouseDirection()
    {
        Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Adjust the Z-axis to the fixed value
        mouseWorldPosition.z = zAxisValue;

        return mouseWorldPosition - transform.position;
    }
}