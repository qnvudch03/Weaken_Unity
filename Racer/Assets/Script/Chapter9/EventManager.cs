using System;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    TurboOn,
    TakeDamage
}

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }


    private Dictionary<EventType, (Action, BikeController_9)> eventMap = new Dictionary<EventType, (Action, BikeController_9)>();
    private Dictionary<EventType, List<SubScriber>> subscriberMap = new Dictionary<EventType, List<SubScriber>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegistEvent(EventType eventtype, Action action, BikeController_9 pulisher)
    {
        if (!eventMap.ContainsKey(eventtype))
        {
            eventMap[eventtype] = (action, pulisher);
        }
    }

    public void SubScribeEvent(EventType eventtype, SubScriber subscriber)
    {
        if(!subscriberMap.ContainsKey(eventtype))
        {
            subscriberMap[eventtype] = new List<SubScriber>();
        }

        subscriberMap[eventtype].Add(subscriber);
    }

    public void OnEventTriggered(EventType eventtype)
    {
        if(!subscriberMap.ContainsKey(eventtype))
            return;

        if (subscriberMap[eventtype].Count == 0)
            return;

        foreach(SubScriber subScriber in subscriberMap[eventtype])
        {
            BikeController_9 publisher = eventMap[eventtype].Item2;
            subScriber.RecieveEvent(eventtype, publisher);
        }
    }
}
