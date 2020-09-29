using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    [SerializeField] protected ItemBuffStats _stats;

    public virtual void Initialize(ItemBuffStats stats)
    {
        _stats = stats;
        GetComponent<UIBuffCountdownController>().Initialize(stats);
    }
}
