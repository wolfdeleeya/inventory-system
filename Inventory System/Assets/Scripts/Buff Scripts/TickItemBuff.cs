using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickItemBuff : ItemBuff
{
    public override void Initialize(ItemBuffStats stats)
    {
        base.Initialize(stats);
        StartCoroutine(TickAway());
    }

    private IEnumerator TickAway()
    {
        int numOfTicks =Mathf.RoundToInt(_stats.Duration);
        float tickAmount = _stats.Amount / _stats.Duration;
        for (int i = 0; i < numOfTicks; ++i)
        {
            CharacterStats.Instance.ReceiveBuffSpendables(((SpendableBuffStats)_stats).AffectsHealth, tickAmount);
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }
}
