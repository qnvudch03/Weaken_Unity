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
        //MotorCycleAble �� �����ؼ�, �� ���� current Speed ���� 0���� �ʱ�ȭ
        int a = 010;
    }
}
