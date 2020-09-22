using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : PickupableItem
{
    public EquipmentStats EquipmentStats
    {
        get { return (EquipmentStats)Stats; }
    }

    public override void Pickup()
    {
        if (Equipment.Instance.IsSlotOccupied(EquipmentStats.Type))
            base.Pickup();
        else
        {
            ItemInfo info = Instantiate(_uiPrefab).GetComponent<ItemInfo>();
            info.Initialize(EquipmentStats);
            Equipment.Instance.EquipItem(info);
        }
    }
}
