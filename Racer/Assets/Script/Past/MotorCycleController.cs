using UnityEngine;

public class MotorCycleController : MonoBehaviour
{
    //public float maxSpeed = 2.0f;
    //public float turnDistance = 2.0f;

    //public float CurrentSpeed {  get; set; }

    public MotorCycleDirection CurrentTurnDirection { get; set; }

    string currentState;
    private IMotorCycleStateAble state;
    private EventEnum currentEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        EventBus.Subscribe(RaceEventEnum.Start, StartBike);
        EventBus.Subscribe(RaceEventEnum.Stop, StopBike);
    }
    void Start()
    {
        state = new MotorCycleStopState();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        state.Update(deltaTime);

        currentEvent = GetInputEvent();

        state = state.OnInputtedEvent(currentEvent);
    }

    private EventEnum GetInputEvent()
    {
        if (Input.GetKey(KeyCode.W))
            return EventEnum.Start;

        if (Input.GetKey(KeyCode.S))
            return EventEnum.Brake;

        return EventEnum.Max;
    }

    void StartBike()
    {
        state = new MotorCycleRunState();
        currentState = "Run";
    }

    void StopBike()
    {
        state = new MotorCycleStopState();
        currentState = "Stop";
    }

    private void OnGUI()
    {
        GUI.color = Color.green;
        GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS : " + currentState);
    }
}
