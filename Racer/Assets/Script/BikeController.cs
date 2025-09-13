using UnityEngine;

public enum Direction
{
    left = -1,
    right = 1
}

public class BikeController : MonoBehaviour
{
    private string _status;

    

    private bool isTurbonOn = false;
    private float distance = 1.0f;

    void OnEnable()
    {
        RaceEventBus.Subscribe(
            RaceEventType.START, StartBike);

        RaceEventBus.Subscribe(
            RaceEventType.STOP, StopBike);
    }

    void OnDisable()
    {
        RaceEventBus.Unsubscribe(
            RaceEventType.START, StartBike);

        RaceEventBus.Unsubscribe(
            RaceEventType.STOP, StopBike);
    }

    private void StartBike()
    {
        _status = "Started";
    }

    private void StopBike()
    {
        _status = "Stopped";
    }

    public void ToggleTurbo(CommandType command)
    {
        if ((command != CommandType.Turbo))
            return;

        isTurbonOn = true;
    }

    public void Turn(CommandType commandDirection)
    {
        if (commandDirection == CommandType.Command_Max)
            return;

        if (commandDirection == CommandType.Left) transform.Translate(Vector3.left * distance);
        if (commandDirection == CommandType.Right) transform.Translate(Vector3.right * distance);
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(
            new Rect(10, 60, 200, 20),
            "BIKE STATUS: " + _status);
    }
}