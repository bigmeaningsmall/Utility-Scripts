using UnityEngine;

/*
 * The `RayCastCameraWithLineRenderer` class is a MonoBehaviour that is used to visualize raycasts from the main camera in Unity using a LineRenderer.
 * It casts a ray from the camera's position in the direction of the mouse cursor and logs information about any objects hit by the ray.
 *
 * The class has several public properties that can be adjusted in the Unity editor, such as:
 * - The maximum distance of the raycast
 * - The colors used to visualize the ray and the hit point
 * - Offsets for the ray's origin and end point
 * - A GameObject representing the end of the ray
 *
 * In the `Start` method, it caches a reference to the main camera and the LineRenderer component, and sets the start and end widths of the LineRenderer.
 * If an end sphere GameObject is provided, it also caches the material of the sphere's Renderer.
 *
 * In the `Update` method, it calls the `PerformRaycastAndVisualize` method, which performs the raycast and visualizes the results using the LineRenderer.
 * It sets the positions and color of the LineRenderer based on whether the raycast hit an object.
 * If an end sphere is provided, it also updates the position and color of the sphere.
 *
 * If the raycast hits an object, it logs the name of the object and the position of the hit point.
 */

[RequireComponent(typeof(LineRenderer))]
public class RayCastCameraWithLineRenderer : MonoBehaviour
{
    public float maxDistance = 100.0f;
    public Color hitColor = Color.blue;
    public Color noHitColor = Color.cyan;
    public Vector3 originOffset = new Vector3(0, 0, 0); // Offset for the ray origin
    public Vector3 endOffset = new Vector3(0, 0, 0); // New: Offset for the ray end
    public GameObject endSphere;
    
    private LineRenderer lineRenderer;
    private Material sphereMaterial;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        if (endSphere != null)
        {
            sphereMaterial = endSphere.GetComponent<Renderer>().material;
        }
    }

    void Update()
    {
        PerformRaycastAndVisualize();
    }

    private void PerformRaycastAndVisualize()
    {
        Vector3 rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition).origin + originOffset;
        Vector3 rayDirection = mainCamera.ScreenPointToRay(Input.mousePosition).direction;
        RaycastHit hit;
        bool hasHit = Physics.Raycast(rayOrigin, rayDirection, out hit, maxDistance);
        Vector3 baseEndPoint = hasHit ? hit.point : rayOrigin + rayDirection * maxDistance;
        Vector3 adjustedEndPoint = baseEndPoint + endOffset; // Apply end offset here

        // Update LineRenderer positions and colors
        lineRenderer.SetPosition(0, rayOrigin);
        lineRenderer.SetPosition(1, adjustedEndPoint); // Use adjusted end point
        lineRenderer.material.color = hasHit ? hitColor : noHitColor;

        // Update the sphere position and color
        if (endSphere != null)
        {
            endSphere.transform.position = adjustedEndPoint; // Position sphere using adjusted end point
            sphereMaterial.color = hasHit ? hitColor : noHitColor;
        }

        if (hasHit)
        {
            Debug.Log($"{hit.collider.name} was hit by the ray.");
            Debug.Log($"Hit point position: {hit.point}");
        }
    }
}
