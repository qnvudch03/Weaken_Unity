using UnityEngine;

[CreateAssetMenu(fileName = "TestScpirtStruct", menuName = "TestScpirt/TestScpirtStruct")]
public class TestScpirtStruct : ScriptableObject
{
    [Header("기본 정보")]
    public string playerName;
    public int level;
    public int hp;
    public int mp;

    [Header("능력치")]
    public float moveSpeed;
    public float attackPower;
    public float defense;
}
