using UnityEngine;

public class Command_ToggleTurbo : Command
{
    public Command_ToggleTurbo()
    {
        commandType = CommandType.Turbo;

    }

    public override void Execute()
    {
        base.Execute();
    }
}
