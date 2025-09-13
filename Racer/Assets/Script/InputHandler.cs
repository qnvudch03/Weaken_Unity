using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker invoker;
    private bool isRecording = false;
    private bool isReplaying = false;
    private BikeController bikeController;
    private Command commandLeft, commandRight, commandTurbo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invoker = gameObject.AddComponent<Invoker>();
        //bikeController = FindObjectsByType<BikeController, FindObjectsSortMode.None> ();
        bikeController = FindFirstObjectByType<BikeController>();

        commandLeft = new Command_TurnLeft();
        commandLeft.onTriggered = bikeController.Turn;

        commandRight = new Command_TurnRight();
        commandRight.onTriggered = bikeController.Turn;

        commandTurbo = new Command_ToggleTurbo();
        commandTurbo.onTriggered = bikeController.ToggleTurbo;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRecording && !isReplaying)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //c_Left.Execute();
                invoker.ExecuteCommand(commandLeft);
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                invoker.ExecuteCommand(commandRight);
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                invoker.ExecuteCommand(commandTurbo);
            }
        }
    }
}
