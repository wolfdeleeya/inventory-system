using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentItem : Item
{
    public override void Pickup()
    {
        Debug.Log("I just picked up permanent usage item called: " + Stats.Name);
    }
}
