using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCellControllerAndroid : InventoryCellController
{
    private AndroidCellController _androidCellController;

    protected override void Awake()
    {
        base.Awake();
        _androidCellController = GetComponent<AndroidCellController>();
        _androidCellController.Click = base.OnClick;
    }

    public override void OnPointerEnter(PointerEventData eventData) { }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _androidCellController.OnPointerClick(eventData);
    }
}
