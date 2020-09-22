using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Equipable Item", menuName = "Items/Equipable Item" )]
public class EquipmentStats : ItemStats
{
    public enum SlotType { Head, Armor, Weapon, Boots };

    public List<Stats> Stats;

    public SlotType Type;
}

[Serializable]
public struct Stats
{
    public string StatName;
    public float Amount;
}
