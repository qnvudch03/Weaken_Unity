using UnityEngine;

public class MotorCycleFlipState : IMotorCycleStateAble
{
    public IMotorCycleStateAble OnInputtedEvent(EventEnum InputEvent)
    {
        return this;
    }

    public void Update(float deltaTime)
    {
        int a = 10;
    }

    public void ApplyState()
    {
        //TODO
        //MotorCycleAble �� �����ؼ�, �� ���� current Speed ���� 0���� �ʱ�ȭ
        int a = 10;
    }
}
