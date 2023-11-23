using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 direction = new Vector3(0.001f, 0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //apply a constant movement in the x direction (for testing
        transform.position += direction;
    }
}
