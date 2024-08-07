using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerGearView: MonoBehaviour
{
    private GearEvent _gearEvent;
    private PlayerGearController _playerGearController;
    [SerializeField] private Image helmetImage;
    [SerializeField] private Image topArmorImage;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Image bootsImage;

    [Inject]
    public void Construct(PlayerGearController playerGearController ,GearEvent gearEvent)
    {
        _gearEvent = gearEvent;
        _playerGearController = playerGearController;
    }

    public void EquipHelmet(GearData gearData)
    {
        Debug.Log("gear view helmet: " + gearData.name);
        helmetImage.sprite = gearData.itemIcon;
    }

    public void EquipTopArmor(GearData gearData)
    {
        Debug.Log("gear view top armor: " + gearData.name);
        topArmorImage.sprite = gearData.itemIcon;
    }

    public void EquipWeapon(GearData gearData)
    {
        Debug.Log("gear view weapon: " + gearData.name);
        weaponImage.sprite = gearData.itemIcon;
    }

    public void EquipBoots(GearData gearData)
    {
        Debug.Log("gear view boots: " + gearData.name);
        bootsImage.sprite = gearData.itemIcon;
    }

}
