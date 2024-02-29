using UnityEngine;

/*
 * The `FollowMouse` class is a MonoBehaviour that makes a GameObject follow the mouse cursor in a 2D space.
 *
 * In the `Update` method, it:
 * - Retrieves the mouse position in screen coordinates.
 * - Converts the screen coordinates to world coordinates using the `ScreenToWorldPoint` method of the main camera.
 * - Sets the z-coordinate of the world position to 0 to keep the GameObject on the 0 Z-plane.
 * - Assigns the world position to the GameObject's position, making the GameObject follow the mouse cursor.
 */

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0; // Keep the object on the 0 Z-plane

        transform.position = mouseWorldPosition;
    }
}