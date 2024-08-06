using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController
{
    private readonly InventoryModel _inventoryModel;
    private InventoryEvent _inventoryEvent;

    private StatusEvent _statusEvent;
    private GearEvent _gearEvent;
    public List<ItemController> ItemControllers { get; private set; }

    public ItemController selectedItem;

    [Inject]
    private void Initialize(StatusEvent statusEvent, GearEvent gearEvent)
    {
        if(statusEvent != null)
        {
            _statusEvent = statusEvent;
        }
        if(gearEvent != null)
        {
            _gearEvent = gearEvent;
        }
    }

    [Inject]
    public InventoryController(InventoryModel inventoryModel, InventoryEvent inventoryEvent)
    {
        _inventoryModel = inventoryModel;
        _inventoryEvent = inventoryEvent;
        ItemControllers = new List<ItemController>();
    }

    public void AddItem(ItemData itemData)
    {
        var itemModel = new ItemModel(itemData);
        Debug.Log("item id: " + itemModel.itemId);
        _inventoryModel.AddItem(itemModel);
        var itemController = new ItemController(this,itemModel);
        ItemControllers.Add(itemController);
        _inventoryEvent.ItemAdded(itemController);
    }

    public void RemoveItem(ItemController itemController)
    {
        ItemController foundItemController = ItemControllers.Find(e => e.ItemId == itemController.ItemId);
        _inventoryModel.RemoveItem(itemController.ItemId);
        _inventoryEvent.ItemRemoved(itemController);
        ItemControllers.Remove(itemController);
        _inventoryEvent.ItemUnselected();
    }

    public void SelectItem(ItemController itemController)
    {
        selectedItem = itemController;
        _inventoryEvent.ItemSelected(selectedItem);
    }

    public void RemoveSelectedItem()
    {
        if(selectedItem is null)return;
        RemoveItem(selectedItem);
        selectedItem = null;
    }

    public void ConsumableUsed(ConsumableData consumable)
    {
        Debug.Log("Consumiu!!");
        _statusEvent.ConsumableChangeStatus(consumable);
    }

    public void EquipedGear(GearData gearData)
    {
        Debug.Log("Equipou!!");
        _gearEvent.GearEquiped(gearData);
        _statusEvent.GearChangeStatus(gearData);
    }
}
