using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryController
{
    private readonly InventoryModel _inventoryModel;
    private InventoryEvent _inventoryEvent;
    public List<ItemController> ItemControllers { get; private set; }

    public ItemController selectedItem;

    [Inject]
    public InventoryController(InventoryModel inventoryModel, InventoryEvent inventoryEvent)
    {
        Debug.Log("Criou um inventory model");
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
    }

    public void SelectItem(ItemController itemController)
    {
        selectedItem = itemController;
    }

    public void RemoveSelectedItem()
    {
        if(selectedItem is null)return;
        RemoveItem(selectedItem);
        selectedItem = null;
    }
}
