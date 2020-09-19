using System;
using UnityEngine;

[Serializable]
public abstract class Item
{
    protected String _itemName;

    public abstract void Pickup();
}
