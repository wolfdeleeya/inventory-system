using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCellController : CellController
{
    public EquipmentStats.SlotType Type;

    public override void OnClick()
    {
        if(!ItemHolder.Instance.IsEmpty)
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
            Equipment.Instance.EquipItem((EquipableItemInfo)item);
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
            Equipment.Instance.EquipItem((EquipableItemInfo)itemHolder);
        }
    }

    public override void OnRightClick()
    {
            Inventory.Instance.AddItem(_itemContainer.Item);
            Equipment.Instance.RemoveItem(((EquipmentStats)_itemContainer.Item.Stats).Type);
    }

    public override void OnMiddleClick()
    {
        throw new System.NotImplementedException();
    }
}
