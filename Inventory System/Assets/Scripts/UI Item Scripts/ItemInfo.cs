using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemStats Stats;
    [SerializeField]protected GameObject _worldPrefab;
    protected Type _type;

    public virtual void Initialize(ItemStats stats)
    {
        Stats = stats;
        if (Stats is EquipmentStats stat)
            _type = Type.GetType("EquipableItem");
        else
            _type = Type.GetType("PickupableItem");
    }

    public virtual void SpawnWorldItem(Vector3 position)
    {
        GameObject obj = Instantiate(_worldPrefab, position, Quaternion.identity);
        obj.AddComponent(_type);
        obj.GetComponent<PickupableItem>().Initialize(this);
    }
}
