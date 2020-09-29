using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    private List<float> _startingStats;
    private List<float> _totalStats;

    private float _currentHealth;
    private float _currentMana;

    private List<CharacterStatsListener> _listeners;

    public static CharacterStats Instance { get; private set; }

    public IReadOnlyList<float> TotalStats { get { return _totalStats.AsReadOnly(); } }

    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            if (value > _totalStats[(int)Attribute.Health])
            {
                _currentHealth = _totalStats[(int)Attribute.Health];
            } else if(value < 0)
            {
                _currentHealth = 0;
                Debug.Log("You died.");
            }
            else
            {
                _currentHealth = value;
            }
            InformListeners();
        }
    }

    public float CurrentMana
    {
        get
        {
            return _currentMana;
        }

        private set
        {
            if (value > _totalStats[(int)Attribute.Mana])
            {
                _currentMana = _totalStats[(int)Attribute.Mana];
            }
            else if (value < 0)
            {
                _currentMana = 0;
            }
            else
            {
                _currentMana = value;
            }
            InformListeners();
        }
    }

    public static void CreateCharacterStats(List<float> startingStats)
    {
        if (Instance == null)
            Instance = new CharacterStats(startingStats);
    }

    private CharacterStats(List<float> startingStats)
    {
        _startingStats = new List<float>(startingStats);
        _totalStats = new List<float>(startingStats);

        _listeners = new List<CharacterStatsListener>();

        CurrentHealth = _totalStats[(int)Attribute.Health];
        CurrentMana = _totalStats[(int)Attribute.Mana];
    }

    public void AddItemStats(EquipableItemInfo item)
    {
        List<Stats> statsToChange = ((EquipmentStats)item.Stats).Stats;
        foreach (Stats stat in statsToChange)
            _totalStats[(int)stat.StatName] += stat.Amount;

        InformListeners();
    }

    public void ReceiveBuff(Attribute attribute, float value)
    {
        _totalStats[(int)attribute] += value;
        InformListeners();
    }

    public void ReceiveBuffSpendables(bool affectsHealth, float value)
    {
        if (affectsHealth)
            CurrentHealth += value;
        else
            CurrentMana += value;
        InformListeners();
    }

    public void RemoveItemStats(EquipableItemInfo item)
    {
        List<Stats> statsToChange = ((EquipmentStats)item.Stats).Stats;
        foreach (Stats stat in statsToChange)
        {
            _totalStats[(int)stat.StatName] -= stat.Amount;
            switch (stat.StatName)
            {
                case Attribute.Health:
                    CurrentHealth = CurrentHealth;
                    break;
                case Attribute.Mana:
                    CurrentMana = CurrentMana;
                    break;
            }
        }

        InformListeners();
    }

    public void InformListeners()
    {
        foreach (CharacterStatsListener listener in _listeners)
            listener.StatsChanged(); 
    }

    public void AddListener(CharacterStatsListener listener) => _listeners.Add(listener);

    public void RemoveListener(CharacterStatsListener listener) => _listeners.Remove(listener);
}
