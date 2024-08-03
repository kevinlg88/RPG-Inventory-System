using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class ConsumableData : ItemData
{
    public int healthRestore;

    public override void Use()
    {
        Debug.Log($"Consuming {itemName} to restore {healthRestore} health.");
    }
}

