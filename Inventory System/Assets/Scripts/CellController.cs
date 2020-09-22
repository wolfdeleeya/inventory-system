using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CellController : MonoBehaviour
{
    protected ItemContainer _itemContainer;

    protected virtual void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
    }

    public abstract void OnClick();
}
