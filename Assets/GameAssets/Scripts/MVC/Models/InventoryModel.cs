using System;
using System.Collections.Generic;

public class InventoryModel
{
    private List<ItemModel> items;

    public InventoryModel()
    {
        items = new List<ItemModel>();
    }

    public void AddItem(ItemModel item)
    {
        items.Add(item);
    }

    public void RemoveItem(Guid id)
    {
        ItemModel itemModel = items.Find(e => e.itemId == id);
        items.Remove(itemModel);
    }
}
