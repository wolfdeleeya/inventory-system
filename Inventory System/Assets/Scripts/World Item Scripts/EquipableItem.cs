using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : PickupableItem
{
    public float CurrentDurability { get; private set; }
    public EquipmentStats EquipmentStats
    {
        get { return (EquipmentStats)Stats; }
    }

    protected override void Awake()
    {
        base.Awake();
        if (EquipmentStats != null)
            CurrentDurability = EquipmentStats.MaxDurability;
    }

    public override void Initialize(ItemInfo info)
    {
        base.Initialize(info);
        CurrentDurability = EquipmentStats.MaxDurability;
    }

    public void Initialize(ItemInfo info, float currentDurability)
    {
        Initialize(info);
        CurrentDurability = currentDurability;
    }
    
    public override void Initialize(ItemStats stats)
    {
        base.Initialize(stats);
        CurrentDurability = EquipmentStats.MaxDurability;
    }
}
