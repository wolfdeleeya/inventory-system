using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellControllerAndroid : InventoryCellController, IPointerDownHandler
{
    private float _timer = 0;
    private bool _down = false;

    private void Update()
    {
        if (_down)
        {
            _timer += Time.deltaTime;
            if (_timer >= CellController.MIN_HOLD_TIMER)
            {
                base.OnClick();
                _down = false;
                _timer = 0;
            }
        }
    }

    public override void OnPointerEnter(PointerEventData eventData) { }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_itemContainer.IsEmpty())
            ItemHolder.Instance.HideDescription();
        else
            ItemHolder.Instance.ShowDescription(_itemContainer.Item.Description());
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        _down = false;
        _timer = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
    }
}
