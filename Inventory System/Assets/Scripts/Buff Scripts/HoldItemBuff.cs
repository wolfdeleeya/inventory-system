using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItemBuff : ItemBuff
{
    public override void Initialize(ItemBuffStats stats)
    {
        base.Initialize(stats);
        StartCoroutine(HoldValue());
    }

    private IEnumerator HoldValue()
    {
        CharacterStats.Instance.ReceiveBuff(((NonSpendableBuffStats)_stats).Attribute, _stats.Amount);

        yield return new WaitForSeconds(_stats.Duration);

        CharacterStats.Instance.ReceiveBuff(((NonSpendableBuffStats)_stats).Attribute, -_stats.Amount);
        Destroy(gameObject);
    }
}
