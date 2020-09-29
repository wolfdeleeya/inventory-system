using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCellController : CellController
{
    private InventoryController _inventoryController;
    public int Index { get { return _inventoryController.GetIndexOfButton(_itemContainer); } }
    protected override void Awake()
    {
        base.Awake();
        _inventoryController = transform.parent.gameObject.GetComponent<InventoryController>();
    }

    public override void OnClick()
    {
        if (UIManager.Instance.IsSplitOpened)
            return;

        if (_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty)
            return;
        else if (_itemContainer.IsEmpty() && !ItemHolder.Instance.IsEmpty)
        {
            ItemInfo item = ItemHolder.Instance.InAirItem;
            Inventory.Instance.AddItemAtIndex(item, Index);
            ItemHolder.Instance.DropItem();

        }
        else if(!_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty)
        {
            ItemInfo item = _itemContainer.Item;
            ItemHolder.Instance.HoldItem(item, _itemContainer);
        }
        else
        {
            ItemInfo itemInventory = _itemContainer.Item;
            ItemInfo itemHolder = ItemHolder.Instance.InAirItem;
            ItemHolder.Instance.HoldItem(itemInventory);
            Inventory.Instance.AddItemAtIndex(itemHolder, Index);
        }
    }

    public override void OnRightClick()
    {
        if (UIManager.Instance.IsSplitOpened)
            return;

        if (_itemContainer.Item.Stats is EquipmentStats stats)
        {
            int index = Equipment.Instance.GetEquipableIndex(stats.Type);
            ItemInfo item = Equipment.Instance.GetItemAt(index);
            Equipment.Instance.EquipItemAt((EquipableItemInfo)_itemContainer.Item,index);
            Inventory.Instance.RemoveItem(Index);
            if (item != null)
                Inventory.Instance.AddItem(item);
        } else if(_itemContainer.Item.Stats is StackableItemStats stackStats)
        {
            if (!_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty)
            {
                UIManager.Instance.OpenSlider();
                ItemInfo item = _itemContainer.Item;
                ItemSpliter.Instance.TakeItem((StackableItemInfo)item);
            }
        }
    }

    public override void OnMiddleClick()
    {
        if (_itemContainer.Item is ConsumableItemInfo consumable)
        {
            consumable.Consume();
            if (consumable.Done)
                Inventory.Instance.RemoveItem(Index);
        }
    }

}
