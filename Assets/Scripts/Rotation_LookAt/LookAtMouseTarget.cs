using UnityEngine;

/*
 * The `LookAtMouseObject` class is a MonoBehaviour that makes a GameObject look at another GameObject (the target) in a 2D space.
 *
 * The class has a public property `target` that can be adjusted in the Unity editor. This is the GameObject that the current GameObject will look at.
 *
 * In the `Update` method, it:
 * - Checks if a target has been assigned.
 * - If a target is assigned, it calculates the direction from the GameObject to the target.
 * - Calculates the angle of this direction in degrees.
 * - Sets the rotation of the GameObject to this angle, offset by -90 degrees to align the GameObject's up direction with the target.
 */

public class LookAtMouseObject : MonoBehaviour
{
    public Transform target; // Assign the mouse-following object here in the inspector

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}