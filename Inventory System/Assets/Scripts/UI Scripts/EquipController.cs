using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour, EquipmentListener
{
    [SerializeField] private List<ItemContainer> _cells;
    [SerializeField] private List<int> _startingStats;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        Equipment.CreateEquipment(_startingStats, _cells);
        Equipment.Instance.AddListener(this);
        for (int i = 0; i < _cells.Count; ++i)
            _cells[i].GetComponent<EquipCellController>().Index = i;
    }

    public void ItemEquiped(ItemInfo item, int index)
    {
        _cells[index].AddItem(item);
    }

    public void ItemUnequiped(int index)
    {
        _cells[index].RemoveItem();
    }
}
