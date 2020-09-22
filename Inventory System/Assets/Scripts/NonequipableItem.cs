using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonequipableItem : PickupableItem
{
    public int Amount;

    public override void Pickup()
    {
        ItemInfo info = Instantiate(_uiPrefab).GetComponent<ItemInfo>();
        info.Initialize(Stats, Amount);
        Inventory.Instance.AddItem(info);
    }
}
