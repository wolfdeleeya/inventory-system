using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour, EquipmentListener
{
    [SerializeField] private List<ItemContainer> _cells;
    [SerializeField] private List<float> _startingStats;

    private void Awake()
    {
        Equipment.CreateEquipment(_cells);
        Equipment.Instance.AddListener(this);
        CharacterStats.CreateCharacterStats(_startingStats);
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
