using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryListener
{
    void AddItem(Item itemToAdd);
    void RemoveItem(Item itemToRemove);
}
