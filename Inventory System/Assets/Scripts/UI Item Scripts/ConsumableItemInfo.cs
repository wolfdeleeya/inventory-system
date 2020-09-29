using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemInfo : ItemInfo
{
    public bool Done { get; protected set; }

    public virtual void Consume()
    {
        if(((NonequipableStats)Stats).Consumable)
            Debug.Log("Just consumed: " + Stats.Name);
        BuffManager.Instance.SpawnBuff(((NonequipableStats)Stats).ItemBuffStats);
        Done = true;
    }
}
