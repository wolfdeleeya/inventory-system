using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StackableItemInfo : ItemInfo
{
    public int Amount;
    [SerializeField] private TextMeshProUGUI text;


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
}
