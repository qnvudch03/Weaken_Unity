using UnityEngine;

public interface SubScriber
{
    void Subscrive(EventType concernedEvent);

    void RecieveEvent(EventType broadCastedEvent, BikeController_9 pulisher);
}
