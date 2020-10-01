using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidItemSplitter : MonoBehaviour
{
    public static AndroidItemSplitter Instance { get; private set; }

    public int IndexToSet { get; set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void ReturnItem()
    {
        if (IndexToSet < 0)
            return;
        ItemInfo item = ItemHolder.Instance.InAirItem;
        ItemHolder.Instance.DropItem();
        Inventory.Instance.AddItemAtIndex(item, IndexToSet);
        IndexToSet = -1;
    }
}
