using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    private List<ItemInfo> _cells;
    private List<EquipmentListener> _listeners;

    public static Equipment Instance { get; private set; }

    public static void CreateEquipment()
    {
        if (Instance == null)
            Instance = new Equipment();
    }

    private Equipment()
    {
        _cells = new List<ItemInfo>();
        for (int i = 0; i < 4; ++i)
            _cells.Add(null);
        _listeners = new List<EquipmentListener>();
    }

    public void EquipItem(ItemInfo itemToEquip)
    {
        EquipmentStats.SlotType type = ((EquipmentStats)itemToEquip.Stats).Type;

        if (IsSlotOccupied(type))
            RemoveItem(type);

        _cells[(int) type] = itemToEquip;
        InformListenersItemEquiped(itemToEquip);
    }

    public void RemoveItem(EquipmentStats.SlotType slot)
    {
        ItemInfo item = _cells[(int)slot];

        _cells[(int) slot] = null;
        InformListenersItemUnequiped(slot);
    }

    public void AddListener(EquipmentListener listener) => _listeners.Add(listener);

    public void RemoveListener(EquipmentListener listener) => _listeners.Remove(listener);

    private void InformListenersItemEquiped(ItemInfo item)
    {
        foreach (EquipmentListener listener in _listeners)
            listener.ItemEquiped(item);
    }

    private void InformListenersItemUnequiped(EquipmentStats.SlotType type)
    {
        foreach (EquipmentListener listener in _listeners)
            listener.ItemUnequiped(type);
    }

    public bool IsSlotOccupied(EquipmentStats.SlotType type) { return _cells[(int)type] != null; }
}
