using UnityEngine;
using UnityEngine.Serialization;

/*
 * The `FireProjectile` class is a MonoBehaviour that provides functionality for firing projectiles from a specified point in Unity.
 *
 * The class has several public properties that can be adjusted in the Unity editor:
 * - `firePoint`: The Transform from which projectiles are fired.
 * - `projectilePrefab`: The GameObject that is instantiated as a projectile.
 * - `projectileSpeed`: The speed at which the projectile moves.
 * - `zRotationOffset`: An offset angle in degrees that is added to the fire point's rotation when calculating the direction of the projectile.
 *
 * In the `Update` method, it checks if the "Fire1" input button is pressed. If it is, it calls the `Fire` method.
 *
 * The `Fire` method instantiates a projectile at the fire point's position with a rotation that is offset from the fire point's rotation.
 * It then retrieves the Rigidbody2D component of the projectile and applies a velocity to it in the direction of the fire point's right vector, adjusted by the offset rotation.
 * This makes the projectile move in the direction that the fire point is facing, with an additional rotation offset.
 */

public class FireProjectile : MonoBehaviour
{
    public Transform firePoint; // The point from which projectiles are fired
    public GameObject projectilePrefab; // Your projectile prefab
    public float projectileSpeed = 10f; // Speed of the projectile
    [FormerlySerializedAs("rotationOffset")] public float zRotationOffset = 0f; // Offset angle in degrees

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // You can change the input condition as needed
        {
            Fire();
        }
    }

    void Fire()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Calculate the rotated fire direction with offset
            Quaternion fireRotation = Quaternion.Euler(0, 0, firePoint.eulerAngles.z + zRotationOffset);

            // Instantiate the projectile at the firePoint with offset rotation
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, fireRotation);

            // Get the Rigidbody2D component of the projectile and apply a force
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply velocity in the direction of the firePoint's right, adjusted by the offset
                rb.velocity = fireRotation * Vector2.right * projectileSpeed;
            }
        }
    }
}