using UnityEngine;

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