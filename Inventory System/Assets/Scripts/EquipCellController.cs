using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCellController : CellController
{
    public EquipmentStats.SlotType Type;

    public override void OnClick()
    {
        if(!ItemHolder.Instance.IsEmpty())
        {
            EquipmentStats stats =  ItemHolder.Instance.InAirItem.Stats as EquipmentStats;
            if (stats == null || stats.Type!=Type)
                return;
        }
        if (_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty())
            return;
        else if (_itemContainer.IsEmpty() && !ItemHolder.Instance.IsEmpty())
        {
            Equipment.Instance.EquipItem(ItemHolder.Instance.InAirItem);
            ItemHolder.Instance.DropItem();
        }
        else if (!_itemContainer.IsEmpty() && ItemHolder.Instance.IsEmpty())
        {
            ItemInfo item = _itemContainer.Item;
            Equipment.Instance.RemoveItem(Type);
            ItemHolder.Instance.HoldItem(item);
        }
        else
        {
            ItemInfo itemEquip = _itemContainer.Item;
            ItemInfo itemHolder = ItemHolder.Instance.InAirItem;
            Equipment.Instance.RemoveItem(Type);
            ItemHolder.Instance.HoldItem(itemEquip);
            Equipment.Instance.EquipItem(itemHolder);
        }
    }
}
