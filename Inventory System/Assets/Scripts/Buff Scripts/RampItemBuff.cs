using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampItemBuff : ItemBuff
{
    private float _timer=0;

    public override void Initialize(ItemBuffStats stats)
    {
        base.Initialize(stats);
        _timer = stats.Duration;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            CharacterStats.Instance.ReceiveBuff(((NonSpendableBuffStats)_stats).Attribute, Time.deltaTime * (_stats.Amount / _stats.Duration));
            if (_timer <= 0)
                StartCoroutine(StartHold());
        }
    }

    private IEnumerator StartHold()
    {
        yield return new WaitForSeconds(((RampBuffStats)_stats).HoldDuration);

        CharacterStats.Instance.ReceiveBuff(((NonSpendableBuffStats)_stats).Attribute, -_stats.Amount);
        Destroy(gameObject);
    }
}
