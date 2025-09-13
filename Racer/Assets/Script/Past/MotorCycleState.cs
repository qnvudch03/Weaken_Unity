using UnityEngine;

public interface IMotorCycleStateAble
{
    IMotorCycleStateAble OnInputtedEvent(EventEnum InputEvent);
    void Update(float deltaTime);
    void ApplyState();
}
