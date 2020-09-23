using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Non-equipable Item", menuName = "Items/Non-equipable Item")]
public class NonequipableStats : ItemStats
{
    public bool Consumable;

    public override string Description()
    {
        string maxStack = "Consumable: ";
        maxStack += Consumable ? "Yes\n" : "No\n" ;
        return base.Description() + maxStack;
    }
}
