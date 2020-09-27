using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemStats Stats;
    [SerializeField]protected GameObject _worldPrefab;

    public virtual void Initialize(ItemStats stats)
    {
        Stats = stats;
    }

    public virtual void SpawnWorldItem(Vector3 position)
    {
        GameObject obj = Instantiate(_worldPrefab, position, Quaternion.identity);
        obj.GetComponent<PickupableItem>().Initialize(this);
    }

    public virtual string Description()
    {
        return Stats.Description();
    }

    internal void Destroy()
    {
        Destroy(gameObject);
    }
}
