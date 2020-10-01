using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidItemSplitter : MonoBehaviour
{
    public static AndroidItemSplitter Instance { get; private set; }

    public int IndexToSet { get; set; }
    private int Amount { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void ReturnItem()
    {
        if (IndexToSet < 0 || Amount<=0)
            return;
        ItemInfo item = ItemHolder.Instance.InAirItem;
        ItemHolder.Instance.DropItem();
        Inventory.Instance.AddItemAtIndex(item, IndexToSet);
        IndexToSet = -1;
        Amount = 0;
    }

    public void SetAmount()
    {
        Amount = ItemSpliter.Instance.AmountToTake;
    }
    
}
