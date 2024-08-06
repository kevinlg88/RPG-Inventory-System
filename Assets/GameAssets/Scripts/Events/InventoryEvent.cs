using System;
using UnityEngine;

public class InventoryEvent : MonoBehaviour
{
    public event Action<ItemController> OnItemAdded;
    public event Action<ItemController> OnItemRemoved;

    public void ItemAdded(ItemController itemController)
    {
        OnItemAdded?.Invoke(itemController);
        Debug.Log($"Item {itemController.ItemData.itemName} foi adicionado ao inventário.");
    }

    public void ItemRemoved(ItemController itemController)
    {
        OnItemRemoved?.Invoke(itemController);
        Debug.Log($"Item {itemController.ItemData.itemName} foi removido do inventário.");
    }
}