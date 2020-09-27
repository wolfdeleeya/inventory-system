using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void Initialize(ItemInfo info)
    {
        Stats = info.Stats;
    }
}
