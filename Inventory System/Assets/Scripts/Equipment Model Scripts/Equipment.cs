using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    private int[] _startingStats;
    private List<ItemInfo> _cells;
    private List<EquipmentListener> _listeners;

    public static Equipment Instance { get; private set; }

    public static void CreateEquipment(int[] startingStats)
    {
        if (Instance == null)
            Instance = new Equipment(startingStats);
    }

    private Equipment(int[] startingStats)
    {
        _startingStats = startingStats;
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

    public void RemoveItem(EquipmentStats.SlotType type)
    {
        ItemInfo item = _cells[(int)type];

        _cells[(int) type] = null;
        InformListenersItemUnequiped(type);
    }

    public ItemInfo GetItemAt(EquipmentStats.SlotType type)
    {
        return _cells[(int)type];
    }

    public int[] CalculateTotalStats()
    {
        int[] bonus = new int[Enum.GetNames(typeof(Attribute)).Length];
        foreach(ItemInfo item in _cells)
        {
            if (item == null)
                continue;
            EquipmentStats stats = item.Stats as EquipmentStats;
            foreach (Stats stat in stats.Stats)
                bonus[(int)stat.StatName] += stat.Amount;
        }
        for (int i = 0; i < bonus.Length; ++i)
            bonus[i] += _startingStats[i];
        return bonus;
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
