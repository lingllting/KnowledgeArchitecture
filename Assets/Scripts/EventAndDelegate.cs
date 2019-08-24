using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class DemoEventArgs : EventArgs
{
        
}
public class EventAndDelegate
{
    // define class, similar to typedef in C++
    public delegate void DemoDelegate<TEventArgs>(Object sender, TEventArgs e);
    
    // define variables
    // event
    public event DemoDelegate<DemoEventArgs> demoEvent;
    // delegate
    public DemoDelegate<DemoEventArgs> demoDelegate;
    private void Trigger()
    {
        demoDelegate(null, null);
        // event cannot only be invoked inside the class
        demoEvent(null, null);
    }
}

public class User1 : MonoBehaviour
{
    public EventAndDelegate eventAndDelegate = new EventAndDelegate();

    private void Start()
    {
        // difference1
        // delegate is allowed to use = operation
        eventAndDelegate.demoDelegate = delegateCallback;
        // event is not allowed to use = operation
        // eventAndDelegate.demoEvent = eventCallback; --compile error
        eventAndDelegate.demoEvent += eventCallback;

        // difference2
        // delegate can be invoked outside the class which defines it.
        eventAndDelegate.demoDelegate(null, null);
        // event cannot be invoked outside the class which defines it.
        // eventAndDelegate.demoEvent(null, null);    --compile error
    }

    public void delegateCallback(Object sender, DemoEventArgs e)
    {
        Debug.Log("delegateCallback");
    }

    public void eventCallback(Object sender, DemoEventArgs e)
    {
        Debug.Log("eventCallback");
    }
}
