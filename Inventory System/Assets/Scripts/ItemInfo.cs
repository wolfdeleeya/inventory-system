using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemStats Stats;// { get; private set; }
    private int _amount;
    private GameObject _worldPrefab;

    public void Initialize(ItemStats stats, int amount)
    {
        Stats = stats;
        _amount = amount;
    }

    public void Initialize(ItemStats stats)
    {
        Stats = stats;
    }
}
