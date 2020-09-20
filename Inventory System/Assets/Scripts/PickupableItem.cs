using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    public int CellIndex;

    public override void Pickup()
    {
        Inventory.Instance.AddItem(this);
    }
}
