using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Animator _animator;

    public static UIManager Instance { get; private set; }
    public bool InventoryOpened { get; private set; }
    public bool EquipOpened { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _animator = GetComponent<Animator>();
    }

    public void OpenInventory()
    {
        if (InventoryOpened)
            return;

        _animator.SetTrigger("Inventory In");
        InventoryOpened = true;
    }

    public void CloseInventory()
    {
        if (!InventoryOpened)
            return;

        _animator.SetTrigger("Inventory Out");
        InventoryOpened = false;
    }

    public void OpenEquip()
    {
        if (EquipOpened)
            return;

        _animator.SetTrigger("Equip In");
        EquipOpened = true;
    }

    public void CloseEquip()
    {
        if (!EquipOpened)
            return;

        _animator.SetTrigger("Equip Out");
        EquipOpened = false;
    }

    public void ChangeInventoryState()
    {
        if (InventoryOpened)
            _animator.SetTrigger("Inventory Out");
        else
            _animator.SetTrigger("Inventory In");
        InventoryOpened = !InventoryOpened;
    }

    public void ChangeEquipState()
    {
        if (EquipOpened)
            _animator.SetTrigger("Equip Out");
        else
            _animator.SetTrigger("Equip In");
        EquipOpened = !EquipOpened;
    }
}
