using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    protected override void Awake()
    {
        base.Awake();
    }

    public virtual void Initialize(ItemInfo info)
    {
        Stats = info.Stats;
    }

    public virtual void Initialize(ItemStats stats)
    {
        Stats = stats;
    }
}
