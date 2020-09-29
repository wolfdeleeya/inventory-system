using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buffs/Spendable Buff")]
public class SpendableBuffStats : ItemBuffStats
{
    public bool AffectsHealth;
}
