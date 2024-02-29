using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a script that debugs a message when the mouse is clicked on an object
public class MouseClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Mouse clicked on " + gameObject.name);
    }
}
