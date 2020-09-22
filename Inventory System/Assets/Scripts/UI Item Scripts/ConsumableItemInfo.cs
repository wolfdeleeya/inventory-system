using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItemInfo : ItemInfo
{
    public void Consume()
    {
        Debug.Log("Just consumed: " + Stats.Name);
    }
}
