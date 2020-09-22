using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Non-equipable Item", menuName = "Items/Non-equipable Item")]
public class NonequipableStats : ItemStats
{
    public int MaxStack;

    public override string Description()
    {
        string maxStack = "Maximum stack: ";
        maxStack += MaxStack == -1 ? "unlimited\n" : MaxStack+"\n" ;
        return base.Description() + maxStack;
    }
}
