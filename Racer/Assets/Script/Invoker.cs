using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    StringBuilder sb;

    private bool isRecording = true;
    private bool isReplaying = false;
    private float replayTime = 0.0f;
    private float recrodingTime = 0.0f;
    private SortedList<float, Command> recordedCommands = new SortedList<float, Command>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteCommand(Command command)
    {
        command.Execute();
        //command.onTriggered.invoke()

        if (isRecording)
        {
            recordedCommands.Add(recrodingTime, command);
        }

        sb = new StringBuilder("Recorded Time : ");
        sb.Append(recrodingTime);

        Debug.Log(sb);

        sb = new StringBuilder("Recorded Command : ");
        sb.Append(command);

        Debug.Log(sb);
    }

    public void StartRecording()
    {
        isRecording = true;
        recrodingTime = 0.0f;
    }

    public void StartReplay()
    {
        replayTime = 0.0f;
        isReplaying = true;

        if(recordedCommands.Count <= 0)
        {
            Debug.Log("Nothing recorded");
        }


    }
    private void FixedUpdate()
    {
        if (isRecording)
        {
            recrodingTime += Time.deltaTime;
        }

        if(isReplaying)
        {
            replayTime += Time.deltaTime;

            if(recordedCommands.Any())
            {
                if(Mathf.Approximately(replayTime, recordedCommands.Keys[0]))
                {
                    sb = new StringBuilder("Replay Time : ");
                    sb.Append(replayTime);
                    Debug.Log(sb);

                    sb = new StringBuilder("Replay Command : ");
                    sb.Append(recordedCommands.Values[0]);
                    Debug.Log(sb);

                }
            }

            else
            {
                isReplaying = false;
            }
        }

    }
}
