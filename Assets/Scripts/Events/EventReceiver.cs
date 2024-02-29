using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The EventReceiver class is a MonoBehaviour that subscribes to events sent by the EventSender class.
/// It contains two methods to handle the received events: one for a generic event and one for an event with parameters.
/// These methods are subscribed to the corresponding events in the EventSender class when this MonoBehaviour is enabled and unsubscribed when it is disabled.
/// When an event is received, it logs a message and can be modified to perform additional actions.
/// </summary>

public class EventReceiver : MonoBehaviour
{
    //to receive events you must subscribe to the event using the += operator and the event delegate
    
    //subscribe to the event (this is important to receive the event)
    void OnEnable()
    {
        EventSender.OnEvent += EventSenderOnEvent;
        EventSender.OnEventWithParameters += EventSenderOnOnEventWithParameters;
    }
    //unsubscribe from the event (this is very very important to prevent memory leaks and errors when scenes are reloaded)
    void OnDisable()
    {
        EventSender.OnEvent -= EventSenderOnEvent;
        EventSender.OnEventWithParameters -= EventSenderOnOnEventWithParameters;
    }

    private void EventSenderOnEvent()
    {
        Debug.Log("Event received by GameObject: " + gameObject.name);
        //do something (call a function) eg. play a sound, change the color of the object, etc.
    }
    
    private void EventSenderOnOnEventWithParameters(string s, int num)
    {
        Debug.Log("Event with parameters received by GameObject: " + gameObject.name + " Parameters: " + s + " " + num);
        //do something (call a function) eg. play a sound, change the color of the object, etc.
    }

    
}
