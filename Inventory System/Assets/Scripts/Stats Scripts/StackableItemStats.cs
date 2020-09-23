using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stackable Item", menuName = "Items/Stackable Item")]
public class StackableItemStats : NonequipableStats
{
    public int MaxStack;

    public override string Description()
    {
        string maxStack = "Maximum stack: ";
        maxStack += MaxStack == -1 ? "unlimited\n" : MaxStack + "\n";
        return base.Description() + maxStack;
    }
}
