using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Animator _animator;

    public static UIManager Instance { get; private set; }
    public bool InventoryOpened { get; private set; }
    public bool EquipOpened { get; private set; }
    public bool AttributesOpened { get; private set; }
    public bool IsMenuOpened { get { return InventoryOpened || EquipOpened; } }
    public bool IsSplitOpened { get; private set; }

    private List<UIListener> _listeners;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _animator = GetComponent<Animator>();
        _listeners = new List<UIListener>();
    }

    public void OpenInventory()
    {
        if (InventoryOpened)
            return;

        _animator.SetTrigger("Inventory In");
        InventoryOpened = true;
        InformListeners();
    }

    public void CloseInventory()
    {
        if (!InventoryOpened)
            return;

        _animator.SetTrigger("Inventory Out");
        InventoryOpened = false;
        if (!EquipOpened)
            ItemHolder.Instance.ReturnItem();
        if (!IsMenuOpened)
            ItemHolder.Instance.HideDescription();
        InformListeners();
    }

    public void OpenEquip()
    {
        if (EquipOpened)
            return;

        _animator.SetTrigger("Equip In");
        EquipOpened = true;
        InformListeners();
    }

    public void CloseEquip()
    {
        if (!EquipOpened)
            return;

        _animator.SetTrigger("Equip Out");
        EquipOpened = false;
        if (!InventoryOpened)
            ItemHolder.Instance.ReturnItem();
        if (!IsMenuOpened)
            ItemHolder.Instance.HideDescription();
        InformListeners();
    }

    public void OpenAttributes()
    {
        if (AttributesOpened)
            return;

        _animator.SetTrigger("Attributes In");
        AttributesOpened = true;
    }

    public void CloseAttributes()
    {
        if (!AttributesOpened)
            return;

        _animator.SetTrigger("Attributes Out");
        AttributesOpened = false;
    }

    public void OpenSlider()
    {
        if (IsSplitOpened)
            return;

        _animator.SetTrigger("Slider In");
        IsSplitOpened = true;
    }

    public void CloseSlider()
    {
        if (!IsSplitOpened)
            return;

        _animator.SetTrigger("Slider Out");
        IsSplitOpened = false;
    }

    public void ChangeInventoryState()
    {
        if (IsSplitOpened)
            return;
        if (InventoryOpened)
            CloseInventory();
        else
            OpenInventory();
    }

    public void ChangeEquipState()
    {
        if (EquipOpened)
            CloseEquip();
        else
            OpenEquip();
    }

    public void ChangeAttributesState()
    {
        if (AttributesOpened)
            CloseAttributes();
        else
            OpenAttributes();
    }

    public void AddListener(UIListener listener) => _listeners.Add(listener);

    public void RemoveListener(UIListener listener) => _listeners.Remove(listener);

    private void InformListeners()
    {
        foreach (UIListener listener in _listeners)
            listener.UIStateChanged();
    }
}
