using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuffCountdownController : MonoBehaviour
{
    [SerializeField] private Image _countdownImage;
    [SerializeField] private Image _iconSlot;

    private float _timer;
    private float _duration;

    public void Initialize(ItemBuffStats stats)
    {
        _duration = stats.TotalDuration();
        _timer = _duration;
        _countdownImage.color = stats.Color;
        _iconSlot.sprite = stats.UIImage;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
                _timer = 0;
            _countdownImage.fillAmount = _timer / _duration;
        }
    }
}
