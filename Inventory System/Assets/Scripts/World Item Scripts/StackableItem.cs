using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackableItem : PickupableItem
{
    private List<StackableItemListener> _listeners;
    [SerializeField]private int _amount;

    public int Amount {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
            foreach (StackableItemListener listener in _listeners)
                listener.StackChanged(Amount);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _listeners = new List<StackableItemListener>();
    }

    public void Initialize(ItemInfo info, int amount)
    {
        base.Initialize(info);
        Amount = amount;
    }

    public void AddListener(StackableItemListener listener) => _listeners.Add(listener);

    public void RemoveListener(StackableItemListener listener) => _listeners.Remove(listener);
}
