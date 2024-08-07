using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InventoryView : MonoBehaviour
{
    [Header("Slots")]
    public List<Transform> itemSlotParents;
    //public Transform itemSlotParent;
    public GameObject itemSlotPrefab;

    [Space(5)]
    [Header("Buttons")]
    [SerializeField] Button removeItemBttn;

    [Space(5)]
    [Header("Description")]
    [SerializeField] GameObject descriptionPanel;
    [SerializeField] Image iconDescription;
    [SerializeField] TextMeshProUGUI descriptionText;

    private InventoryController _inventoryController;
    private List<ItemView> _itemViews;

    private readonly int emptySlot = 0;

    [Inject]
    public void Construct(InventoryController inventoryController, InventoryEvent inventoryEvent)
    {
        _inventoryController = inventoryController;
        _itemViews = new List<ItemView>();

        inventoryEvent.OnItemAdded += AddItemView;
        inventoryEvent.OnItemRemoved += RemoveItemView;
        inventoryEvent.OnItemSelected += SetDescription;
        inventoryEvent.OnItemUnselected += UnselectDescription;

        removeItemBttn.onClick.AddListener(inventoryController.RemoveSelectedItem);

        foreach (var itemController in _inventoryController.ItemControllers)
        {
            AddItemView(itemController);
        }
    }

    private void SetDescription(ItemController itemController)
    {
        descriptionPanel.SetActive(true);
        iconDescription.sprite = itemController.ItemData.itemIcon;
        descriptionText.text = itemController.ItemData.description;
    }
    private void UnselectDescription()
    {
        descriptionText.text = null;
        iconDescription.sprite = null;
        descriptionPanel.SetActive(false);
    }
    private void AddItemView(ItemController itemController)
    {
        AddNewItem(itemController);
        // if(IsNewItem(itemData))
        //     AddNewItem(itemData);
        // else
        //     AddNewItemUnit(itemData);
    }

    private void RemoveItemView(ItemController itemController)
    {
        var itemView = _itemViews.Find(view => view.ItemController.ItemId == itemController.ItemId);
        if (itemView != null)
        {
            _itemViews.Remove(itemView);
            Destroy(itemView.gameObject);
        }
    }

    private bool IsNewItem(ItemData itemData)
    {
        foreach (var item in _inventoryController.ItemControllers)
        {
            if(item.ItemData == itemData)return false;
        }
        return true;
    }
    private void AddNewItem(ItemController itemController)
    {
        var currentSlotParent = GetEmptySlot();
        var itemSlot = Instantiate(itemSlotPrefab, currentSlotParent);
        var itemView = itemSlot.GetComponent<ItemView>();
        itemView.Initialize(itemController);
        _itemViews.Add(itemView);
    }

    private Transform GetEmptySlot()
    {
        foreach (var slot in itemSlotParents)
        {
            if(slot.childCount == emptySlot)
            {
                return slot;
            }
        }
        return null;
    }

    private void AddNewItemUnit(ItemData itemData)
    {
        //TODO: Stackable Item
    }
}
