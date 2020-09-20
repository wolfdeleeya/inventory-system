using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int _startSize;
    private int _numOfColumns;
    private List<PickupableItem> _items;
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
        _items = new List<PickupableItem>(_startSize);
        _listeners = new List<InventoryListener>();
    }

    public void AddItem(PickupableItem itemToAdd)
    {
        for(int i = 0;i<_items.Capacity;++i)
            if (_items[i] == null)
            {
                _items[i] = itemToAdd;
                _items[i].CellIndex = i;
                InformListenersItemAdded(itemToAdd, i);
                return;
            }

        _items.Add(itemToAdd);
        InformListenersItemAdded(itemToAdd,_items.Capacity-1);
        for (int i = 0; i < _numOfColumns - 1; ++i)
        {
            _items.Add(null);
            InformListenersEmptySlotAdded();
        }

        //ONDA U VIEWU TO TREBA DOBRO UPDATEAT NAKON CEGA TREBA NAPRAVITI WORLD PREFABE ITEMA NAKON ČEGA TREBA SVE MERGEAT SA DEVOM DI ĆE VEĆ BITI MOVEMENT
        // I RADITI NA DODAVANJU STVARI U INVENNTORY
        //ONDA IDE INVENTORY MANAGMENT TE ANIMACIJE I UPDATEANJE IZGLEDA I ONDA SMINKANJE ET. 8 SATI
    }

    public void RemoveItem(PickupableItem itemToRemove)
    {
        int index = _items.IndexOf(itemToRemove);
        int row = (int)index / _numOfColumns;
        int occupiedSlots = 0;

        for (int i = row * _numOfColumns; i < row * _numOfColumns + _numOfColumns; ++i)
            if (_items[i] != null)
                occupiedSlots++;

        if(occupiedSlots > 1)
        {
            _items[index] = null;
            InformListenersItemRemoved(index);
        }
        else
        {
            _items[index] = null;
            for (int i = row * _numOfColumns; i < row * _numOfColumns + _numOfColumns; ++i)
            {
                _items.RemoveAt(i);
                InformListenersEmptySlotRemoved(i);
            }
        }
    }
    public void AddListener(InventoryListener listener) => _listeners.Add(listener);

    public void RemoveListener(InventoryListener listener) => _listeners.Remove(listener);

    private void InformListenersItemAdded(PickupableItem item, int index)
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
