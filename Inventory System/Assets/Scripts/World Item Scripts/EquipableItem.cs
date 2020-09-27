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
}
