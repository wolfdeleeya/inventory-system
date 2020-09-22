using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CellController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    protected ItemContainer _itemContainer;

    protected virtual void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
    }

    public abstract void OnClick();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_itemContainer.Item != null)
            ItemHolder.Instance.ShowDescription(_itemContainer.Item.Stats.Description());
    }
    
    public void OnPointerClick(PointerEventData eventData)
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

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemHolder.Instance.HideDescription();
    }
}
