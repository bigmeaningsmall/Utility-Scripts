using UnityEngine;
using UnityEngine.Serialization;

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