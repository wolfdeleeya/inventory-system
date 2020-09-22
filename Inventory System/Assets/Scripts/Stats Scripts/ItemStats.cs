using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Basic Item", menuName = "Items/Basic Item")]
public class ItemStats : ScriptableObject
{
    public string Name;
    public Sprite sprite;

    public virtual string Description()
    {
        return "Name: " + Name + "\n";
    }
}
