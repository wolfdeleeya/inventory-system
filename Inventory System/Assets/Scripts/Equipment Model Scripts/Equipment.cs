using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    private List<int> _startingStats;
    private List<int> _totalStats;
    private List<ItemInfo> _cells;
    private List<EquipmentListener> _listeners;

    public static Equipment Instance { get; private set; }

    public IReadOnlyList<int> TotalStats { get { return _totalStats.AsReadOnly(); } }

    public static void CreateEquipment(List<int> startingStats)
    {
        if (Instance == null)
            Instance = new Equipment(startingStats);
    }

    private Equipment(List<int> startingStats)
    {
        _startingStats = new List<int>(startingStats);
        _totalStats = new List<int>(startingStats);
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
        List<Stats> statsToChange = ((EquipmentStats)itemToEquip.Stats).Stats;
        foreach (Stats stat in statsToChange)
            _totalStats[(int)stat.StatName] += stat.Amount;

        InformListenersItemEquiped(itemToEquip);
    }

    public void RemoveItem(EquipmentStats.SlotType type)
    {
        ItemInfo item = _cells[(int)type];
        List<Stats> statsToChange = ((EquipmentStats)item.Stats).Stats;
        foreach (Stats stat in statsToChange)
            _totalStats[(int)stat.StatName] -= stat.Amount;
        _cells[(int) type] = null;
        InformListenersItemUnequiped(type);
    }

    public ItemInfo GetItemAt(EquipmentStats.SlotType type)
    {
        return _cells[(int)type];
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
