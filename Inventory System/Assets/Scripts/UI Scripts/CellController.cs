using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CellController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    protected ItemContainer _itemContainer;
    protected const float MIN_HOLD_TIMER=2f;

    protected virtual void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
    }

    public abstract void OnClick();

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (!_itemContainer.IsEmpty())
            ItemHolder.Instance.ShowDescription(_itemContainer.Item.Description());
    }
    
    public virtual void OnPointerClick(PointerEventData eventData)
    {
            if (_itemContainer.IsEmpty())
                return;
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Right:
                    OnRightClick();
                    break;
                case PointerEventData.InputButton.Middle:
                    OnMiddleClick();
                    break;
            }

    }

    public abstract void OnRightClick();
    public abstract void OnMiddleClick();

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        ItemHolder.Instance.HideDescription();
    }
}
