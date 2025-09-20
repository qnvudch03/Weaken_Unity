using UnityEngine;

public interface IWeaponAble
{
    float Range {  get;}
    float Rate { get; }
    float Strength { get; }
    float CoolDown { get; }
}
