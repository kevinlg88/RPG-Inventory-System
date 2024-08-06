using System;

public class ItemModel
{
    public ItemData itemData;

    public Guid itemId;
    public ItemModel(ItemData data)
    {
        itemData = data;
        itemId = Guid.NewGuid();
    }
}