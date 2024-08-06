using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    public Image itemIcon;
    public ButtonHandler useButton;

    public ItemController ItemController { get; private set; }

    public void Initialize(ItemController itemController)
    {
        ItemController = itemController;
        itemIcon.sprite = itemController.ItemData.itemIcon;
        useButton.onClick.AddListener(ItemController.UseItem);
        useButton.OnLeftClick += ItemController.SelectItem;
    }
}
