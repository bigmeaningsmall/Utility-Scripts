using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDebugger : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float maxDistance = 10.0f;
    public Color hitColor = Color.green;
    public Color noHitColor = Color.red;
    public Color hitPointColor = Color.blue; // Color for the hit point marker
    public float hitPointSize = 0.2f; // Size of the hit point marker

    void Update()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, maxDistance);

        // Determine the distance and color of the ray based on whether it hit something
        float distance = hasHit ? hit.distance : maxDistance;
        Color color = hasHit ? hitColor : noHitColor;

        // Draw the ray in the editor
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * distance, color);

        if (hasHit)
        {
            Debug.Log($"{hit.collider.name} was hit by the ray.");
            Debug.Log($"Hit point position: {hit.point}");
            Debug.Log($"Hit normal: {hit.normal}");
            
            // Draw a cross at the hit point
            Vector3 hitPoint = hit.point;
            Debug.DrawRay(hitPoint + Vector3.up * hitPointSize, Vector3.down * hitPointSize * 2, hitPointColor, 0, false);
            Debug.DrawRay(hitPoint + Vector3.left * hitPointSize, Vector3.right * hitPointSize * 2, hitPointColor, 0, false);
            Debug.DrawRay(hitPoint + Vector3.forward * hitPointSize, Vector3.back * hitPointSize * 2, hitPointColor, 0, false);
        }
    }
}

