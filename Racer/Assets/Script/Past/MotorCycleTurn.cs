using UnityEngine;

public class MotorCycleTurnpState : IMotorCycleStateAble
{
    public IMotorCycleStateAble OnInputtedEvent(EventEnum InputEvent)
    {
        if (InputEvent == EventEnum.Collide)
        {
            return new MotorCycleFlipState();
        }

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
        int a = 010;
    }
}
