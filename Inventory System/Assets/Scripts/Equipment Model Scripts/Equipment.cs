using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : PlayerMovementListener
{
    struct EquipSlot
    {
        public EquipableItemInfo Item;

        public EquipmentStats.SlotType SlotType { get; private set; }

        public static implicit operator EquipSlot(EquipmentStats.SlotType type)
        {
            return new EquipSlot() { SlotType = type, Item = null };
        }

        public void SetItem(EquipableItemInfo item) => Item = item;
    }

    private List<EquipSlot> _cells;
    private List<EquipmentListener> _listeners;

    public static Equipment Instance { get; private set; }

    public static void CreateEquipment(List<ItemContainer> containers)
    {
        if (Instance == null)
            Instance = new Equipment(containers);
    }

    private Equipment(List<ItemContainer> containers)
    {
        _cells = new List<EquipSlot>();
        for (int i = 0; i < containers.Count; ++i)
        {
            EquipSlot slot = containers[i].GetComponent<EquipCellController>().Type;
            _cells.Add(slot);

        }
        _listeners = new List<EquipmentListener>();
    }

    public void EquipItem(EquipableItemInfo itemToEquip)
    {
        for(int i=0;i<_cells.Count;++i)
            if (_cells[i].SlotType == ((EquipmentStats)itemToEquip.Stats).Type && _cells[i].Item == null)
            {
                EquipItemAt(itemToEquip, i);
                return;
            }
    }

    public void EquipItemAt(EquipableItemInfo itemToEquip, int index)
    {
        if (_cells[index].Item!=null)
            RemoveItem(index);

        EquipSlot slot = _cells[index];
        slot.Item = itemToEquip;
        _cells[index] = slot;

        CharacterStats.Instance.AddItemStats(itemToEquip);

        InformListenersItemEquiped(itemToEquip, index);
    }

    public void RemoveItem(int index)
    {
        ItemInfo item = _cells[index].Item;

        CharacterStats.Instance.RemoveItemStats((EquipableItemInfo)item);

        EquipSlot slot = _cells[index];
        slot.Item = null;
        _cells[index] = slot;

        InformListenersItemUnequiped(index);
    }

    public ItemInfo GetItemAt(int index)
    {
        return _cells[index].Item;
    }
    
    public void PlayerMoved(float distance)
    {
        for(int i=0;i<_cells.Count;++i)
        {
            if (_cells[i].Item != null)
            {
                _cells[i].Item.Spend(distance);
                if (_cells[i].Item.CurrentDurability <= 0)
                {
                    ItemInfo item = _cells[i].Item;
                    RemoveItem(i);
                    item.Destroy();
                }
            }
        }
    }

    public void AddListener(EquipmentListener listener) => _listeners.Add(listener);

    public void RemoveListener(EquipmentListener listener) => _listeners.Remove(listener);

    private void InformListenersItemEquiped(ItemInfo item, int index)
    {
        foreach (EquipmentListener listener in _listeners)
            listener.ItemEquiped(item, index);
    }

    private void InformListenersItemUnequiped(int index)
    {
        foreach (EquipmentListener listener in _listeners)
            listener.ItemUnequiped(index);
    }
 
    public bool IsSlotOccupied(EquipmentStats.SlotType type)
    {
        foreach (EquipSlot slot in _cells)
            if (slot.SlotType == type && slot.Item == null)
                return false;
        return true;
    }

    public int GetEquipableIndex(EquipmentStats.SlotType type)
    {
        int index = -1;
        for(int i = 0; i < _cells.Count; ++i)
        {
            if (_cells[i].SlotType == type)
            {
                if (_cells[i].Item == null)
                    return i;
                else if (index == -1)
                    index = i;
            }
        }
        return index;
    }
}
