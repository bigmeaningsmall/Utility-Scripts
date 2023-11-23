using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is in development and is not used in the game
/// </summary>

public class RayCastDebugger : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        Vector2 mousePosition;
        // Create a ray from the camera towards the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Perform the raycast
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null){
            // Set the mouse position to the hit point
            mousePosition = hit.point;

            // Calculate the direction from the camera to the hit point
            Vector2 direction = mousePosition - (Vector2)Camera.main.transform.position;

            // Draw a ray in the Scene view from the camera to the hit point
            Debug.DrawRay(Camera.main.transform.position, direction, Color.green);
        }
        else{
            // Draw a ray in the Scene view to represent the full length of the ray
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            return; // Early exit if the raycast didn't hit anything
        }
    }
}