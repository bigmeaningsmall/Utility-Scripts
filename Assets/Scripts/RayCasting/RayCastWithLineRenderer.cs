using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The `RayCastWithLineRenderer` class is a MonoBehaviour that is used to perform raycasts in Unity and visualize the results using a LineRenderer.
 * It casts a ray from the object's position in the specified direction and changes the color of the LineRenderer based on whether the raycast hits an object.
 *
 * The class has several public properties that can be adjusted in the Unity editor, such as:
 * - The direction of the raycast
 * - The maximum distance of the raycast
 * - The colors used when the raycast hits an object or does not hit an object
 * - A GameObject representing the end of the ray
 *
 * In the `Start` method, it caches a reference to the LineRenderer component and sets the start and end widths of the LineRenderer.
 * If an end sphere GameObject is provided, it also initializes the sphere's color.
 *
 * In the `Update` method, it calls the `PerformRaycastAndVisualize` method, which performs the raycast and visualizes the results using the LineRenderer.
 * It sets the positions and color of the LineRenderer based on whether the raycast hit an object.
 * If an end sphere is provided, it also updates the position and color of the sphere.
 *
 * If the raycast hits an object, it logs the name of the object and the position of the hit point.
 */

[RequireComponent(typeof(LineRenderer))]
public class RayCastWithLineRenderer : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float maxDistance = 10.0f;
    public Color hitColor = Color.green;
    public Color noHitColor = Color.red;
    public GameObject endSphere; // Reference to the sphere GameObject
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        
        if (endSphere != null)
        {
            // Initialize sphere color
            ChangeSphereColor(Color.cyan);
        }
    }

    void Update()
    {
        PerformRaycastAndVisualize();
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized; // Normalize to ensure it's a direction vector
    }

    private void PerformRaycastAndVisualize()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, maxDistance);
        Vector3 endPosition = hasHit ? hit.point : transform.position + transform.TransformDirection(direction) * maxDistance;

        // Set color
        lineRenderer.material.color = hasHit ? hitColor : noHitColor;

        // Update LineRenderer positions
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
        
        if (endSphere != null)
        {
            // Position the sphere at the end of the line
            endSphere.transform.position = endPosition;
            // Change the sphere's color based on hit status
            ChangeSphereColor(hasHit ? Color.magenta : Color.yellow);
        }

        if (hasHit)
        {
            Debug.Log($"{hit.collider.name} was hit by the ray.");
            Debug.Log($"Hit point position: {hit.point}");
        }
    }
    private void ChangeSphereColor(Color color)
    {
        var renderer = endSphere.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
