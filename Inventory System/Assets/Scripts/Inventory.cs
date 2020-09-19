using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> _items;
    private List<InventoryListener> _listeners;

    public static Inventory instance;

    public static void CreateInventory()
    {
        if (instance == null)
            instance = new Inventory();
    }

    private Inventory()
    {
        _items = new List<Item>();
        _listeners = new List<InventoryListener>();
    }

    public void AddItem(Item itemToAdd)
    {
        _items.Add(itemToAdd);
        InformListenersItemAdded(itemToAdd);
    }
    public void RemoveItem(Item itemToRemove)
    {
        _items.Remove(itemToRemove);
        InformListenersItemRemoved(itemToRemove);
    }
    public void AddListener(InventoryListener listener) => _listeners.Add(listener);

    public void RemoveListener(InventoryListener listener) => _listeners.Remove(listener);

    private void InformListenersItemAdded(Item item)
    {
        foreach (InventoryListener listener in _listeners)
            listener.AddItem(item);
    }

    private void InformListenersItemRemoved(Item item)
    {
        foreach (InventoryListener listener in _listeners)
            listener.RemoveItem(item);
    }
}
