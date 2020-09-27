using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemStats Stats;
    private Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Stats.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetTrigger("Glow");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetTrigger("Fade");
    }
}
