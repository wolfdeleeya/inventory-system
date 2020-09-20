using System;
using UnityEngine;

[Serializable]
public abstract class Item
{
    protected String _itemName;

    public Sprite Sprite;

    public abstract void Pickup();
}
