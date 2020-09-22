using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Image))]
public class ItemHolder : MonoBehaviour
{
    public static ItemHolder Instance { get; private set; }
    public ItemInfo InAirItem { get; private set; }
    private Camera _camera;
    private Image _image;
    private RectTransform _rectTransform;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
        _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        _rectTransform.position = Mouse.current.position.ReadValue();
    }

    //TODO: POPRAVI OVO ZA KADA SE JEDAN ITEM DRŽI A DRUGI UHVATI
    public void HoldItem(ItemInfo itemToHold)
    {
        if (InAirItem != null)
            DropItem();
        itemToHold.transform.parent = transform;
        InAirItem = itemToHold;
        _image.sprite = itemToHold.Stats.sprite;
        _image.color = new Color(1, 1, 1, 1);
    }

    public void DropItem()
    {
        InAirItem = null;
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0);
    }
    
    public bool IsEmpty() { return (InAirItem == null); }
}
