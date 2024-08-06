using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGearModel
{
    private GearData helmet;
    private GearData topArmor;
    private GearData weapon;
    private GearData boots;

    public void EquipHelmet(GearData item)
    {
        helmet = item;
    }

    public void EquipTopArmor(GearData item)
    {
        topArmor = item;
    }

    public void EquipWeapon (GearData item)
    {
        weapon = item;
    }

    public void EquipBoots(GearData item)
    {
        boots = item;
    }

    public GearData GetHelmet()
    {
        return helmet;
    }

    public GearData GetTopArmor()
    {
        return topArmor;
    }

    public GearData GetWeapon()
    {
        return weapon;
    }

    public GearData GetBoots()
    {
        return boots;
    }

}
