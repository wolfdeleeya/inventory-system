using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StackableItemInfo : ItemInfo
{
    [SerializeField] private TextMeshProUGUI text;
    private int _amount;

    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            text.text = value.ToString();
        }
    }

    public void Initialize(ItemStats stats, int amount)
    {
        Stats = stats;
        _type = Type.GetType("StackableItem");
        Amount = amount;
        text.text = Amount.ToString();
    }

    public override void SpawnWorldItem(Vector3 position)
    {
        GameObject obj = Instantiate(_worldPrefab, position, Quaternion.identity);
        obj.AddComponent(_type);
        obj.GetComponent<StackableItem>().Initialize(this, Amount);
    }

    public bool IsFull()
    {
        int maxStack = ((NonequipableStats)Stats).MaxStack;
        if (maxStack == -1 || maxStack > _amount)
            return false;
        return true;
    }
}
