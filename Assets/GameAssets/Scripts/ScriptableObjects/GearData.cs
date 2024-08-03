using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gear", menuName = "Inventory/Gear")]
public class GearData : ItemData
{
    public int attack;

    public override void Use()
    {
        Debug.Log($"Equipping {itemName} with {attack} attack.");
    }
}
