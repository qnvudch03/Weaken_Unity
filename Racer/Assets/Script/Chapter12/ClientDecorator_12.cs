using Pattern.Visitor;
using UnityEngine;

public class ClientDecorator_12 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BikeWeapon_12 bikeWeapon;
    private bool isWeaponDecorated;
    void Start()
    {
        bikeWeapon = (BikeWeapon_12)FindFirstObjectByType(typeof(BikeWeapon_12));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (!isWeaponDecorated)
        {
            if(GUILayout.Button("Decorate Weapon"))
            {
                bikeWeapon.Decorate();
                isWeaponDecorated = !isWeaponDecorated;
            }
        }

        if (isWeaponDecorated)
        {
            if (GUILayout.Button("Reset Weapon"))
            {
                bikeWeapon.Reset();
                isWeaponDecorated = !isWeaponDecorated;
            }
        }

        if (GUILayout.Button("Toggle Fire"))
            bikeWeapon.ToggleFire();
    }
}
