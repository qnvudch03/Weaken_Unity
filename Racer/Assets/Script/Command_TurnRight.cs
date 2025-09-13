using System.Data;
using UnityEngine;

public class Command_TurnRight : Command
{
    public Command_TurnRight()
    {
        commandType = CommandType.Right;

    }
    public override void Execute()
    {
        base.Execute();
    }
}
