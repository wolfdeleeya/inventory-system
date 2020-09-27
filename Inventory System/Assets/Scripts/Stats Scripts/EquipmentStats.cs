﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Equipable Item", menuName = "Items/Equipable Item" )]
public class EquipmentStats : ItemStats
{
    public enum SlotType { Head, Armor, Weapon, Boots };

    public List<Stats> Stats;

    public SlotType Type;

    public override string Description()
    {
        string total = "Type: " + Type.ToString() + "\nStats:\n";

        foreach (Stats stat in Stats)
            total += stat.StatName.ToString() + ": +" + stat.Amount+"\n";
        return base.Description()+total;
    }
}

[Serializable]
public struct Stats
{
    public Attribute StatName;
    public int Amount;
}

public enum Attribute { Strength, Speed, Intelligence, Health, Luck }