using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemController
{
    private readonly ItemModel _itemModel;

    private readonly InventoryController _inventoryController;

    public ItemData ItemData => _itemModel.itemData;
    public Guid ItemId=> _itemModel.itemId;
    public ItemController(InventoryController inventoryController ,ItemModel itemModel)
    {
        _inventoryController = inventoryController;
        _itemModel = itemModel;
    }

    public void SelectItem()
    {
        _inventoryController.SelectItem(this);
    }

    public void UseItem()
    {
        if(_itemModel.itemData is ConsumableData)
        {
            Debug.Log("it's a potion");
            ConsumableData consumableData = _itemModel.itemData as ConsumableData;
            _inventoryController.ConsumableUsed(consumableData);
            _inventoryController.RemoveItem(this);
        }
        else if(_itemModel.itemData is GearData)
        {
            Debug.Log("it's a gear");
            GearData gearData = _itemModel.itemData as GearData;
            _inventoryController.EquipedGear(gearData);
        }
    }

}
