using System.Collections;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class BikeWeapon_12 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    StringBuilder sb;

    public WeaponConfig weaponConfig;                                   //데이터 에셋(기본 무기의 스텟표)
    public WeaponAttachment mainAttachment;                             //데이터 에셋(부착물의 증가수치)
    public WeaponAttachment secondaryAttachment;                        //데이터 에셋(부착물의 증가수치)

    private bool isFiring;
    private IWeaponAble weapon;
    private bool isDecorated;
    void Start()
    {
        weapon = new Weapon(weaponConfig);                              //메인 무기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.color = Color.green;

        //sb.Append("Range: ");
        //sb.Append(weapon.Range);

        sb.AppendFormat("Range: {0}", weapon.Range);
        GUI.Label(new Rect(5, 50, 150, 100), sb.ToSafeString());

        sb.AppendFormat("Strength: {0}", weapon.Strength);
        GUI.Label(new Rect(5, 70, 150, 100), sb.ToSafeString());

        sb.AppendFormat("Cooldown: {0}", weapon.CoolDown);
        GUI.Label(new Rect(5, 90, 150, 100), sb.ToSafeString());

        sb.AppendFormat("Firing Rate: {0}", weapon.Rate);
        GUI.Label(new Rect(5, 110, 150, 100), sb.ToSafeString());

        sb.AppendFormat("Weapon Firing: {0}", isFiring);
        GUI.Label(new Rect(5, 130, 150, 100), sb.ToSafeString());

        if(mainAttachment && isDecorated)
        {
            sb.AppendFormat("Main Attachment: {0}", mainAttachment.name);
            GUI.Label(new Rect(5, 150, 150, 100), sb.ToSafeString());
        }

        if (secondaryAttachment && isDecorated)
        {
            sb.AppendFormat("Secondary Attachment: {0}", secondaryAttachment.name);
            GUI.Label(new Rect(5, 170, 200, 100), sb.ToSafeString());
        }
    }

    public void ToggleFire()
    {
        isFiring = !isFiring;

        if(isFiring)
        {
            StartCoroutine(FireWeapon());
        }
    }

    IEnumerator FireWeapon()
    {
        float firingRate = 1.0f / weapon.Rate;

        while(isFiring)
        {
            yield return new WaitForSeconds(firingRate);
            Debug.Log("fire");
        }
    }

    public void Reset()
    {
        weapon = new Weapon(weaponConfig);
        isDecorated = !isDecorated;

    }

    public void Decorate()          //장식이 아니라, 아예 새로운 무기로 바뀌는데?? 이것이 방문자와의 차이인가?
    {
        if(mainAttachment && !secondaryAttachment)
        {
            weapon = new WeaponDecorator(weapon, mainAttachment);
        }

        if(mainAttachment && secondaryAttachment)
        {
            weapon = new WeaponDecorator(new WeaponDecorator(weapon, mainAttachment), secondaryAttachment);
        }

        isDecorated = !isDecorated;
    }
}
