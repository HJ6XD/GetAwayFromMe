using UnityEngine;

public class PlayerWeaponChange : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] GameObject ar;
    [SerializeField] GameObject sg;
    [SerializeField] GameObject uz;

    WeaponType activeWeapon;

    private void Start()
    {
        activeWeapon = WeaponType.Uzi;
        ChangeWeapons(activeWeapon);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            activeWeapon = WeaponType.AsaultRifle;
            ChangeWeapons(activeWeapon);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            activeWeapon = WeaponType.Shotgun;
            ChangeWeapons(activeWeapon);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            activeWeapon = WeaponType.Uzi;
            ChangeWeapons(activeWeapon);
        }
    }

    private void ChangeWeapons(WeaponType active)
    {
        ar.SetActive(false);
        sg.SetActive(false);
        uz.SetActive(false);
        switch (active)
        {
            case WeaponType.AsaultRifle:
                ar.SetActive(true);
                WeaponsUIManager.wuiInstance.ChangeToAR();
                break;
            case WeaponType.Shotgun:
                sg.SetActive(true);
                WeaponsUIManager.wuiInstance.ChangeToSG();
                break;
            case WeaponType.Uzi:
                uz.SetActive(true);
                WeaponsUIManager.wuiInstance.ChangeToUZ();
                break;
        }
    }

    public GameObject ProvideCurWeapon()
    {
        if (ar.activeInHierarchy)
            return ar;
        else if (sg.activeInHierarchy)
            return sg;
        else if (uz.activeInHierarchy)
            return uz;
        else
            return null;        
    }
}
