using UnityEngine;

public class MotorCycleRunState : IMotorCycleStateAble
{
    public IMotorCycleStateAble OnInputtedEvent(EventEnum InputEvent)
    {
        switch(InputEvent)
        {
            case EventEnum.Collide:
                return new MotorCycleFlipState();

            case EventEnum.Turn:
                return new MotorCycleTurnpState();

            default:
                return this;
        }
    }

    public void Update(float deltaTime)
    {
        int a = 10;
    }

    public void ApplyState()
    {
        int a = 010;
    }
}
