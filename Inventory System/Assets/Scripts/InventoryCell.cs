using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCell : MonoBehaviour
{
    private PickupableItem _item;

    public void AddItem(PickupableItem item)
    {
        throw new UnityException("Nisi još implementirao");
    }

    public void RemoveItem()
    {
        throw new UnityException("Nisi još implementirao");
    }

    public bool IsEmpty() { return (_item == null); }
}
