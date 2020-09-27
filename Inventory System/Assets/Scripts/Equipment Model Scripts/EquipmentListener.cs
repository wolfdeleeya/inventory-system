using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EquipmentListener
{
    void ItemEquiped(ItemInfo item, int index);
    void ItemUnequiped(int index);
}
