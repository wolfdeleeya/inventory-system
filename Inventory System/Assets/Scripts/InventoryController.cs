using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, InventoryListener
{
    [SerializeField] private int _numOfColumns;
    [SerializeField] private int _startingSize;
    [SerializeField] private GameObject _cellPrefab;
    
    private List<InventoryCell> _buttons;

    private void Awake()
    {
        _buttons = new List<InventoryCell>();
    }

    private void Start()
    {
        Inventory.CreateInventory(_startingSize, _numOfColumns);
        Inventory.Instance.AddListener(this);

        for (int i = 0; i < _startingSize; ++i)
            _buttons.Add(Instantiate(_cellPrefab, transform).GetComponent<InventoryCell>());
    }

    public virtual void AddItem(PickupableItem itemToAdd, int index)
    {
        if(index>=_buttons.Capacity)
        {
            _buttons.Add(Instantiate(_cellPrefab, transform).GetComponent<InventoryCell>());
            _buttons[index].AddItem(itemToAdd);
        }
        else
        {
            _buttons[index].AddItem(itemToAdd);
        }
    }

    public virtual void RemoveItem(int index)
    {
        _buttons[index].RemoveItem();
    }

    public void AddEmptySlot()
    {
        _buttons.Add(Instantiate(_cellPrefab, transform).GetComponent<InventoryCell>());
    }

    public void RemoveEmptySlot(int index)
    {
        GameObject buttonToRemove = _buttons[index].gameObject;
        _buttons.RemoveAt(index);
        Destroy(buttonToRemove);
    }
}
