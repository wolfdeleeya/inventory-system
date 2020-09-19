using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentUsageItem : Item
{
    public override void Pickup()
    {
        Debug.Log("I just picked up permanent usage item called: " + _itemName);
    }
}
