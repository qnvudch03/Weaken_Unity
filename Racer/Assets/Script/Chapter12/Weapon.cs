using UnityEngine;

public class Weapon : IWeaponAble
{
    private readonly WeaponConfig config;

    public Weapon(WeaponConfig weaponConfig)
    {
        config = weaponConfig;
    }

    public float Range { get { return config.Range; } }
    public float Rate { get { return config.Rate; } }
    public float Strength { get { return config.Strength; } }
    public float CoolDown { get { return config.Range; } }


}
