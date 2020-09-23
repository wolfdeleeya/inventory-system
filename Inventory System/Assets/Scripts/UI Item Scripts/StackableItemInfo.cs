using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StackableItemInfo : ConsumableItemInfo
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
        Amount = amount;
        text.text = Amount.ToString();
    }

    public override void SpawnWorldItem(Vector3 position)
    {
        GameObject obj = Instantiate(_worldPrefab, position, Quaternion.identity);
        obj.GetComponent<StackableItem>().Initialize(this, Amount);
    }

    public bool IsFull()
    {
        int maxStack = ((StackableItemStats)Stats).MaxStack;
        if (maxStack == -1 || maxStack > _amount)
            return false;
        return true;
    }

    public override void Consume()
    {
        if (((NonequipableStats)Stats).Consumable)
            Debug.Log("Just consumed: " + Stats.Name);
        if (((NonequipableStats)Stats).Consumable)
        {
            --Amount;
        }
        if (Amount == 0)
            Done = true;
    }
}
