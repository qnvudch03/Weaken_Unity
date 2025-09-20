using UnityEngine;

[CreateAssetMenu(fileName = "TestScpirtStruct", menuName = "TestScpirt/TestScpirtStruct")]
public class TestScpirtStruct : ScriptableObject
{
    [Header("�⺻ ����")]
    public string playerName;
    public int level;
    public int hp;
    public int mp;

    [Header("�ɷ�ġ")]
    public float moveSpeed;
    public float attackPower;
    public float defense;
}
