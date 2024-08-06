using UnityEngine;
using Zenject;

public class PlayerInventory : MonoBehaviour
{
    private InventoryController _inventoryController;

    [SerializeField] int maxInventoryItens = 12;
    [SerializeField] int countItems = 0;

    public bool isInventoryFull = false;

    [Inject]
    public void Construct(InventoryController inventoryController, InventoryEvent inventoryEvent)
    {
        _inventoryController = inventoryController;
        inventoryEvent.OnItemRemoved += OnItemRemoved;
    }

    public void AddItemToInventory(ItemData itemData)
    {
        _inventoryController.AddItem(itemData);
        Debug.Log($"Item {itemData.itemName} adicionado ao inventário.");
        countItems = _inventoryController.ItemControllers.Count;
        if(countItems >= maxInventoryItens) isInventoryFull = true;
        else isInventoryFull = false;
    }

    private void OnItemRemoved(ItemController itemController)
    {
        countItems--;
        isInventoryFull = false;
    }
}