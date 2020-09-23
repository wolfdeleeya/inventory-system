using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Item
{
    protected GameObject _uiPrefab;

    protected override void Awake()
    {
        base.Awake();
        _uiPrefab = GetComponent<UiHolder>().UIPrefab;
    }

    public override void Pickup()
    {
        ItemInfo info = Instantiate(_uiPrefab).GetComponent<ItemInfo>();
        info.Initialize(Stats);
        Inventory.Instance.AddItem(info);
    }

    public void Initialize(ItemInfo info)
    {
        Stats = info.Stats;
    }
}
