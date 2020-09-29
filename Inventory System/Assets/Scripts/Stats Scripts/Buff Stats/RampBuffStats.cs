using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buffs/Ramp Buff")]
public class RampBuffStats : NonSpendableBuffStats
{
    public float HoldDuration;

    public override float TotalDuration()
    {
        return base.TotalDuration() + HoldDuration;
    }
}
