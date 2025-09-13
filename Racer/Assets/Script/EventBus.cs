using System.Collections;
//using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventBus
{
    private static readonly IDictionary<RaceEventEnum, UnityEvent>
    Events = new Dictionary<RaceEventEnum, UnityEvent>();

    public static void Subscribe(RaceEventEnum eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if(Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }

        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void Unsubscrive(RaceEventEnum type, UnityAction listener)
    {
        UnityEvent thisEvent;

        if(Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void Publish(RaceEventEnum type)
    {
        UnityEvent thisEvent;

        if(Events.TryGetValue(type, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
    private void OnEnable()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
