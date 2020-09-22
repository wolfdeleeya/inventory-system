using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour, EquipmentListener
{
    [SerializeField] private List<ItemContainer> _cells;

    private void Awake()
    {
        Equipment.CreateEquipment();
        Equipment.Instance.AddListener(this);
    }

    public void ItemEquiped(ItemInfo item)
    {
        EquipmentStats.SlotType type = ((EquipmentStats)item.Stats).Type;

        _cells[(int)type].AddItem(item);
    }

    public void ItemUnequiped(EquipmentStats.SlotType type)
    {
        _cells[(int)type].RemoveItem();
    }
}
