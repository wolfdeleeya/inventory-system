using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuffStats : ScriptableObject
{
    public enum BuffType { Hold, Ramp, Tick }

    public Sprite UIImage;
    public float Duration;
    public float Amount;
    public BuffType Type;
    public Color Color;

    public virtual float TotalDuration()
    {
        return Duration;
    }
}
