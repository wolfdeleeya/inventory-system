using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Image))]
public class ItemHolder : MonoBehaviour
{
    public static ItemHolder Instance { get; private set; }
    public ItemInfo InAirItem { get; private set; }
    public bool IsEmpty { get { return InAirItem == null; } }
    private ItemContainer _itemContainer;
    private Camera _camera;
    private Image _image;
    private Transform _transform;
    private RectTransform _rectTransform;
    private GameObject _descriptionPanel;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _transform = transform;
        _descriptionPanel = _transform.GetChild(0).gameObject;
        _descriptionPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        _rectTransform.position = Mouse.current.position.ReadValue();
    }
    
    public void HoldItem(ItemInfo itemToHold, ItemContainer itemContainer)
    {
        if (InAirItem != null)
            DropItem();
        itemToHold.transform.parent = _transform;
        InAirItem = itemToHold;
        _image.sprite = itemToHold.Stats.sprite;
        _image.color = new Color(1, 1, 1, 1);
        _itemContainer = itemContainer;
        _itemContainer.RemoveItem();
    }

    public void HoldItem(ItemInfo itemToHold)
    {
        if (InAirItem != null)
            DropItem();
        itemToHold.transform.parent = _transform;
        InAirItem = itemToHold;
        _image.sprite = itemToHold.Stats.sprite;
        _image.color = new Color(1, 1, 1, 1);
    }

    public void DropItem()
    {
        if (_itemContainer != null)
        {
            if (_itemContainer.GetComponent<CellController>() is InventoryCellController cell)
                Inventory.Instance.RemoveItem(cell.Index);
            else
                Equipment.Instance.RemoveItem(_itemContainer.GetComponent<EquipCellController>().Index);
            _itemContainer = null;
        }
        InAirItem = null;
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0);
    }

    public void ReturnItem()
    {
        if (InAirItem == null)
            return;
        if (_itemContainer == null)
            Inventory.Instance.AddItem(InAirItem);
        else
            _itemContainer.AddItem(InAirItem);

        InAirItem = null;
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0);
        _itemContainer = null;
    }
 
    public void ShowDescription(string description)
    {
        _descriptionPanel.SetActive(true);
        _descriptionText.text = description;
    }

    public void HideDescription()
    {
        _descriptionPanel.SetActive(false);
    }
}
