using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
/// <summary>
/// The JumpBasic class is a MonoBehaviour in Unity.
/// It has a public float variable 'jumpVelocity' which can be set in the Unity editor to control the speed of the jump.
/// The 'Update' method is a Unity callback method that is called once per frame.
/// Inside the 'Update' method, it checks if the space key is pressed.
/// If the space key is pressed, it gets the Rigidbody2D component of the GameObject and sets its velocity to the upward direction multiplied by the 'jumpVelocity'.
/// This causes the GameObject to jump.
/// </summary>
*/

public class JumpBasic : MonoBehaviour
{
    [Range(0, 10)]
    public float jumpVelocity = 5.0f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    }
}
