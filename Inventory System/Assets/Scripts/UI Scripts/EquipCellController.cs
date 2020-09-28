using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCellController : CellController
{
    public EquipmentStats.SlotType Type;

    public int Index { get; set; }

    public override void OnClick()
    {
        if (UIManager.Instance.IsSplitOpened)
            return;

        if (!ItemHolder.Instance.IsEmpty)
        {
            EquipmentStats stats =  ItemHolder.Instance.InAirItem.Stats as EquipmentStats;
            if (stats == null || stats.Type!=Type)
                return;
        }
        if (_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty)
            return;
        else if (_itemContainer.IsEmpty() && !ItemHolder.Instance.IsEmpty)
        {
            ItemInfo item = ItemHolder.Instance.InAirItem;
            ItemHolder.Instance.DropItem();
            Equipment.Instance.EquipItemAt((EquipableItemInfo)item,Index);
        }
        else if (!_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty)
        {
            ItemInfo item = _itemContainer.Item;
            ItemHolder.Instance.HoldItem(item, _itemContainer);
        }
        else
        {
            ItemInfo itemEquip = _itemContainer.Item;
            ItemInfo itemHolder = ItemHolder.Instance.InAirItem;
            ItemHolder.Instance.HoldItem(itemEquip);
            Equipment.Instance.EquipItemAt((EquipableItemInfo)itemHolder,Index);
        }
    }

    public override void OnRightClick()
    {
            Inventory.Instance.AddItem(_itemContainer.Item);
            Equipment.Instance.RemoveItem(Index);
    }

    public override void OnMiddleClick()
    {
        throw new System.NotImplementedException();
    }

}
