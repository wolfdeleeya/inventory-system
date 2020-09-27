using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributesController : MonoBehaviour, EquipmentListener
{
    [SerializeField] private TextMeshProUGUI[] _statTexts;

    private void Start()
    {
        Equipment.Instance.AddListener(this);
        SetTexts();
    }

    public void ItemEquiped(ItemInfo item)
    {
        SetTexts();
    }

    public void ItemUnequiped(EquipmentStats.SlotType type)
    {
        SetTexts();
    }

    private void SetTexts()
    {
        IReadOnlyList<int> stats = Equipment.Instance.TotalStats;
        string[] statNames = Enum.GetNames(typeof(Attribute));
        for(int i = 0; i < stats.Count; ++i)
        {
            _statTexts[i].text = statNames[i] + " = " + stats[i];
        }
    }
}
