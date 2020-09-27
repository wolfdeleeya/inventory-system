using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItemInfo : ItemInfo
{
    public float CurrentDurability { get; private set; }

    public virtual void Initialize(ItemStats stats, float currentDurability)
    {
        Stats = stats;
        CurrentDurability = currentDurability;
    }

    public override void SpawnWorldItem(Vector3 position)
    {
        GameObject obj = Instantiate(_worldPrefab, position, Quaternion.identity);
        obj.GetComponent<EquipableItem>().Initialize(this,CurrentDurability);
    }

    public void Spend(float value)
    {
        CurrentDurability -= value;
    }

    public override string Description()
    {
        return Stats.Description()+"Current Durability: "+CurrentDurability+"\n";
    }
}
