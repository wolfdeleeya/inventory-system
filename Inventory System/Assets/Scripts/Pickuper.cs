using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuper : MonoBehaviour
{
    [SerializeField] private GameObject _stackUIPrefab;
    [SerializeField] private GameObject _equipUIPrefab;
    [SerializeField] private GameObject _consumeUIPrefab;

    public void Pickup(Item item)
    {
        switch (item.GetType().ToString())
        {
            case "PickupableItem":
                Pickup((PickupableItem)item);
                break;
            case "EquipableItem":
                Pickup((EquipableItem)item);
                break;
            case "PermanentItem":
                Pickup((PermanentItem)item);
                break;
            case "StackableItem":
                Pickup((StackableItem)item);
                break;
        }
        AnalyticsManager.Instance.SendAnalyticsMessage("Picked up an item called " + item.Stats.Name + " and it's type is " + item.GetType().ToString() + ".");
    }


    public void Pickup(PickupableItem item)
    {
        ItemInfo info;
        if (item is EquipableItem eItem)
        {
            info = Instantiate(_equipUIPrefab).GetComponent<ItemInfo>();
            ((EquipableItemInfo)info).Initialize(item.Stats, ((EquipableItem)item).CurrentDurability);
        }
        else
        {
            info = Instantiate(_consumeUIPrefab).GetComponent<ItemInfo>();
            info.Initialize(item.Stats);
        }
        Inventory.Instance.AddItem(info);
    }

    public void Pickup(EquipableItem item)
    {
        if (Equipment.Instance.IsSlotOccupied(item.EquipmentStats.Type))
            Pickup((PickupableItem)item);
        else
        {
            EquipableItemInfo info = Instantiate(_equipUIPrefab).GetComponent<EquipableItemInfo>();
            info.Initialize(item.EquipmentStats,item.CurrentDurability);
            Equipment.Instance.EquipItem(info);
        }
    }

    public void Pickup(PermanentItem item)
    {
        Debug.Log("I just picked up permanent usage item called: " + item.Stats.Name);
    }

    public void Pickup(StackableItem item)
    {
        StackableItemInfo info = Instantiate(_stackUIPrefab).GetComponent<StackableItemInfo>();
        info.Initialize(item.Stats, item.Amount);
        Inventory.Instance.AddItem(info);
    }
}
