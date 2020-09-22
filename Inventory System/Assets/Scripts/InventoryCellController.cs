using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCellController : CellController
{
    private InventoryController _inventoryController;

    protected override void Awake()
    {
        base.Awake();
        _inventoryController = transform.parent.gameObject.GetComponent<InventoryController>();
    }

    public override void OnClick()
    {
        if (_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty())
            return;
        else if (_itemContainer.IsEmpty() && !ItemHolder.Instance.IsEmpty())
        {
            Inventory.Instance.AddItemAtIndex(ItemHolder.Instance.InAirItem, _inventoryController.GetIndexOfButton(_itemContainer));
            ItemHolder.Instance.DropItem();
        }
        else if(!_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty())
        {
            ItemInfo item = _itemContainer.Item;
            ItemHolder.Instance.HoldItem(item);
            Inventory.Instance.RemoveItem(item);
        }
        else
        {
            ItemInfo itemInventory = _itemContainer.Item;
            ItemInfo itemHolder = ItemHolder.Instance.InAirItem;
            Inventory.Instance.RemoveItem(itemInventory);
            ItemHolder.Instance.HoldItem(itemInventory);
            Inventory.Instance.AddItemAtIndex(itemHolder, _inventoryController.GetIndexOfButton(_itemContainer));
        }
    }
}
