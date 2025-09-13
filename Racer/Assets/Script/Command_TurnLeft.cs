using UnityEngine;

public class Command_TurnLeft : Command
{
    public Command_TurnLeft()
    {
        commandType = CommandType.Left;

    }
    public override void Execute()
    {
        base.Execute();
    }
}
