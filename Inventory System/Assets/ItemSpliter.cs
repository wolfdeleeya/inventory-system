using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSpliter : MonoBehaviour
{
    [SerializeField] private GameObject _stackUIPrefab;
    [SerializeField] private TextMeshProUGUI _amountText;

    public static ItemSpliter Instance { get; private set; }

    private int _amountToTake;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private int AmountToTake
    {
        get { return _amountToTake; }

        set
        {
            _amountToTake = value;
            _amountText.text = value.ToString();
        }
    }

    private StackableItemInfo _itemToSplit;

    public void SetAmountToTake(float value)
    {
        AmountToTake = (int)((((StackableItemStats)_itemToSplit.Stats).MaxStack - 1) * -value);
        _amountText.text = AmountToTake.ToString();
    }

    public void TakeItem(StackableItemInfo itemToTake)
    {
        _itemToSplit = itemToTake;
    }

    public void TakeAway()
    {
        if (_amountToTake == 0)
            return;

        _itemToSplit.Amount -= AmountToTake;

        StackableItemInfo info = Instantiate(_stackUIPrefab).GetComponent<StackableItemInfo>();
        info.Initialize(_itemToSplit.Stats, AmountToTake);
        ItemHolder.Instance.HoldItem(info);
        _itemToSplit = null;
        AmountToTake = 0;
    }
}
