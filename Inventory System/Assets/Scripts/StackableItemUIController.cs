using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StackableItemUIController : MonoBehaviour, StackableItemListener
{
    [SerializeField] private TextMeshProUGUI _stackText;

    private void Awake()
    {
        StackableItem item = GetComponent<StackableItem>();

        if (item == null)
            GetComponent<StackableItemInfo>().AddListener(this);
        else
            item.AddListener(this);
    }

    public void StackChanged(int amount)
    {
        _stackText.text = amount.ToString();
    }
}
