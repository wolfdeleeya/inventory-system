using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    public override void Pickup()
    {
        Inventory.instance.AddItem(this);
    }
}
