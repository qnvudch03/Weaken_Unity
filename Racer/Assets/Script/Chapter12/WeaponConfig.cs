using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
public class WeaponConfig : ScriptableObject, IWeaponAble
{
    [Range(0, 60)]
    [Tooltip("Rate of firing per second")]
    [SerializeField]
    public float rate;

    [Range(0, 50)]
    [Tooltip("Weapon range")]
    [SerializeField]
    public float range;

    [Range(0, 100)]
    [Tooltip("Weapon strength")]
    [SerializeField]
    public float strength;

    [Range(0, 5)]
    [Tooltip("Cooldown duration")]
    [SerializeField]
    public float cooldown;

    public string weaponName;
    public GameObject weaponPrefab;
    public string weaponDescription;

    public float Range
    {
        get { return range; }
    }
    public float Rate { get { return rate; } }
    public float Strength { get { return strength; } }
    public float CoolDown { get { return cooldown; } }
}
