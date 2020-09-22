using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackableItem : PickupableItem
{
    public int Amount;
    private TextMeshProUGUI _amountText;

    protected override void Awake()
    {
        base.Awake();
        _amountText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _amountText.text = Amount.ToString();
    }

    public void Initialize(ItemInfo info, int amount)
    {
        base.Initialize(info);
        Amount = amount;
        _amountText.text = Amount.ToString();
    }

    public override void Pickup()
    {
        StackableItemInfo info = Instantiate(_uiPrefab).GetComponent<StackableItemInfo>();
        info.Initialize(Stats, Amount);
        Inventory.Instance.AddItem(info);
    }

}
