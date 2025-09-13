using System;
using UnityEngine;

public enum CommandType
{
    Left,
    Right,
    Turbo,
    Command_Max
}
public abstract class Command
{
    public Action<CommandType> onTriggered;
    public CommandType commandType = CommandType.Command_Max;
    public virtual void Execute()
    {
        onTriggered?.Invoke(commandType);
    }
}
