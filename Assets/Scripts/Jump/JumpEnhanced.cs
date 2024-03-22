using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The JumpEnhanced class is a MonoBehaviour in Unity.
/// It has two public float variables 'fallMultiplier' and 'lowJumpMultiplier' which can be set in the Unity editor to control the speed of the fall and low jump respectively.
/// The 'Awake' method is a Unity callback method that is called when the script instance is being loaded.
/// Inside the 'Awake' method, it gets the Rigidbody2D component of the GameObject and assigns it to the 'rb' variable.
/// The 'Update' method is a Unity callback method that is called once per frame.
/// Inside the 'Update' method, it checks if the velocity of the Rigidbody2D component in the y-axis is less than 0 (falling) or greater than 0 (jumping).
/// If the GameObject is falling, it increases the fall speed by adding an additional gravity force multiplied by the 'fallMultiplier'.
/// If the GameObject is jumping but the space key is not being pressed, it increases the fall speed by adding an additional gravity force multiplied by the 'lowJumpMultiplier'.
/// This gives the jump a more responsive feel.
/// EXPLAINATION: https://www.youtube.com/watch?v=7KiK0Aqtmzc
/// </summary>

public class JumpEnhanced : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }  
}