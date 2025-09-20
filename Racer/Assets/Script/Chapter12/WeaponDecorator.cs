using UnityEngine;

public class WeaponDecorator : IWeaponAble
{

    private readonly IWeaponAble decoratedWeapon;
    private readonly WeaponAttachment attachment;

    public WeaponDecorator(IWeaponAble Weapon, WeaponAttachment Attachment)
    {
        attachment = Attachment;
        decoratedWeapon = Weapon;
    }

    public float Range { get { return attachment.Range + decoratedWeapon.Range; } }
    public float Rate { get { return attachment.Rate + decoratedWeapon.Rate; } }
    public float Strength { get { return attachment.Strength + decoratedWeapon.Strength; } }
    public float CoolDown { get { return attachment.CoolDown + decoratedWeapon.CoolDown; } }
}
