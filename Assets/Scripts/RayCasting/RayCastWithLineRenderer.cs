using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
