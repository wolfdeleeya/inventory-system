using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int _startSize;
    private int _numOfColumns;
    private List<ItemInfo> _items;
    private List<InventoryListener> _listeners;

    public static Inventory Instance { get; private set; }

    public static void CreateInventory(int startSize, int numOfColumns)
    {
        if (Instance == null)
            Instance = new Inventory(startSize, numOfColumns);
    }
    private Inventory(int startSize, int numOfColumns)
    {
        _startSize = startSize;
        _numOfColumns = numOfColumns;
        _items = new List<ItemInfo>();
        for (int i = 0; i < startSize; ++i)
            _items.Add(null);
        _listeners = new List<InventoryListener>();
    }

    public void AddItem(ItemInfo itemToAdd)
    {
        for(int i = 0;i<_items.Count;++i)
            if (_items[i] == null)
            {
                _items[i] = itemToAdd.GetComponent<ItemInfo>();
                InformListenersItemAdded(itemToAdd, i);
                return;
            }

        _items.Add(itemToAdd);
        InformListenersItemAdded(itemToAdd, _items.Count-1);
        for (int i = 0; i < _numOfColumns - 1; ++i)
        {
            _items.Add(null);
            InformListenersEmptySlotAdded();
        }
    }

    public void AddItemAtIndex(ItemInfo itemToAdd, int index)
    {
        _items[index] = itemToAdd;
        InformListenersItemAdded(itemToAdd, index);
    }

    //BACANJE NA POD TREBA DODAT O TOM KASNIJE
    public void RemoveItem(ItemInfo itemToRemove)
    {
        int index = _items.IndexOf(itemToRemove);
        int row = (int)index / _numOfColumns;
        int occupiedSlots = 0;

        for (int i = row * _numOfColumns; i < row * _numOfColumns + _numOfColumns; ++i)
            if (_items[i] != null)
                occupiedSlots++;

        if(occupiedSlots > 1 || _items.Count==_startSize)
        {
            _items[index] = null;
            InformListenersItemRemoved(index);
        }
        else
        {
            _items[index] = null;
            for (int ind = _numOfColumns*row , i = 0; i < _numOfColumns; ++i)
            {
                _items.RemoveAt(ind);
                InformListenersEmptySlotRemoved(ind);
            }
        }
    }

    public void AddListener(InventoryListener listener) => _listeners.Add(listener);

    public void RemoveListener(InventoryListener listener) => _listeners.Remove(listener);

    private void InformListenersItemAdded(ItemInfo item, int index)
    {
        foreach (InventoryListener listener in _listeners)
            listener.AddItem(item, index);
    }

    private void InformListenersItemRemoved(int index)
    {
        foreach (InventoryListener listener in _listeners)
            listener.RemoveItem(index);
    }

    private void InformListenersEmptySlotAdded()
    {
        foreach (InventoryListener listener in _listeners)
            listener.AddEmptySlot();
    }

    private void InformListenersEmptySlotRemoved(int index)
    {
        foreach (InventoryListener listener in _listeners)
            listener.RemoveEmptySlot(index);
    }
}
