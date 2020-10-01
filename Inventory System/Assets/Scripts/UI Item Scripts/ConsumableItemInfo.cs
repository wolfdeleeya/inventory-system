using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemInfo : ItemInfo
{
    public bool Done { get; protected set; }

    public virtual void Consume()
    {
        if (((NonequipableStats)Stats).Consumable)
        {
            BuffManager.Instance.SpawnBuff(((NonequipableStats)Stats).ItemBuffStats);
            Done = true;
            AnalyticsManager.Instance.SendAnalyticsMessage("Consumed an item called " + Stats.Name + " and it's type is " + ((NonequipableStats)Stats).ItemBuffStats.Type.ToString() + ".");
        }
    }
}
