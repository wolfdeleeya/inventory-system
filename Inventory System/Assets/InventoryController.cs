using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour, InventoryListener
{
    [SerializeField] private int _numOfColumns;
    [SerializeField] private int _startingSize;
    [SerializeField] private GameObject _cellPrefab;

    private List<Item> _cells;
    private List<GameObject> _buttons;

    private void Awake()
    {
        _cells = new List<Item>(_startingSize);
        _buttons = new List<GameObject>();
    }

    private void Start()
    {
        Inventory.CreateInventory();
        Inventory.instance.AddListener(this);

        for (int i = 0; i < _startingSize; ++i)
            _buttons.Add(Instantiate(_cellPrefab, transform));
    }

    public virtual void AddItem(Item itemToAdd)
    {

    }

    public virtual void RemoveItem(Item itemToRemove)
    {

    }
}
