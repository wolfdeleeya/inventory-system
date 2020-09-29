using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributesController : MonoBehaviour, CharacterStatsListener
{
    [SerializeField] private TextMeshProUGUI[] _statTexts;

    private void Start()
    {
        CharacterStats.Instance.AddListener(this);
        SetTexts();
    }

    private void SetTexts()
    {
        IReadOnlyList<float> stats = CharacterStats.Instance.TotalStats;
        string[] statNames = Enum.GetNames(typeof(Attribute));
        for(int i = 0; i < stats.Count; ++i)
        {
            switch (i)
            {
                case (int)Attribute.Health:
                    _statTexts[i].text = statNames[i] + " = " + Mathf.RoundToInt(CharacterStats.Instance.CurrentHealth) + "/" + Mathf.RoundToInt(stats[i]);
                    break;
                case (int)Attribute.Mana:
                    _statTexts[i].text = statNames[i] + " = " + Mathf.RoundToInt(CharacterStats.Instance.CurrentMana) + "/" + Mathf.RoundToInt(stats[i]);
                    break;
                default:
                    _statTexts[i].text = statNames[i] + " = " + Mathf.RoundToInt(stats[i]);
                    break;
            }
        }
    }

    public void StatsChanged()
    {
        SetTexts();
    }
}
