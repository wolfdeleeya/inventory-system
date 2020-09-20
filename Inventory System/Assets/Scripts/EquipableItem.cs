using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : PickupableItem
{
    public enum SlotType { Head, Armor, Legs, Weapon };

    public SlotType Type { get; private set; }

}
