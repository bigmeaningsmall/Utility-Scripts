using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The EventSender class is a MonoBehaviour that provides functionality for sending events.
/// It contains two types of events: a generic static event and a generic static event with parameters.
/// These events can be subscribed to by any class and are triggered when the space key is pressed.
/// </summary>

public class EventSender : MonoBehaviour
{
    
    //a generic static event delegate sender that can be used to send events to any class
    public delegate void EventDelegate();
    public static event EventDelegate OnEvent;
    
    //a generic static event delegate sender with parameters that can be used to send events to any class
    public delegate void EventDelegateWithParameters(string name, int num);
    public static event EventDelegateWithParameters OnEventWithParameters;

    public string nameToSend = "Name To Send";
    public int numToSend = 1;
    
    void Update()
    {
        //if the space key is pressed, send the event
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if there are any subscribers to the event, send the event
            if (OnEvent != null)
            {
                OnEvent();
                Debug.Log("Event sent");
            }
            //if there are any subscribers to the event, send the event with parameters
            if (OnEventWithParameters != null)
            {
                OnEventWithParameters(nameToSend, numToSend);
                Debug.Log("Event with parameters sent" + nameToSend + " " + numToSend);
            }
        }
    }
}
