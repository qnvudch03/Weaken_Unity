using UnityEngine;

public class MotorCycleStopState : IMotorCycleStateAble
{
    public IMotorCycleStateAble OnInputtedEvent(EventEnum InputEvent)
    {
        if(InputEvent != EventEnum.Start &&
            InputEvent != EventEnum.Run)
            { return this; }

        return new MotorCycleRunState();
    }

    public void Update(float deltaTime)
    {
        int a = 10;
    }

    public void ApplyState()
    {
        //TODO
        //MotorCycleAble 을 구현해서, 그 놈의 current Speed 값을 0으로 초기화
        int a = 010;
    }
}
