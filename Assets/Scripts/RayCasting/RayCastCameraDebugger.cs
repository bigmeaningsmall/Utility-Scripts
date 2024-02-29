using UnityEngine;

/*
 * The `RayCastCameraDebugger` class is a MonoBehaviour that is used to visualize raycasts from the main camera in Unity.
 * It casts a ray from the camera's position in the direction of the mouse cursor and logs information about any objects hit by the ray.
 *
 * The class has several public properties that can be adjusted in the Unity editor, such as:
 * - The maximum distance of the raycast
 * - The colors used to visualize the ray and the hit point
 * - Offsets for the ray's origin and end point
 *
 * In the `Start` method, it caches a reference to the main camera.
 * In the `Update` method, it calls the `PerformRaycastAndVisualize` method, which performs the raycast and visualizes the results using `Debug.DrawRay`.
 *
 * If the raycast hits an object, it logs the name of the object, the position of the hit point, and the normal of the hit surface.
 * It also draws a cross at the hit point.
 * If the raycast does not hit an object, it does not perform any additional actions.
 */

public class RayCastCameraDebugger : MonoBehaviour
{
    public float maxDistance = 100.0f;
    public Color hitColor = Color.green;
    public Color noHitColor = Color.red;
    public Color hitPointColor = Color.blue; // Color for the hit point marker
    public Vector3 originOffset = new Vector3(0, 0, 0); // Offset for the ray origin
    public Vector3 endOffset = new Vector3(0, 0, 0); // Offset for the ray end
    public float hitPointSize = 0.2f; // Size of the hit point marker
    
    private Camera mainCamera;
    private Material sphereMaterial;

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
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

        // Draw the ray in the editor
        Debug.DrawRay(rayOrigin, rayDirection * (hasHit ? hit.distance : maxDistance), hasHit ? hitColor : noHitColor);
        
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
        else
        {
            // Optionally hide or draw something for not hit
        }
    }
}
