using System;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryEvent : MonoBehaviour
{
    public event Action<ItemController> OnItemAdded;
    public event Action<ItemController> OnItemRemoved;
    public event Action<ItemController> OnItemSelected;
    public event Action OnItemUnselected;

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

    public void ItemSelected(ItemController itemController)
    {
        OnItemSelected?.Invoke(itemController);
    }
    public void ItemUnselected()
    {
        OnItemUnselected?.Invoke();
    }
}