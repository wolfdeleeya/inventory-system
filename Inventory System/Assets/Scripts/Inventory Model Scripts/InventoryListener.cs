using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryListener
{
    void AddItem(ItemInfo itemToAdd, int index);
    void RemoveItem(int index);
    void AddEmptySlot();
    void RemoveEmptySlot(int index);
}
