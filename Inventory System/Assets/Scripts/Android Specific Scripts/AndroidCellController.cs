using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class AndroidCellController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IDragHandler
{
    public Action Click;

    private ItemContainer _itemContainer;
    private float _timer = 0;
    private float _doubleTapTimer = 0;
    private bool _tapped = false;
    private bool _down = false;
    private PlayerControllerAndroid _player;
    private CellController _cell;
    private const float MIN_HOLD_TIMER = 1f;
    private const float MIN_DOUBLE_TAP_TIMER = 0.5f;
    private PointerEventData _pointerEventData;
    private List<RaycastResult> _results;

    protected void Awake()
    {
        _itemContainer = GetComponent<ItemContainer>();
        _pointerEventData = new PointerEventData(null);
        _results = new List<RaycastResult>();
        _player = GameObject.FindObjectOfType<PlayerControllerAndroid>();
        _cell = GetComponent<CellController>();
    }

    private void Update()
    {
        if (_down)
        {
            _timer += Time.deltaTime;
            if (_timer >= MIN_HOLD_TIMER)
            {
                Click?.Invoke();
                _down = false;
                _timer = 0;
            }
        }
        if (_tapped)
        {
            _doubleTapTimer += Time.deltaTime;
            if (_doubleTapTimer >= MIN_DOUBLE_TAP_TIMER)
            {
                _tapped = false;
                _doubleTapTimer = 0;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemContainer.IsEmpty())
        {
            ItemHolder.Instance.HideDescription();
            _tapped = false;
            _doubleTapTimer = 0f;
        }
        else
        {
            if (_tapped)
            {
                if (_itemContainer.Item is ConsumableItemInfo item)
                    _cell.OnMiddleClick();
                else
                    _cell.OnRightClick();
            }
            else
            {
                ItemHolder.Instance.ShowDescription(_itemContainer.Item.Description());
                _tapped = true;
            }
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        _down = false;
        _timer = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!ItemHolder.Instance.IsEmpty)
            ButtonUp();
        _down = false;
        _timer = 0;
    }

    public void ButtonUp()
    {
        _pointerEventData.position = ItemHolder.Instance.Transform.position;
        UIManager.Instance.Raycaster.Raycast(_pointerEventData, _results);

        if (_results.Count >= 1)
        {
            GameObject obj = _results[0].gameObject;

            if (!obj.CompareTag("Cell"))
            {
                ItemHolder.Instance.ReturnItem();
            }
            else
            {
                CellController cell = obj.GetComponent<CellController>();
                if (cell.IsEmpty())
                {
                    if(ItemHolder.Instance.InAirItem is StackableItemInfo stackableItem)
                    {
                        ItemHolder.Instance.ReturnItem();
                        UIManager.Instance.OpenSlider();
                        ItemSpliter.Instance.TakeItem(stackableItem);
                        AndroidItemSplitter.Instance.IndexToSet = ((InventoryCellController)cell).Index;
                    } else
                        cell.OnClick();
                }
                else
                {
                    ItemHolder.Instance.ReturnItem();
                }
            }
            _results.Clear();
        }
        else
        {
            _player.DropItemOut();
        }

        _results.Clear();
    }

    public void OnDrag(PointerEventData eventData) {}
}
