﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    public ItemInfo Item { get; private set; }
    [SerializeField] private Image _image;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void AddItem(ItemInfo itemToAdd)
    {
        Item = itemToAdd;
        _image.sprite = Item.Stats.sprite;
        _image.color = new Color(1, 1, 1, 1);
        itemToAdd.transform.parent = _transform;
        itemToAdd.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void RemoveItem()
    {
        Item = null;
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0);
    }

    public bool IsEmpty() { return (Item == null); }
}
