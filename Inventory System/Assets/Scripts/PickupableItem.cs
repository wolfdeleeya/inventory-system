﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    [SerializeField] protected GameObject _uiPrefab;

    public override void Pickup()
    {
        ItemInfo info = Instantiate(_uiPrefab).GetComponent<ItemInfo>();
        info.Initialize(Stats);
        Inventory.Instance.AddItem(info);
    }
}
